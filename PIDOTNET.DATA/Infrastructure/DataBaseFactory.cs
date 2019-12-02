using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIDOTNET.DATA.DataModel;

namespace PIDOTNET.DATA.Infrastructure
{
    public class DataBaseFactory: Disposable, IDataBaseFactory
    {
        Model1 ctxt;

        public Model1 Ctxt
        {
            get
            {
                return ctxt;
            }
        }

        public DataBaseFactory()
        {
            ctxt = new Model1();
        }

        public override void DisposeCore()
        {
            if (ctxt != null)
                ctxt.Dispose();
        }
    }
}
