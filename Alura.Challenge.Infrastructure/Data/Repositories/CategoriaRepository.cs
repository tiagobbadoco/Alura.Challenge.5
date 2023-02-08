using Alura.Challenge.Core.Entities;
using Alura.Challenge.Infrastructure.Data.Context;
using Alura.Challenge.Infrastructure.Data.Repositories.Interfaces;

namespace Alura.Challenge.Infrastructure.Data.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AluraFlixContext context) : base(context) { }
    }
}