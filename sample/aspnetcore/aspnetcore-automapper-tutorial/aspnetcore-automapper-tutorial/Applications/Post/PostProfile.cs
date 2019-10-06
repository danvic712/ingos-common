using aspnetcore_automapper_tutorial.Models.Post;
using aspnetcore_automapper_tutorial.ViewModels.Post;
using AutoMapper;
using System;
using System.Linq;

namespace aspnetcore_automapper_tutorial.Applications.Post
{
    public class PostProfile : Profile
    {
        /// <summary>
        /// ctor
        /// </summary>
        public PostProfile()
        {
            // Config mapping rules
            //
            CreateMap<PostModel, PostViewModel>()
                .ForMember(destination => destination.CommentCounts, source => source.MapFrom(i => i.Comments.Count()))
                .ForMember(destination => destination.ReleaseDate, source => source.ConvertUsing(new DateTimeConverter()));
        }
    }

    public class DateTimeConverter : IValueConverter<DateTime, string>
    {
        public string Convert(DateTime source, ResolutionContext context)
            => source.ToString("yyyy-MM-dd HH:mm:ss");
    }
}