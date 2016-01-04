using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System;

namespace SIMCardAdmin.Core.Entities
{
    /// <summary>
    /// Represents a Batch.
    /// </summary>
    [Table(Name = "Batch")]
    public class Batch
    {
        public Batch()
        {
            SubBatches = new HashSet<SubBatch>();
        }

        /// <summary>
        /// Gets or sets BatchID.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int BatchID { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Column]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets DateCreated.
        /// </summary>
        [Column]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets CreatedBy.
        /// </summary>
        [Column]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the SubBatches
        /// </summary>
        public virtual ICollection<SubBatch> SubBatches { get; set; }
    }
}
