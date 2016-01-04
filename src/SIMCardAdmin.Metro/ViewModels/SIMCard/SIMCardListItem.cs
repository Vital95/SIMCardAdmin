namespace SIMCardAdmin.Metro.ViewModels.SIMCard
{
    public class SimCardListItem
    {
        /// <summary>
        /// The ID of the simcard.
        /// </summary>
        public int SIMCardID { get; set; }

        /// <summary>
        /// The tracking code.
        /// </summary>
        public string TrackingCode { get; set; }

        /// <summary>
        /// The ICCID
        /// </summary>
        public string ICCID { get; set; }

        /// <summary>
        /// The MSISDN
        /// </summary>
        public string MSISDN { get; set; }

        /// <summary>
        /// The group ID isn't used yet, but you could use this to jump to a list for this network.
        /// </summary>
        public int GroupID { get; set; }

        /// <summary>
        /// The name of the group, for display purposes.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// The network ID isn't used yet, but you could use this to jump to a list for this network.
        /// </summary>
        public int NetworkID { get; set; }

        /// <summary>
        /// The name of the network, for display purposes.
        /// </summary>
        public string NetworkName { get; set; }
    }
}
