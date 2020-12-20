using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAccountSpike
{
    public class Configuration
    {
        public static string ConnectionString { get; } = "AzureWebJobsStorage";

        public static string ContainerName { get; } = "kafka-scale-controller";

        public static string BlobName { get; } = "current-scale-decision.json";
    }
}
