using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QueryableExperiment
{
    public class CustomQueryableExecutor
    {
        public IEnumerable<int> Execute(Expression expression)
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}
