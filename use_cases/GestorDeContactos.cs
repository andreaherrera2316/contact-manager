using System.Linq;
using DigitalSolutions.Repositories;
using DigitalSolutions.Entities;

public class GestorDeContactos
{
    private readonly IContactosRepo _repo;
    private List<Contacto> _recordContactos = new List<Contacto>();
    private List<int> _contactosEliminados = new List<int>();
    private List<Contacto> _contactosAgregados = new List<Contacto>();

    private int _maxId;

    public GestorDeContactos(IContactosRepo repo)
    {
        _repo = repo;
    }

    public OperacionEstatus CargarContactos()
    {
        try
        {
            _recordContactos = _repo.Cargar();
            _maxId = _recordContactos.Count > 0 ? _recordContactos.Max(c => c.Id) : 0;
            return new OperacionEstatus(true, "Contactos cargados exitosamente.");
        }
        catch (Exception)
        {
            return new OperacionEstatus(false, $"Error al cargar contactos/");
        }
    }

    public OperacionEstatus AgregarContacto(Contacto contacto)
    {
        try
        {
            _maxId++;
            contacto.Id = _maxId;
            _contactosAgregados.Add(contacto);
            return new OperacionEstatus(true, "Contacto agregado exitosamente.");
        }
        catch (Exception ex)
        {
            return new OperacionEstatus(false, $"Error al agregar contacto: {ex.Message}");
        }
    }

    public ContactosDisponibles BuscarContacto(string busqueda)
    {
        var enRecords = _recordContactos.Where(c => c.Nombre.Contains(busqueda) || c.Telefono.Contains(busqueda)).ToList();
        var porGuardar = _contactosAgregados.Where(c => c.Nombre.Contains(busqueda) || c.Telefono.Contains(busqueda)).ToList();
        var porEliminar = enRecords.Where(c => _contactosEliminados.Contains(c.Id)).ToList();

        return new ContactosDisponibles(enRecords, porGuardar, porEliminar);
    }

    public ContactosDisponibles ListarContactos()
    {
        var enRecords = _recordContactos.Except(_recordContactos.Where(c => _contactosEliminados.Contains(c.Id))).ToList();
        var porGuardar = _contactosAgregados;
        var porEliminar = _recordContactos.Where(c => _contactosEliminados.Contains(c.Id)).ToList();

        return new ContactosDisponibles(enRecords, porGuardar, porEliminar);
    }

    public OperacionEstatus EliminarContacto(int id)
    {
        bool existeEnRecord = _recordContactos.Any(c => c.Id == id);
        bool existeEnAgregados = _contactosAgregados.Any(c => c.Id == id);


        if (existeEnRecord)
        {
            try
            {
                _contactosEliminados.Add(id);
                return new OperacionEstatus(true, "Contacto eliminado exitosamente.");
            }
            catch (Exception)
            {
                return new OperacionEstatus(false, $"Error al eliminar contacto.");
            }
        }
        else if (existeEnAgregados)
        {
            return eliminarDeAgregados(id);

        }

        return new OperacionEstatus(false, "El contacto no existe.");
    }

    private OperacionEstatus eliminarDeAgregados(int id)
    {
        try
        {
            var contactoEliminado = _contactosAgregados.FirstOrDefault(c => c.Id == id);
            if (contactoEliminado != null)
            {
                _contactosAgregados.Remove(contactoEliminado);
                return new OperacionEstatus(true, "Eliminado exitosamente de los contactos agregados.");
            }
        }
        catch (Exception)
        {
            return new OperacionEstatus(false, $"Error al eliminar contacto.");
        }
        return new OperacionEstatus(false, "El contacto no existe.");
    }

    public OperacionEstatus GuardarContactos()
    {
        bool noHayCambios = _contactosAgregados.Count() == 0 && _contactosEliminados.Count() == 0;
        if (noHayCambios)
        {
            return new OperacionEstatus(true, "No hay cambios, los contactos estan al dia.");

        }

        return eliminacionPermanente() ??
        guardarPermanente() ??
        new OperacionEstatus(true, "Contactos guardados exitosamente.");
    }

    public OperacionEstatus RevertirContactos()
    {
        _contactosAgregados.Clear();
        _contactosEliminados.Clear();
        return new OperacionEstatus(true, "Se han descartado los cambios.");

    }

    private OperacionEstatus? eliminacionPermanente()
    {
        try
        {
            foreach (var contactoID in _contactosEliminados)
            {
                _repo.Eliminar(contactoID);
            }

            _recordContactos.RemoveAll(c => _contactosEliminados.Contains(c.Id));
            _contactosEliminados.Clear();
            return null;
        }
        catch (Exception ex)
        {
            return new OperacionEstatus(false, $"Error al eliminar contactos: {ex.Message}");
        }
    }

    private OperacionEstatus? guardarPermanente()
    {

        try
        {
            foreach (var contacto in _contactosAgregados)
            {
                _repo.Agregar(contacto);
            }

            _recordContactos.AddRange(_contactosAgregados);
            _contactosAgregados.Clear();
            return null;
        }
        catch (Exception ex)
        {
            return new OperacionEstatus(false, $"Error al agregar contactos: {ex.Message}");
        }
    }


}

