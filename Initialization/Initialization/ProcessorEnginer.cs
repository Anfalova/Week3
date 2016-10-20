using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    class ProcessorEnginer<TEngine>
    {
        public ProcessorEntition<TEngine, TEntity> For<TEntity>()
        {
            return new ProcessorEntition<TEngine, TEntity>();
        }
    }
}
