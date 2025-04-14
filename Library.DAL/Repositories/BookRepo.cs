using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class BookRepo
    {
        private MyLibraryContext _context;

        public List<Book> GetAllBooks()
        {
            _context = new();
            return _context.Books.ToList(); // Lấy tất cả sách từ cơ sở dữ liệu
        }

        public Book GetBookById(int bookId)
        {
            _context = new();
            return _context.Books.FirstOrDefault(b => b.BookId == bookId); // Lấy sách theo ID
        }

        public List<Book> GetAll()
        {
            _context = new();
            //return _context.AirConditioners.ToList(); // khong join
            return _context.Books.Include("Author").Include("Genre").ToList();//join
        }

        public void Create(Book obj)
        {
            _context = new();
            _context.Books.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Book obj)
        {
            _context = new();
            _context.Books.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(Book obj)
        {
            _context = new();
            _context.Books.Remove(obj);
            _context.SaveChanges();
        }

    }
}
