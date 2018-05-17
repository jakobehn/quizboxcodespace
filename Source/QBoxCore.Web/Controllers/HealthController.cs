﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QBox.Api.Client;

namespace QBoxCore.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Health")]
    public class HealthController : Controller
    {
        private readonly IQBoxClient apiClient;

        public HealthController(IQBoxClient apiClient)
        {
            this.apiClient = apiClient;
        }

        // GET: api/Health
        [HttpGet]
        public IActionResult Get()
        {
            var allCategories = apiClient.GetCategories().Result; 
            if( allCategories.Any())
                return StatusCode(200);
            return StatusCode(500);
        }

    }
}
