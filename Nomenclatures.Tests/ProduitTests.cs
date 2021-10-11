using NUnit.Framework;

namespace Nomenclatures.Tests
{
    public class ProduitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Produit_AddOne()
        {
           _produit.add(IComponent, Quantity, Unit);
        }
    }
}