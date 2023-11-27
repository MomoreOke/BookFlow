using System;
using System.Collections.Generic;

namespace LibraryManagement.Data.LibraryDBContext
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int PublisherId { get; set; }
        public string PublusherName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
