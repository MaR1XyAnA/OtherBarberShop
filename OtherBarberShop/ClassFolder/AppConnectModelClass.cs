using OtherBarberShop.ModelFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherBarberShop.ClassFolder
{
    internal class AppConnectModelClass
    {
        private static OtherBarberShopDataBaseEntities _context;
        public static OtherBarberShopDataBaseEntities DataBase()
        {
            if (_context == null)
            {
                _context = new OtherBarberShopDataBaseEntities();
            }
            return _context;
        }
    }
}
