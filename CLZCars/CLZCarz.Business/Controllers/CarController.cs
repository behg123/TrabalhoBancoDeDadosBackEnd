using CLZCarz.Business.Business;
using Microsoft.AspNetCore.Mvc;
using Model.Shared.Car;
using Model.Shared.User;


namespace CLZCarz.Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private CarBusiness business;

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
            this.business = CarBusiness.GetInstance();
        }


        [HttpPost("Create")]
        public object Create([FromBody] CarModel car)
        {
            try
            {
                return Ok(this.business.CreateCar(car));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("GetCar")]
        public object GetCar(int id)
        {
            try
            {
                CarModel? car = new CarModel();
                car = this.business.GetCar(id);
                return Ok(car);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpGet("GetAllCar")]

        public object GetAllLogin()
        {
            try
            {
                return this.business.GetAllCar();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update")]
        public object Update([FromBody] CarModel car)
        {
            try
            {
                return Ok(this.business.UpdateCar(car));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("Delete")]
        public object Delete(int id)
        {
            try
            {
                return Ok(this.business.DeleteCar(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
