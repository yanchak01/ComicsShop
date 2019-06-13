using System;
using System.Collections.Generic;
using System.Text;

namespace Model.MainModel
{
    public interface IBaseUser
    {
        Guid Id { get; set; }
        string UserName { get; set; }
        string PassWord { get; set; }
    }
}
