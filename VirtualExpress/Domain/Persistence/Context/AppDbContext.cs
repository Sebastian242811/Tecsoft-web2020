using Microsoft.EntityFrameworkCore;
using VirtualExpress.Domain.Models;

namespace VirtualExpress.Domain.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Dispatcher> Dispatchers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Pay> Pays { get; set; }
        public DbSet<CustomerServiceEmployee> CustomerServiceEmployees { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Freight> Freights { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Comentary> Comentaries { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Company
            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Company>().HasKey(key => key.Id);
            builder.Entity<Company>().Property(key => key.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.Number)
                .IsRequired().HasMaxLength(9);
            builder.Entity<Company>().Property(p => p.Ruc)
                .IsRequired().HasMaxLength(11);
            builder.Entity<Company>()
                .HasMany(p => p.Terminals)
                .WithOne(p => p.Company)
                .HasForeignKey(p => p.CompanyId);
            builder.Entity<Company>()
                .HasData(
                new Company { Id = 10, Name = "Antezana", Number = "7854", Ruc = "78555" }
                );
            //City
            builder.Entity<City>().ToTable("Cities");
            builder.Entity<City>().HasKey(key => key.Id);
            builder.Entity<City>().Property(key => key.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<City>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<City>()
                .HasMany(p => p.Terminals)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId);

            //Terminal
            builder.Entity<Terminal>().ToTable("Terminals");
            builder.Entity<Terminal>().HasKey(key => key.Id);
            builder.Entity<Terminal>().Property(key => key.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Terminal>().Property(p => p.Name)
                .IsRequired().HasMaxLength(25);
            builder.Entity<Terminal>().Property(p => p.Direction)
                .IsRequired().HasMaxLength(30);

            //Dispatchers
            builder.Entity<Dispatcher>().ToTable("Dispatchers");
            builder.Entity<Dispatcher>().HasKey(Key => Key.Id);
            builder.Entity<Dispatcher>().Property(Key => Key.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Dispatcher>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Dispatcher>().Property(p => p.DNI).HasMaxLength(8);
            builder.Entity<Dispatcher>().HasOne(p => p.Terminal)
                .WithMany(p => p.Dispatchers).HasForeignKey(p=>p.TerminalId);


            //Driver
            builder.Entity<Driver>().ToTable("Driver");
            builder.Entity<Driver>().HasKey(Key=>Key.Id);
            builder.Entity<Driver>().Property(Key => Key.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Driver>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Driver>().Property(p => p.DNI).HasMaxLength(8);
            builder.Entity<Driver>().Property(p => p.Telephone)
                .IsRequired().HasMaxLength(9);
            builder.Entity<Driver>().HasOne(p => p.Company)
                .WithMany(p => p.Drivers).HasForeignKey(p=>p.CompanyId);


            //pay
            builder.Entity<Pay>().ToTable("Pay");
            builder.Entity<Pay>().HasKey(Key => Key.Id);
            builder.Entity<Pay>().Property(Key => Key.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Pay>().HasOne(p => p.Company)
                .WithMany(p => p.Pays).HasForeignKey(p => p.CompanyId);

            //CustomerServiceEmployee
            builder.Entity<CustomerServiceEmployee>().ToTable("CustomerServiceEmployee");
            builder.Entity<CustomerServiceEmployee>().HasKey(p=>p.Id);
            builder.Entity<CustomerServiceEmployee>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CustomerServiceEmployee>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<CustomerServiceEmployee>().HasOne(p => p.Terminal)
                .WithMany(p => p.ServiceEmployees).HasForeignKey(p=>p.TerminalId);


            //Package
            builder.Entity<Package>().ToTable("Package");
            builder.Entity<Package>().HasKey(p => p.Id);
            builder.Entity<Package>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Package>().Property(p => p.Description)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Package>().Property(p => p.Observations).HasMaxLength(50);
            builder.Entity<Package>().Property(p => p.Priority).IsRequired();
            builder.Entity<Package>().Property(p => p.State).IsRequired();
            builder.Entity<Package>().HasOne(p => p.Dispatcher)
                .WithMany(p => p.Packages).HasForeignKey(p=>p.DispatcherId);
            builder.Entity<Package>().HasOne(p => p.Freight)
                .WithMany(p => p.Packages).HasForeignKey(p=>p.FreightId);
            builder.Entity<Package>().HasOne(p => p.Customer)
                .WithMany(p => p.Packages).HasForeignKey(p=>p.CustomerId);


            //Freight
            builder.Entity<Freight>().ToTable("Freight");
            builder.Entity<Freight>().HasKey(prop => prop.Id);
            builder.Entity<Freight>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Freight>().Property(p => p.Observations).HasMaxLength(50);
            builder.Entity<Freight>().HasOne(p => p.Driver)
                .WithMany(p => p.Freights).HasForeignKey(p=>p.DriverId);


            //Customer
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Customer>().HasKey(P => P.Id);
            builder.Entity<Customer>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(p => p.DNI).HasMaxLength(8);
            builder.Entity<Customer>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Customer>().Property(p => p.Telephone)
                .IsRequired().HasMaxLength(9);
            builder.Entity<Customer>().Property(p => p.Direction)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Customer>().Property(p => p.EMail).HasMaxLength(50);
            builder.Entity<Customer>().Property(p => p.Password)
                .IsRequired().HasMaxLength(20);


            //chat
            builder.Entity<Chat>().ToTable("Chat");
            builder.Entity<Chat>().HasKey(p=>p.Id);
            builder.Entity<Chat>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Chat>().HasOne(p => p.Customer)
                .WithMany(p => p.Chats).HasForeignKey(p => p.CustomerId);
            builder.Entity<Chat>().HasOne(p => p.ServiceEmployee)
                .WithMany(prop => prop.Chats).HasForeignKey(P=>P.ServiceEmployeeId);


            //Comentary
            builder.Entity<Comentary>().ToTable("Comentary");
            builder.Entity<Comentary>().HasKey(p => p.Id);
            builder.Entity<Comentary>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Comentary>().HasOne(p => p.Terminal)
                .WithMany(p => p.Comentaries).HasForeignKey(p=>p.TerminalId);
            builder.Entity<Comentary>().HasOne(p => p.Customer)
                .WithMany(p => p.Comentaries).HasForeignKey(p=>p.CustomerId);

            //Subscription
            builder.Entity<Subscription>().ToTable("Subscription");
            builder.Entity<Subscription>().HasKey(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subscription>().Property(p => p.Name)
                .IsRequired().HasMaxLength(20);
            builder.Entity<Subscription>().HasOne(p => p.Customer)
                .WithMany(p => p.Subscriptions).HasForeignKey(p=>p.CustomerId);
            builder.Entity<Subscription>().HasOne(p => p.Company)
                .WithMany(p => p.Subscriptions).HasForeignKey(p=>p.CompanyId);
        }
    }
}
