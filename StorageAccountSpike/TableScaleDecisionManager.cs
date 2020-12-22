using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace StorageAccountSpike
{
    public class TableScaleDecisionManager : IScaleDecisionManager
    {
        private CloudTableClient client;

        public TableScaleDecisionManager()
        {

        }

        public void SetUp()
        {
            // https://stackoverflow.com/questions/16936530/azure-table-storage-simplest-possible-example
            // For the table sample for WindowsAzure namespace refer to https://github.com/TsuyoshiUshio/StorageTableQueryCore
            var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings[Configuration.ConnectionString]);
            this.client = storageAccount.CreateCloudTableClient();
        }
        public Task<string> ReadScaleDecisionAsync()
        {
            throw new NotImplementedException();
        }

        public Task UploadScaleDecisionAsync(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
