using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryFinalProject.Models.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=LibraryDB1.mssql.somee.com;packet size=4096;user id=Desouki_SQLLogin_1;pwd=metofwmrpy;data source=LibraryDB1.mssql.somee.com;persist security info=False;initial catalog=LibraryDB1;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Return>()
                .ToTable("Returns", tb => tb.HasTrigger("insertinpenalty"));
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(r => new { r.UserId, r.RoleId });
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Checkouts> Checkouts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<Return> Returns { get; set; }

    }
}
