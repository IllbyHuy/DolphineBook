using Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories { 
    public class MemberRepository
    {
        private MyLibraryContext _context;

        public User? GetOne(string useremail, string password)
        {
            _context = new();
            //return _context.StaffMember.ToList() trả về hết
            return _context.Users.FirstOrDefault(x => x.UserEmail == useremail && x.Password == password);
        }
        public string GetName(int userId)
        {
            _context = new();
            var user = _context.Users.FirstOrDefault(x => x.UserId == userId);
            return user?.UserName ?? "Tên không tìm thấy"; // Trả về tên hoặc thông báo nếu không tìm thấy
        }

        public int? GetId(int userId)
        {
            _context = new();
            var user = _context.Users.FirstOrDefault(x => x.UserId == userId);
            return user?.UserId; // Trả về tên hoặc thông báo nếu không tìm thấy
        }


        public User GetOneById(int userId)
        {
            _context = new();
            return _context.Users.FirstOrDefault(x => x.UserId == userId);
        }

    }
}
