using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesStore.API.DTO.Products;
using ShoesStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShoesStoreContext _shoesStoreContext;
        public ProductsController(ShoesStoreContext shoesStoreContext)
        {
            this._shoesStoreContext = shoesStoreContext;
        }

        [HttpGet]
        public IQueryable<ProductsDto> GetProductsByCategory(int branchID)
        {
            var query = from a in this._shoesStoreContext.Products
                        where a.BranchId == branchID
                        select new ProductsDto()
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Price = a.Price
                        };
            return query;
        }

        [HttpGet("{id}")]
        public DetailProductDto GetDetail(int id)
        {
            var query = this._shoesStoreContext.Products.Where(m => m.Id == id).Select(m => new DetailProductDto()
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Descriptions,
                Price = m.Price
            }).First();

            return query;
        }

        [HttpGet("Features")]
        public IEnumerable<ProductsDto> GetFeatureProducts(int n = 4)
        {
            var query = this._shoesStoreContext.Products.ToList();

            var listFeature = new List<Product>();
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                int randomNumber = rand.Next(1, this._shoesStoreContext.Products.Count());
                listFeature.Add(query.ElementAt(randomNumber));
            }

            var selectQuery = from a in listFeature
                              select new ProductsDto()
                              {
                                  Id = a.Id,
                                  Name = a.Name,
                                  Price = a.Price
                              };
                
            return selectQuery;
        }
    }
}
