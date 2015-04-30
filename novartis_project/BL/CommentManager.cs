using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.DAL.EF;
using JPP.BL.Domain.Antwoorden;

namespace JPP.BL
{
    class CommentManager:ICommentManager
    {


        IngelogdeGebruikerSCEF inlog;

        public CommentManager()
        {
            inlog = new IngelogdeGebruikerSCEF();
        }
        public List<Comment> topComments(int top)
        {
            List<Comment> commentList = inlog.getAllComments();
            List<Comment> commentTussenRes = commentList.OrderBy(o => o.aantalStemmen).ToList();
            List<Comment> commentReturn = new List<Comment>();
            for (int i = 0; i < top; i++)
            {
                commentReturn.Add(commentTussenRes[i]);
            }
            return commentReturn;
        }

        public Comment readComment(int id)
        {
            return inlog.getComment(id);
        }

        public List<Comment> readAllComments()
        {
            List<Comment> commentReturn = inlog.getAllComments();
            return commentReturn;
        }

        public Comment createComment(Comment comment)
        {
           return inlog.createComment(comment);
        }

        public void updateComment(Comment comment)
        {
            inlog.wijzigComment(comment);
        }

        public void removeComment(int id)
        {
            inlog.deleteComment(id);
        }

        public void stemOpComment(int id)
        {
            inlog.stemOpComment(id);
        }
    }
}
