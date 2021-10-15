using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Nomenclatures.Data;
using Microsoft.EntityFrameworkCore;


namespace Nomenclatures.Web
{
    public class MatierePremiereController : Controller
    {
        private NomenclaturesContext _dbContext;
        private const int cstPageSize = 10;
        public MatierePremiereController(NomenclaturesContext dbContext){
            _dbContext = dbContext;
        }

        public IActionResult List(int pageIndex)
        {
            return View(
                _dbContext.MatieresPremieres
                .Skip(pageIndex*cstPageSize)
                .Take(cstPageSize)
                .OrderBy(mp => mp.Nom)
                );
        }

        public IActionResult Edit(int id)
        {
            var mp = _dbContext.MatieresPremieres
            .FirstOrDefault(m => m.Id == id);
            if( mp != null) return NotFound();

            return View(mp);
        }

        public IActionResult Delete(int id)
        {
            var mp = _dbContext.MatieresPremieres
            .FirstOrDefault(m => m.Id == id);
            // .Find(id)
            if (mp != null)
            {
                _dbContext.MatieresPremieres.Remove(mp);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        public IActionResult Save(Nomenclatures.Data.MatierePremiere mp)
        {
            if(mp.Id != 0)
            {
                _dbContext.Attach(mp).State =EntityState.Modified;

            } 
            else 
            {
                _dbContext.MatieresPremieres.Add(mp);

            }


            return RedirectToAction(nameof(List));

        }

        [HttpPost]
        public IActionResult Create()
        {
            return View(nameof(Edit), new Nomenclatures.Data.MatierePremiere());
        }

    }
}