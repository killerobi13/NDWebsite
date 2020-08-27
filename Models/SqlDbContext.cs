using Microsoft.EntityFrameworkCore;

namespace NewDawnWeb.Models
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Primary Keys

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<News>().HasKey(t => t.Id);
            modelBuilder.Entity<CoinsOffer>().HasKey(t => t.Id);
            modelBuilder.Entity<IMItem>().HasKey(t => t.Id);
            modelBuilder.Entity<Ticket>().HasKey(t => t.Id);
            modelBuilder.Entity<TicketReply>().HasKey(t => t.Id);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
            //Relationships

            modelBuilder.Entity<User>().HasMany(u => u.AssignedTickets).WithOne(t => t.Solver);
            modelBuilder.Entity<User>().HasMany(u => u.IssuedTickets).WithOne(t => t.Issuer);
            modelBuilder.Entity<User>().HasMany(u => u.TicketReplies).WithOne(t => t.User);
            modelBuilder.Entity<User>().HasMany(u => u.Transactions).WithOne(t => t.User);


        }
        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketReply> TicketReplies { get; set; }
        public DbSet<IMItem> IMItems { get; set; }
        public DbSet<CoinsOffer> CoinsOffers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}