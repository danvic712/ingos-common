using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_automapper_tutorial.Applications.Post.Contacts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspnetcore_automapper_tutorial.Controllers
{
    public class PostController : Controller
    {
        #region Init

        /// <summary>
        ///
        /// </summary>
        private readonly IPostAppService _postApp;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="postApp"></param>
        public PostController(IPostAppService postApp)
        {
            _postApp = postApp ?? throw new ArgumentNullException(nameof(postApp));
        }

        #endregion Init

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IActionResult List()
        {
            var datas = _postApp.GetPostLists();
            return View(datas);
        }
    }
}