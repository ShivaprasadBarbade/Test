using CorporateClassifieds.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.ViewModels
{
    public class ClassifiedFieldView
    {
        public Guid Id { get; set; }
        public Guid AttributeId { get; set; }
        public ClassifiedFieldValue Value { get; set; }
        public bool IsRequired { get; set; }
    }
}
