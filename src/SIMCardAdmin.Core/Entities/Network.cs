using System.Data.Linq.Mapping;

namespace SIMCardAdmin.Core.Entities
{
    /// <summary>
    /// Represents a Network.
    /// </summary>
    [Table(Name = "Network")]
    public class Network
    {
        /// <summary>
        /// Gets or sets NetworkID.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int NetworkID { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        [Column]
        public string Name { get; set; }

        ///// <summary>
        ///// Gets or sets MccNc.
        ///// </summary>
        [Column(CanBeNull = true)]
        public int? MccNc { get; set; }
    }
}
