using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAccountSpike
{
    public class ParallelUploadTest
    {
        public void Execute()
        {
            // Create a client
            // Run Two Threads
            var manager = new ScaleDecisionManager(ConfigurationManager.AppSettings[Configuration.ConnectionString]);
            Task.Run(async () => { await ProducerLoopAsync(manager); });
            Task.Run(async () => { await ConsumerLoopAsync(manager);});
            Console.ReadLine();
        }

        private async Task ProducerLoopAsync(ScaleDecisionManager manager)
        {
            Parallel.ForEach(Enumerable.Range(1, 32).ToArray(), async (idx) =>
            {
                while (true)
                {
                    await manager.UploadScaleDecisionAsync(new ScaleDecision(){Decision = "AddWorker", Index = idx, TimeStamp = DateTime.UtcNow});
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            });
        }

        private async Task ConsumerLoopAsync(ScaleDecisionManager manager)
        {
            while (true)
            {
                var json = await manager.ReadScaleDecisionAsync();
                Console.WriteLine(json);
                await Task.Delay(TimeSpan.FromSeconds(3));
            }
        }
    }
}
