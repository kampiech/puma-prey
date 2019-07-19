﻿using Coyote.Controllers.Authentication.Model;
using Coyote.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puma.Prey.Rabbit.Context;
using Puma.Prey.Rabbit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Coyote.Controllers.Safaris
{
    [ApiController]
    [Route("api/[controller]")]
    public class SafarisController : Controller
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISafariService _safariService;
        

        public SafarisController(ISafariService safariService, IHttpContextAccessor httpContextAccessor)
        {
            _safariService = safariService;
            _httpContextAccessor = httpContextAccessor;
            
        }

        [HttpGet]
        public ActionResult<List<Safari>> GetSafaris()
        {
            return _safariService.GetSafaris(_httpContextAccessor.HttpContext.User);
        }

        [HttpGet("{Id}")]
        public ActionResult<Safari> GetSafari(int Id)
        {
            var safari = _safariService.GetSafari(Id);
            if (safari == null)
                return NotFound();

            return safari;
        }

        [HttpDelete("{Id}")]
        public ActionResult<Safari> DeleteSafari(int Id)
        {
            var success = _safariService.DeleteSafari(Id);
            if (!success)
                return NotFound();

            return Ok();
        }

      
        [HttpPost]
        public ActionResult<Safari> AddSafari([FromBody] SafariRequest model)
        {
            var safari = _safariService.CreateSafari(model.Name, model.Address, model.StartDate, model.EndDate);
            
            return safari;
        }

        [HttpPut]
        public ActionResult<Safari> UpdateSafaris([FromBody] SafariRequest model)
        {
            var exist = _safariService.GetSafari(model.Id);

            if (exist == null)
                return NotFound();
            _safariService.UpdateSafari(model);

            return Ok();
        }

        [HttpPost("Register")]
        public ActionResult<User> AddSafariUsers([FromBody] SafariUserRequest model)
        {
            var success = _safariService.RegisterUsers(model);

            if (!success)
                return NotFound();

            return Ok();

        }

    }
}
