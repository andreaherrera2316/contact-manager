using System.Text.Json;
using DigitalSolutions.Entities;

public class JsonSerializer : ISerializer<Contacto>
{
    public string Serialize(List<Contacto> contactos)
    {
        return System.Text.Json.JsonSerializer.Serialize(contactos, new JsonSerializerOptions { WriteIndented = true });
    }

    public List<Contacto> Deserialize(string json)
    {
        if (string.IsNullOrWhiteSpace(json) || string.IsNullOrEmpty(json))
        {
            return [];
        }
        try
        {
            List<Contacto>? contactos = System.Text.Json.JsonSerializer.Deserialize<List<Contacto>>(json);
            if (contactos == null)
            {
                throw new Exception();
            }
            return contactos;
        }
        catch (Exception)
        {
            throw new Exception("Hubo un error al extraer los Contactos del JSON ");
        }

    }
}
