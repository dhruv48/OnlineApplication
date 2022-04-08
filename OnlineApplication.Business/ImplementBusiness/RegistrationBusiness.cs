using OnlineApplication.Business.InterfaceBusiness;
using OnlineApplication.Common.Entities;
using OnlineApplication.Common.Model;
using OnlineApplication.DB.InterfaceDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApplication.Business.ImplementBusiness
{
    public class RegistrationBusiness : IRegistrationBusiness
    {
        private readonly IRegistrationDB _registrationDB;
        public RegistrationBusiness(IRegistrationDB registrationDB)
        {
            _registrationDB = registrationDB;
        }
        public long Add(RegistrationModel registrationModel)
        {
            
            return (_registrationDB.Add(registrationModel));
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public List<RegistrationModel> GetAll()
        {
           return _registrationDB.GetAll();
        }

        public RegistrationModel GetBy(long Id)
        {
            throw new NotImplementedException();
        }

        public List<RegistrationModel> GetByCapacity(int id)
        {
            return _registrationDB.GetByCapacity(id);
        }

        public List<RegistrationModel> GetByCategory(int id)
        {
            return _registrationDB.GetByCategory(id);
        }

        public List<RegistrationModel> GetByTechnicalParameters(int id)
        {
            return _registrationDB.GetByTechnicalParameters(id);
        }

        public List<EnumModel> TechnicalParameters()
        {
            return _registrationDB.TechnicalParameters();
        }

        public long Update(RegistrationModel Obj)
        {
            throw new NotImplementedException();
        }
    }
}
