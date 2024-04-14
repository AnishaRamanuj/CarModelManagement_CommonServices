using CarModelManagement_CommonServices.Context.CarModelManagementModel;
using CarModelManagement_CommonServices.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace CarModelManagement_CommonServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarService _carServices;

        public CarController(ILogger<CarController> logger, ICarService carServices)
        {
            _carServices = carServices;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllCars")]
        public async Task<ActionResult> GetAllCars()
        {
            var results = await _carServices.GetAllCars();
            return new OkObjectResult(results);
        }

        [HttpPost]
        [Route("AddCar")]
        public async Task<ActionResult<bool>> AddCar([FromBody] Cars car)
        {
            var results = await _carServices.AddCar(car);
            return Ok(results);
        }

        [HttpPut]
        [Route("UpdateCar")]
        public async Task<ActionResult<bool>> UpdateCar([FromBody] Cars car)
        {
            var results = await _carServices.UpdateCar(car);
            return Ok(results);
        }

        [HttpPost]
        [Route("DeleteCar")]
        public async Task<ActionResult<int>> DeleteCar(Cars car)
        {
            var results = await _carServices.DeleteCar(car);
            return Ok(results);
        }
    }
}
