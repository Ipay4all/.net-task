using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VPM.Models.CustomModels;
using VPM.Models.Request;
using VPM.Models.Response;

namespace VPM.Domain.Interface
{
    public interface IProduct
    {
        Task<ProductDetailResponse> Post(CreateProductRequest model, List<string> files);
        Task DeleteProduct(int id);
        Task<Page> List(Dictionary<string, object> parameters);
        Task<string> GetProduct(int productId);
        Task<bool> ValidateProductId(int productId);
        Task<ProductDetailResponse> Update(CreateProductRequest model, List<string> files, int ProductId);
    }
}
