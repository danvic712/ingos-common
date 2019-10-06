using aspnetcore_automapper_tutorial.Domains.Post.Contacts;
using aspnetcore_automapper_tutorial.Models.Post;
using System;
using System.Collections.Generic;

namespace aspnetcore_automapper_tutorial.Domains.Post
{
    public class PostDomain : IPostDomain
    {
        #region Initialize

        private static List<PostModel> list = new List<PostModel> {
            new PostModel{
                Id = Guid.NewGuid(),
                SerialNo=Convert.ToInt64(DateTime.Now.AddDays(-10).ToString("yyyyMMddHHmmss")),
                Title="how to get started with automapper in asp net core",
                Author="danvic.wang",
                CategoryCode=1001,
                Content=@"在实际项目开发过程中，我们使用到的各种 ORM 组件都可以很便捷的将我们获取到的数据绑定到对应的 `List<T>` 集合中，
                    因为我们最终想要在页面上展示的数据与数据库实体类之间可能存在很大的差异，所以这里更常见的方法是去创建一些对应于页面数据展示的
                    `视图模型` 类，通过对获取到的数据进行二次加工，从而满足实际显示的需要。",
                Image="",
                IsDraft=true,
                ReleaseDate=DateTime.Now.AddDays(-10),
                Comments=new List<CommentModel>{
                    new CommentModel{
                        Id=Guid.NewGuid(),
                        Email="lalala@gmail.com",
                        Content="lalalalalallalalalalalalal",
                        CommentDate = DateTime.Now
                    },new CommentModel{
                        Id=Guid.NewGuid(),
                        Email="lulululu@gmail.com",
                        Content="dasldjaklsdjaksldjkalsdjklasjdklasjdklas",
                        CommentDate = DateTime.Now
                    }
                },
            }
        };

        #endregion Initialize

        #region APIs

        /// <summary>
        /// Get all post list data
        /// </summary>
        /// <returns></returns>
        public IList<PostModel> GetPostLists()
        {
            return list;
        }

        #endregion APIs
    }
}