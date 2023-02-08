namespace Alura.Challenge.Application.Models.InputModel
{
    public class VideoInputModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Url { get; set; }
        public long? CategoriaId { get; set; }
    }
}