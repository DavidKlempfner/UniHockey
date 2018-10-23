using DataAccess.Abstract;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BusinessService : IBusinessService
    {
        private IDataAccess _dataAccess;
        public BusinessService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public List<object> TestMethod()
        {
            return _dataAccess.Test();
        }
    }
}
