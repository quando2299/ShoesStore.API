using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesStore.API.DTO.Home;
using ShoesStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ShoesStoreContext _shoesStoreContext;
        public HomeController(ShoesStoreContext shoesStoreContext)
        {
            this._shoesStoreContext = shoesStoreContext;
        }

        [HttpGet]
        public IEnumerable<HomeProductsDto> GetHomeProducts(int n = 10)
        {
            var query = this._shoesStoreContext.Products.Join(
                        this._shoesStoreContext.Branches,
                        p => p.BranchId,
                        b => b.Id,
                        (p, b) => new HomeProductsDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Price = p.Price,
                            BranchName = b.Name
                        }
                    ).ToList();

            var list = new List<HomeProductsDto>();

            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                int randomNumber = rand.Next(1, this._shoesStoreContext.Products.Count());
                list.Add(query.ElementAt(randomNumber));
            }

            return list;
        }
    }
}
