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
    public class Eval360Service: Service<evaluation360>, IEval360Service
    {

        static IDatabaseFactory Factory = new DatabaseFactory();
        static IUnitOfWork Uok = new UnitOfWork(Factory);
        public Eval360Service() : base(Uok)
        {
        }
        public IEnumerable<evaluation360> GetEval360byavis(string avis)
        {

            return GetMany(c => c.avis == avis);
        }


    }
}
