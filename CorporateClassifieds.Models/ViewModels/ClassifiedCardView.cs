using CorporateClassifieds.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.ViewModels
{
    public class ClassifiedCardView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public short Type { get; set; }
        public DateTime AddedOn { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public short CategoryIcon { get; set; }
        public string Description { get; set; }
        public short RemovedBy { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }
        public Guid UserId { get; set; }
        public string PublishedBy { get; set; }
        public Guid? ProfileImageId { get; set; }
        public Guid ImageId { get; set; }
        public int OfferCount { get; set; }
        public int CommentCount { get; set; }
    }
}
