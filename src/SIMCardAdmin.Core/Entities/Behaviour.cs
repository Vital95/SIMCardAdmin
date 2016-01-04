using System.Data.Linq.Mapping;

namespace SIMCardAdmin.Core.Entities
{
    /// <summary>
    /// Represents a Behaviour.
    /// </summary>
    [Table(Name = "Behaviour")]
    public class Behaviour
    {
        /// <summary>
        /// Gets or sets BehaviourID.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int BehaviourID { get; set; }

        /// <summary>
        /// Gets or sets BehaviourGroupID.
        /// </summary>
        [Column]
        public int BehaviourGroupID { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Column]
        public string Name { get; set; }
    }
}
