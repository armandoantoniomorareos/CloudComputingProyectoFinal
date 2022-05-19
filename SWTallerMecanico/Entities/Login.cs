using System.ComponentModel.DataAnnotations;

namespace SWTallerMecanico
{
    public class Login{
        [Key]
        public string? email {get; set;}
        public string? password {get; set;}
        public string? type {get; set;}
        
        

    }
    
}