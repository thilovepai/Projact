using System;
using System.Collections.Generic;

namespace Book.Models
{
    public partial class TableBook
    {
        public TableBook()
        {
            TableDetail = new HashSet<TableDetail>();
        }

        public int Idbook { get; set; }
        public string NameBook { get; set; }
        public string DetailBook { get; set; }
        public int? PriceBook { get; set; }
        public byte[] PictureBook { get; set; }

        public ICollection<TableDetail> TableDetail { get; set; }
    }
}
