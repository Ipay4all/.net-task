using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VPM.Domain.Interface
{
    public interface IDropdowns
    {
        Task<string> ListCountry(Dictionary<string, object> parameters);
        Task<string> ListBrand(Dictionary<string, object> parameters);
        Task<string> ListCurrency(Dictionary<string, object> parameters);
    }
}
