using System;
namespace Nomenclatures
{
    public class ComponentQty
    {
        public IComponent Component { get; set; }

        public double Qty { get; set; }

        public Unit Unit { get; set; }

        public TimeSpan DureeConsomation {get; set;}

        public TimeSpan DureeUtilisationOptimale {get; set;}
    }
}