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
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> _appSettings;
        private IConfiguration configuration;
        public CategoryController(IOptions<MySettingsModel> appSettings, IConfiguration iConfig)
        {
            configuration = iConfig;
            _appSettings = appSettings;
        }

        [HttpGet]
        public IEnumerable<CategoriesModel> getAllCategories()
        {
            var data = DbClientFactory<MyEventsDBClient>.Instance.GetAllCategories(_appSettings.Value.DbConnection);
            //var data = DbClientFactory<MyEventsDBClient>.Instance.GetAllCategories(configuration.GetSection("MySettings").GetSection("DbConnection").Value);
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
        public IActionResult saveCategory([FromBody]CategoriesModel category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            var msg = new Message<CategoriesModel>();
            var data = DbClientFactory<MyEventsDBClient>.Instance.SaveCategory(category,
                configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            if (data == "c200")
            {
                msg.IsSuccess = true;
                if (category.Id == 0)
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
        public IActionResult deleteCategory(int Id)
        {
            var msg = new Message<CategoriesModel>();
            var data = DbClientFactory<MyEventsDBClient>.Instance.DeleteCategory(Id,
                configuration.GetSection("MySettings").GetSection("DbConnection").Value);
            if (data == "C200")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "User Deleted";
            }
            else if (data == "C203")
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Events not found";
            }
            return Ok(msg);
        }
    }
}