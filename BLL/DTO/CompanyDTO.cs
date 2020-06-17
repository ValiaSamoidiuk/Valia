using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities;

namespace BLL.DTO
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }
        public ICollection<ProductionDTO> CompanyProduction { get; set; }
        public string Name { get; set; }
        public uint Employees { get; set; }
        public int Capitalization { get; set; }
    }
}