using Microsoft.AspNetCore.Mvc;
using SWTallerMecanico.Context;
using SWTallerMecanico.Entities;

namespace SWTallerMecanico.Controllers;

[ApiController]
[Route("api/[controller]")]
    public class CustomerController{

        private readonly AppDbContext context;
        public CustomerController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            var wraper = new{
                client = context.customer
            };
           return new OkObjectResult(wraper);
        }

        [HttpGet("{id:int}")]
        public Customer? Get(int id){
            var customer = context.customer.FirstOrDefault(p => p.id == id);
            return customer;
        }


        [HttpGet("{name}")]
        public IActionResult Get(string name){
            var wrapper = new{
                client = context.customer.Where(p => p.name.StartsWith(name)).ToList()
            };
            //var customer = context.customer.FirstOrDefault(p => p.name.StartsWith(name));
            return new OkObjectResult(wrapper);
        }

        [HttpPost]
        public void Post([FromBody] Customer customer){
            long? id = 0L;
            if(context.customer.Any()){
                id = context.customer.Max(c => c.id);
            }
            customer.id = ++id;
            context.customer.Add(customer);
            context.SaveChanges();

        }

        [HttpPut]
        public void Put(Customer client){
           
           context.Entry(client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           context.SaveChanges();
        }

    }