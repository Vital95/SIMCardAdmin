using SIMCardAdmin.Core.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SIMCardAdmin.Core.Database
{
    /// <summary>
    /// Database Context based on EntityFramework (CodeFirst).
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        public DatabaseContext()
            : base("DatabaseContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        //// <summary>
        /// Gets or sets the <see cref="Batch">Batches</see>.
        /// </summary>
        public DbSet<Batch> Batches { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SubBatch">SubBatches</see>.
        /// </summary>
        public DbSet<SubBatch> SubBatches { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SIMCard">SIMCard</see>.
        /// </summary>
        public DbSet<SIMCard> SIMCards { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Group">Groups</see>.
        /// </summary>
        public DbSet<Group> Groups { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Network">Networks</see>.
        /// </summary>
        public DbSet<Network> Networks { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Package">Packages</see>.
        /// </summary>
        public DbSet<Package> Packages { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="BehaviourGroup">BehaviourGroups</see>.
        /// </summary>
        public DbSet<BehaviourGroup> BehaviourGroups { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Behaviour">Behaviours</see>.
        /// </summary>
        public DbSet<Behaviour> Behaviours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
