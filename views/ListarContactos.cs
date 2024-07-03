
namespace DigitalSolutions.Views
{
    public class ListarContactos : IMenuOption
    {
        private readonly GestorDeContactos _gestor;
        public ListarContactos(GestorDeContactos gestor)
        {
            _gestor = gestor;
        }
        public void Select()
        {
            Console.WriteLine("\n\nListar Contactos\n");
            var resultados = _gestor.ListarContactos();
            Console.WriteLine($"Contactos en records:{resultados.EnRecords.Count()}");
            foreach (var contacto in resultados.EnRecords)
            {
                Console.WriteLine("\t" + contacto);
            }
            Console.WriteLine($"\nContactos por guardar: {resultados.PorGuardar.Count()}");
            foreach (var contacto in resultados.PorGuardar)
            {
                Console.WriteLine("\t" + contacto);
            }
            Console.WriteLine($"\nContactos por eliminar: {resultados.PorEliminar.Count()}");
            foreach (var contacto in resultados.PorEliminar)
            {
                Console.WriteLine("\t" + contacto);
            }
            Console.WriteLine("");
        }
    }
}