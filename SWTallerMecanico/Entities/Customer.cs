using System.ComponentModel.DataAnnotations;

namespace SWTallerMecanico.Entities{
    public class Customer{
        [Key]
        public long? id {get; set;}
        public string name {get; set;} = string.Empty;
        public string? address {get; set;}
        public string? telephone {get; set;}
    
    }
}