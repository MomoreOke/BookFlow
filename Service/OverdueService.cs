using LibraryManagement.Data.LibraryDBContext;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Service
{
    public class OverdueService
    {
        private LibraryDBContext _Context;
        public OverdueService(LibraryDBContext context)
        {
            _Context = context;
        }


        public bool AddOverDueBooks()
        {
            //Check if there is data in loan table
            int countborrowedbook = _Context.Loans.Count();
            if(countborrowedbook == 0)
            {
                return false;
            }

            //Get list of unreturned borrowed books with it members
            List<Loan> GetborrowedBooksWhichHasNotBeenReturned = _Context.Loans.Where(x => x.ReturnStatus =="Not Returned")
                                                                               .Include(x => x.Book)
                                                                               .Include(x => x.Member)
                                                                               .ToList();

            foreach (var item in GetborrowedBooksWhichHasNotBeenReturned)
            {

                var CheckIfMemberExistIntheOverdueBookTable = _Context.OverdueBooks.Where(x => x.MemberId == item.MemberId).FirstOrDefault();
                int numberdaysOverdue = (int)Math.Abs(DateTime.Now.Subtract(item.ReturnDate).TotalDays);
                if (CheckIfMemberExistIntheOverdueBookTable == null)
                {
                    OverdueBook overdueBook = new()
                    {
                        NumberOfDaysOverdue = numberdaysOverdue,
                        FineAmount = Convert.ToDecimal(numberdaysOverdue * 2),
                        BorrowerName = $"{item.Member.UserName}",
                        MemberId = item.MemberId,
                        BookId = item.BookId

                    };

                    _Context.OverdueBooks.Add(overdueBook);
                    _Context.SaveChanges();
                }
               
            }

            return true;
            
        }

    }
}
