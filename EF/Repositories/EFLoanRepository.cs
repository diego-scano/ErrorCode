using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF.Repositories
{
    public class EFLoanRepository : ILoanRepository
    {
        private readonly LibraryContext ctx;

        public EFLoanRepository() : this(new LibraryContext()) { }

        public EFLoanRepository(LibraryContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Loan newLoan)
        {
            if (newLoan == null)
                return false;

            try
            {
                ctx.Loans.Add(newLoan);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Loan item)
        {
            if (item == null)
                return false;

            try
            {
                var book = ctx.Loans.Find(item.Id);

                if (book != null)
                    ctx.Loans.Remove(book);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Loan> Fetch(Func<Loan, bool> filter = null)
        {
            try
            {
                if (filter != null)
                    return ctx.Loans.Where(filter).ToList();

                return ctx.Loans.ToList();
            }
            catch (Exception)
            {
                return new List<Loan>();
            }
        }

        public Loan GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Loans.Find(id);
        }

        public bool Update(Loan updatedLoan)
        {
            if (updatedLoan == null)
                return false;

            try
            {
                ctx.Loans.Update(updatedLoan);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
