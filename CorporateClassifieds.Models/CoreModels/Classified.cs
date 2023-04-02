using CorporateClassifieds.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.CoreModels
{
    public class Classified
    {
        public Guid Id { get; set; }
        public ClassifiedType Type { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int? ViewCount { get; set; }
        public DateTime AddedOn { get; set; }
        public Guid AddedBy { get; set; }   
        public Role? RemovedBy { get; set; }
        public DateTime? RemovedOn { get; set; }
        public string? DeletedReason { get; set; }
        public bool ShowContact { get; set; }
    }
    
}
