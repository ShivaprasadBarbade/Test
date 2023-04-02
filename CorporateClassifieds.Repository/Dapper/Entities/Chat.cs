using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Repository.Dapper.Entities
{
    public class Chat
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public DateTime AddedOn { get; set; }
        public string OfferId { get; set; }
        public string AddedBy { get; set; }
        public Guid ClassfiedID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
