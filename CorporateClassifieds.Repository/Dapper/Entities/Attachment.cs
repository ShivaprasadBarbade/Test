using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CorporateClassifieds.Repository.Dapper.Entities
{
    [Table("Attachment")]
    public class Attachment
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public Guid ClassifiedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
