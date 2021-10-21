using System.Collections.Generic;
using System.Linq;
namespace Nomenclatures
{
    public class PrixCalculateur : IVisitor
    {

        private Stack<double> _prix = new Stack<double>();
         void IVisitor.Visit(ProduitFini pf)
        {
            Visit(pf);
        }

        void IVisitor.Visit(ProduitSemiFini psf)
        {
            Visit(psf);
        }

        void IVisitor.Visit(MatierePremiere mp)
        {
            // if(_onlyBio && !mp.Bio)
            //     _poids.Push(0);
            // else
            //     _poids.Push(mp.PoidsUnitaire - mp.PoidsUnitaire * mp.PourcentageHumidite / 100);
        }

        void IVisitor.Visit(FamilleMatierePremiere fmp)
        {

        }

        private void Visit(Produit p)
        {

            double prix = 0;
            foreach (var cpqty in p)
            {
                prix += _prix.Pop();
            }
            // double poids = 0;

            // foreach (var cpqty in p.Reverse())
            // {
            //     poids += _poids.Pop() * cpqty.Qty;
            // }

            // _poids.Push(poids);
        }

    }
}