using System.Data.Entity;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository
{
    public class AccountAtAGlanceContext : DbContext, IDisposedTracker
    {

        public DbSet<BrokerageAccount> BrokerageAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<MarketIndex> MarketIndexes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<MutualFund> MutualFunds { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public bool IsDisposed { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //Ignores
            modelBuilder.Ignore<DataPoint>();
            modelBuilder.Ignore<MarketsAndNews>();
            modelBuilder.Ignore<MarketQuotes>();
            modelBuilder.Ignore<OperationStatus>();
            modelBuilder.Ignore<TickerQuote>();

            // inherited table types
            // Map these class names to the table names in the DB
            modelBuilder.Entity<Security>().ToTable("Securities");
            modelBuilder.Entity<Stock>().ToTable("Securities_Stock");
            modelBuilder.Entity<MutualFund>().ToTable("Securities_MutualFund");

            // Many to many resolver
            // Map the WatchList and Securities navigation property using the WatchListSecurity Many-to-Many table.
            // To avoid a Cycle condition, WatchList has Securities, but Security does not have WatchLists.
            modelBuilder.Entity<WatchList>()
                    .HasMany(w => w.Securities)
                    .WithMany()
                    .Map(map => map.ToTable("WatchListSecurity")
                    .MapRightKey("SecurityId")
                   .MapLeftKey("WatchListId"));
        }

        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            base.Dispose(disposing);
        }

        public int DeleteAccounts()
        {
            return base.Database.ExecuteSqlCommand("DeleteAccounts");
        }

        public int DeleteSecuritiesAndExchanges()
        {
            return base.Database.ExecuteSqlCommand("DeleteSecuritiesAndExchanges");
        }
    }
}

