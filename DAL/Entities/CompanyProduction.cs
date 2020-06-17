using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class CompanyProduction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public Production Production { get; set; }
        public Guid ProductionId { get; set; }
        public int Manufactured { get; set; }
        public int Sold { get; set; }
    }
}