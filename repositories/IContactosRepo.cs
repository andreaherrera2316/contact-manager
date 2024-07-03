using DigitalSolutions.Entities;

namespace DigitalSolutions.Repositories
{
    public interface IContactosRepo
    {
        void Agregar(Contacto contacto);
        void Eliminar(int id);
        List<Contacto> Cargar();
    }
}
