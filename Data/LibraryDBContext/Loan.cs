using System;
using System.Collections.Generic;

namespace LibraryManagement.Data.LibraryDBContext
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public string ReturnStatus { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
    }
}
