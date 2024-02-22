using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaRealOrgArchivos
{
    public class ArchivoSecuencial
    {
        private const string filePath = "contactos.txt";

        // Método para agregar un nuevo contacto al archivo
        public static void AgregarContacto(Contacto contacto)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{contacto.Id},{contacto.Nombre},{contacto.Email},{contacto.Telefono}");
            }
        }

        // Método para buscar un contacto por su ID
        public static Contacto BuscarContacto(int id)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (int.Parse(parts[0]) == id)
                    {
                        return new Contacto
                        {
                            Id = int.Parse(parts[0]),
                            Nombre = parts[1],
                            Email = parts[2],
                            Telefono = parts[3]
                        };
                    }
                }
            }
            return null; // Retorna null si no se encuentra el contacto
        }
    }
}
