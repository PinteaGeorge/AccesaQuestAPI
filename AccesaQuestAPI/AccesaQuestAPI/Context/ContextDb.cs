using AccesaQuestAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesaQuestAPI.Context
{
    public class ContextDb: DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<CommonQuests> CommonQuests { get; set; }
        public DbSet<CompletedQuestsFromUser> CompletedQuestsFromUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<CommonQuests>().ToTable("CommonQuests");
            modelBuilder.Entity<CompletedQuestsFromUser>().ToTable("CompletedQuestsFromUsers");
        }
    }
}
