using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_v1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Cliente> clientes = new Dictionary<string, Cliente>();
            string json = File.ReadAllText("clientes.json");

            // Deserializamos el JSON a una lista de objetos Cliente
            List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);

            // Creamos la tabla hash para almacenar los clientes
            Dictionary<int, Cliente> tablaHash = new Dictionary<int, Cliente>();

            // Agregamos los clientes a la tabla hash
            foreach (Cliente cliente in clientes)
            {
                tablaHash.Add(cliente.Id, cliente);
            }

            // Ejemplo de búsqueda de un cliente a partir de su identificador
            int idBuscado = 123;
            if (tablaHash.ContainsKey(idBuscado))
            {
                Cliente clienteEncontrado = tablaHash[idBuscado];
                Console.WriteLine("Cliente encontrado: " + clienteEncontrado.Nombre);
            }
            else
            {
                Console.WriteLine("Cliente no encontrado");
            }
        }
    }
    class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string CodigoPostal { get; set; }
    }


}

