using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    class ProcessorBuilder
    {
        public static ProcessorEnginer<TEngine> CreateEngine<TEngine>()
        {
            return new ProcessorEnginer<TEngine>();
        }
    }
}
