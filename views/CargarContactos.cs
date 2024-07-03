
using DigitalSolutions.Entities;

namespace DigitalSolutions.Views
{
    public class CargarContactos : IMenuOption
    {
        private readonly GestorDeContactos _gestor;
        public CargarContactos(GestorDeContactos gestor)
        {
            _gestor = gestor;
        }
        public void Select()
        {
            Console.WriteLine("\n\nCargar Contactos\n");
            OperacionEstatus estatus = _gestor.CargarContactos();
            Console.WriteLine(estatus.Mensaje + "\n");
        }
    }
}