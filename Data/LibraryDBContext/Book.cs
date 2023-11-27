using System;
using System.Collections.Generic;

namespace LibraryManagement.Data.LibraryDBContext
{
    public partial class Book
    {
        public Book()
        {
            BookReservations = new HashSet<BookReservation>();
            Loans = new HashSet<Loan>();
            OverdueBooks = new HashSet<OverdueBook>();
            Reviews = new HashSet<Review>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }
        public int TotalCopies { get; set; }
        public string LoanedCopies { get; set; }
        public int NumberOfPages { get; set; }

        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<BookReservation> BookReservations { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<OverdueBook> OverdueBooks { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
