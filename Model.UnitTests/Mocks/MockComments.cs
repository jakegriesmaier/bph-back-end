using Model.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Model.UnitTests.Mocks
{
    public static class MockComments
    {
        public static Comment GetComment(string id)
        {
            if (id == Comment1().CommentId)
            {
                return Comment1();
            }
            return new Comment();
        }

        public static Comment Comment1()
        {
            return new Comment
            {
                CommentId = "comment-1",
                CreatedDate = DateTime.Now,
                CreatedById = MockUsers.Coach().UserId,
                Description = "comment-1 descript"
            };
        }
        public static Comment creationNullCommentId()
        {
            return new Comment
            {
                CommentId = null,
                CreatedDate = DateTime.Now,
                CreatedById = MockUsers.Coach().UserId,
                Description = "pizza"
            };
        }
        public static Comment creationWithoutDescription()
        {
            return new Comment
            {
                CommentId = "Spaghetti",
                CreatedDate = DateTime.Now,
                CreatedById = MockUsers.Coach().UserId,
                Description = null
            };
        }
    }
}
