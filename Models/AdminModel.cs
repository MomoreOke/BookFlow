using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Models
{
    public class AdminModel
    {
        public int Book { get; set; }
        public int Borrowed{ get; set; }
        public int OverDue { get; set; }
        public int UserRequest { get; set; }

        
    }
}



