using Library.DAL.Entities;
using Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public class BookService
    {
        public BookRepo _repo = new();

        public List<Book> GetAllBook_2()
        {
            return _repo.GetAll();
        }

        public void CreateBook(Book book)
        {
            _repo.Create(book);
        }

        public void UpdateBook(Book book)
        {
            _repo.Update(book);
        }

        public void DeleteBook(Book book)
        {
            _repo.Delete(book);
        }
    }
}
