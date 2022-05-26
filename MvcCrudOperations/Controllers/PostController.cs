using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Categories.Queries;
using Application.Features.Posts.Commands;
using Application.Features.Posts.Queries;
using Domain.Boundary.Requests;
using Domain.Entities;
using Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcCrudOperations.Controllers
{
    public class PostController : Controller
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            var posts = await _mediator.Send(new GetAllPostsQuery());
            
            return View(posts);
        }

        [HttpGet("create-post")]
        public async Task<IActionResult> Create()
        {

            //get all categories
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            var model = new CategorySelectionViewModel();
            
            foreach (var category in categories)
            {
                var editorViewModel = new SelectCategoryEditorViewModel()
                {
                    CategoryId = category.CategoryId,
                    Title = category.Title 
                };
                model.Categories.Add(editorViewModel);
            }

            var postCreationModel = new PostCreationRequest()
            {
                Title = string.Empty,
                Author = string.Empty,
                Content = string.Empty,
                CategorySelectionViewModel = model
            };
            
            return View(postCreationModel);
        }

        [HttpPost("create-post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostCreationRequest postCreationRequest)
        {
            postCreationRequest.Categories = postCreationRequest.CategorySelectionViewModel.GetSelectedIds();
            var response = await _mediator.Send(new CreatePostCommand(postCreationRequest));
            if (!response.Succeeded)
            {
                return View(postCreationRequest);
            }
            
            return RedirectToAction("Index");
        }
        
        private async Task<List<SelectListItem>> PreparePostCreationView()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            //create a list to populate the Category drop down
            var list = categories.Select(category => new SelectListItem
            {
                Text = category.Title,
                Value = category.CategoryId.ToString()
            }).ToList();

            return list;
        }
    }
}