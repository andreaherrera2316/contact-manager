
using DigitalSolutions.Entities;

namespace DigitalSolutions.Views
{
    public class GuardarContactos : IMenuOption
    {
        private readonly GestorDeContactos _gestor;
        public GuardarContactos(GestorDeContactos gestor)
        {
            _gestor = gestor;
        }
        public void Select()
        {
            Console.WriteLine("\n\nGuardar Contactos\n");
            OperacionEstatus estatus = _gestor.GuardarContactos();
            Console.WriteLine(estatus.Mensaje + "\n");
        }
    }
}