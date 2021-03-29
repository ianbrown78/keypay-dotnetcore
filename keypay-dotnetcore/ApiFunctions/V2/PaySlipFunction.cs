using System.Collections.Generic;
using KeyPay.DomainModels.V2.PaySlip;

namespace KeyPay.ApiFunctions.V2
{
    public class PaySlipFunction : BaseFunction
    {
        public PaySlipFunction(ApiRequestExecutor api) : base(api)
        {
        }

        public Dictionary<string, PaySlipModel> List(int businessId, int payRunId, bool showAllData = false)
        {
            return ApiRequest<Dictionary<string, PaySlipModel>>(
                $"business/{businessId}/payrun/{payRunId}/payslips?showAllData={showAllData}");
        }

        public byte[] Download(int businessId, int payRunId, int employeeId)
        {
            return ApiByteArrayRequest($"/business/{businessId}/payrun/{payRunId}/file/payslip/{employeeId}");
        }
    }
}