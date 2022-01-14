using Microsoft.AspNetCore.Mvc;
using NetCoreAppLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAppLayout.Controllers
{
    public class PostController : Controller
    {
        [HttpGet("post-detail/{postId}")]//dinamik link oluşturduk
        public IActionResult Detail(string postId)
        {
            var post = new CommentManager().GetPostComment();
            if (post.Id!=postId)
            {
                return NotFound();
            }
            //post datasını alıp view modele mappledik.post entity bilgisini ile view e gönderilecek olan modeli doldurduk.//view modellerin içine entity girmesin
            var model = new PostDetailViewModel
            {
                PostBody = post.Description,
                PostId = post.Id,
                PostTitle = post.Title,
                PostComments = post.Comments.Select(a => new CommentViewModel
                {
                    CommentBy = a.CommentUser.UserName,
                    CommentDate = a.Date,
                    Message = a.body
                }).ToList()
            };
            return View(model);
        }
        [HttpPost("send-comment")]
        public JsonResult SendComment([FromBody] CommentInputModel model)//json olarak veri gönderdiğimiz de post body den veriyi yakalamamızı sağlar.sadece application/json tipinde[fromform] ise postman üzerinden x-www-urlencoded olarak veri gönderdiğimiz yöntem
        {
            return Json("OK");
        }
    }
}
