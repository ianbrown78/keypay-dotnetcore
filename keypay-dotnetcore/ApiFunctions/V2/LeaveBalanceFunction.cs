using System;
using System.Collections.Generic;
using KeyPay.DomainModels.V2.Employee;

namespace KeyPay.ApiFunctions.V2
{
    public class LeaveBalanceFunction : BaseFunction
    {
        public LeaveBalanceFunction(ApiRequestExecutor api)
            : base(api)
        {
        }

        public List<LeaveBalanceModel> List(int businessId, int employeeId, DateTime? asAtDate = null)
        {
            var url = $"/business/{businessId}/employee/{employeeId}/leavebalances";
            if (asAtDate.HasValue)
            {
                var asatdate = asAtDate.Value.ToString("yyyy-MM-dd");
                url = string.Format(url + $"?asatdate={asAtDate}");
            }
            
            return
                ApiRequest<List<LeaveBalanceModel>>(url);
        }
    }
}