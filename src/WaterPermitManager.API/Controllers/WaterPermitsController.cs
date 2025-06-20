using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaterPermitManager.Application.DTOs;
using WaterPermitManager.Core.Models;
using WaterPermitManager.Infrastructure.Data;

namespace WaterPermitManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaterPermitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WaterPermitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterPermitDto>>> GetWaterPermits()
        {
            var permits = await _context.WaterPermits
                .Include(p => p.Parameters)
                .ToListAsync();

            var permitDtos = permits.Select(p => new WaterPermitDto
            {
                Id = p.Id,
                PermitNumber = p.PermitNumber,
                FacilityName = p.FacilityName,
                FacilityAddress = p.FacilityAddress,
                IssueDate = p.IssueDate,
                ExpirationDate = p.ExpirationDate,
                Status = p.Status,
                WaterSourceType = p.WaterSourceType,
                AllowedDailyDischarge = p.AllowedDailyDischarge,
                DischargeUnit = p.DischargeUnit,
                IssuingAuthority = p.IssuingAuthority,
                Parameters = p.Parameters.Select(param => new PermitParameterDto
                {
                    Id = param.Id,
                    Name = param.Name,
                    LimitValue = param.LimitValue,
                    Unit = param.Unit,
                    MonitoringFrequency = param.MonitoringFrequency,
                    SampleType = param.SampleType
                }).ToList()
            }).ToList();

            return Ok(permitDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WaterPermitDto>> GetWaterPermit(Guid id)
        {
            var permit = await _context.WaterPermits
                .Include(p => p.Parameters)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (permit == null)
            {
                return NotFound();
            }

            var permitDto = new WaterPermitDto
            {
                Id = permit.Id,
                PermitNumber = permit.PermitNumber,
                FacilityName = permit.FacilityName,
                FacilityAddress = permit.FacilityAddress,
                IssueDate = permit.IssueDate,
                ExpirationDate = permit.ExpirationDate,
                Status = permit.Status,
                WaterSourceType = permit.WaterSourceType,
                AllowedDailyDischarge = permit.AllowedDailyDischarge,
                DischargeUnit = permit.DischargeUnit,
                IssuingAuthority = permit.IssuingAuthority,
                Parameters = permit.Parameters.Select(param => new PermitParameterDto
                {
                    Id = param.Id,
                    Name = param.Name,
                    LimitValue = param.LimitValue,
                    Unit = param.Unit,
                    MonitoringFrequency = param.MonitoringFrequency,
                    SampleType = param.SampleType
                }).ToList()
            };

            return Ok(permitDto);
        }

        [HttpPost]
        public async Task<ActionResult<WaterPermitDto>> CreateWaterPermit(CreateWaterPermitDto createDto)
        {
            var permit = new WaterPermit
            {
                Id = Guid.NewGuid(),
                PermitNumber = createDto.PermitNumber,
                FacilityName = createDto.FacilityName,
                FacilityAddress = createDto.FacilityAddress,
                IssueDate = createDto.IssueDate,
                ExpirationDate = createDto.ExpirationDate,
                Status = PermitStatus.Draft,
                WaterSourceType = createDto.WaterSourceType,
                AllowedDailyDischarge = createDto.AllowedDailyDischarge,
                DischargeUnit = createDto.DischargeUnit,
                IssuingAuthority = createDto.IssuingAuthority,
                LastModified = DateTime.UtcNow,
                LastModifiedBy = User.Identity?.Name ?? "System",
                Parameters = createDto.Parameters.Select(p => new PermitParameter
                {
                    Id = Guid.NewGuid(),
                    Name = p.Name,
                    LimitValue = p.LimitValue,
                    Unit = p.Unit,
                    MonitoringFrequency = p.MonitoringFrequency,
                    SampleType = p.SampleType
                }).ToList()
            };

            _context.WaterPermits.Add(permit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWaterPermit), new { id = permit.Id }, 
                new WaterPermitDto
                {
                    Id = permit.Id,
                    PermitNumber = permit.PermitNumber,
                    FacilityName = permit.FacilityName,
                    FacilityAddress = permit.FacilityAddress,
                    IssueDate = permit.IssueDate,
                    ExpirationDate = permit.ExpirationDate,
                    Status = permit.Status,
                    WaterSourceType = permit.WaterSourceType,
                    AllowedDailyDischarge = permit.AllowedDailyDischarge,
                    DischargeUnit = permit.DischargeUnit,
                    IssuingAuthority = permit.IssuingAuthority,
                    Parameters = permit.Parameters.Select(p => new PermitParameterDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        LimitValue = p.LimitValue,
                        Unit = p.Unit,
                        MonitoringFrequency = p.MonitoringFrequency,
                        SampleType = p.SampleType
                    }).ToList()
                });
        }
    }
} 