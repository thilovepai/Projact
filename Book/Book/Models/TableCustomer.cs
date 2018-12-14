using System;
using System.Collections.Generic;

namespace Book.Models
{
    public partial class TableCustomer
    {
        public TableCustomer()
        {
            TableOrder = new HashSet<TableOrder>();
        }

        public int Idcus { get; set; }
        public string NameCus { get; set; }
        public string Tel { get; set; }
        public string Idcard { get; set; }
        public byte[] PictureCus { get; set; }

        public ICollection<TableOrder> TableOrder { get; set; }
    }
}
