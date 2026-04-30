using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimeExam.Module
{
     class TypeSuppliers
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TypeName { get; set; }

        public string INN { get; set; }

        public string Rate { get; set; }

        public DateTime startWork { get; set; }
    }
}
