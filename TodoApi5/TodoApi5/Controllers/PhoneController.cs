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
    [Route("api/Phone")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> _appSettings;
        private IConfiguration configuration;
        public PhoneController(IOptions<MySettingsModel> appSettings, IConfiguration iConfig)
        {
            configuration = iConfig;
            _appSettings = appSettings;
        }

        [HttpGet("{id}")]
        public IEnumerable<PhonesModel> getPhonesById(int id)
        {
            var data = DbClientFactory<MyEventsDBClient>.Instance.GetPhonesById(id,_appSettings.Value.DbConnection);
            //var data = DbClientFactory<MyEventsDBClient>.Instance.GetPhonesById(id,configuration.GetSection("MySettings").GetSection("DbConnection").Value);
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
        public IActionResult savePhone([FromBody]PhonesModel phone)
        {
            if (phone == null)
            {
                return BadRequest();
            }

            var msg = new Message<PhonesModel>();
            var data = DbClientFactory<MyEventsDBClient>.Instance.SavePhone(phone,
                configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            if (data == "c200")
            {
                msg.IsSuccess = true;
                if (phone.OrganizerId == 0)
                    msg.ReturnMessage = "Email saved successfully";
                else
                    msg.ReturnMessage = "Email updated successfully";
            }
            else if (data == "c203")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "This email does not exist";
            }
            return Ok(msg);
        }

        [HttpDelete("{id}")]
        public IActionResult deletePhone(int id)
        {
            var msg = new Message<PhonesModel>();
            var data = DbClientFactory<MyEventsDBClient>.Instance.DeletePhone(id,
                configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            if (data == "c200")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Email deleted";
            }
            else if (data == "c203")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Email not found";
            }
            return Ok(msg);
        }
    }
}