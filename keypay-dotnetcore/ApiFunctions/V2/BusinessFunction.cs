using System.Collections.Generic;
using KeyPay.DomainModels.V2;
using KeyPay.DomainModels.V2.Business;
using RestSharp;

namespace KeyPay.ApiFunctions.V2
{
    public class BusinessFunction : BaseFunction
    {
        public BusinessFunction(ApiRequestExecutor api) : base(api)
        {
            ABA = new ABAFunction(api);
            JournalAccounts = new JournalAccountsFunction(api);
            JournalServices = new JournalServicesFunction(api);
            ChartOfAccounts = new ChartOfAccountsFunction(api);
            Access = new BusinessAccessFunction(api);
            ActionItems = new BusinessActionItems(api);
        }

        public ABAFunction ABA { get; set; }
        public JournalAccountsFunction JournalAccounts { get; set; }
        public JournalServicesFunction JournalServices { get; set; }
        public ChartOfAccountsFunction ChartOfAccounts { get; set; }
        public BusinessAccessFunction Access { get; set; }
        public BusinessActionItems ActionItems { get; set; }

        public BusinessModel Create(BusinessModel model)
        {
            return ApiRequest<BusinessModel, BusinessModel>("/business", model, Method.POST);
        }

        public BusinessModel Get(int id)
        {
            return ApiRequest<BusinessModel>($"/business/{id}");
        }

        public void Delete(int id)
        {
            ApiRequest($"/business/{id}", Method.DELETE);
        }

        public List<BusinessModel> List()
        {
            return ApiRequest<List<BusinessModel>>(string.Format("/business"));
        }

        public SingleSignOnModel SingleSignOn(int id)
        {
            return ApiRequest<SingleSignOnModel>($"/business/{id}/singlesignon", Method.POST);
        }

        public EntitlementsModel Entitlements(int id)
        {
            return ApiRequest<EntitlementsModel>($"/business/{id}/entitlements");
        }
    }
}