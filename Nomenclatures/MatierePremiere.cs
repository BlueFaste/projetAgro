using System;

namespace Nomenclatures
{
    public class MatierePremiere : IComponent
    {
        public MatierePremiere() { }

        public MatierePremiere(Nomenclatures.Data.MatierePremiere mp)
        {
            Nom = mp.Nom;
            Id = mp.Id;
            Description = mp.Description;
            PourcentageHumidite = mp.PourcentageHumidite;
            PoidsUnitaire = mp.PoidsUnitaire;
            Bio = mp.Bio;
            DureeConservation = mp.DureeConservation;
            if(mp.Famille != null)
                Famille = new FamilleMatierePremiere
                {
                    Id = mp.Famille.Id,
                    DureeOptimaleUtilisation = mp.Famille.DureeOptimaleUtilisation
                };
        }

        public string Nom { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }

        public int PourcentageHumidite { get; set; }

        public double PoidsUnitaire { get; set; }

        public bool Bio {get; set;}

        public TimeSpan? DureeConservation { get; set; }

        public TimeSpan? DureeOptimaleUtilisation 
        { 
            get
            {
                if (Famille != null) return Famille.DureeOptimaleUtilisation;
                return null;
            }
        }

        public FamilleMatierePremiere Famille { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            if (Famille != null) Famille.Accept(visitor);
        }
    }
}