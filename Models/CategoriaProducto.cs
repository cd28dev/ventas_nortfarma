namespace Models
{
    public class CategoriaProducto
    {
        // Propiedades automáticas
        public string IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        // Constructor vacío
        public CategoriaProducto() { }

        // Constructor lleno
        public CategoriaProducto(string idCategoria, string descripcion, string estado)
        {
            IdCategoria = idCategoria;
            Descripcion = descripcion;
            Estado = estado;
        }
    }
}
