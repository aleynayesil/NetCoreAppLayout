using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAppLayout.Models
{
    public class Post//makale
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Comment> Comments { get; set; }//makalenin yorumları bilgisi join için 

    }
 
    //veri tabanında post comment bilgilerini tutmak için kullanacapımız entity simule etsşin
    public class Comment
    {
        public string Id { get; set; }
        public string body { get; set; }
        public string UserId { get; set; }//kim tarafından yorum yapıldı
        public string PostId { get; set; }//yorumun hangi makaleye atıldığını tuttuk
        public DateTime Date { get; set; }//hangi tarihte yorum yapıldığı
        public User CommentUser { get; set; }//navigation property join işlemleri için
        public Post CommentPost { get; set; }


    }
    //sayfaya çekilecek olan veriler viewmodel olarak tanımlanırlar
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
    public class CommentManager
    {
        public Post GetPostComment()
        {
            var post = new Post
            {
                Id = "2f7bcb42-a38a-4ac0-a519-5144ca8896a0",
                Comments = new List<Comment>(),
                Description="Makale-1",
                Title="Makale"
            };
            var user1 = new User
            {
                Email="test@test.com",
                Id=Guid.NewGuid().ToString(),
                UserName="test-user"
            };
            var user2 = new User
            {
                Email = "test1@test.com",
                Id = Guid.NewGuid().ToString(),
                UserName = "test-user1"
            };
            post.Comments.Add(new Comment
            {
                body = "Comment-1",
                CommentPost = post,
                CommentUser=user1,
                Date=DateTime.Now.AddDays(-2),
                Id = Guid.NewGuid().ToString(),
                PostId=post.Id,
                UserId=user1.Id
            }) ;
            post.Comments.Add(new Comment
            {
                body = "Comment-1",
                CommentPost = post,
                CommentUser = user2,
                Date = DateTime.Now.AddDays(-3),
                Id = Guid.NewGuid().ToString(),
                PostId = post.Id,
                UserId = user2.Id
            });
            return post;
        }
    }
    public class PostDetailViewModel
    {
        public string PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public List<CommentViewModel> PostComments { get; set; }//makaleye ait yorumlar
        //göstermek istediğimiz veriler view model entitylerimizi bozmuyoruz
    }

    public class CommentViewModel
    {
        public string CommentBy { get; set; }
        public string Message { get; set; }
        public DateTime CommentDate { get; set; }

    }
}
