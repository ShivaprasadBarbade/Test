using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.CoreModels
{
    public class ClassifiedOffer
    {
        public Guid Id { get; set; }
        public Guid ClassifiedId { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; } 

    }
}
