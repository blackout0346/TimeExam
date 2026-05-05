using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeExam.Module
{
    class MaterialSuppliers
    {
        [Key]

        public int Id { get; set; }
        [ForeignKey("PostavshickType")]
        public int PostavshickTypeId { get; set; }
        public PostavshickType PostavshickType { get; set; }

        [ForeignKey("materials")]
        public int? MaterialId { get; set; }
        public Materials materials { get; set; }
    }
}
