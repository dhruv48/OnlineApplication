using OnlineApplication.Common.Entities;
using OnlineApplication.Common.Model;
using OnlineApplication.DB.InterfaceDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApplication.Business.InterfaceBusiness
{
    public interface IRegistrationBusiness:IBaseBusiness<RegistrationModel>
    {
        List<RegistrationModel> GetByCategory(int id);
        List<RegistrationModel> GetByCapacity(int id);
        List<RegistrationModel> GetByTechnicalParameters(int id);
        List<EnumModel> TechnicalParameters();
    }

    
}
