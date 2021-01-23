using AutoMapper;
using Models.Entities.UserModels;

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
                 
       
        }
    }
}