using aspnetcore_automapper_tutorial.Applications.Post.Contacts;
using aspnetcore_automapper_tutorial.Domains.Post.Contacts;
using aspnetcore_automapper_tutorial.Models.Post;
using aspnetcore_automapper_tutorial.ViewModels.Post;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_automapper_tutorial.Applications.Post
{
    public class PostAppService : IPostAppService
    {
        #region Initialize

        /// <summary>
        ///
        /// </summary>
        private readonly IPostDomain _post;

        /// <summary>
        ///
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="post"></param>
        /// <param name="mapper"></param>
        public PostAppService(IPostDomain post, IMapper mapper)
        {
            _post = post ?? throw new ArgumentNullException(nameof(post));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Initialize

        /// <summary>
        /// Get all post list data
        /// </summary>
        /// <returns></returns>
        public IList<PostViewModel> GetPostLists()
        {
            var datas = _post.GetPostLists();
            return _mapper.Map<IList<PostModel>, IList<PostViewModel>>(datas);
        }
    }
}