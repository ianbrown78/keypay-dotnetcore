using System.Collections.Generic;
using System.Linq;
using KeyPay.DomainModels.V2.Report;
using RestSharp;

namespace KeyPay.ApiFunctions.V2
{
    public class PaymentSummaryFunction : BaseFunction
    {
        public PaymentSummaryFunction(ApiRequestExecutor api)
            : base(api)
        {
        }

        public List<PaygPaymentSummaryModel> Get(int businessId, int financialYearEnding, int? employeeId = null, int? employingEntityId = 0, int? locationId = null)
        {
            var url = $"/business/{businessId}/paymentsummary/{financialYearEnding}?$filter=";
            var hasFilter = false;
            if (employeeId.HasValue)
            {
                hasFilter = true;
                url += $"EmployeeId eq {employeeId.Value}";
            }
            if (employingEntityId != 0)
            {
                url +=
                    $"{(hasFilter ? " and " : "")} EmployingEntityId eq {(employingEntityId == null ? "null" : employingEntityId.ToString())}";
                hasFilter = true;
            }
            if (locationId.HasValue)
            {
                url += $"{(hasFilter ? " and " : "")} LocationId eq {locationId.Value}";
            }
            return ApiRequest<List<PaygPaymentSummaryModel>>(url);
        }

        public PaygPaymentSummaryModel Get(int businessId, int financialYearEnding, int employeeId)
        {
            return ApiRequest<List<PaygPaymentSummaryModel>>(
                $"/business/{businessId}/paymentsummary/{financialYearEnding}?$filter=EmployeeId eq {employeeId}").FirstOrDefault();
        }

        public void Generate(int businessId, int financialYearEnding, int? employeeId = null, int? employingEntityId = null, int? locationId = null)
        {
            ApiRequest(FormatUrl(businessId, financialYearEnding, employeeId, employingEntityId, locationId), Method.PUT);
        }

        private string FormatUrl(int businessId, int financialYearEnding, int? employeeId = null, int? employingEntityId = null, int? locationId = null)
        {
            var url = $"/business/{businessId}/paymentsummary/{financialYearEnding}?x=1";
            if (employeeId.HasValue)
            {
                url += $"&employeeId={employeeId.Value}";
            }
            if (employingEntityId.HasValue)
            {
                url += $"&employingEntityId={employingEntityId.Value}";
            }
            if (locationId.HasValue)
            {
                url += $"&locationId={locationId.Value}";
            }
            return url;
        }

        public void Publish(int businessId, int financialYearEnding, int? employeeId = null, int? employingEntityId = null, int? locationId = null)
        {
            ApiRequest(FormatUrl(businessId, financialYearEnding, employeeId, employingEntityId, locationId), Method.POST);
        }
        public void Unpublish(int businessId, int financialYearEnding, int? employeeId = null, int? employingEntityId = null, int? locationId = null)
        {
            ApiRequest(FormatUrl(businessId, financialYearEnding, employeeId, employingEntityId, locationId), Method.DELETE);
        }
    }
}