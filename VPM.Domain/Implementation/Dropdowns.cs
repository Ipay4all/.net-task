using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VPM.Common;
using VPM.Domain.Interface;
using VPM.Infrastructure.SpRepository;
using VPM.Infrastructure.UnitOfWork;
using VPM.Models.DbEntity;

namespace VPM.Domain.Implementation
{
    public class Dropdowns : IDropdowns
    {
        public IUnitOfWork uow;
        private readonly SpContext _dataContext;
        public Dropdowns(IUnitOfWork unitOfWork, SpContext dataContext)
        {
            uow = unitOfWork;
            _dataContext = dataContext;
        }
        public async Task<string> ListBrand(Dictionary<string, object> parameters)
        {
            var xmlParam = CommonHelper.DictionaryToXml(parameters, "Search");
            string sqlQuery = "Exec sp_ddl_brands {0}";
            object[] param = { xmlParam };
            var result = await _dataContext.ExecuteStoreProcedure(sqlQuery, param);
            return result;
        }

        public async Task<string> ListCountry(Dictionary<string, object> parameters)
        {

            var xmlParam = CommonHelper.DictionaryToXml(parameters, "Search");
            string sqlQuery = "Exec sp_ddl_countries {0}";
            object[] param = { xmlParam };
            var result = await _dataContext.ExecuteStoreProcedure(sqlQuery, param);
            return result;

        }
        public async Task<string> ListCurrency(Dictionary<string, object> parameters)
        {

            var xmlParam = CommonHelper.DictionaryToXml(parameters, "Search");
            string sqlQuery = "Exec sp_ddl_currencies {0}";
            object[] param = { xmlParam };
            var result = await _dataContext.ExecuteStoreProcedure(sqlQuery, param);
            return result;

        }
    }
}
