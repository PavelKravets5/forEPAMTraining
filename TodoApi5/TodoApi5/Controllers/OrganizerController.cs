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
    [Route("api/Organizer")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> _appSettings;
        private IConfiguration configuration;
        public OrganizerController(IOptions<MySettingsModel> appSettings, IConfiguration iConfig)
        {
            configuration = iConfig;
            _appSettings = appSettings;
        }

        [HttpGet]
        public IEnumerable<OrganizersModel> getAllOrganizers()
        {
            var data = DbClientFactory<MyEventsDBClient>.Instance.GetAllOrganizers(_appSettings.Value.DbConnection);
            //var data = DbClientFactory<MyEventsDBClient>.Instance.GetAllOrganizers(configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            return data;
        }

        // GET api/users/5
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    List<MyEventsModel> data = DbClientFactory<MyEventsDBClient>.Instance.GetAllMyEvents(
        //        configuration.GetSection("MySettings").GetSection("DbConnection").Value);
        //    var user = data.FirstOrDefault(x => x.Id == id);
        //    if (user == null)
        //        return NotFound();
        //    return new ObjectResult(user);
        //}

        // POST api/users
        [HttpPost]
        public IActionResult saveOrganizer([FromBody]OrganizersModel organizer)
        {
            if (organizer == null)
            {
                return BadRequest();
            }

            var msg = new Message<OrganizersModel>();
            var data = DbClientFactory<MyEventsDBClient>.Instance.SaveOrganizer(organizer,
                configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            if (data == "c200")
            {
                msg.IsSuccess = true;
                if (organizer.Id == 0)
                    msg.ReturnMessage = "Organizer saved successfully";
                else
                    msg.ReturnMessage = "Organizer updated successfully";
            }
            else if (data == "c203")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Updated organizer not found";
            }
            return Ok(msg);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteOrganizer(int Id)
        {
            var msg = new Message<OrganizersModel>();
            var data = DbClientFactory<MyEventsDBClient>.Instance.DeleteOrganizer(Id,
                configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            if (data == "c200")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Organizer deleted";
            }
            else if (data == "c201")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "You cannot delete an organizer that is associated with an event(events)";
            }
            else if (data == "c203")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Organizer not found";
            }
            return Ok(msg);
        }
    }
}