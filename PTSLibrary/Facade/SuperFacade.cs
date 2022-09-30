using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.Facade
{
    internal class SuperFacade : MarshalByRefObject
    {
        protected DataAccess.SuperDAO dao;

        public SuperFacade(DataAccess.SuperDAO dao)
        {
            this.dao = dao;
        }
    }
}
