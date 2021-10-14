using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.BusinessLayer
{
    public class LibraryBL : ILibraryBL
    {
        private readonly IBookRepository bookRepo;
        private readonly ILoanRepository loanRepo;

        public LibraryBL(IBookRepository bookR, ILoanRepository loanR)
        {
            this.bookRepo = bookR;
            this.loanRepo = loanR;
        }

        #region Book

        public bool CreateBook(Book newBook)
        {
            if (newBook == null)
                return false;

            return bookRepo.Add(newBook);
        }
        public bool EditBook(Book editedBook)
        {
            if (editedBook == null)
                return false;

            return bookRepo.Update(editedBook);
        }

        public IEnumerable<Book> FetchBooks(Func<Book, bool> filter = null)
        {
            if (filter != null)
                return bookRepo.Fetch().Where(filter);

            return bookRepo.Fetch();
        }

        public Book FetchBookById(int id)
        {
            if (id <= 0)
                return null;

            return bookRepo.GetById(id);
        }

        public bool DeleteBookById(int idBook)
        {
            if (idBook <= 0)
                return false;

            Book bookToBeDeleted = this.bookRepo.GetById(idBook);

            if (bookToBeDeleted != null)
                return bookRepo.Delete(bookToBeDeleted);

            return false;
        }

        #endregion

        #region Loan

        public IEnumerable<Loan> FetchLoans(Func<Loan, bool> filter = null)
        {
            if (filter != null)
                return loanRepo.Fetch().Where(filter);

            return loanRepo.Fetch();
        }

        public Loan FetchLoanById(int id)
        {
            if (id <= 0)
                return null;

            return loanRepo.GetById(id);
        }

        public bool CreateLoan(Loan newLoan)
        {
            if (newLoan == null)
                return false;

            return loanRepo.Add(newLoan);
        }

        public bool EditLoan(Loan editedLoan)
        {
            if (editedLoan == null)
                return false;

            return loanRepo.Update(editedLoan);
        }

        public bool DeleteLoanById(int idLoan)
        {
            if (idLoan <= 0)
                return false;

            Loan loanBeDeleted = this.loanRepo.GetById(idLoan);

            if (loanBeDeleted != null)
                return loanRepo.Delete(loanBeDeleted);

            return false;
        }

        #endregion

        #region Other Operations

        public bool LoanBook(int idBook, string user)
        {
            if (idBook <= 0 || string.IsNullOrEmpty(user))
                return false;

            var lentBook = bookRepo.GetById(idBook);

            if (lentBook == null)
                return false;

            // TODO check se il libro è disponibile

            return loanRepo.Add(new Loan()
            {
                Book = lentBook,
                LoanDate = DateTime.Now,
                User = user
            });
        }

        public bool ReturnBook(int idBook)
        {
            if (idBook <= 0)
                return false;

            Book loanBook = bookRepo.GetById(idBook);

            if (loanBook == null)
                return false;

            var loan = loanBook.Loans.SingleOrDefault(l => l.ReturnDate == null);

            if (loan == null)
                return false;

            loan.ReturnDate = DateTime.Now;

            return loanRepo.Update(loan);
        }

        #endregion
    }
}
