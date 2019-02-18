using _365Plus.Core.Data;
using _365Plus.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Plus.Service.User
{
    public class UserService
    {
        private readonly IRepository<Data.Models.User> _userRepository;
        public UserService(IRepository<Data.Models.User> userRepository)
        {
            this._userRepository = userRepository;
        }

        public Data.Models.User GetById(int Id)
        {
            return this._userRepository.GetById(Id);
        }

        public List<Data.Models.User> GetAll()
        {
            int[] roleIds = { };
            return this._userRepository.Table.ToList();
        }
    }
}
