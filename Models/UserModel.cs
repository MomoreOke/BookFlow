// User.cs
using System.Collections.Generic;

namespace LibraryManagement.Models
{
    // BookRequest.cs
    namespace LibraryManagement.Models
    {
        public class RequestBook
        {
            public int BookRequestId { get; set; }
            public int BookId { get; set; }
            public int UserId { get; set; }
            public DateTime RequestBookDate { get; set; }

            // Add more properties specific to a book request, e.g., RequestDate, Status, etc.
        }
    }

}
