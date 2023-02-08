using Alura.Challenge.Application.Models.InputModel;
using Alura.Challenge.Application.Models.ViewModel;
using Alura.Challenge.Application.Services.Interfaces;
using Alura.Challenge.Core.Entities;
using Alura.Challenge.Infrastructure.Data.Repositories.Interfaces;

namespace Alura.Challenge.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public List<CategoriaViewModel> List()
        {
            return _categoriaRepository.List().Select(categoria => new CategoriaViewModel {
                Id = categoria.Id,
                Titulo = categoria.Titulo,
                Cor = categoria.Cor
            }).ToList();
        }

        public CategoriaViewModel FindById(long id)
        {
            return _categoriaRepository.Query(x => x.Id == id).Select(categoria => new CategoriaViewModel {
                Id = categoria.Id,
                Titulo = categoria.Titulo,
                Cor = categoria.Cor
            }).FirstOrDefault()?? throw new KeyNotFoundException("Não foi encontrada uma categoria com o id informado");
        }

        public CategoriaViewModel Insert(CategoriaInputModel categoria)
        {
            Categoria _categoria = new Categoria(categoria.Titulo, categoria.Cor);

            _categoriaRepository.Insert(_categoria);

            _categoriaRepository.SaveChanges();

            return new CategoriaViewModel {
                Id = _categoria.Id,
                Titulo = _categoria.Titulo,
                Cor = _categoria.Cor
            };
        }

        public CategoriaViewModel Update(long id, CategoriaInputModel categoria)
        {
            Categoria _categoria = _categoriaRepository.Query(x => x.Id == id).FirstOrDefault()?? throw new KeyNotFoundException("Não foi encontrada uma categoria com o id informado");

            _categoria.Update(categoria.Titulo, categoria.Cor);

            _categoriaRepository.SaveChanges();

            return new CategoriaViewModel {
                Id = _categoria.Id,
                Titulo = _categoria.Titulo,
                Cor = _categoria.Cor
            };
        }

        public string Delete(long id)
        {
            Categoria _categoria = _categoriaRepository.Query(x => x.Id == id).FirstOrDefault()?? throw new KeyNotFoundException("Não foi encontrada uma categoria com o id informado");

            _categoriaRepository.Delete(_categoria);

            _categoriaRepository.SaveChanges();

            return "Categoria deleteada com sucesso";
        }
    }
}