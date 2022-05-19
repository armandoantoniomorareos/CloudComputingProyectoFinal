using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWTallerMecanico.Entities{
    public class CreateService{
    
        [Key]
        public long id {get; set;}
        public long id_client {get; set;}
        public string? type {get; set;} // I could use 1 and 2
        public long id_vehicle {get; set;}
        public string? next_date {get; set;}
        public string? description {get; set;}
        public decimal total {get; set;}

        [NotMapped]
        public Vehicle? vehicle {get; set;}

        [NotMapped]
        public Customer? client {get; set;}

    }
}