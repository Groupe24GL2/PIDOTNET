

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIDOTNET.DATA.DataModel;

namespace PIDOTNET.DATA.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
       private Model4 dataContext;
        public Model4 DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new Model4();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
