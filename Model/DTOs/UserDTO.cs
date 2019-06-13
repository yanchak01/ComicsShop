using Model.MainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    class UserDTO : IBaseUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
