using Alura.Challenge.Core.Interfaces;

namespace Alura.Challenge.Core.Entities
{
    public class Categoria : IBaseEntity
    {
        public long Id { get; }
        public string Titulo { get; private set; }
        public string Cor { get; private set; }

        public Categoria() { }

        public Categoria(string titulo, string cor)
        {
            Titulo = titulo;
            Cor = cor;
        }

        public void Update(string titulo, string cor)
        {
            Titulo = titulo ?? Titulo;
            Cor = cor ?? Cor;
        }
    }
}