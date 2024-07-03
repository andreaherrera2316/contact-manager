using System.Text.RegularExpressions;

namespace DigitalSolutions.Validation
{
    public static class Validacion
    {
        public static bool ValidarNombre(string nombre)
        {
            return !string.IsNullOrEmpty(nombre) && Regex.IsMatch(nombre, @"^[a-zA-Z\s]{2,}$");
        }

        public static bool ValidarTelefono(string telefono)
        {
            return !string.IsNullOrEmpty(telefono) && Regex.IsMatch(telefono.Trim(), @"^[\d\s\+\-\(\)]{1,15}$");
        }


        public static bool ValidarEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && Regex.IsMatch(email,
                @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<=[-a-z0-9!#$%&'*+/=?^_`{|}~"
                + @"])@(((?!-)[a-z0-9-]{1,63}(?<!-)\.)+[a-z]{2,63}"
                + @"|([a-zA-Z‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌\.]{2,}))$");
        }
    }
}
