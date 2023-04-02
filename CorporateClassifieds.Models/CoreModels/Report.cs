using CorporateClassifieds.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.CoreModels
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid ClassfiedId { get; set; }
        public string Description { get; set; }
        public ReportType ReportType { get; set; }
        public Guid ReportedBy { get; set; }
    }
}
