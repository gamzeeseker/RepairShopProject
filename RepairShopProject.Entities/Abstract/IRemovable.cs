using System;
using System.Collections.Generic;
using System.Text;

namespace RepairShopProject.Entities.Abstract
{
    public interface IRemovable
    {
        bool IsRemoved { get; set; }
    }
}
