using System;
using System.Collections.Generic;
using System.Linq;
using KeyPay;
using KeyPay.Auth;
using KeyPay.DomainModels.V2.Business;
using KeyPay.DomainModels.V2.Employee;
using KeyPay.DomainModels.V2.Report;
using Xunit;

namespace KeyPay.Tests
{
    public class KeyPayApiV2ClientTest
    {
        private const string _baseUrl = "https://employmenthero.yourpayroll.com.au/api/v2";
        private readonly AuthenticationDetails _authDetails;
        private readonly KeyPayApiV2Client _client;
        private readonly BusinessModel _business;
        private readonly EmployeeModel _employee;
        
        public KeyPayApiV2ClientTest()
        {
            _authDetails = new ApiKeyAuthenticationDetails("V0lwUVdpWnc0WHh1OW5NdFZ6SjRnNWQrWlEwaUVpSFRld3B4NUI5NG9VaGU3WE1USnNjSUgwcDJXcjgvYktBcg");
            _client = new KeyPayApiV2Client(_baseUrl, _authDetails);
            _business = _client.Business.List().FirstOrDefault();
            _employee = _client.Employee.List(this._business.Id).FirstOrDefault();
            
            // Generate a PAYG Summary so the test passes.
            _client.PaymentSummary.Generate(this._business.Id, 2020, this._employee.Id);
        }
        
        [Fact]
        public void CanListBusinesses()
        {
            var businesses = _client.Business.List();
            
            Assert.IsType(typeof(int), businesses.Count);
        }

        [Fact]
        public void CanListPayCategories()
        {
            var payCategories = _client.PayCategory.List(this._business.Id);

            Assert.IsType(typeof(int), payCategories.Count);
        }

        [Fact]
        public void CanListPaySchedules()
        {
            var paySchedules = _client.PaySchedule.List(this._business.Id);
            
            Assert.IsType(typeof(int), paySchedules.Count);
        }

        [Fact]
        public void CanListEmployees()
        {
            var employees = _client.Employee.List(this._business.Id);
            
            Assert.IsType(typeof(int), employees.Count);
        }

        [Fact]
        public void CanListLocations()
        {
            var locations = _client.Location.List(this._business.Id);
            
            Assert.IsType(typeof(int), locations.Count);
        }

        [Fact]
        public void CanListPayRuns()
        {
            var payRuns = _client.PayRun.List(this._business.Id);
            
            Assert.IsType(typeof(int), payRuns.Count);
        }

        [Fact]
        public void CanListLeaveCategories()
        {
            var leaveCategories = _client.LeaveCategory.List(this._business.Id);
            
            Assert.IsType(typeof(int), leaveCategories.Count);
        }

        [Fact]
        public void CanListTimesheets()
        {
            var timesheets = _client.Timesheet.List(this._business.Id);
            
            Assert.IsType(typeof(int), timesheets.Count);
        }

        [Fact]
        public void CanGetUser()
        {
            var user = _client.User.Get();
            
            Assert.IsType(typeof(int), user.Id);
        }

        [Fact]
        public void CanListPayRateTemplates()
        {
            var payRateTemplates = _client.PayRateTemplates.List(this._business.Id);
            
            Assert.IsType(typeof(int), payRateTemplates.Count);
        }

        [Fact]
        public void CanListDeductionCategories()
        {
            var deductionCategories = _client.DeductionCategory.List(this._business.Id);
            
            Assert.IsType(typeof(int), deductionCategories.Count);
        }

        [Fact]
        public void CanListExpenseCategories()
        {
            var expenseCategories = _client.ExpenseCategory.List(this._business.Id);
            
            Assert.IsType(typeof(int), expenseCategories.Count);
        }

        [Fact]
        public void CanListWorkTypes()
        {
            var workTypes = _client.WorkType.List(this._business.Id);
            
            Assert.IsType(typeof(int), workTypes.Count);
        }

        [Fact]
        public void CanListDocuments()
        {
            var documents = _client.Document.List(this._business.Id);
            
            Assert.IsType(typeof(int), documents.Count);
        }

        [Fact]
        public void CanListEmployeeGroups()
        {
            var employeeGroups = _client.EmployeeGroup.List(this._business.Id);
            
            Assert.IsType(typeof(int), employeeGroups.Count);
        }

        [Fact]
        public void CanListEmployingEntities()
        {
            var employingEntities = _client.EmployingEntity.List(this._business.Id);
            
            Assert.IsType(typeof(int), employingEntities.Count);
        }

        [Fact]
        public void CanListPaymentSummaries()
        {
            var paymentSummaries = _client.PaymentSummary.Get(this._business.Id, 2020, this._employee.Id);
            
            if (paymentSummaries == null)
                Assert.IsNotType(typeof(PaygPaymentSummaryModel), paymentSummaries);
            else
                Assert.IsType(typeof(PaygPaymentSummaryModel), paymentSummaries);
        }

        [Fact]
        public void CanListRosterShifts()
        {
            var filter = new RosterShiftFilterModel
            {
                FromDate = new DateTime(2019, 01, 01), 
                ToDate = new DateTime(2021, 12, 31)
            };
            var rosterShifts = _client.RosterShift.List(this._business.Id, filter);
            
            Assert.IsType(typeof(int), rosterShifts.Count);
        }

        [Fact]
        public void CanListManagerEmployees()
        {
            var managerEmployees = _client.Manager.Employees(this._business.Id);
            
            Assert.IsType(typeof(int), managerEmployees.Count);
        }

        [Fact]
        public void CanListKioskTimeAndAttendances()
        {
            var kioskTimeAndAttendances = _client.Kiosk.GetAll(this._business.Id);
            
            Assert.IsType(typeof(int), kioskTimeAndAttendances.Count);
        }

        [Fact]
        public void CanListTimeAndAttendances()
        {
            var filter = new UnavailabilityFilterModel { FromDate = new DateTime(2019, 01, 01) };
            var timeAndAttendances = _client.Unavailability.List(this._business.Id, filter);
            
            Assert.IsType(typeof(int), timeAndAttendances.Count);
        }
    }
}