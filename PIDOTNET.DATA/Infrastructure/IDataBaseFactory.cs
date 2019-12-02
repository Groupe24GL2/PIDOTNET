using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIDOTNET.DATA.DataModel;

namespace PIDOTNET.DATA.Infrastructure
{
    public interface IDataBaseFactory:IDisposable
    {
        Model1 Ctxt { get; }
    }
}
