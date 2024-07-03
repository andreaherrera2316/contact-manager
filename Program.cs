using DigitalSolutions.Repositories;
using DigitalSolutions.Views;

IContactosRepo contactosRepo = new JsonContactosRepo();
GestorDeContactos gestorDeContactos = new GestorDeContactos(contactosRepo);

gestorDeContactos.CargarContactos();

bool salir = false;
var option1 = new AgregarContacto(gestorDeContactos);
var option2 = new BuscarContacto(gestorDeContactos);
var option3 = new ListarContactos(gestorDeContactos);
var option4 = new EliminarContacto(gestorDeContactos);
var option5 = new GuardarContactos(gestorDeContactos);
var option6 = new CargarContactos(gestorDeContactos);
var option7 = new RevertirContactos(gestorDeContactos);
var option8 = new CambiosNoGuardados(gestorDeContactos);

Console.WriteLine("\nBienvenido/a");

while (!salir)
{

    Console.WriteLine("\nMenú de Contactos:");
    Console.WriteLine("1. Agregar contacto");
    Console.WriteLine("2. Buscar contacto");
    Console.WriteLine("3. Listar contactos");
    Console.WriteLine("4. Eliminar contacto");
    Console.WriteLine("5. Guardar contactos");
    Console.WriteLine("6. Cargar contactos");
    Console.WriteLine("7. Revertir Contactos");
    Console.WriteLine("8. Cambios No Guardados");
    Console.WriteLine("9. Salir");
    Console.Write("Seleccione una opción: ");

    switch (Console.ReadLine())
    {
        case "1":
            option1.Select();
            break;
        case "2":
            option2.Select();
            break;
        case "3":
            option3.Select();
            break;
        case "4":
            option4.Select();
            break;
        case "5":
            option5.Select();
            break;
        case "6":
            option6.Select();
            break;
        case "7":
            option7.Select();
            break;
        case "8":
            option8.Select();
            break;
        case "9":
            salir = true;
            Console.WriteLine("!Hasta pronto!");
            break;
        default:
            Console.WriteLine("Opción no válida.\n\n");
            break;
    }

}
