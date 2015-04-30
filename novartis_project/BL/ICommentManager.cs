using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Antwoorden;

namespace JPP.BL
{
    interface ICommentManager
    {
        List<Comment> topComments(int top);
        Comment readComment(int id);
        List<Comment> readAllComments();
        Comment createComment(Comment comment);
        void updateComment(Comment comment);
        void removeComment(int id);

        void stemOpComment(int id);
    }
}
