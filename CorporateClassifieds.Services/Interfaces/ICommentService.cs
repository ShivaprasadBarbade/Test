using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporateClassifieds.Models.CoreModels;

namespace CorporateClassifieds.Services.Interfaces
{
    public interface ICommentService
    {
        public void GetComments();

        public void AddComment(Comment comment);
    }
}
