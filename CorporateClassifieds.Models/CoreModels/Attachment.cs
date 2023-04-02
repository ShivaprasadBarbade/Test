using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.CoreModels
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public Guid ClassifiedId { get; set; } 
  
    }
}
