using Alura.Challenge.Application.Models.InputModel;
using Alura.Challenge.Application.Models.ViewModel;

namespace Alura.Challenge.Application.Services.Interfaces
{
    public interface IVideoService
    {
        List<VideoViewModel> List(string? nome);
        VideoViewModel FindById(long id);
        VideoViewModel Insert(VideoInputModel video);
        VideoViewModel Update(long id, VideoInputModel video);
        string Delete(long id);
    }
}