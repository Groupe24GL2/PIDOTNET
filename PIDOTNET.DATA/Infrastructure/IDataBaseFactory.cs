
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIDOTNET.DATA.DataModel;
namespace PIDOTNET.DATA.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        Model4 DataContext { get; }
    }

}
