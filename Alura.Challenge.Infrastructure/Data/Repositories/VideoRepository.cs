using Alura.Challenge.Core.Entities;
using Alura.Challenge.Infrastructure.Data.Context;
using Alura.Challenge.Infrastructure.Data.Repositories.Interfaces;

namespace Alura.Challenge.Infrastructure.Data.Repositories
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(AluraFlixContext context) : base(context) { }
    }
}