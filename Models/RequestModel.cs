using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Models
{
    // RequestModel.cs
    public class RequestModel
    {
        public int BookId { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string RequestMessage { get; set; }
    }
}


