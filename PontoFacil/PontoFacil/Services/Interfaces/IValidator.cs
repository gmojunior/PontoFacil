using System.Text;

namespace PontoFacil.Services.Interfaces
{
    public interface IValidator
    {
        bool IsValid();
        StringBuilder MessagesValidator { get; }
    }
}
