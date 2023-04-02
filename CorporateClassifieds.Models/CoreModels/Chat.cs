using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.CoreModels
{
    public class Chat
    {
        public Guid Id { get; set; }    
        public string Message { get; set; } 
        public DateTime AddedOn { get; set; }   
        public Guid OfferId { get; set; } 
        public string AddedBy { get; set;} 
        public Guid ClassfiedId { get; set; }

    }
}
