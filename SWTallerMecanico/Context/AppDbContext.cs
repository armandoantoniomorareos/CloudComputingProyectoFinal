
using Microsoft.EntityFrameworkCore;
using SWTallerMecanico.Entities;

namespace SWTallerMecanico.Context{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Entities.Customer> customer {get; set;}

        public DbSet<Service> service {get; set;}

        public DbSet<Vehicle> vehicle {get; set;}
        public DbSet<Login> login {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // First we identify the model-types by examining the properties in the DbContext class
        // Here, I am assuming that your DbContext class is called "DataContext"
        var modelTypes = typeof(AppDbContext).GetProperties()
                         .Where(x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                         .Select(x => x.PropertyType.GetGenericArguments().First())
                         .ToList();

        // Feel free to add any other possible types you may have defined your "Id" property with
        // Here I am assuming that only short, int, and bigint would be considered identity
        var identityTypes = new List<Type> { typeof(Int16), typeof(Int32), typeof(Int64) };

        foreach (Type modelType in modelTypes)
        {
            // Find the first property that is named "id" with the types defined in identityTypes collection
            var key = modelType.GetProperties()
                               .FirstOrDefault(x => x.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase) && identityTypes.Contains(x.PropertyType));

            // Once we know a matching property is found
            // We set the propery as Identity using UseSqlServerIdentityColumn() method
            if (key == null)
            {
                continue;
            }

            // Here we identify the Id property to be set to Identity
            // Also, we use change the PropertySaveBehavior on the same
            // property to ignore the values 
            modelBuilder.Entity(modelType)
                        .Property(key.Name)
                        .ValueGeneratedOnAdd();
        }
    }

    }
}