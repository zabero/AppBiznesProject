﻿using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BussinesLogic
{
    public class Voucher:DatabaseClass
    {

        #region Constructor
        public Voucher(VoucherShopEntities db)
            : base(db) { }
        #endregion
        #region Logic methods
        public IQueryable<KeyAndValue> GetVoucherKeyAndValueItems()
        {
            return db.Vouchers
                .Select(voucher => new KeyAndValue
                {
                    Key = voucher.VoucherID,
                    Value = voucher.Name
                })
                .AsQueryable();
        }
        #endregion
    }
}
