using System;
using System.Data.Linq.Mapping;

namespace SIMCardAdmin.Core.Entities
{
    /// <summary>
    /// Represents a SIMCard.
    /// </summary>
    [Table(Name = "SIMCard")]
    public class SIMCard
    {
        /// <summary>
        /// Gets or sets SIMCardID.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int SIMCardID { get; set; }

        /// <summary>
        /// Gets or sets SubBatchID.
        /// </summary>
        [Column]
        public int SubBatchID { get; set; }

        /// <summary>
        /// Gets or sets NetworkID.
        /// </summary>
        [Column]
        public int NetworkID { get; set; }

        /// <summary>
        /// Gets or sets PackageID.
        /// </summary>
        [Column]
        public int PackageID { get; set; }

        /// <summary>
        /// Gets or sets GroupID
        /// </summary>
        [Column]
        public int GroupID { get; set; }

        /// <summary>
        /// Gets or sets TrackingCode.
        /// </summary>
        [Column]
        public string TrackingCode { get; set; }

        /// <summary>
        /// Gets or sets ICCID.
        /// </summary>
        [Column]
        public string ICCID { get; set; }

        /// <summary>
        /// Gets or sets MSISDN.
        /// </summary>
        [Column]
        public string MSISDN { get; set; }

        /// <summary>
        /// Gets or sets IMSI.
        /// </summary>
        [Column]
        public string IMSI { get; set; }

        /// <summary>
        /// Gets or sets DateCaptured.
        /// </summary>
        [Column]
        public DateTime DateCaptured { get; set; }

        /// <summary>
        /// Gets or sets CapturedBy.
        /// </summary>
        [Column]
        public string CapturedBy { get; set; }

        /// <summary>
        /// Gets or sets the SubBatch
        /// </summary>
        public virtual SubBatch SubBatch { get; set; }

        /// <summary>
        /// Gets or sets the Network
        /// </summary>
        public virtual Network Network { get; set; }

        /// <summary>
        /// Gets or sets the Package
        /// </summary>
        public virtual Package Package { get; set; }

        /// <summary>
        /// Gets or Sets the Group
        /// </summary>
        public virtual Group Group { get; set; }
    }
}
