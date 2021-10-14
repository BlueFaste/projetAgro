using System;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;
namespace Nomenclatures.Tests
{
    public class dbTest
    {
        [Test]
        public void Create_Matiere_Premiere()
        {
            using(var db = new NomenclaturesContext())
            {
                var FamilleMP = new FamilleMatierePremiere { DureeOptimaleUtilisation =TimeSpan.FromHours(2) };

                var newMatierePremiere = new MatierePremiere {Nom = "Farine", Description = "Poudre blanche de blé", PourcentageHumidite = 50, PoidsUnitaire = 1, DureeConservation = TimeSpan.FromHours(2), Famille = FamilleMP };

                db.MatierePremieres.Add(newMatierePremiere);

                db.SaveChanges();

                Trace.WriteLine(newMatierePremiere.Id);

                var MPdb = db.MatierePremieres.ToList();

                Trace.WriteLine(MPdb[0]);

                db.MatierePremieres.Remove(MPdb[0]);
                db.SaveChanges();

                Assert.AreEqual(MPdb[0].Id, newMatierePremiere.Id);               
            }
            
        }

        [Test]
        public void Create_One_Produit()
        {
            using(var db = new NomenclaturesContext())
            {
                var paquetPitchs = new ProduitFini();
                var pitch = new ProduitSemiFini();
                var farine = new MatierePremiere();
                var chocolat = new MatierePremiere();

                farine.PoidsUnitaire = 1;
                farine.PourcentageHumidite = 50;
                chocolat.PoidsUnitaire = 1;

                paquetPitchs.Add(pitch, 8);
                pitch.Add(farine, 100);
                pitch.Add(chocolat, 20);

                db.Produits.Add(paquetPitchs);

                db.SaveChanges();

                Trace.WriteLine(paquetPitchs.Id);

                var produitDb = db.Produits.ToList();

                Trace.WriteLine(produitDb[0]);

                db.Produits.Remove(produitDb[0]);
                db.SaveChanges();

                 Assert.AreEqual(produitDb[0].Id, paquetPitchs.Id);              

            }
            
        }
    }
}