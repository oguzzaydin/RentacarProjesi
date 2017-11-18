using MS_Rentacar.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Rentacar.DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        protected static object _lockSync = new object();
        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if(context==null)
            {
                lock(_lockSync)
                {
                    if(context==null)
                    {
                        context = new EntityFramework.DatabaseContext();
                    }
                }
            }

        }
    }
}
