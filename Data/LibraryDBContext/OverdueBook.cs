using System;
using System.Collections.Generic;

namespace LibraryManagement.Data.LibraryDBContext
{
    public partial class OverdueBook
    {
        public int OverdueBookId { get; set; }
        public int? NumberOfDaysOverdue { get; set; }
        public decimal? FineAmount { get; set; }
        public string BorrowerName { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
    }
}
