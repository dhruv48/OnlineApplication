using OnlineApplication.Common.Entities;
using OnlineApplication.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApplication.DB.InterfaceDB
{
    public interface IRegistrationDB:IBaseDB<RegistrationModel>
    {
        List<RegistrationModel> GetByCategory(int id);
        List<RegistrationModel> GetByCapacity(int id);
        List<RegistrationModel> GetByTechnicalParameters(int id);
        List<EnumModel> TechnicalParameters();
    }
}
