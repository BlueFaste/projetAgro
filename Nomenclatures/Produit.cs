using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nomenclatures
{
    public abstract class Produit : IComposite
    {
        private List<ComponentQty> _components = new List<ComponentQty>();

        public string Nom {get ; set;}

        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateLimiteConsomation {get; set;}

        public DateTime DateFabrication {get; set;}

        public void Add(IComponent component, double qty, Unit unit, TimeSpan DureeConsomation, TimeSpan DureeUtilisationOptimale)
        {
            _components.Add(new ComponentQty()
                    {
                        Component = component,
                        Qty = qty,
                        Unit = unit,
                        DureeConsomation = DureeConsomation,
                        DureeUtilisationOptimale = DureeUtilisationOptimale,
                    }
                
            );
        }

        public void Remove(IComponent component)
        {
            _components.Remove(_components.First(c => c.Component == component));
        }

        public void CalculateDateLimiteConsomation(Produit produit)
        {
            Console.WriteLine(produit);

        }
        
        public void CalculateDateLimiteUtilisationOptimal(Produit produit)
        {
            Console.WriteLine(produit);
            

        }

        public IEnumerator<ComponentQty> GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}