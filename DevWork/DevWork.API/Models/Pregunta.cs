namespace Proyecto.API.Models
{
    public class Pregunta
    {
        public int Id { get; set; }
        public int PublicacionId { get; set; }
        public string TextoPregunta { get; set; } = string.Empty;
    }
}
