using System.Threading.Tasks;
namespace Nomenclatures.Produit
{
    public interface IComposite
    {
        Task Add(IComponent _iComponent);
        Task Remove();
    }
}