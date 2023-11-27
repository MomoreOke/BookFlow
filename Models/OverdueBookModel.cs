using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Models
{
    public class OverdueBookModel
    {
        public int OverdueBookId { get; set; }
        public int? NumberOfDaysOverdue { get; set; }
        public decimal? FineAmount { get; set; }
        public string BorrowerName { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
    }
}
