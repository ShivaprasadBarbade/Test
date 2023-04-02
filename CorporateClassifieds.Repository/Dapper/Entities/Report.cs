using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Repository.Dapper.Entities
{
    public class Report
    {
        public string Id { get; set; }
        public string ClassfiedId { get; set; }
        public string Description { get; set; }
        public short ReportType { get; set; }
        public string ReportedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
