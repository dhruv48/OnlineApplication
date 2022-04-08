using OnlineApplication.DB.ImplementDB;
using OnlineApplication.DB.InterfaceDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApplication.DB.IOC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>()
            {
                { typeof(IRegistrationDB),typeof(RegistrationDB)}
            
            };
            return dic;
        }
    }
}
