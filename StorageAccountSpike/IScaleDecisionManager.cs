using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageAccountSpike
{
    interface IScaleDecisionManager
    {
        Task UploadScaleDecisionAsync(object obj);
        Task<string> ReadScaleDecisionAsync();
    }
}
