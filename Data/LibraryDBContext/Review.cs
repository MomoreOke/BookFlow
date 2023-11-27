using System;
using System.Collections.Generic;

namespace LibraryManagement.Data.LibraryDBContext
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int? MemberId { get; set; }
        public int? BookId { get; set; }
        public int? ReviewScore { get; set; }
        public string ReviewDescription { get; set; }

        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
    }
}
