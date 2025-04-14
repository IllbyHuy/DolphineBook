using Library.DAL.Entities;
using Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public class AuthorService
    {
        private AuthorRepo _repo = new();
        public List<Author> GetAllAuth()
        {
            return _repo.GetAll();
        }

        public void CreateAu(Author au)
        {
            _repo.Create(au);
        }

        public void UpdateAu(Author au)
        {
            _repo.Update(au);
        }

        public void DeleteAu(Author au)
        {
            _repo.Delete(au);
        }
    }
}
