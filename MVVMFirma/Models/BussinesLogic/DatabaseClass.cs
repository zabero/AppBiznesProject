using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BussinesLogic
{
    public class DatabaseClass
    {
        #region Context
        public VoucherShopEntities db { get; set; }
        #endregion

        #region Constructor
        public DatabaseClass(VoucherShopEntities db)
        {
            this.db = db;
        }
        #endregion
    }
}
