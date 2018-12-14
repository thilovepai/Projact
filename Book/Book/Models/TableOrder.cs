using System;
using System.Collections.Generic;

namespace Book.Models
{
    public partial class TableOrder
    {
        public TableOrder()
        {
            TableDetail = new HashSet<TableDetail>();
        }

        public int Idorder { get; set; }
        public int? Idcus { get; set; }
        public string DateOrder { get; set; }

        public TableCustomer IdcusNavigation { get; set; }
        public ICollection<TableDetail> TableDetail { get; set; }
    }
}
