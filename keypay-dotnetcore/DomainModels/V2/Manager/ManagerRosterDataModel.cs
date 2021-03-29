using System.Collections.Generic;

namespace KeyPay.DomainModels.V2.Manager
{
    public class ManagerRosterDataModel
    {
        public IList<ManagerRosterShiftModel> RosteredShifts { get; set; }
        public IList<ManagerRosterShiftModel> UnassignedShifts { get; set; }
        public IList<ManagerUnavailabilityModel> Unavailability { get; set; }
        public IList<ManagerLeaveRequestModel> LeaveRequests { get; set; }
    }
}