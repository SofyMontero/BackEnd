namespace Back.Proyecto.Shared.Models;

public class Producto
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string descripcion { get; set; }
    public decimal precio { get; set; }
    public int stock { get; set; }
    public string imagen_url { get; set; }
    public int marca_id { get; set; }
    public int categoria_id { get; set; }
    public int disponible { get; set; }
    public DateTime fecha_creacion { get; set; }
}