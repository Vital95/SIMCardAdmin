using System.Data.Linq.Mapping;

namespace SIMCardAdmin.Core.Entities
{
    /// <summary>
    /// Represents a Group.
    /// </summary>
    [Table(Name = "Group")]
    public class Group
    {
        /// <summary>
        /// Gets or sets GroupID.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int GroupID { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Column]
        public string Name { get; set; }
    }
}
