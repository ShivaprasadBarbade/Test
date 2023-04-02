using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateClassifieds.Models.Enums
{
    
    
        public enum Icon
        {
            //to be issued from Front End

        }
        public enum FieldType 
        {
            Int=1,
            String
        }
        public enum ClassifiedType
        {
            Sale=1,
            Rent,
            Required
            
        }
        public enum Role
        {
            None=0,
            Admin,
            User
        }
        public enum ReportType
        {
            FakeProduct = 1,
            MisLeading,
            Fraud,
        }
}
