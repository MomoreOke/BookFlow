using System;
using System.Collections.Generic;

namespace LibraryManagement.Data.LibraryDBContext
{
    public partial class BookReservation
    {
        public int ReservationId { get; set; }
        public int? BookId { get; set; }
        public int? MemberId { get; set; }
        public DateTime ExpectedAvailabilityDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
    }
}
