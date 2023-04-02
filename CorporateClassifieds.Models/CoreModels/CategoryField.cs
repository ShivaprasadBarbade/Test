using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.CoreModels
{
    public class CategoryField
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public short Type { get; set; }
        public bool IsRequired { get; set; }
        public Guid CategoryId { get; set; }

    }
}
