using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Nomenclatures.Produit
{
    public abstract class ProduitBase
    {
        private int codeUnique = 0;
        private string nom;
        private string description;

        private List<ProduitFini> produits;

        private Task Add(IComponent component, Double Quantity)
        {
            var produit = new ProduitFini();

            codeUnique = codeUnique++;

            produits.add(produit);
        }

        private Task Remove()
        {
            
        }


    }
}