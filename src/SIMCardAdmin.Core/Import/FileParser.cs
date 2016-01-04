using SIMCardAdmin.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SIMCardAdmin.Core.Import
{
    public class FileParser : Interfaces.IFileParser
    {

        protected string FilePath { get; set; }

        /// <summary>
        /// Constructor for the file parser.
        /// </summary>
        /// <param name="filePath">The full path to the file, f.e. "C:\www\uploads\myfile.xslx"</param>
        public FileParser(string filePath)
        {
            FilePath = filePath;
        }

        public Batch Parse()
        {
            var fileInfo = new FileInfo(FilePath);
            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException(string.Format("The file '{0}' does not exist", FilePath));
            }

            // The file represents the batch. The name of the batch is the name of the file.
            var batch = new Batch();
            batch.Name = DetermineFileName(fileInfo);
            batch.SubBatches = new List<SubBatch>();
            try
            {
                using (var factory = new LinqToExcel.ExcelQueryFactory(FilePath))
                {
                    // The work sheets are the sub batches.
                    var subBatchNames = factory.GetWorksheetNames();
                    foreach (var subBatchName in subBatchNames)
                    {
                        // Loop the sub batches.
                        var subBatch = new SubBatch
                        {
                            Code = subBatchName
                        };
                        var subBatchRows = factory.Worksheet(subBatchName);

                        // Read the rows. The rows are matched  using the row number.
                        subBatch.SimCards = subBatchRows.Select(row => new SIMCard
                        {
                            TrackingCode = row[0].Value.ToString(),
                            SubBatch = subBatch,
                            DateCaptured = DateTime.Parse(row[3].Value.ToString()),
                            CapturedBy = row[4].Value.ToString(),
                            Network = new Network
                            {
                                Name = row[5].Value.ToString()
                            },
                            Package = new Package
                            {
                                Name = row[6].Value.ToString()
                            },
                            ICCID = row[7].Value.ToString(),
                            IMSI = row[8].Value.ToString(),
                            MSISDN = row[9].Value.ToString(),
                            Group = new Group
                            {
                                Name = row[10].Value.ToString()
                            }
                        }).ToList();

                        batch.SubBatches.Add(subBatch);
                    }
                }
            }
            catch (Exception)
            {
                // perhaps some cleaning up?
                throw;
            }

            return batch;
        }

        /// <summary>
        /// Method to determine the name of the batch. We need the name to be 
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        protected string DetermineFileName(FileInfo fileInfo)
        {
            return fileInfo.Name.Replace(".xlsx", "");
        }
    }
}
