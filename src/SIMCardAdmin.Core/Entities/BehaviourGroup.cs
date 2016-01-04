using System.Data.Linq.Mapping;
using System.Collections.Generic;

namespace SIMCardAdmin.Core.Entities
{
    /// <summary>
    /// Represents a BehaviourGroup.
    /// </summary>
    [Table(Name = "BehaviourGroup")]
    public class BehaviourGroup
    {
        /// <summary>
        /// Gets or sets BehaviourGroupID.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int BehaviourGroupID { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Column]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Behaviour
        /// </summary>
        public virtual ICollection<Behaviour> Behaviours { get; set; }
    }
}
