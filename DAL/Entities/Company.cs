using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public ICollection<CompanyProduction> CompanyProductions { get; set; }
        public string Name { get; set; }
        public uint Employees { get; set; }
        public int Capitalization { get; set; }
    }
}
