using Microsoft.AspNetCore.Mvc;
using NetCoreAppLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAppLayout.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }//bir sayfada form varsa hem get i hem postu vardır
        [HttpGet("create-category")]//attribute routing sayfa bu routing ile açılsın demek 
        public IActionResult Create()
        {
            return View();
        }//
        [HttpPost("create-category-post")]//httppost olarak create category olarak sayfaya istek atılsın demek 
        public IActionResult Create([Bind("Name","Description")] CategoryCreateInputModel model)//bind attribute ile formadaki bazı alanların sınıcıdaki methoda taşınmasını istemeyiz sadece yazdıklrımız post edilir
        {
            ModelState.AddModelError("Error", "Different Error");

            if (ModelState.IsValid)//model validasyondan geçiyorsa
            {
                //veri tabanına kaydı gönder
            }
            return View();
        }

        [HttpGet("update-category")]
        public IActionResult Update()
        {//form dolu gelsin
            var model = new CategoryUpdateInputModel
            {
                Name = "deneme",
                Description = "text"
            };
            return View(model);
        }

        [HttpPost("update-category-post")]
        public IActionResult Update([Bind("Name", "Description")] CategoryUpdateInputModel model)
        {
            ModelState.AddModelError("Error", "Different Error");

            if (ModelState.IsValid)//model validasyondan geçiyorsa
            {
                //veri tabanına kaydı gönder
            }
            return View();
        }
    }
}
