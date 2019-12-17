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
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TodoApi5.Controllers
{
    [Route("api/Email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> _appSettings;
        private IConfiguration configuration;
        public EmailController(IOptions<MySettingsModel> appSettings, IConfiguration iConfig)
        {
            configuration = iConfig;
            _appSettings = appSettings;
        }

        [HttpGet("{id}")]
        public IEnumerable<EmailsModel> getEmailsById(int id)
        {
            var data = DbClientFactory<MyEventsDBClient>.Instance.GetEmailsById(id,_appSettings.Value.DbConnection);
            //var data = DbClientFactory<MyEventsDBClient>.Instance.GetEmailsById(id,configuration.GetSection("MySettings").GetSection("DbConnection").Value);
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
        public IActionResult saveEmail([FromBody]EmailsModel email)
        {
            if (email == null)
            {
                return BadRequest();
            }

            var msg = new Message<EmailsModel>();
            var data = DbClientFactory<MyEventsDBClient>.Instance.SaveEmail(email,
                configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            if (data == "c200")
            {
                msg.IsSuccess = true;
                if (email.OrganizerId == 0)
                    msg.ReturnMessage = "Email saved successfully";
                else
                    msg.ReturnMessage = "Email updated successfully";
            }
            else if (data == "c203")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "This phone does not exist";
            }
            return Ok(msg);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteEmail(int id)
        {
            var msg = new Message<EmailsModel>();
            var data = DbClientFactory<MyEventsDBClient>.Instance.DeleteEmail(id,
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