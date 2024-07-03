using DigitalSolutions.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace DigitalSolutions.Repositories
{
    public class JsonContactosRepo : IContactosRepo
    {
        private readonly string _directorio;
        private readonly ISerializer<Contacto> _serializer;

        public JsonContactosRepo(string folderPath = "../../../contactos")
        {
            _directorio = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderPath));
            VerificarDirectorio(_directorio);
            _serializer = new JsonSerializer();
        }

        public void Agregar(Contacto contacto)
        {
            VerificarDirectorio(_directorio);
            string archivo = ArchivoDelContacto(contacto.Id);
            string json = _serializer.Serialize(new List<Contacto> { contacto });
            File.WriteAllText(archivo, json);
        }

        public void Eliminar(int id)
        {
            VerificarDirectorio(_directorio);
            string archivo = ArchivoDelContacto(id);
            File.Delete(archivo);
        }

        public List<Contacto> Cargar()
        {
            VerificarDirectorio(_directorio);
            var contactos = new List<Contacto>();

            foreach (var file in Directory.GetFiles(_directorio, "contacto_*.json"))
            {
                string json = File.ReadAllText(file);
                var loadedContacts = _serializer.Deserialize(json);
                contactos.AddRange(loadedContacts);
            }

            return contactos;
        }

        private void VerificarDirectorio(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private string ArchivoDelContacto(int id)
        {
            return Path.Combine(_directorio, $"contacto_{id}.json");
        }
    }
}
