using System.Collections.Generic;

namespace Models
{
    public class CarritoCompra
    {
        // Propiedades automáticas
        public string IdCarrito { get; set; }
        public List<Item> Items { get; set; }

        public List<Pedido> Pedidos { get; set; }
        public double TotalPagar { get; set; }

        public CarritoCompra(string idCarrito, List<Item> items, double totalPagar)
        {
            IdCarrito = idCarrito;
            Items = items;
            TotalPagar = totalPagar;
        }


        public CarritoCompra() { 
            Items = new List<Item>();
            Pedidos = new List<Pedido>();
        }


        // Método adicional para agregar un ítem al carrito
        public void AgregarItem(Item item)
        {
            Items.Add(item);
            TotalPagar += item.SubTotal;  // Suponiendo que `Item` tiene un método `GetSubTotal()`
        }
    }
}
