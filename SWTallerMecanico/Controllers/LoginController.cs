using Microsoft.AspNetCore.Mvc;
using SWTallerMecanico.Context;
using SWTallerMecanico.Entities;

namespace SWTallerMecanico.Controllers;

[ApiController]
[Route("api/[controller]")]
    public class LoginController{

        private readonly AppDbContext context;
        public LoginController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Login> Get(){
            return context.login.ToList();
        }

        [HttpGet("{id}")]
        public Customer? Get(int id){
            var customer = context.customer.FirstOrDefault(p => p.id == id);
            return customer;
        }

        [HttpPost]
        public void Post([FromBody] Customer customer){
            context.customer.Add(customer);
            context.SaveChanges();

        }

    }