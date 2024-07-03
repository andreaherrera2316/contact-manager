namespace DigitalSolutions.Views
{
    using System;
    using DigitalSolutions.Entities;

    public class CambiosNoGuardados : IMenuOption
    {
        private readonly GestorDeContactos _gestor;

        public CambiosNoGuardados(GestorDeContactos gestor)
        {
            _gestor = gestor;
        }

        public void Select()
        {
            Console.WriteLine("\n\nCambios No Guardados\n");
            ContactosDisponibles resultados = _gestor.ListarContactos();

            if (resultados.PorGuardar.Any() || resultados.PorEliminar.Any())
            {
                Console.WriteLine($"Contactos por guardar: {resultados.PorGuardar.Count()}");
                foreach (var contacto in resultados.PorGuardar)
                {
                    Console.WriteLine("\t" + contacto);
                }
                Console.WriteLine($"\nContactos por eliminar: {resultados.PorEliminar.Count()}");
                foreach (var contacto in resultados.PorEliminar)
                {
                    Console.WriteLine("\t" + contacto);
                }
            }
            else
            {
                Console.WriteLine("No hay cambios sin guardar.");
            }

            Console.WriteLine("");


        }
    }
}
