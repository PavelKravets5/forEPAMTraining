using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using TodoApi5.Utility;
using TodoApi5.Repository;
using TodoApi5.Models;

namespace TodoApi5.Controllers
{
    [Route("api/MyEvent")]
    public class MyEventController : Controller
    {
        private readonly IOptions<MySettingsModel> _appSettings;
        private IConfiguration configuration;
        public MyEventController(IOptions<MySettingsModel> appSettings, IConfiguration iConfig)
        {
            configuration = iConfig;
            _appSettings = appSettings;
        }

        [HttpGet]
        public IEnumerable<MyEventsModel> getAllMyEvents()
        {
            var data = DbClientFactory<MyEventsDBClient>.Instance.GetAllMyEvents(_appSettings.Value.DbConnection);
            //var data = DbClientFactory<MyEventsDBClient>.Instance.GetAllMyEvents(configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            return data;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            List<MyEventsModel> data = DbClientFactory<MyEventsDBClient>.Instance.GetAllMyEvents(
                configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            var user = data.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public IActionResult saveMyEvent([FromBody]MyEventsModel myEvents)
        {
            if (myEvents == null)
            {
                return BadRequest();
            }

            var msg = new Message<MyEventsModel>();
            var data = DbClientFactory<MyEventsDBClient>.Instance.SaveMyEvent(myEvents,
                configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            if (data == "c200")
            {
                msg.IsSuccess = true;
                if (myEvents.Id == 0)
                    msg.ReturnMessage = "User saved successfully";
                else
                    msg.ReturnMessage = "User updated successfully";
            }
            else if (data == "c201")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Organizer not found";
            }
            else if (data == "c202")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Category not found";
            }
            else if (data == "c203")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Updated myevent not found";
            }
            return Ok(msg);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteMyEvent(int Id)
        {
            var msg = new Message<MyEventsModel>();
            var data = DbClientFactory<MyEventsDBClient>.Instance.DeleteMyEvent(Id,
                configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            if (data == "c200")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "User Deleted";
            }
            else if (data == "c203")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Events not found";
            }
            return Ok(msg);
        }
    }
}