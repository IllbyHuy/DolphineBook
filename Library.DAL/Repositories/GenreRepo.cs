using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class GenreRepo
    {
        private MyLibraryContext _context;

        public GenreRepo()
        {
            _context = new MyLibraryContext(); // Khởi tạo DbContext
        }

        // Phương thức để lấy tên thể loại dựa trên genre_id
        public string GetGenreNameById(int? genreId)
        {
            // Truy vấn để lấy tên thể loại
            var genre = _context.Genres
                .FirstOrDefault(g => g.GenreId == genreId); // Giả sử bạn có bảng Genres

            return genre != null ? genre.GenreName : "Unknown Genre"; // Trả về tên thể loại hoặc giá trị mặc định
        }

        // Nếu bạn muốn lấy tất cả thể loại
        public List<Genre> GetAllGenres()
        {
            return _context.Genres.ToList(); // Lấy tất cả thể loại
        }


    }
}
