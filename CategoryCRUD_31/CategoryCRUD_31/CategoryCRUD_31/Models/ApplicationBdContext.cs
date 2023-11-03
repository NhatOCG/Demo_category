using CategoryCRUD_31.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CategoryCRUD_31.Models
{
	public class ApplicationBdContext : DbContext
	{
		public ApplicationBdContext(DbContextOptions options) : base(options)
		{
			//
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Category> categorys { get; set; }
	}
}
