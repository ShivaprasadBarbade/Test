using CorporateClassifieds.Models.CoreModels;
using CorporateClassifieds.Models.Enums;

namespace CorporateClassifieds.Models.ViewModels
{
    public class ClassifiedFormView
    {
        public Guid Id { get; set; }
        public ClassifiedType Type { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime AddedOn { get; set; }
        public Guid AddedBy { get; set; }
        public bool ShowContact { get; set; }
        public int? ViewCount { get; set; }
        public List<ClassifiedFieldView> Fields { get; set; } 
    }
}
