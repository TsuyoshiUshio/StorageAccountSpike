using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace StorageAccountSpike
{
    class Program
    {
        static void Main(string[] args)
        {
           new ParallelUploadTest().Execute();
        }
    }
}
