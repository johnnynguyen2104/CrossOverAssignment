using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using CrossOverAssignment.DAL.Interfaces;
using CrossOverAssignment.DAL.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CrossOverAssignment.DAL.DomainModels
{
    public class StockTickerDbContext : IdentityDbContext<User, Role, string, UserLogin, UserRoles, UserClaim>, IDbContext
    {
        private static string ConnectionString { get; set; } = "StockExchangeConnection";

        public StockTickerDbContext()
            :base("StockExchangeConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StockTickerDbContext, Configuration>("StockExchangeConnection"));
        }
        public StockTickerDbContext(string connection) 
            : base(connection)
        {
            ConnectionString = string.IsNullOrEmpty(connection) ? ConnectionString: connection;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StockTickerDbContext, Configuration>(connection));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRoles>().ToTable("UserRoles");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");

            modelBuilder.Entity<User>()
                .HasMany(a => a.Stocks)
                .WithRequired(b => b.User)
                .HasForeignKey(a => a.UserId);

        }

        public static StockTickerDbContext Create()
        {
            return new StockTickerDbContext();
        }

        public int CommitChanges()
        {
            return this.SaveChanges();
        }

        public DbSet<TEntity> Set<TKey, TEntity>() where TKey : struct where TEntity : BaseEntity<TKey>
        {
            return this.Set<TEntity>();
        }

        public DbEntityEntry<TEntity> Entry<TKey, TEntity>(TEntity entity) where TKey : struct where TEntity : BaseEntity<TKey>
        {
            return this.Entry(entity);
        }
    }
}
