using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Services
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }

    public interface IBooksRepository
    {
        void AddBook(Book book);
        List<Book> GetBooks();
    }


    public class BooksRepository : IBooksRepository
    {
        public List<Book> GetBooks()
        {
            using (var db = new BooksContext())
            {
                var books = (from entity in db.Books
                             select entity).ToList();
                return books;
            }
        }

        public void AddBook(Book book)
        {
            using (var db = new BooksContext())
            {



                db.Books.Add(book);
                db.SaveChanges();

            }
        }
    }
}