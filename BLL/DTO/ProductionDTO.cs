using System;
using DAL.Entities;

namespace BLL.DTO
{
    public class ProductionDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}