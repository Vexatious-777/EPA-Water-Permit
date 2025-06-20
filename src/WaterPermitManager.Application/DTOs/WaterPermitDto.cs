using System;
using System.Collections.Generic;
using WaterPermitManager.Core.Models;

namespace WaterPermitManager.Application.DTOs
{
    public class WaterPermitDto
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
        public List<PermitParameterDto> Parameters { get; set; }
        public string IssuingAuthority { get; set; }
    }

    public class PermitParameterDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal LimitValue { get; set; }
        public string Unit { get; set; }
        public string MonitoringFrequency { get; set; }
        public string SampleType { get; set; }
    }

    public class CreateWaterPermitDto
    {
        public string PermitNumber { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAddress { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string WaterSourceType { get; set; }
        public decimal AllowedDailyDischarge { get; set; }
        public string DischargeUnit { get; set; }
        public List<CreatePermitParameterDto> Parameters { get; set; }
        public string IssuingAuthority { get; set; }
    }

    public class CreatePermitParameterDto
    {
        public string Name { get; set; }
        public decimal LimitValue { get; set; }
        public string Unit { get; set; }
        public string MonitoringFrequency { get; set; }
        public string SampleType { get; set; }
    }
} 