using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeExam.Module
{
    class Materials
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public MaterialSuppliers materialsSuppliers { get; set; }
        public MaterialType materialType { get; set; }

        public decimal priceoneMaterial { get; set; }

        public decimal count { get; set; }
        public decimal minCount { get; set; }

        public int countInBox { get; set; }
        public string unitofmeasurement { get; set; }

    }
}
