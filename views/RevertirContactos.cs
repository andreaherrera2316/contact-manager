namespace DigitalSolutions.Views
{
    using System;
    using DigitalSolutions.Entities;

    public class RevertirContactos : IMenuOption
    {
        private readonly GestorDeContactos _gestor;

        public RevertirContactos(GestorDeContactos gestor)
        {
            _gestor = gestor;
        }

        public void Select()
        {
            Console.WriteLine("\n\nRevertir Contactos\n");
            OperacionEstatus estatus = _gestor.RevertirContactos();
            Console.WriteLine(estatus.Mensaje + "\n");
        }
    }
}
