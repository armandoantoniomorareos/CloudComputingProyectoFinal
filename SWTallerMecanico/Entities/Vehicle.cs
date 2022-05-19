namespace SWTallerMecanico.Entities{
    public class Vehicle{
        public long? id {get; set;}
        public long id_client {get; set;}
        public string? model {get; set;}
        public string? plate {get; set;}
        public long km {get; set;}
        public string? color {get; set;}

        //public string? image{get; set;}
    }
}