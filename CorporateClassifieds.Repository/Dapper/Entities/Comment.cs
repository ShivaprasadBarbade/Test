using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Repository.Dapper.Entities
{
    public class Comment
    {       
        public string Id { get; set; }
        public string AddedBy { get; set; }
        public string ClassifiedId { get; set; }
        public string? ParentCommentId { get; set; }
        public string Message { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
