using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using aspnetcore_mediatr_tutorial.ViewModels;

namespace aspnetcore_mediatr_tutorial.Controllers
{
    public class HomeController : Controller
    {
        #region Initialize

        /// <summary>
        ///
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        ///
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion Initialize

        #region Views

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        #endregion Views

        #region APIs

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            return Json("");
        }

        #endregion APIs
    }
}