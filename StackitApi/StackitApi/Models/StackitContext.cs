using Microsoft.EntityFrameworkCore;

namespace StackitApi.Models
{
    public class StackitContext : DbContext
    {
        public StackitContext(DbContextOptions<StackitContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<StatusCode> StatusCodes { get; set; }
        public DbSet<Stack> Stacks { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<MachineOperator> MachineOperators { get; set; }
        public DbSet<JobFile> JobFiles { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<UserPrivilege> UserPrivileges { get; set; }
        public DbSet<DefaultPrivilege> DefaultPrivileges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite primary keys can only be defined with fluent API
            modelBuilder.Entity<MachineOperator>()
                .HasKey(mo => new { mo.UserId, mo.MachineId });
            modelBuilder.Entity<UserPrivilege>()
                .HasKey(up => new { up.UserId, up.PrivilegeId });
            modelBuilder.Entity<DefaultPrivilege>()
                .HasKey(dp => new { dp.UserTypeId, dp.PrivilegeId });
            modelBuilder.Entity<JobFile>()
                .HasKey(jf => new { jf.JobId, jf.FileId });
        }

    }
}
