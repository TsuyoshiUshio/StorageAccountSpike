using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json;

namespace StorageAccountSpike
{
    public class ScaleDecisionManager : IScaleDecisionManager
    {
        private CloudStorageAccount storageAccount;
        private CloudBlobContainer cloudBlobContainer;

        public ScaleDecisionManager(string connectionString)
        {
            SetUp(connectionString);
        }

        public async Task UploadScaleDecisionAsync(object obj)
        {
            var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(Configuration.BlobName);
            var json = JsonConvert.SerializeObject(obj);
            await cloudBlockBlob.UploadTextAsync(json);
        }

        public Task<string> ReadScaleDecisionAsync()
        {
            var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(Configuration.BlobName);
            return cloudBlockBlob.DownloadTextAsync();
        }

        private void SetUp(string connectionString)
        {
            if (CloudStorageAccount.TryParse(connectionString, out storageAccount))
            {
                // Create a client
                CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

                // Create a container with private // If it necessary
                this.cloudBlobContainer =
                    cloudBlobClient.GetContainerReference(Configuration.ContainerName);
                if (this.cloudBlobContainer.CreateIfNotExists())
                {
                    BlobContainerPermissions permissions = new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Off
                    };
                    this.cloudBlobContainer.SetPermissions(permissions);
                }
            }
            else
            {
                // Error
                throw new ArgumentException($"Failed to create the Storage Account Client. Refer to your {Configuration.ConnectionString} AppSettings");
            }

        }


    }
}
