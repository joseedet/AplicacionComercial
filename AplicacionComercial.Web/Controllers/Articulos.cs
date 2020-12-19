using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Interfaces;
using AplicacionComercial.Web.Models;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly IPostRepository _repo;
        private readonly IFileManager _fileManager;
        private readonly ICommentRepository _commentRepository;

        public ArticulosController(IPostRepository repo, IFileManager fileManager, ICommentRepository commentRepository)
        {
            _repo = repo;
            _fileManager = fileManager;
            _commentRepository = commentRepository;
            var _comment = new MainComment();

        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Index(int pageNumber, string category) //=>
        {
            if (pageNumber < 1)
                RedirectToAction("Index", new { pageNumber = 1, category });

            /* var vm = new IndexViewModel
             {
                 PageNumber=pageNumber,
                 Posts = string.IsNullOrEmpty(category) ? _repo.GetAllPosts(pageNumber) : _repo.GetAll(category)

             };*/
            var vm = _repo.GetAllPosts(pageNumber, category);
            return View(vm);
        }
        public async Task<IActionResult> Post(int id) => View(await _repo.GetByIdAsync(id));

        // GET: /<controller>/
        [HttpGet("/Image/{image}")]
        public  IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf("."), +1);

            return new FileStreamResult(_fileManager.imageStream(image), $"image/{mime}");
        }


        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel vm)
        {
            if (!ModelState.IsValid)

                return RedirectToAction("Post", new { id = vm.PostId });

            var post = await _repo.GetByIdAsync(vm.PostId);

            if (vm.MainCommentId == 0)
            {

                post.MainComments = post.MainComments ?? new List<MainComment>();

                post.MainComments.Add(new MainComment
                {
                    Message = vm.Message,
                    Created = DateTime.Now,


                });


                await _repo.UpdateAsync(post);
            }
            else
            {

                var comment = new SubComment
                {
                    MainCommentId = vm.MainCommentId,
                    Message = vm.Message,
                    Created = DateTime.Now

                };

                await _commentRepository.CreateAsync(comment);
                
            }

            //await _repo.SaveAllChangesAsync();

            return RedirectToAction("Post", new { id = vm.PostId });


        }
       
    }
}
