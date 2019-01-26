using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerInquiry.DAL.Entities
{
    /// <summary>
    /// CustomerDbContext class
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public partial class CustomerDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDbContext"/> class.
        /// </summary>
        public CustomerDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        public virtual DbSet<Customers> Customers { get; set; }
        /// <summary>
        /// Gets or sets the customer transaction.
        /// </summary>
        /// <value>
        /// The customer transaction.
        /// </value>
        public virtual DbSet<CustomerTransaction> CustomerTransaction { get; set; }
        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        /// <value>
        /// The transactions.
        /// </value>
        public virtual DbSet<Transactions> Transactions { get; set; }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SQLAZURECONNSTR_AzureSQL"));
            }
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ContactEmail).HasMaxLength(25);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.MobileNo).HasColumnType("numeric(10, 0)");
            });

            modelBuilder.Entity<CustomerTransaction>(entity =>
            {
                entity.Property(e => e.CustomerTransactionId).HasColumnName("CustomerTransactionID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerTransaction)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Customer_CustomerID");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.CustomerTransaction)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK_Transaction_TransactionID");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CurrencyCode).HasMaxLength(3);

                entity.Property(e => e.Status).HasColumnType("numeric(1, 0)");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            });
        }
    }
}
