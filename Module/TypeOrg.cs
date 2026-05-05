using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeExam.Module
{
    internal class TypeOrg
    {
        [Key]
        public int Id {  get; set; }

        public string Name { get; set; }


        public List<TypeSuppliers> TypeSuppliers { get; set; }
    }
}
