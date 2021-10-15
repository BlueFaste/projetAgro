using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nomenclatures.Data;

namespace Nomenclatures.Web.Controllers
{
    public class ProduitController : Controller
    {
         private NomenclaturesContext _dbContext;
        private const int cstPageSize = 10;

         public ProduitController(NomenclaturesContext dbContext)
        {
            _dbContext = dbContext;
        }

         public IActionResult List(int pageIndex)
        {
            return View(_dbContext.Produits
                .Skip(pageIndex * cstPageSize)
                .Take(cstPageSize)
                .OrderBy(mp => mp.Nom));
        }

         public IActionResult Edit(int id)
        {
            var pdt = _dbContext.Produits.Find(id);
            if (pdt == null) return NotFound();

            return View(pdt);
        }
        
        public IActionResult Create()
        {
            return View(nameof(Edit), new Nomenclatures.Data.ProduitFini());
        }

        public IActionResult Delete(int id)
        {
            var mp = _dbContext.Produits.Find(id);
            if (mp != null)
            {
                _dbContext.Produits.Remove(mp);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public IActionResult Save(Nomenclatures.Data.ProduitFini mp)
        {
            if (mp.Id != 0)
            {
                _dbContext.Attach(mp).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Produits.Add(mp);
            }

            _dbContext.SaveChanges();

            return RedirectToAction(nameof(List));
        }
    }

}