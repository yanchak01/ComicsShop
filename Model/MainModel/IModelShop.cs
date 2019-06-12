using System;
using System.Collections.Generic;
using System.Text;

namespace Model.MainModel
{
    public interface IModelShop
    {
        Guid Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
    }
}
