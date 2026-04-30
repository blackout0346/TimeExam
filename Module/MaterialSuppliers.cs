using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeExam.Module
{
    class MaterialSuppliers
    {
        [Key]

        public int Id { get; set; }

        public List<MaterialSuppliers> materialSuppliers { get; set; }

        public List<Materials> materials { get; set; }
    }
}
