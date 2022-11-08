
using Microsoft.EntityFrameworkCore;
using Music4All.Infraestructure.Models;

namespace Music4All.Infraestructure.Context;

public class Music4AllBDContext : DbContext //Base de datos
{
    public Music4AllBDContext()
    {

    }

    public Music4AllBDContext(DbContextOptions<Music4AllBDContext> options) : base(options)
    {
    }
    
    public DbSet<Music> Musics { get; set; }
    public DbSet<Event> Events { get; set; }
    //public DbSet<Contractor> Contractors { get; set; }
    //public DbSet<Musician> Musicians { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("server=localhost;user=root;password=galeria123;database=Music4All;", serverVersion);
        }
    }
    
//control de tablas 
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        builder.Entity<Event>().ToTable("Events");
       builder.Entity<Event>().HasKey(p => p.Id);
       builder.Entity<Event>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
       builder.Entity<Event>().Property(c => c.Title).IsRequired().HasMaxLength(50);
       builder.Entity<Event>().Property(c => c.Description).IsRequired().HasMaxLength(150);
       builder.Entity<Event>().Property(c => c.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
       
       builder.Entity<Music>().ToTable("Musics");
       builder.Entity<Music>().HasKey(p => p.Id);
       builder.Entity<Music>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
       builder.Entity<Music>().Property(c => c.Title).IsRequired().HasMaxLength(50);
       builder.Entity<Music>().Property(c => c.Description).IsRequired().HasMaxLength(150);
       builder.Entity<Music>().Property(c => c.DateCreated).IsRequired().HasDefaultValue(DateTime.Now);
       
       builder.Entity<Contractor>().ToTable("Contractors");
       builder.Entity<Contractor>().HasKey(p => p.Id);
      // builder.Entity<Contractor>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);
       
       builder.Entity<Musician>().ToTable("Musicians");
       builder.Entity<Musician>().HasKey(p => p.Id);
      // builder.Entity<Musician>().Property(c => c.IsActive).IsRequired().HasDefaultValue(true);
    }

    
    
}