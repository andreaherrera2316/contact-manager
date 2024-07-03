namespace DigitalSolutions.Entities
{

    public class ContactosDisponibles
    {

        public List<Contacto> EnRecords;
        public List<Contacto> PorGuardar;

        public List<Contacto> PorEliminar;
        public ContactosDisponibles(List<Contacto> enRecords, List<Contacto> porGuardar, List<Contacto> porEliminar)
        {

            EnRecords = enRecords;
            PorGuardar = porGuardar;
            PorEliminar = porEliminar;

        }


    }


}