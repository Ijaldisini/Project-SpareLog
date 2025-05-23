using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SpareLog.Core.Interface
{
    public interface ILoginService
    {
        bool Login(string password);
    }
}
