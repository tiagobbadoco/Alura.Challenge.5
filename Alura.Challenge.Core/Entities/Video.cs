using Alura.Challenge.Core.Interfaces;

namespace Alura.Challenge.Core.Entities
{
    public class Video : IBaseEntity
    {
        public long Id { get; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Url { get; private set; }

        public virtual Categoria Categoria { get; private set; }
        public long CategoriaId { get; private set; }

        public Video() { }
        public Video(string titulo, string descricao, string url, long? categoriaId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Url = url;
            CategoriaId = categoriaId ?? 1;
        }

        public void Update(string? titulo, string? descricao, string? url, long? categoriaId)   
        {
            Titulo = titulo ?? Titulo;
            Descricao = descricao ?? Descricao;
            Url = url ?? Url;
            CategoriaId = categoriaId ?? CategoriaId;
        }
    }
}