using System;
using DigitalSolutions.Entities;
using DigitalSolutions.Validation;

namespace DigitalSolutions.Views
{
    public class AgregarContacto : IMenuOption
    {
        private readonly GestorDeContactos _gestor;

        public AgregarContacto(GestorDeContactos gestor)
        {
            _gestor = gestor;
        }

        public void Select()
        {
            string nombre, telefono, email;
            bool esNombreValido = false, esTelefonoValido = false, esEmailValido = false;

            Console.WriteLine("\n\nAgregar Contactos\n");

            do
            {
                Console.Write("Ingrese el nombre del contacto: ");
                nombre = Console.ReadLine() ?? "";
                esNombreValido = Validacion.ValidarNombre(nombre);
                if (!esNombreValido) Console.WriteLine("Nombre no válido. Debe tener al menos 2 letras y no contener números.");
            } while (!esNombreValido);


            do
            {
                Console.Write("Ingrese el teléfono del contacto: ");
                telefono = Console.ReadLine() ?? "";
                esTelefonoValido = Validacion.ValidarTelefono(telefono);
                if (!esTelefonoValido) Console.WriteLine("Teléfono no válido. Debe contener solo números y caracteres de teléfono válidos, y no más de 15 caracteres.");
            } while (!esTelefonoValido);


            do
            {
                Console.Write("Ingrese el email del contacto: ");
                email = Console.ReadLine() ?? "";
                esEmailValido = Validacion.ValidarEmail(email);
                if (!esEmailValido) Console.WriteLine("Email no válido.");
            } while (!esEmailValido);

            var contacto = new Contacto
            {
                Nombre = nombre,
                Telefono = telefono,
                Email = email
            };

            _gestor.AgregarContacto(contacto);
            Console.WriteLine("\nContacto agregado exitosamente.");
            Console.WriteLine("Para persistir los contactos agregados debe seleccionar \"Guardar contactos\". Si desea revertirlos, seleccione \"Revertir contactos\".\n");
        }
    }
}
