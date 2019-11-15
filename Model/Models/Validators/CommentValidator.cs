using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class CommentValidator
    {
        public static bool ValidateCreateComment(Comment comment, string ownerId)
        {
            if (comment.CommentId != null)
            {
                return false;
            }
            if (ownerId != null)
            {
                return false;
            }
            if (comment.Description == null)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateGetComment(string commentId)
        {
            if (commentId == null)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateUpdateComment(Comment comment)
        {
            if (comment.CommentId == null)
            {
                return false;
            }
            if (comment.Description == null)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateDeleteComment(string commentId)
        {
            if (commentId == null)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateGetComments(string ownerId)
        {
            if (ownerId == null)
            {
                return false;
            }
            return true;
        }
    }
}
