using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class CommentValidator
    {
        #region Validators
        public static bool ValidateCreateComment(Comment comment, string ownerId)
        {
            if (CommentExists(comment))
            {
                return false;
            }
            if (!OwnerExists(ownerId))
            {
                return false;
            }
            if (!CommentHasDescription(comment))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateGetComment(string commentId)
        {
            if (!CommentExists(commentId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateUpdateComment(Comment comment)
        {
            if (!CommentExists(comment))
            {
                return false;
            }
            if (!CommentHasDescription(comment))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDeleteComment(string commentId)
        {
            if (!CommentExists(commentId))
            {
                return false;
            }
            return true; 
        }

        public static bool ValidateGetComments(string ownerId)
        {
            if (!OwnerExists(ownerId))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Helper Functions
        private static bool CommentExists(Comment comment)
        {
            return comment.CommentId != null;
        }

        private static bool CommentExists(string commentId)
        {
            return commentId != null;
        }

        private static bool CommentHasDescription(Comment comment)
        {
            return (comment.Description != null) && (comment.Description != "");
        }

        private static bool OwnerExists(string ownerId)
        {
            return (ownerId != null) && (ownerId != "");
        }
        #endregion
    }
}
