using Alura.Challenge.Application.Models.InputModel;
using Alura.Challenge.Application.Models.ViewModel;

namespace Alura.Challenge.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        List<CategoriaViewModel> List();
        CategoriaViewModel FindById(long id);
        CategoriaViewModel Insert(CategoriaInputModel video);
        CategoriaViewModel Update(long id, CategoriaInputModel video);
        string Delete(long id);
    }
}