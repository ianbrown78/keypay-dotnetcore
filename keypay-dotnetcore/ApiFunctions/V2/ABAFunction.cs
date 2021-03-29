using System.Collections.Generic;
using KeyPay.DomainModels.V2.Business;
using RestSharp;

namespace KeyPay.ApiFunctions.V2
{
    public class ABAFunction : BaseFunction
    {
        public ABAFunction(ApiRequestExecutor api) : base(api)
        {
        }

        public List<ABAModel> Get(int businessId)
        {
            return ApiRequest<List<ABAModel>>($"/business/{businessId}/ABA");
        }

        public void Update(int businessId, ABAModel model)
        {
            ApiRequest($"/business/{businessId}/ABA", model, Method.POST);
        }
    }
}