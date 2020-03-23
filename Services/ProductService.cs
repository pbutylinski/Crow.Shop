using AutoMapper;
using AutoMapper.QueryableExtensions;
using Crow.Shop.Data;
using Crow.Shop.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crow.Shop.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductService(
            ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<ProductItem>> GetAll()
        {
            return await this.context.Products
                .Where(x => !x.IsDeleted)
                .Include(x => x.Translations)
                .Include(x => x.Images)
                .ProjectTo<ProductItem>(this.mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await this.context.Products
                .Include(x => x.Translations)
                .Include(x => x.Images)
                .Include(x => x.OptionGroups)
                    .ThenInclude(x => x.Options)
                    .ThenInclude(x => x.Translations)
                .Include(x => x.OptionGroups)
                    .ThenInclude(x => x.Translations)
                .Where(x => !x.IsDeleted)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Product product)
        {
            this.context.Entry(product).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

        public async Task Create(Product product)
        {
            this.context.Products.Add(product);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await this.context.Products.FindAsync(id);
            product.IsDeleted = true;

            this.context.Entry(product).State = EntityState.Modified;

            await this.context.SaveChangesAsync();
        }

        public bool CheckIfExists(int id)
        {
            return this.context.Products.Any(e => e.Id == id);
        }
    }
}
