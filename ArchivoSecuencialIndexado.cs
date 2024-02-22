using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaRealOrgArchivos
{
    public class ArchivoSecuencialIndexado
    {
        private const string indexPath = "index.txt";
        private const string dataFilePath = "contactosIndexados.txt";

        // Método para agregar un nuevo contacto al archivo y su índice
        public static void AgregarContacto(Contacto contacto)
        {
            // Agregar al archivo de datos
            using (StreamWriter writer = new StreamWriter(dataFilePath, true))
            {
                writer.WriteLine($"{contacto.Id},{contacto.Nombre},{contacto.Email},{contacto.Telefono}");
            }

            // Agregar al índice
            using (StreamWriter writer = new StreamWriter(indexPath, true))
            {
                writer.WriteLine($"{contacto.Id},{writer.BaseStream.Position}");
            }
        }

        // Método para buscar un contacto por su ID
        public static Contacto BuscarContacto(int id)
        {
            using (StreamReader reader = new StreamReader(indexPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (int.Parse(parts[0]) == id)
                    {
                        long position = long.Parse(parts[1]);
                        using (StreamReader dataReader = new StreamReader(dataFilePath))
                        {
                            dataReader.BaseStream.Seek(position, SeekOrigin.Begin);
                            string dataLine = dataReader.ReadLine();
                            string[] dataParts = dataLine.Split(',');
                            return new Contacto
                            {
                                Id = int.Parse(dataParts[0]),
                                Nombre = dataParts[1],
                                Email = dataParts[2],
                                Telefono = dataParts[3]
                            };
                        }
                    }
                }
            }
            return null; // Retorna null si no se encuentra el contacto
        }
    }
}
