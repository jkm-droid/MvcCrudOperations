using System.Threading.Tasks;
using Application.Features.Category.Queries;
using LoggerService.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MvcCrudOperations.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILoggerManager _loggerManager;

        public CategoryController(IMediator mediator, ILoggerManager loggerManager)
        {
            _mediator = mediator;
            _loggerManager = loggerManager;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}