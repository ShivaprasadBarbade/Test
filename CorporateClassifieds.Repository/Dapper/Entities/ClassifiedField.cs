namespace CorporateClassifieds.Repository.Dapper.Entities
{

    public class ClassifiedField
    {
        public Guid Id { get; set; }
        public Guid ClassifiedId { get; set; }
        public Guid AttributeId { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
