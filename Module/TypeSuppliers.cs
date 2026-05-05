using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimeExam.Module
{
     class TypeSuppliers
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("typeOrg")]
        public int TypeOrgId { get; set; }
        public string Name { get; set; }

       

        public TypeOrg typeOrg { get; set; }
        public string INN { get; set; }

        public string Rate { get; set; }

        public DateTime startWork { get; set; }

        public int PostavshickTypeId { get; set; }
        public PostavshickType postavshickType { get; set; }


    }
}
