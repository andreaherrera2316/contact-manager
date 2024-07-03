namespace DigitalSolutions.Entities
{

    public class OperacionEstatus
    {
        public bool Exito;
        public string Mensaje;

        public OperacionEstatus(bool exito, string mensaje)
        {
            Exito = exito;
            Mensaje = mensaje;
        }


    }


}