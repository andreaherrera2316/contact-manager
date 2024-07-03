namespace DigitalSolutions.Views
{
    using System;
    using System.Linq;
    using DigitalSolutions.Validation;

    public class BuscarContacto : IMenuOption
    {
        private readonly GestorDeContactos _gestor;
        public BuscarContacto(GestorDeContactos gestor)
        {
            _gestor = gestor;
        }

        public void Select()
        {
            string busqueda;
            bool isValid;

            Console.WriteLine("\n\nBuscar Contactos\n");

            do
            {
                Console.WriteLine("El termino de búsqueda puede ser un numero de teléfono o un nombre");
                Console.Write("Ingrese el término de búsqueda: ");
                busqueda = Console.ReadLine() ?? "";
                isValid = ValidarBusqueda(busqueda);
                if (!isValid)
                {
                    Console.WriteLine("Búsqueda no válida. Ingrese un nombre sin números o un teléfono sin letras.\n");
                }
            } while (!isValid);

            var resultados = _gestor.BuscarContacto(busqueda);

            if (resultados.EnRecords.Any() || resultados.PorGuardar.Any() || resultados.PorEliminar.Any())
            {
                Console.WriteLine("\nContactos Encontrados");

                Console.WriteLine($"Contactos encontrados en records:{resultados.EnRecords.Count()}");
                foreach (var contacto in resultados.EnRecords)
                {
                    Console.WriteLine("\t" + contacto);
                }
                Console.WriteLine($"\nContactos encontrados en por guardar: {resultados.PorGuardar.Count()}");
                foreach (var contacto in resultados.PorGuardar)
                {
                    Console.WriteLine("\t" + contacto);
                }
                Console.WriteLine($"\nContactos encontrados en por eliminar: {resultados.PorEliminar.Count()}");
                foreach (var contacto in resultados.PorEliminar)
                {
                    Console.WriteLine("\t" + contacto);
                }
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("\nNo se encontraron contactos.\n");
            }
        }

        private bool ValidarBusqueda(string busqueda)
        {
            bool esNombre = Validacion.ValidarNombre(busqueda);
            bool esTelefono = Validacion.ValidarTelefono(busqueda);
            return esNombre || esTelefono;
        }
    }
}
