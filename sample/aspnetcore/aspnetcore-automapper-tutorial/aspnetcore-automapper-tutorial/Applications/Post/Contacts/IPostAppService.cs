using aspnetcore_automapper_tutorial.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_automapper_tutorial.Applications.Post.Contacts
{
    public interface IPostAppService
    {
        #region APIs

        /// <summary>
        /// Get all post list
        /// </summary>
        /// <returns></returns>
        IList<PostViewModel> GetPostLists();

        #endregion APIs
    }
}