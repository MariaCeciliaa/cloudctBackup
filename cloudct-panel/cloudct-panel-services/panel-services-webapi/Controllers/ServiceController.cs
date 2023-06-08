using Microsoft.AspNetCore.Mvc;
using panel_services_core.Services;

namespace panel_services_webapi.Controllers
{
    [Route("[controller]")]
    public class ServiceController : Controller
    {
        readonly IServicesService _servicesService;
        public ServiceController(IServicesService servicesService) 
        {
            _servicesService = servicesService;
        }

        [HttpGet]
        public IActionResult Get() {

            return Ok(_servicesService.Get());

        }

        [HttpPost]
        public IActionResult Insert() {

            return Ok("Este é o Insert !");

        }

        [HttpPut]
        public IActionResult Update() {

            return Ok("Este é o Update");

        }

        [HttpDelete]
        public IActionResult Delete() {

            return Ok("Este é o delete");

        }


    }
}