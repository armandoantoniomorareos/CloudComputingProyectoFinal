using Microsoft.AspNetCore.Mvc;
using SWTallerMecanico.Context;
using SWTallerMecanico.Entities;

namespace SWTallerMecanico.Controllers;

[ApiController]
[Route("api/[controller]")]
    public class ServiceController : ControllerBase{


        private readonly AppDbContext context;
        public ServiceController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            var l = context.service.ToList();        
            for(int i = 0; i < l.Count; i++){
                var vehicle = context.vehicle.ToList().Find(s => s.id == l[i].id_vehicle);
                var client = context.customer.ToList().Find(c => c.id == l[i].id_client);
                l[i].vehicle = vehicle;
                l[i].client = client;
                
            }
            var wraper = new{
                services = l

            };
            return new OkObjectResult(wraper);
        }

        [HttpGet("{id}")]
        public Service? Get(int id){
            var customer = context.service.FirstOrDefault(p => p.id_client == id);
            return customer;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Service service){
            try{
                long? id =0L;
                if(context.service.Any()){
                    id = context.service.Max(s=> s.id);
                }
                service.id = ++id;
                //service.id = null;
                context.service.Add(service);
                context.SaveChanges();
                return Ok("Ok");
            }catch(Exception e){
                return BadRequest(e.Message);

        }

    }
}