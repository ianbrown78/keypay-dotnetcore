﻿using System;
using System.Collections.Generic;

namespace KeyPay.DomainModels.V2.Report
{
    public class DeductionsReportExportModel
    {
        public string PayRun { get; set; }
        public DateTime DatePaid { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string ExternalId { get; set; }
        public string Location { get; set; }
        public List<DeductionsReportDeductionAmountModel> Amounts { get; set; }
    }
}