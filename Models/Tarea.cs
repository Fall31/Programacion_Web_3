namespace RazorPages.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
