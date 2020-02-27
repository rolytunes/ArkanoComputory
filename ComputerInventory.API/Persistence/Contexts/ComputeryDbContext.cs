using ComputerInventory.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerInventory.API.Persistence.Contexts
{
    public class ComputeryDbContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Ram> Rams { get; set; }

        public ComputeryDbContext(DbContextOptions<ComputeryDbContext> dbContext) : base(dbContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Computer>().ToTable("Computers");
            builder.Entity<Computer>().HasKey(c => c.Id);
            builder.Entity<Computer>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Computer>().Property(c => c.Brand);
            builder.Entity<Computer>().Property(c => c.Name);
            builder.Entity<Computer>().Property(c => c.ModelNumber);
            builder.Entity<Computer>().Property(c => c.Graphics);
            builder.Entity<Computer>().HasOne(c => c.RamMemory).WithOne(r => r.Computer).HasForeignKey<Ram>(r => r.ComputerId);

            builder.Entity<Computer>().HasData(
                new Computer
                {
                    Id = 1,
                    Brand = "HP",
                    Name = "15.6 Touch-Screen Laptop",
                    ModelNumber = "15-DY0013DX",
                    OperatingSystem = "Windows 10 Home in S mode",
                    Graphics = "INTEL UHD Graphics 620"
                },
                new Computer
                {
                    Id = 2,
                    Brand = "HP",
                    Name = "Pavilion Desktop",
                    ModelNumber = "595-P0074",
                    OperatingSystem = "Windows 10 Home",
                    Graphics = "Intel UHD Graphics 630"
                },
                new Computer
                {
                    Id = 3,
                    Brand = "iBUYPOWER",
                    Name = "Gaming Desktop - Intel Core i7-8700 - 32GB Memory - NVIDIA RTX 2070 8GB - 1TB SSD",
                    ModelNumber = "BB952",
                    OperatingSystem = "Windows 10 Home",
                    Graphics = "NVIDIA GeForce RTX 2070"
                }, 
                new Computer
                {
                    Id = 4,
                    Brand = "Dell",
                    Name = "Inspiron Desktop - Intel Core i5 - 16GB Memory - 256GB Solid State Drive",
                    ModelNumber = "I3670-5790BLK-PUS",
                    OperatingSystem = "Windows 10 Home",
                    Graphics = "Intel UHD Graphics 630"
                },
                new Computer
                {
                    Id = 5,
                    Brand = "Dell",
                    Name = "Inspiron 21.5' Touch - Screen All - In - One - AMD A6 - Series - 4GB Memory - 1TB Hard Drive",
                    ModelNumber = "I3275-A356BLK-PUS",
                    OperatingSystem = "Windows 10 Home",
                    Graphics = "AMD Radeon R4"
                },
                new Computer
                {
                    Id = 6,
                    Brand = "Lenovo",
                    Name = "IdeaCentre A340-22IGM 21.5' Touch - Screen All - In - One - Intel Pentium Silver - 8GB Memory - 1TB Hard Drive",
                    ModelNumber = "F0EA000EUS",
                    OperatingSystem = "Windows 10 Home",
                    Graphics = "Intel UHD Graphics 605"
                }
            );

            builder.Entity<Ram>().ToTable("Rams");
            builder.Entity<Ram>().HasKey(r => r.Id);
            builder.Entity<Ram>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Ram>().Property(r => r.Brand);
            builder.Entity<Ram>().Property(r => r.ModelNumber);
            builder.Entity<Ram>().Property(r => r.Capacity);
            builder.Entity<Ram>().Property(r => r.Speed);
            builder.Entity<Ram>().Property(r => r.Pack);
            builder.Entity<Ram>().Property(r => r.Type);

            builder.Entity<Ram>().HasData( 
                new Ram {
                    Id = 1,
                    Brand = "CORSAIR",
                    Name = "Vengeance RGB PRO 32GB (2PK 16GB) 3.2GHz PC4-25600 DDR4 DIMM Unbuffered Non-ECC Desktop Memory Kit with RGB Lighting",
                    ModelNumber = "CMW32GX4M2C3200C16",
                    Capacity = 16,
                    Pack = 2,
                    Speed = 3200,
                    Type = MemoryType.DDR4,
                    ComputerId = 3
                },
                new Ram
                {
                    Id = 2,
                    Brand = "PNY",
                    Name = "8GB 1.6 GHz DDR3 SoDIMM Laptop Memory",
                    ModelNumber = "MN8GSD31600LV",
                    Capacity = 8,
                    Pack = 1,
                    Speed = 1600,
                    Type = MemoryType.DDR3,
                    ComputerId = 6
                },
                new Ram
                {
                    Id = 3,
                    Brand = "PNY",
                    Name = "16 GB (2PK x 8GB) 1.8 GHz DDR3 DIMM Desktop Memory Kit",
                    ModelNumber = "MD16384KD3-1866-K-X10",
                    Capacity = 8,
                    Pack = 2,
                    Speed = 1866,
                    Type = MemoryType.DDR3,
                    ComputerId = 4
                },
                new Ram
                {
                    Id = 4,
                    Brand = "CORSAIR",
                    Name = "Vengeance LPX 4GB 2.4GHz PC4-19200 DDR4 DIMM Unbuffered Non-ECC Desktop Memory",
                    ModelNumber = "CMK4GX4M1A2400C16",
                    Capacity = 8,
                    Pack = 1,
                    Speed = 1866,
                    Type = MemoryType.DDR4,
                    ComputerId = 5
                },
                new Ram
                {
                    Id = 5,
                    Brand = "Crucial Ballistix Sport",
                    Name = "LT 3000 MHz DDR4 DRAM Desktop Gaming Memory Kit 16GB (8GBx2) CL15 ",
                    ModelNumber = "BLS2K8G4D30AESBK",
                    Capacity = 8,
                    Pack = 2,
                    Speed = 1866,
                    Type = MemoryType.DDR4,
                    ComputerId = 1
                },
                new Ram
                {
                    Id = 6,
                    Brand = "Kuesuny",
                    Name = "PC2-5300/PC2-5300U CL5 240-Pin Non-ECC Unbuffered",
                    ModelNumber = "BLS2K8G4D30AESBK",
                    Capacity = 2,
                    Pack = 2,
                    Speed = 667,
                    Type = MemoryType.DDR3,
                    ComputerId = 2
                }

            );
        }
    }
}
