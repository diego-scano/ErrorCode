using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF.Repositories
{
    public class EFBookRepository : IBookRepository
    {
        private readonly LibraryContext ctx;

        public EFBookRepository() : this(new LibraryContext()) { }

        public EFBookRepository(LibraryContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Book newBook)
        {
            if (newBook == null)
                return false;

            try
            {
                ctx.Books.Add(newBook);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Book item)
        {
            if (item == null)
                return false;

            try
            {
                var book = ctx.Books.Find(item.Id);

                if (book != null)
                    ctx.Books.Remove(book);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Book> Fetch(Func<Book, bool> filter = null)
        {
            try
            {
                if (filter != null)
                    return ctx.Books.Where(filter).ToList();

                return ctx.Books.ToList();
            }
            catch (Exception)
            {
                return new List<Book>();
            }
        }

        public Book GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Books.Find(id);
        }

        public Book GetByISBN(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                return null;

            try
            {
                var book = ctx.Books.Find(isbn);

                return book;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Book updatedBook)
        {
            if (updatedBook == null)
                return false;

            try
            {
                ctx.Books.Update(updatedBook);
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
