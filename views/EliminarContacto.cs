
using DigitalSolutions.Entities;

namespace DigitalSolutions.Views
{
    public class EliminarContacto : IMenuOption
    {
        private readonly GestorDeContactos _gestor;
        public EliminarContacto(GestorDeContactos gestor)
        {
            _gestor = gestor;
        }
        public void Select()
        {
            Console.WriteLine("\n\nEliminar Contacto\n");
            Console.Write("Ingrese el ID del contacto a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                OperacionEstatus estatus = _gestor.EliminarContacto(id);
                Console.WriteLine(estatus.Mensaje);

                if (estatus.Exito)
                {
                    Console.WriteLine("Para persistir los contactos eliminados debe seleccionar \"Guardar contactos\". Si desea revertirlos, seleccione \"Revertir contactos\".");
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("ID inválido.\n");
            }
        }
    }
}