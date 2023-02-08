using Alura.Challenge.Application.Models.InputModel;
using Alura.Challenge.Application.Models.ViewModel;
using Alura.Challenge.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alura.Challenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService) 
        {
            _videoService = videoService;
        }

        /// <summary>
        /// Exibe todos os vídeos disponíveis de acordo com os critérios de busca. É possível deixar os critérios em branco para listar tudo
        /// </summary>
        /// <param name="nomeContem">Nome ou parte do nome do vídeo a ser exibido</param>
        [HttpGet]
        [ProducesResponseType(typeof(List<VideoViewModel>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult List(string? nomeContem = null)
        {
            try
            {
                return new OkObjectResult(_videoService.List(nomeContem));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }    
        }

        /// <summary>
        /// Busca e exibe os dados do vídeo cujo ID informado
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<VideoViewModel>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult FindById(long id)
        {
            try
            {
                return new OkObjectResult(_videoService.FindById(id));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }  
        }

        /// <summary>
        /// Insere um novo vídeo
        /// </summary>
        /// <param name="video">Dados do vídeo</param>
        [HttpPost]
        [ProducesResponseType(typeof(VideoViewModel), 201)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(VideoInputModel video)
        {
            try
            {
                return new CreatedResult(HttpContext.Request.Path, _videoService.Insert(video));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }  
        }

        /// <summary>
        /// Altera os dados do vídeo segundo o ID informado
        /// </summary>
        /// <param name="id">Id do vídeo</param>
        /// <param name="video">Dados do vídeo</param>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VideoViewModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(long id, VideoInputModel video)
        {
            try
            {
            return new OkObjectResult(_videoService.Update(id, video));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }  
        }

        /// <summary>
        /// Deleta o video cujo ID informado
        /// </summary>
        /// <param name="id">Id do vídeo</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(long id)
        {
            try
            {
            return new OkObjectResult(_videoService.Delete(id));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }  
        }
    }
}