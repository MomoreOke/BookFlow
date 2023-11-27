using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class BorrowedModel
    {
        public int BookId { get; set; }         // Assuming you need to link the borrowed book to a specific book
        public string Title { get; set; }       // Title of the book
        public string BorrowerName { get; set; } // Name of the borrower
        public string BorrowerPhoneNumber { get; set; } // Number Of borrower
        [DataType(DataType.Date)]
        public DateTime DateBorrowed { get; set; } // Date the book was borrowed
    }
}

