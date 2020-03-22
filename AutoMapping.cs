namespace Crow.Shop
{
    using AutoMapper;
    using Models;
    using System.Linq;

    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            this.CreateMap<Product, ProductItem>()
                .ForMember(x => x.Image, opt => opt.MapFrom(src => src.Images.OrderBy(i => i.Order).FirstOrDefault()));
        }
    }
}
