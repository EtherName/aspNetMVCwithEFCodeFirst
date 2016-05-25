using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Repositories
{
     public class RepositoryFactory
    {
        public static Repository GetRepository()
        {
            return new BookStorageRepositoty();
        }
    }
}
