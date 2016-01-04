using SIMCardAdmin.Core.Database;
using SIMCardAdmin.Core.Entities;
using SIMCardAdmin.Core.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace SIMCardAdmin.Core.Import
{
    public class ImportLogic
    {
        /// <summary>
        /// The file parser.
        /// </summary>
        protected IFileParser FileParser { get; set; }

        protected DatabaseContext DatabaseContext { get; set; }

        public ImportLogic(string fileName, DatabaseContext context)
        {
            FileParser = new FileParser(fileName);
            DatabaseContext = context;
        }

        public ImportReport Import()
        {
            Batch fileContents = null;
            var importReport = new ImportReport();

            try
            {
                fileContents = FileParser.Parse();
                MergeData(fileContents);
                importReport.IsSuccess = true;
            }
            catch (Exception ex)
            {
                importReport.IsSuccess = false;
                importReport.InnerException = ex;
            }

            return importReport;
        }

        protected void MergeData(Batch batchFile)
        {
            // See if there is an existing batch in the DB. Ignore casing in the batch names.
            var existingBatch = DatabaseContext.Batches.FirstOrDefault(batch => batch.Name.ToLower() == batch.Name.ToLower());
            if (existingBatch == null)
            {
                // The batch does not exist. Create a new item in the database, and save it directly.
                existingBatch = new Batch
                {
                    CreatedBy = "System",
                    DateCreated = DateTime.Now,
                    Name = batchFile.Name,
                };

                DatabaseContext.Batches.Add(existingBatch);
                DatabaseContext.SaveChanges();
            }

            foreach (var subBatch in batchFile.SubBatches)
            {
                var existingSubBatch = DatabaseContext.SubBatches.FirstOrDefault(databaseSubBatch => subBatch.Code.ToLower() == databaseSubBatch.Code.ToLower());
                if (existingSubBatch == null)
                {
                    // The sub batch does not exist. Create a new item in the database and save it directly.
                    existingSubBatch = new SubBatch
                    {
                        Code = subBatch.Code,
                        BatchID = existingBatch.BatchID,
                    };

                    DatabaseContext.SubBatches.Add(existingSubBatch);
                    DatabaseContext.SaveChanges();
                }
                else
                {
                    // The sub batch exists, make sure the BatchId's match.
                    if (existingSubBatch.BatchID != existingBatch.BatchID)
                    {
                        throw new InvalidDataException(string.Format("Importing subbatch '{0}' caused an error. The batch id in the file is '{1}' but the batch id in the database is '{2}' ", existingSubBatch.Code, existingSubBatch.BatchID, existingBatch.BatchID));
                    }
                }

                foreach (var simCard in subBatch.SimCards)
                {
                    var addToDb = false;
                    var existingSimcard = DatabaseContext.SIMCards.FirstOrDefault(card => card.ICCID == simCard.ICCID);
                    if (existingSimcard == null)
                    {
                        existingSimcard = new SIMCard
                        {
                            ICCID = simCard.ICCID,
                            SubBatch = existingSubBatch,
                            SubBatchID = existingSubBatch.SubBatchID,
                        };

                        addToDb = true;
                    }
                    else
                    {
                        if (simCard.SubBatchID != existingSubBatch.SubBatchID)
                        {
                            throw new InvalidDataException(string.Format("Simcard with ICCID belongs to subbatch {0} according to the file, but the database says it belongs to subbatch {1}", existingSimcard.SubBatchID, simCard.SubBatchID));
                        }

                    }

                    existingSimcard.CapturedBy = simCard.CapturedBy;

                    existingSimcard.DateCaptured = simCard.DateCaptured;

                    var group = GetGroup(simCard.Group.Name);
                    existingSimcard.Group = group;
                    existingSimcard.GroupID = group.GroupID;

                    existingSimcard.IMSI = simCard.IMSI;

                    existingSimcard.MSISDN = simCard.MSISDN;

                    var network = GetNetwork(simCard.Network.Name);
                    existingSimcard.Network = network;
                    existingSimcard.NetworkID = network.NetworkID;

                    var package = GetPackage(simCard.Package.Name);
                    existingSimcard.Package = package;
                    existingSimcard.PackageID = package.PackageID;

                    existingSimcard.TrackingCode = simCard.TrackingCode;

                    if (addToDb)
                    {
                        DatabaseContext.SIMCards.Add(existingSimcard);
                    }
                    DatabaseContext.SaveChanges();
                }
            }
        }

        protected Network GetNetwork(string networkName)
        {
            var networkEntity = DatabaseContext.Networks.FirstOrDefault(network => network.Name.ToLower() == networkName.ToLower());
            if (networkEntity == null)
            {
                // The network does not exist, create a new one.
                networkEntity = new Network
                {
                    Name = networkName
                };

                DatabaseContext.Networks.Add(networkEntity);
                DatabaseContext.SaveChanges();
            }

            return networkEntity;
        }

        protected Package GetPackage(string packageName)
        {
            var packageEntity = DatabaseContext.Packages.FirstOrDefault(package => package.Name.ToLower() == packageName.ToLower());
            if (packageEntity == null)
            {
                // The package does not exist, create a new one.
                packageEntity = new Package
                {
                    Name = packageName
                };

                DatabaseContext.Packages.Add(packageEntity);
                DatabaseContext.SaveChanges();
            }

            return packageEntity;
        }

        protected Group GetGroup(string groupName)
        {
            var groupEntity = DatabaseContext.Groups.FirstOrDefault(group => group.Name.ToLower() == groupName.ToLower());
            if (groupEntity == null)
            {
                // The group does not exist, create a new one.
                // If group is empty set to default group "unassigned"
                groupEntity = new Group
                {
                    Name = groupName
                };

                DatabaseContext.Groups.Add(groupEntity);
                DatabaseContext.SaveChanges();
            }

            return groupEntity;
        }

        public class ImportReport
        {
            public bool IsSuccess { get; set; }

            public Exception InnerException { get; set; }
        }
    }
}
