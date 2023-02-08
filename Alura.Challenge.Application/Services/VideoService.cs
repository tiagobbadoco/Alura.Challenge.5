using System.Linq.Expressions;
using Alura.Challenge.Application.Models.InputModel;
using Alura.Challenge.Application.Models.ViewModel;
using Alura.Challenge.Application.Services.Interfaces;
using Alura.Challenge.Core.Entities;
using Alura.Challenge.Infrastructure.Data.Repositories.Interfaces;

namespace Alura.Challenge.Application.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly ICategoriaService _categoriaService;
        public VideoService(IVideoRepository videoRepository, ICategoriaService categoriaService)
        {
            _videoRepository = videoRepository;
            _categoriaService = categoriaService;
        }

        public List<VideoViewModel> List(string? nome)
        {
            Expression<Func<Video, bool>> filtro = x => true;

            if (nome != null)
                filtro = x => x.Titulo.Contains(nome);

            return _videoRepository.List().Where(filtro).Select(video => new VideoViewModel {
                Id = video.Id,
                Titulo = video.Titulo,
                Descricao = video.Descricao,
                Url = video.Url,
                Categoria = video.Categoria.Titulo
            }).ToList();
        }

        public VideoViewModel FindById(long id)
        {
            return _videoRepository.Query(x => x.Id == id).Select(video => new VideoViewModel {
                Id = video.Id,
                Titulo = video.Titulo,
                Descricao = video.Descricao,
                Url = video.Url,
                Categoria = video.Categoria.Titulo
            }).FirstOrDefault()?? throw new KeyNotFoundException("Não foi encontrado video com o id informado");
        }

        public VideoViewModel Insert(VideoInputModel video)
        {
            CategoriaViewModel _categoria = _categoriaService.FindById((long)video.CategoriaId);

            Video _video = new Video(video.Titulo, video.Descricao, video.Url, video.CategoriaId);

            _video = _videoRepository.Insert(_video);

            _videoRepository.SaveChanges();

            return new VideoViewModel {
                Id = _video.Id,
                Titulo = _video.Titulo,
                Descricao = _video.Descricao,
                Url = _video.Url,
                Categoria = _categoria.Titulo
            };
        }

        public VideoViewModel Update(long id, VideoInputModel video)
        {
            Video _video = _videoRepository.Query(x => x.Id == id).FirstOrDefault()?? throw new KeyNotFoundException("Não foi encontrado video com o id informado");

            _video.Update(video.Titulo, video.Descricao, video.Url, video.CategoriaId);

            _videoRepository.SaveChanges();

            return new VideoViewModel {
                Id = _video.Id,
                Titulo = _video.Titulo,
                Descricao = _video.Descricao,
                Url = _video.Url,
                Categoria = _video.Categoria.Titulo
            };
        }

        public string Delete(long id)
        {
            Video _video = _videoRepository.Query(x => x.Id == id).FirstOrDefault()?? throw new KeyNotFoundException("Não foi encontrado video com o id informado");

            _videoRepository.Delete(_video);

            _videoRepository.SaveChanges();

            return "Vídeo deleteado com sucesso";
        }
    }
}