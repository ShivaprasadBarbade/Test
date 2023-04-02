using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateClassifieds.Repository.Dapper.Entities
{
    [Table ("CategoryField")]
    public class CategoryField
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public short Type { get; set; }
        public bool IsRequired { get; set; }
        public string CategoryId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
