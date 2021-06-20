using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoesStore.API.DTO.Branches;
using ShoesStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoesStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly ShoesStoreContext _shoesStoreContext;
        public BranchesController(ShoesStoreContext shoesStoreContext)
        {
            this._shoesStoreContext = shoesStoreContext;
        }

        [HttpGet]
        public IQueryable<BranchDto> Get()
        {
            var branches = from a in this._shoesStoreContext.Branches
                           select new BranchDto()
                           {
                               Id = a.Id,
                               Name = a.Name
                           };
            return branches;
        }
    }
}
