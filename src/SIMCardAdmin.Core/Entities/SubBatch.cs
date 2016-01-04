using System.Data.Linq.Mapping;
using System.Collections.Generic;

namespace SIMCardAdmin.Core.Entities
{
    /// <summary>
    /// Represents a SubBatch.
    /// </summary>
    [Table(Name = "SubBatch")]
    public class SubBatch
    {
        public SubBatch()
        {
            SimCards = new HashSet<SIMCard>();
        }

        /// <summary>
        /// Gets or sets SubBatchID.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int SubBatchID { get; set; }

        /// <summary>
        /// Gets or sets BatchID.
        /// </summary>
        [Column]
        public int BatchID { get; set; }

        /// <summary>
        /// Gets or sets Code
        /// </summary>
        [Column]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the Batch
        /// </summary>
        public virtual Batch Batch { get; set; }

        /// <summary>
        /// Gets or sets the SimCards
        /// </summary>
        public virtual ICollection<SIMCard> SimCards { get; set; }
    }
}
