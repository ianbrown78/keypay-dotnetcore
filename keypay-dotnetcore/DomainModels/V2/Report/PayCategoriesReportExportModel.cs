﻿using System;

namespace KeyPay.DomainModels.V2.Report
{
    public class PayCategoriesReportExportModel
    {
        public string PayCategory { get; set; }
        public string PayRun { get; set; }
        public DateTime DatePaid { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string ExternalId { get; set; }
        public string Location { get; set; }
        public decimal Units { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal SuperAmount { get; set; }
    }
}