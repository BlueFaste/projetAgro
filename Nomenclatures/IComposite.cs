using System.Collections.Generic;
using System;

namespace Nomenclatures
{
    public interface IComposite : IEnumerable<ComponentQty>
    {
        void Add(IComponent component, double qty, Unit unit, TimeSpan DureeConsomation, TimeSpan DureeUtilisationOptimale);

        void Remove(IComponent component);

        void CalculateDateLimiteConsomation(Produit produit);

        void CalculateDateLimiteUtilisationOptimal(Produit produit);
    }

    public enum Unit
    {
        Gram,
        Piece
    }
}