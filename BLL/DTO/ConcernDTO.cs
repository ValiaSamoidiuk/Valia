using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using DAL.Entities;

namespace BLL.DTO
{
    public class ConcernDTO
    {
        public Guid Id { get; set; }
        public ICollection<CompanyDTO> Companies { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}