using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimeExam.Module
{
    class MaterialType
    {
        [Key]
        public int Id { get ; set; }
        public string TypeMaterial { get; set; }
        public decimal procentRawMaterialsLoss { get; set; }

        public List<Materials> Materials { get; set; }
    }
}
