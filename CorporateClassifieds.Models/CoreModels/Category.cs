using CorporateClassifieds.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.CoreModels
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AddedBy { get; set; } 
        public DateTime AddedOn { get; set; }
        public short Icon { get; set; }
    }
}
