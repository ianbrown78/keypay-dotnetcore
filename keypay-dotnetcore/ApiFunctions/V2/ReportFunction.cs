using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KeyPay.DomainModels.V2.Report;
using KeyPay.Enums;
using Newtonsoft.Json;

namespace KeyPay.ApiFunctions.V2
{
    public class ReportFunction : BaseFunction
    {
        public ReportFunction(ApiRequestExecutor api) : base(api)
        {
        }

        public List<ActivityReportExportModel> PayRunActivity(int businessId, DateTime fromDate, DateTime toDate, int payScheduleId = 0, int locationId = 0)
        {
            return ApiRequest<List<ActivityReportExportModel>>(
                $"/business/{businessId}/report/payrunactivity?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&payScheduleId={payScheduleId}&locationId={locationId}");
        }

        public List<DetailedActivityReportExportModel> DetailedActivity(int businessId, DateTime fromDate, DateTime toDate, int payScheduleId = 0, int locationId = 0, int? employingEntityId = 0)
        {
            return ApiRequest<List<DetailedActivityReportExportModel>>(
                $"/business/{businessId}/report/detailedactivity?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&payScheduleId={payScheduleId}&locationId={locationId}&employingEntityId={employingEntityId}");
        }

        public List<SuperAccrualExportModel> SuperContributionsByEmployee(int businessId, DateTime fromDate, DateTime toDate, int payScheduleId = 0, int locationId = 0, int? employingEntityId = 0)
        {
            return ApiRequest<List<SuperAccrualExportModel>>(
                $"/business/{businessId}/report/supercontributions/byemployee?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&payScheduleId={payScheduleId}&locationId={locationId}&employingEntityId={employingEntityId}");
        }

        public List<SuperContributionsReportExportModel> SuperContributionsBySuperFund(int businessId, DateTime fromDate, DateTime toDate, int payScheduleId = 0, int locationId = 0, int? employingEntityId = 0)
        {
            return ApiRequest<List<SuperContributionsReportExportModel>>(
                $"/business/{businessId}/report/supercontributions/bysuperfund?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&payScheduleId={payScheduleId}&locationId={locationId}&employingEntityId={employingEntityId}");
        }

        public List<DeductionsReportExportModel> Deductions(int businessId, DateTime fromDate, DateTime toDate, int payScheduleId = 0, int locationId = 0, int employeeId = 0, int deductionCategoryId = 0, int? employingEntityId = 0)
        {
            return ApiRequest<List<DeductionsReportExportModel>>(
                $"/business/{businessId}/report/deductions?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&locationId={locationId}&employeeId={employeeId}&deductionCategoryId={deductionCategoryId}&payScheduleId={payScheduleId}&employingEntityId={employingEntityId}");
        }

        public List<PayCategoriesReportExportModel> PayCategories(int businessId, DateTime fromDate, DateTime toDate, int payScheduleId = 0, int locationId = 0, int employeeId = 0, int? employingEntityId = 0, bool groupByEarningsLocation = false)
        {
            return ApiRequest<List<PayCategoriesReportExportModel>>(
                $"/business/{businessId}/report/paycategories?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&locationId={locationId}&employeeId={employeeId}&payScheduleId={payScheduleId}&employingEntityId={employingEntityId}&groupByEarningsLocation={groupByEarningsLocation}");
        }

        public List<PaymentHistoryReportExportModel> PaymentHistory(int businessId, DateTime fromDate, DateTime toDate, int locationId = 0, int employeeId = 0, int? employingEntityId = 0)
        {
            return ApiRequest<List<PaymentHistoryReportExportModel>>(
                $"/business/{businessId}/report/paymenthistory?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&locationId={locationId}&employeeId={employeeId}&employingEntityId={employingEntityId}");
        }

        public List<LeaveBalancesReportExportModel> LeaveBalances(int businessId, int locationId = 0, int leaveTypeId = 0, bool useDefaultLocation = false, int? employingEntityId = 0)
        {
            var groupBy = useDefaultLocation ? LeaveReportDisplay.DefaultLocation : LeaveReportDisplay.AccrualLocation;
            return ApiRequest<List<LeaveBalancesReportExportModel>>(
                $"/business/{businessId}/report/leavebalances?locationId={locationId}&leaveTypeId={leaveTypeId}&groupBy={groupBy}&employingEntityId={employingEntityId}");
        }

        public List<BirthdayReportExportModel> Birthday(int businessId, DateTime fromDate, DateTime toDate, int locationId = 0)
        {
            return ApiRequest<List<BirthdayReportExportModel>>(
                $"/business/{businessId}/report/birthday?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&locationId={locationId}");
        }

        public List<RosterLiveLeaveAccruals> LeaveBalancesExport(int businessId, int[] payScheduleIds)
        {
            var payScheduleFilter = new StringBuilder();
            if (payScheduleIds != null && payScheduleIds.Any())
            {
                payScheduleFilter.Append("?");
                foreach (var payScheduleId in payScheduleIds)
                {
                    payScheduleFilter.AppendFormat("payScheduleIds={0}&", payScheduleId);
                }
            }
            var result = ApiJsonRequest($"/business/{businessId}/report/leavebalancesexport{payScheduleFilter}");
            return JsonConvert.DeserializeObject<List<RosterLiveLeaveAccruals>>(result);
        }

        public List<PayrollExemptReportExportModel> PayrollExempt(int businessId, DateTime fromDate, DateTime toDate, int payScheduleId = 0, int locationId = 0, int? employingEntityId = 0, string state = null)
        {
            return ApiRequest<List<PayrollExemptReportExportModel>>(
                $"/business/{businessId}/report/payrollexempt?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&locationId={locationId}&payscheduleid={payScheduleId}&employingEntityId={employingEntityId}&state={state}");
        }

        public List<MLCSuperReportExportModel> MLCSuperExport(int businessId, int[] payScheduleIds)
        {
            var payScheduleFilter = new StringBuilder();
            if (payScheduleIds != null && payScheduleIds.Any())
            {
                payScheduleFilter.Append("?");
                foreach (var payScheduleId in payScheduleIds)
                {
                    payScheduleFilter.AppendFormat("payScheduleIds={0}&", payScheduleId);
                }
            }
            return ApiRequest<List<MLCSuperReportExportModel>>(
                $"/business/{businessId}/report/mlcsuper{payScheduleFilter}");
        }

        public List<WorkersCompReportGridModel> WorkersComp(int businessId, DateTime fromDate, DateTime toDate, int locationId = 0)
        {
            var url =
                $"/business/{businessId}/report/workerscomp?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&locationId={locationId}";
            return ApiRequest<List<WorkersCompReportGridModel>>(url);
        }

        public List<LeaveHistoryReportGroupModel> LeaveHistory(int businessId, DateTime fromDate, DateTime toDate, int payScheduleId = 0, int locationId = 0)
        {
            var url =
                $"/business/{businessId}/report/leavehistory?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&payScheduleId={payScheduleId}&locationId={locationId}";
            return ApiRequest<List<LeaveHistoryReportGroupModel>>(url);
        }

        public List<EmployeeDetailsReportField> EmployeeDetailsFields(int businessId)
        {
            var url = $"/business/{businessId}/report/employeedetails/fields";
            return ApiRequest<List<EmployeeDetailsReportField>>(url);
        }

        public List<dynamic> EmployeeDetails(int businessId, List<string> selectedFields, int locationId = 0, int? employingEntityId = null, bool includeActive = true, bool includeInactive = true)
        {
            var combinedSelectedFields = "";
            if (selectedFields != null && selectedFields.Any())
            {
                var builder = new StringBuilder();
                foreach (var selectedField in selectedFields)
                {
                    builder.AppendFormat("selectedColumns={0}&", selectedField);
                }
                combinedSelectedFields = builder.ToString();
            }
            var url =
                $"/business/{businessId}/report/employeedetails?{combinedSelectedFields}locationId={locationId}&includeActive={includeActive}&includeInactive={includeInactive}";
            if (employingEntityId != null)
            {
                url = $"{url}&employingEntityId={employingEntityId}";
            }
            var data = ApiJsonRequest<List<dynamic>>(url);
            return data;
        }

        public List<PayrollTaxReportExportModel> PayrollTax(int businessId, DateTime fromDate, DateTime toDate, int locationId = 0, int? employingEntityId = null)
        {
            var url =
                $"/business/{businessId}/report/payrolltax?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&locationId={locationId}{(employingEntityId.HasValue ? "&employingEntityId=" + employingEntityId.Value : "")}";
            return ApiJsonRequest<List<PayrollTaxReportExportModel>>(url);
        }

        public List<PaygReportExportModel> PaygWithholding(int businessId, DateTime fromDate, DateTime toDate, int locationId = 0, int? employingEntityId = null, string state = null)
        {
            var url =
                $"/business/{businessId}/report/payg?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&locationId={locationId}&state={state}{(employingEntityId.HasValue ? "&employingEntityId=" + employingEntityId.Value : "")}";
            return ApiJsonRequest<List<PaygReportExportModel>>(url);
        }

        public List<LeaveLiabilityReportExportModel> LeaveLiability(int businessId, DateTime? asAtDate = null, int locationId = 0, int leaveTypeId = 0, bool includeApprovedLeave = true)
        {
            var url =
                $"/business/{businessId}/report/leaveliability?locationId={locationId}&asAtDate={asAtDate:yyyy-MM-dd}&leaveTypeId={leaveTypeId}&includeApprovedLeave={includeApprovedLeave}";
            return ApiRequest<List<LeaveLiabilityReportExportModel>>(url);
        }

        public List<GrossToNetReportExportModel> GrossToNet(int businessId, DateTime fromDate, DateTime toDate, int payScheduleId = 0, int locationId = 0, int[] payCategoryIds = null, int employeeId = 0, int? employingEntityId = null)
        {
            var employingEntityFilter = employingEntityId.HasValue ? "&employingEntityId=" + employingEntityId.Value : "";
            var payCategoryFilter = new StringBuilder();
            if (payCategoryIds != null)
            {
                foreach (var payCategoryId in payCategoryIds)
                {
                    payCategoryFilter.Append($"&payCategoryIds={payCategoryId}");
                }
            }
            var url =
                $"/business/{businessId}/report/grosstonet?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}&payScheduleId={payScheduleId}&locationId={locationId}&employeeId={employeeId}{employingEntityFilter}{payCategoryFilter}";
            return ApiJsonRequest<List<GrossToNetReportExportModel>>(url);
        }
    }
}