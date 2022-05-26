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
            
            foreach (var category in categories.Data)
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

        [HttpGet("{postId}/edit-post")]
        public async Task<IActionResult> Edit(Guid postId)
        {
            //get the role
            var post = await _mediator.Send(new GetPostByIdQuery(postId, withCategories: true));
            var categoryIds = post.PostCategories.Select(c => c.CategoryId).Distinct().ToList();
            
            //get all categories
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            var model = new CategorySelectionViewModel();
            
            foreach (var category in categories.Data)
            {
                var editorViewModel = new SelectCategoryEditorViewModel()
                {
                    CategoryId = category.CategoryId,
                    Title = category.Title,
                    Selected = categoryIds.Contains(category.CategoryId)
                };
                model.Categories.Add(editorViewModel);
            }

            var postUpdateModel = new PostUpdateRequest()
            {
                Title = post.Title,
                Author = post.Author,
                Content = post.Content,
                CategorySelectionViewModel = model
            };
            
            return View(postUpdateModel);
        }
        
        [HttpPost("{postId}/edit-post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid postId, PostUpdateRequest postUpdateRequest)
        {
            postUpdateRequest.Categories = postUpdateRequest.CategorySelectionViewModel.GetSelectedIds();

            var response = await _mediator.Send(new UpdatePostCommand(postId, postUpdateRequest, trackChanges: true));
            if (response.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View(postUpdateRequest);
        }
        
    }
}