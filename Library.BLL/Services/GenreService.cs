using Library.DAL.Entities;
using Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public class GenreService
    {
        private GenreRepo _repo = new();

        public List<Genre> GetAllGen()
        {
            return _repo.GetAllGenres();
        }
    }
}
