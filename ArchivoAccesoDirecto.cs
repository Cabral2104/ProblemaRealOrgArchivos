using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemaRealOrgArchivos
{
    public class ArchivoAccesoDirecto
    {
        private const string filePath = "contactos.dat";

        // Método para agregar un nuevo contacto al archivo
        public static void AgregarContacto(Contacto contacto)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Append)))
            {
                writer.Write(contacto.Id);
                writer.Write(contacto.Nombre);
                writer.Write(contacto.Email);
                writer.Write(contacto.Telefono);
            }
        }

        // Método para buscar un contacto por su ID
        public static Contacto BuscarContacto(int id)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int currentId = reader.ReadInt32();
                    string nombre = reader.ReadString();
                    string email = reader.ReadString();
                    string telefono = reader.ReadString();

                    if (currentId == id)
                    {
                        return new Contacto
                        {
                            Id = currentId,
                            Nombre = nombre,
                            Email = email,
                            Telefono = telefono
                        };
                    }
                }
            }
            return null; // Retorna null si no se encuentra el contacto
        }
    }
}
