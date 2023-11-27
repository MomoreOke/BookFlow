using System;
using System.Collections.Generic;

namespace LibraryManagement.Data.LibraryDBContext
{
    public partial class Member
    {
        public Member()
        {
            BookReservations = new HashSet<BookReservation>();
            Loans = new HashSet<Loan>();
            OverdueBooks = new HashSet<OverdueBook>();
            Reviews = new HashSet<Review>();
        }

        public int MemberId { get; set; }
        public string UserName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }

        public virtual ICollection<BookReservation> BookReservations { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<OverdueBook> OverdueBooks { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
