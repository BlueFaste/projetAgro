using System;
namespace Nomenclatures.Tests
{
    public class DateConsommation
    {
        public void Date_Consommation_Exist()
        {
             var paquetPitchs = new ProduitFini();
            var pitch = new ProduitSemiFini();
            var farine = new MatierePremiere();
            var chocolat = new MatierePremiere();

            paquetPitchs.Add(pitch, 8, Unit.Piece);
            pitch.Add(farine, 100, Unit.Gram, new TimeSpan(15, 2), new TimeSpan(15, 2));
            pitch.Add(chocolat, 20, Unit.Gram, new TimeSpan(15, 2), new TimeSpan(15, 2));

            pitch.CalculateDateLimiteConsomation(pitch);
        }
    }
}