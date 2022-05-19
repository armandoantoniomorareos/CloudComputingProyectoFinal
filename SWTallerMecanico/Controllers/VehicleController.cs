using Microsoft.AspNetCore.Mvc;
using SWTallerMecanico.Context;
using SWTallerMecanico.Entities;

namespace SWTallerMecanico.Controllers;

[ApiController]
[Route("api/[controller]")]
    public class VehicleController{

        private readonly AppDbContext context;
        public VehicleController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get(){
             var wrapper =new{
                 vehicle = context.vehicle.ToList()
             };

            return new OkObjectResult(wrapper);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id){
            var wrapper =new{
                 vehicle = context.vehicle.FirstOrDefault(p => p.id == id)
            };
            return new OkObjectResult(wrapper);
        }

        [HttpGet("Clients/{clientId}")]
        public IActionResult? GetClientVehicles(int clientId){
            var wrapper = new{
                vehicle = context.vehicle.Where(p => p.id_client == clientId).ToList()
            };
            return new OkObjectResult(wrapper);
        }

        [HttpPost]
        public void Post([FromBody] Vehicle vehicle){
            context.vehicle.Add(vehicle);
            context.SaveChanges();

        }

    }