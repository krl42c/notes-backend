namespace NotesBACKEND.Models;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

public class NoteContext : DbContext
{
   public NoteContext() : base()
   {
   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       string connString;
       DbAuth dbAuth = JsonFileReader.readFile<DbAuth>("dbConfig.json");
       connString = "server=" + dbAuth.server + ";user=" + dbAuth.user + ";database=" + dbAuth.database + ";port=" +
                        dbAuth.port + ";password=" + dbAuth.password;
       optionsBuilder.UseMySQL(connString);
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
       base.OnModelCreating(modelBuilder);
       modelBuilder.Entity<Note>(entity =>
       {
           entity.HasKey(e => e.id);
           entity.Property(e => e.title).IsRequired();
       });
   }
   
   public DbSet<Note> Notes { get; set; }
   
}