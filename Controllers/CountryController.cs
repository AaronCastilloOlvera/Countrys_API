﻿
using Microsoft.AspNetCore.Mvc;
using Countrys_API.Models;
using Countrys_API.Services;

namespace Countrys_API.Controllers
{
    [Route("api/[controller]")]

    public class CountryController : Controller
    {
        ICountryService countryService;
        CountriesContext countriesContext;

        public CountryController(ICountryService service, CountriesContext db)
        {
            countryService = service;
            countriesContext = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(countryService.Get());
        }

        [HttpPost]
        public IActionResult Post( [FromBody] Country country)
        {
            countryService.Save(country);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Country country)
        {
            countryService.Update(id, country);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            countryService.Delete(id);
            return Ok();
        }
    }
}
