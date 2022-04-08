using OnlineApplication.Business.ImplementBusiness;
using OnlineApplication.Business.InterfaceBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApplication.Business.IOC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dic = new Dictionary<Type, Type>
            {
                   { typeof(IRegistrationBusiness),typeof(RegistrationBusiness)},

            };
            return dic;

        }
    }
}
