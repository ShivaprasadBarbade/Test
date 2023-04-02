using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.CoreModels
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid AddedBy { get; set; }
        public Guid ClassifiedId { get; set; }
        public Guid? ParentCommentId { get; set; }
        public string Message { get; set; }
        public DateTime AddedOn { get; set; }

    }
}
