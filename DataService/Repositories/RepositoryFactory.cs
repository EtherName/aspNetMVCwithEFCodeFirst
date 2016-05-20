using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repositories
{
     public class RepositoryFactory
    {
        //private Repository _repos;
        //public RepositoryFactory()
        //{
        //    _repos = new BookStorageRepositoty();
        //}
        public static Repository GetRepository()
        {
            return new BookStorageRepositoty();
        }
    }
}
