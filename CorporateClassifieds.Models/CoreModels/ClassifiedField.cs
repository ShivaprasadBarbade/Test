using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.CoreModels
{
    public class ClassifiedField
    {
        public Guid Id { get; set; }
        public Guid ClassifiedId { get; set; } 
        public Guid AttributeId { get; set;}
        public ClassifiedFieldValue Value { get; set; }
        public bool IsRequired { get; set; }
    }
}
