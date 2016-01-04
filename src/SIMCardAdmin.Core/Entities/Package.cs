using System.Data.Linq.Mapping;

namespace SIMCardAdmin.Core.Entities
{
    /// <summary>
    /// Represents a Package.
    /// </summary>
    [Table(Name = "Package")]
    public class Package
    {
        /// <summary>
        /// Gets or sets PackageID.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int PackageID { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Column]
        public string Name { get; set; }
    }
}
