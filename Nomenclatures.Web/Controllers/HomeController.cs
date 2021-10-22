using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nomenclatures.Web.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Nomenclatures.Data;



namespace Nomenclatures.Web.Controllers
{
    public class HomeController : Controller
    {

         private NomenclaturesContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, NomenclaturesContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


          [HttpPost]
        public IActionResult Recherche(Nomenclatures.Data.Recherche variable)
        {
            Console.WriteLine(variable.search);
            Console.WriteLine(variable.bio);
            Console.WriteLine(variable.nonBio);
            Console.WriteLine(variable.pf);
            Console.WriteLine(variable.psf);
            Console.WriteLine(variable.mp);
            Console.WriteLine(variable.fmp);

            IEnumerable produit;
            IEnumerable famille;
            IEnumerable mp;

                     produit = _dbContext.Produits.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
                    famille = _dbContext.FamillesPremieres.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
                    mp = _dbContext.MatieresPremieres.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
                    return View(
                        (
                            (IEnumerable<Nomenclatures.Data.Produit>)produit,
                            (IEnumerable<Nomenclatures.Data.MatierePremiere>)mp,
                            (IEnumerable<Nomenclatures.Data.FamilleMatierePremiere>)famille
                        )
                    );

            // if(!variable.bio && !variable.nonBio){
            //     if (!variable.pf && !variable.psf && !variable.mp && !variable.fmp){
            //         produit = _dbContext.Produits.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
            //         famille = _dbContext.FamillesPremieres.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
            //         mp = _dbContext.MatieresPremieres.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
            //         return View(
            //             (
            //                 (IEnumerable<Nomenclatures.Data.Produit>)produit,
            //                 (IEnumerable<Nomenclatures.Data.MatierePremiere>)mp,
            //                 (IEnumerable<Nomenclatures.Data.FamilleMatierePremiere>)famille
            //             )
            //         );
            //     } else {
            //         if(variable.pf){
                        
            //             produit = _dbContext.Produits.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
            //             return View(
            //                 (
            //                     (IEnumerable<Nomenclatures.Data.Produit>)produit,
            //                     (IEnumerable<Nomenclatures.Data.MatierePremiere>)mp,
            //                     (IEnumerable<Nomenclatures.Data.FamilleMatierePremiere>)famille
            //                 )
            //             );
                         
            //             } else if ( variable.psf){
            //                 produit = _dbContext.Produits.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
            //                 return View(
            //                    (
            //                        (IEnumerable<Nomenclatures.Data.Produit>)produit
            //                    )
            //                 );
            //             } else if (variable.fmp){
            //                 famille = _dbContext.FamillesPremieres.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
            //                 return View(
            //                    (
            //                        (IEnumerable<Nomenclatures.Data.FamilleMatierePremiere>)famille
            //                    )
            //                 );
            //             } else {
            //                 mp = _dbContext.MatieresPremieres.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
            //                 return View(
            //                     (
            //                         (IEnumerable<Nomenclatures.Data.MatierePremiere>)mp
            //                     )
            //                 );
            //             }
            //     }

            // } else {
            //     if (variable.bio){
            //         if (!variable.pf && !variable.psf && !variable.mp && !variable.fmp){
            //             produit = _dbContext.Produits.Where(p => p.Nom.Contains(variable.search) && p.Bio).OrderBy(p => p.Nom);
            //             famille = _dbContext.FamillesPremieres.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
            //             mp = _dbContext.MatieresPremieres.Where(p => p.Nom.Contains(variable.search) && p.Bio).OrderBy(p => p.Nom);
            //             return View(
            //                 (
            //                     (IEnumerable<Nomenclatures.Data.Produit>)produit,
            //                     (IEnumerable<Nomenclatures.Data.MatierePremiere>)mp,
            //                     (IEnumerable<Nomenclatures.Data.FamilleMatierePremiere>)famille
            //                 )
            //             );
            //         } else {
            //             if(variable.pf){
            //                produit = _dbContext.Produits.Where(p => p.Nom.Contains(variable.search) && p.Bio).OrderBy(p => p.Nom);
            //                return View(
            //                    (
            //                        (IEnumerable<Nomenclatures.Data.Produit>)produit
            //                    )
            //                );
                         
            //             } else if ( variable.psf){
            //                 produit = _dbContext.Produits.Where(p => p.Nom.Contains(variable.search) && p.Bio).OrderBy(p => p.Nom);
            //                 return View(
            //                    (
            //                        (IEnumerable<Nomenclatures.Data.Produit>)produit
            //                    )
            //                 );
            //             } else if (variable.fmp){
            //                 famille = _dbContext.FamillesPremieres.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
            //                 return View(
            //                    (
            //                        (IEnumerable<Nomenclatures.Data.FamilleMatierePremiere>)famille
            //                    )
            //                 );
            //             } else {
            //                 mp = _dbContext.MatieresPremieres.Where(p => p.Nom.Contains(variable.search) && p.Bio).OrderBy(p => p.Nom);
            //                 return View(
            //                     (
            //                         (IEnumerable<Nomenclatures.Data.MatierePremiere>)mp
            //                     )
            //                 );
            //             }
            //         }
            //     } else{
            //         if (!variable.pf && !variable.psf && !variable.mp && !variable.fmp){
            //             produit = _dbContext.Produits.Where(p => p.Nom.Contains(variable.search) && !p.Bio).OrderBy(p => p.Nom);
            //             famille = _dbContext.FamillesPremieres.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
            //             mp = _dbContext.MatieresPremieres.Where(p => p.Nom.Contains(variable.search) && !p.Bio).OrderBy(p => p.Nom);
            //             return View(
            //                 (
            //                     (IEnumerable<Nomenclatures.Data.Produit>)produit,
            //                     (IEnumerable<Nomenclatures.Data.MatierePremiere>)mp,
            //                     (IEnumerable<Nomenclatures.Data.FamilleMatierePremiere>)famille
            //                 )
            //             );
            //         } else {
            //             if(variable.pf){
            //                produit = _dbContext.Produits.Where(p => p.Nom.Contains(variable.search) && !p.Bio).OrderBy(p => p.Nom);
            //                return View(
            //                    (
            //                        (IEnumerable<Nomenclatures.Data.Produit>)produit
            //                    )
            //                 );
                         
            //             } else if ( variable.psf){
            //                 produit = _dbContext.Produits.Where(p => p.Nom.Contains(variable.search) && !p.Bio).OrderBy(p => p.Nom);
            //                 return View(
            //                    (
            //                        (IEnumerable<Nomenclatures.Data.Produit>)produit
            //                    )
            //                 );
            //             } else if (variable.fmp){
            //                 famille = _dbContext.FamillesPremieres.Where(p => p.Nom.Contains(variable.search)).OrderBy(p => p.Nom);
            //                 return View(
            //                    (
            //                        (IEnumerable<Nomenclatures.Data.FamilleMatierePremiere>)famille
            //                    )
            //                 );
            //             } else {
            //                 mp = _dbContext.MatieresPremieres.Where(p => p.Nom.Contains(variable.search) && !p.Bio).OrderBy(p => p.Nom);
            //                 return View(
            //                     (
            //                         (IEnumerable<Nomenclatures.Data.MatierePremiere>)mp
            //                     )
            //                 );
            //             }
            //         }
            //     }
            // }
        }
    }
}
