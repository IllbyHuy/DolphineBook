using Library.DAL.Entities;
using Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public class MemberService
    {
        private MemberRepository _repo = new();

        //username vaf pass nhận từ màn hình login
        public User Authenticate(string useremail, string password)
        {
            return _repo.GetOne(useremail, password);
        }
    }
}
