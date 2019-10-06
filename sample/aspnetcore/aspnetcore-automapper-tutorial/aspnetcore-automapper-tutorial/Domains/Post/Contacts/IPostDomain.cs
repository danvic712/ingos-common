using aspnetcore_automapper_tutorial.Models.Post;
using System.Collections.Generic;

namespace aspnetcore_automapper_tutorial.Domains.Post.Contacts
{
    public interface IPostDomain
    {
        #region APIs

        /// <summary>
        /// Get all post list data
        /// </summary>
        /// <returns></returns>
        IList<PostModel> GetPostLists();

        #endregion APIs
    }
}