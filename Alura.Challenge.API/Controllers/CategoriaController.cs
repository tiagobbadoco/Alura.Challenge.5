using Alura.Challenge.Application.Models.InputModel;
using Alura.Challenge.Application.Models.ViewModel;
using Alura.Challenge.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Alura.Challenge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        /// <summary>
        /// Exibe todos as categorias disponíveis
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriaViewModel>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult List()
        {
            try
            {
                return new OkObjectResult(_categoriaService.List());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }    
        }

        /// <summary>
        /// Busca e exibe os dados da categoria cujo ID informado
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<CategoriaViewModel>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult FindById(long id)
        {
            try
            {
                return new OkObjectResult(_categoriaService.FindById(id));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }  
        }

        /// <summary>
        /// Insere uma nova categoria
        /// </summary>
        /// <param name="categoria">Dados da categoria</param>
        [HttpPost]
        [ProducesResponseType(typeof(CategoriaViewModel), 201)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult Insert(CategoriaInputModel categoria)
        {
            try
            {
                return new CreatedResult(HttpContext.Request.Path, _categoriaService.Insert(categoria));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }  
        }

        /// <summary>
        /// Altera os dados da categoria segundo o ID informado
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <param name="categoria">Dados da categoria</param>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CategoriaViewModel), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult Update(long id, CategoriaInputModel categoria)
        {
            try
            {
            return new OkObjectResult(_categoriaService.Update(id, categoria));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }  
        }

        /// <summary>
        /// Deleta a categoria cujo ID informado
        /// </summary>
        /// <param name="id">Id da categoria</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(long id)
        {
            try
            {
            return new OkObjectResult(_categoriaService.Delete(id));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }  
        }
    }
}