using AutoMapper;
using ShopOnline.API.Models.UserModels;
using ShopOnline.API.Models.CrawlerModels;

namespace ShopOnline.API.Models.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Phía trước là nguồn,phía sau là đích
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<TodoItem, TodoItemDTO>();
             CreateMap<TodoItemDTO, TodoItem>();
             CreateMap<News,NewsDTO>();
             CreateMap<NewsDTO,News>();
        }
    }
}