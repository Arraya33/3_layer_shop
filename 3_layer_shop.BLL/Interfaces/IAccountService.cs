using _3_layer_shop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3_layer_shop.BLL.Interfaces
{
    public interface IAccountService
    {
        public Task RegisterUser(RegisterDTO register);
        public Task Login(LoginDTO login);
        public Task Logout();
    }
}
