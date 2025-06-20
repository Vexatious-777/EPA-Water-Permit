using System;
using System.Collections.Generic;

namespace WaterPermitManager.Core.Models
{
    public class WaterPermit
    {
        public Guid Id { get; set; }
        public string PermitNumber { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAddress { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public PermitStatus Status { get; set; }
        public string WaterSourceType { get; set; }
        public decimal AllowedDailyDischarge { get; set; }
        public string DischargeUnit { get; set; }
        public List<PermitParameter> Parameters { get; set; } = new List<PermitParameter>();
        public string IssuingAuthority { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }

    public enum PermitStatus
    {
        Draft,
        Pending,
        Active,
        Expired,
        Revoked
    }

    public class PermitParameter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal LimitValue { get; set; }
        public string Unit { get; set; }
        public string MonitoringFrequency { get; set; }
        public string SampleType { get; set; }
    }
} 