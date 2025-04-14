using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class AuthorRepo
    {
        private MyLibraryContext _context;
        public string GetAuthorNameById(int? authorId)
        {
            // Truy vấn để lấy tên tác giả
            _context = new();
            var author = _context.Authors
                .FirstOrDefault(a => a.AuthorId == authorId); // Giả sử bạn có bảng Authors

            return author != null ? author.AuthorName : "Unknown Author"; // Trả về tên tác giả hoặc giá trị mặc định
        }

        public List<Author> GetAll()
        {
            _context = new();
            return _context.Authors.ToList(); //khong join
        }

        public void Create(Author obj)
        {
            _context = new();
            _context.Authors.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Author obj)
        {
            _context = new();
            _context.Authors.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(Author obj)
        {
            _context = new();
            _context.Authors.Remove(obj);
            _context.SaveChanges();
        }
    }
}
