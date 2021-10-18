using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nomenclatures.Data
{
    public abstract class Produit
    {
        public int Id { get; set; }

        [Required]   
        public string Nom{ get; set; }

        public string Description { get; set; }   

        public ICollection<ComponentQty> Composants { get; set; }
            = new List<ComponentQty>();
    }
}