using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Models
{
    // AdminRequestModel.cs
    public class AdminRequestModel
    {
        public int RequestId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string UserName { get; set; }
    }

}


