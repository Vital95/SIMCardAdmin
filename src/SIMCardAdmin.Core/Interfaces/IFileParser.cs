namespace SIMCardAdmin.Core.Interfaces
{
    /// <summary>
    /// Interface for the file parser.
    /// </summary>
    public interface IFileParser
    {
        /// <summary>
        /// Parse the file contents.
        /// </summary>
        /// <returns>Returns the batch that was extracted from the file.</returns>
        Entities.Batch Parse();
    }
}
