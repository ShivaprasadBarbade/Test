using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Repository.Dapper.Entities
{
    [Table("Classified")]
    public class Classified
    {
        public Guid Id { get; set; }
        public short Type { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int? ViewCount { get; set; }
        public DateTime AddedOn { get; set; }
        public Guid AddedBy { get; set; }
        public short? RemovedBy { get; set; }
        public DateTime? RemovedOn { get; set; }
        public string? DeletedReason { get; set; }
        public bool ShowContact { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }

}
