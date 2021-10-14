using Core.Models;
using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ILibraryBL
    {
        #region Book

        IEnumerable<Book> FetchBooks(Func<Book, bool> filter = null);
        Book FetchBookById(int id);
        bool CreateBook(Book newBook);
        bool EditBook(Book editedBook);
        bool DeleteBookById(int idBook);

        #endregion

        #region Loan

        IEnumerable<Loan> FetchLoans(Func<Loan, bool> filter = null);
        Loan FetchLoanById(int id);
        bool CreateLoan(Loan newLoan);
        bool EditLoan(Loan editedLoan);
        bool DeleteLoanById(int idLoan);

        bool LoanBook(int idBook, string user);
        bool ReturnBook(int idBook);

        #endregion
    }
}
