using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Nomenclatures.Data;
using System.Collections.Generic;

namespace Nomenclatures.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class searchController : ControllerBase
    {
        private NomenclaturesContext _dbContext;

        public searchController(NomenclaturesContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{expression}")]
        public IActionResult GetResult([FromRoute]string expression)
        {
             var search = new Search(
                 _dbContext.FamillesPremieres, 
                 _dbContext.MatieresPremieres, 
                 _dbContext.Produits
                 )
            {
                NomContient = expression
            };
            var result = search.Execute();

            if (result.Count() > 0) {
                return Ok(result);
            } else {
                return NotFound();
            }

            



        }
        
    }
}