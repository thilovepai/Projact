using System;
using System.Collections.Generic;

namespace Book.Models
{
    public partial class TableDetail
    {
        public int Iddetail { get; set; }
        public string OrderNum { get; set; }
        public int? Idbook { get; set; }
        public string Numbook { get; set; }
        public int? Idorder { get; set; }
        public int? Total { get; set; }

        public TableBook IdbookNavigation { get; set; }
        public TableOrder IdorderNavigation { get; set; }
    }
}
