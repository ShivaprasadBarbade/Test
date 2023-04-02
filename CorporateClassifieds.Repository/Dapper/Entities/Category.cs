using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateClassifieds.Repository.Dapper.Entities
{
    [Table ("Category")]   
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public short Icon { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
