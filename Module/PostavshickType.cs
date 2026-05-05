using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeExam.Module
{
    public class PostavshickType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<TypeSuppliers> Suppliers { get; set; }


    }
}
