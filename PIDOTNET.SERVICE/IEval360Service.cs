using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIDOTNET.DATA.DataModel;
using PIDOTNET.SERVICEPATTERN;
using PIDOTNET.DATA.Infrastructure;
namespace PIDOTNET.SERVICE
{
    public interface IEval360Service:IService<evaluation360>
    {
         IEnumerable<evaluation360> GetEval360byavis(string avis);
    }
}
