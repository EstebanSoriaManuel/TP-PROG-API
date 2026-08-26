using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Testing.Controllers;

[ApiController]
[Route("[controller]")]
public class MascotaController : ControllerBase
{
  private static List<Mascota> ListMascotas = new List<Mascota>()
  {
    new Perro { ID = 1, Nombre = "Firu", Edad = 5, Raza = "caniche"},
    new Gato { ID = 2, Nombre = "Luna", Edad = 3, Color = "naranja"},
    new Perro { ID = 3, Nombre = "Rocky", Edad = 8, Raza = "labrador"},
    new Gato { ID = 4, Nombre = "Michi", Edad = 10, Color = "negro"},
  };


    private readonly ILogger<MascotaController> _logger;

    public MascotaController(ILogger<MascotaController> logger)
    {
        _logger = logger;
    }
    


    [HttpPost ("perro")]
    public IActionResult CreatePerro([FromBody] Perro NuevoPerro)
    {
        ListMascotas.Add(NuevoPerro);
        return Created($"/api/mascotas/perro/{NuevoPerro.ID}",NuevoPerro); //se aclara que se creo el recurso, y se da la url por si se desea consultar
    }

     [HttpPost ("gato")]
    public IActionResult CreateGato([FromBody] Gato NuevoGato)
    {
        ListMascotas.Add(NuevoGato);
        return Created($"/api/mascotas/gato/{NuevoGato.ID}",NuevoGato);
    }
    


    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(ListMascotas);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        foreach (Mascota M in ListMascotas)
        {
            if (M.ID == id)
            {
                return Ok(M);
            }
        }
        return NotFound();

    }


    [HttpGet ("/Mascota/mayores-a/{edad}")]
    public IActionResult MascotasMayores(int edad)
    {
        List<Mascota> listMayoresEdad = new List<Mascota>();
        
        foreach (Mascota m in ListMascotas)
        {
            if (m.Edad > edad)
            {
                listMayoresEdad.Add(m);
            }
        }
        return Ok(listMayoresEdad);
    }


    [HttpGet ("/Mascota/tipo/{tipo}")]
    public IActionResult MascotasPorTipo(string tipo)
    {
        List<Perro> listPerros = new List<Perro>();
        List<Gato> listGatos = new List<Gato>();
        foreach (Mascota m in ListMascotas)
        {
            if (m is Perro p) // Si es es un perro, lo guarda en p como tipo perro, para asi dsps poder guardarlo en la lista.
            {
                listPerros.Add(p);
            }
            if(m is Gato g)
            {
                listGatos.Add(g);
            }
        }

        if(tipo.ToLower() == "perro")
        {
            return Ok (listPerros);
        }
        if(tipo.ToLower() == "gato")
        {
            return Ok (listGatos);
        }
        return BadRequest("Ingrese un tipo de mascota válido");
    }



    [HttpPut("perro/{id}")]
    public IActionResult UpdatePerro(int id, [FromBody] Perro PerroActualizado)
    {
        Perro Perro = null;

        foreach (Mascota m in ListMascotas)
        {
            if (m is Perro p && p.ID == id) //Se verifica si la mascota es un Perro y si es, lo guarda en p (ya con tipo Perro).
            {
                Perro = p;
                break;
            }
        }

        if (Perro == null)
        {
            return NotFound("Perro no encontrado"); //codigo 404, No existe ese recurso.
        }

        Perro.Nombre = PerroActualizado.Nombre;
        Perro.Edad = PerroActualizado.Edad;
        Perro.Raza = PerroActualizado.Raza;

        return NoContent(); //204, salio bien todo, pero como es un put, no se devuelve nada.
    }


   [HttpPut("gato/{id}")]
    public IActionResult UpdateGato(int id, [FromBody] Gato gatoActualizado)
    {
        Gato gato = null;

        foreach (Mascota m in ListMascotas)
        {
            if (m is Gato g && g.ID == id) //Se verifica si la mascota es un gato y si es, lo guarda en g (ya con tipo gato).
            {
                gato = g;
                break;
            }
        }

        if (gato == null)
        {
        return NotFound("Gato no encontrado"); //codigo 404, No existe ese recurso.
        }

        gato.Nombre = gatoActualizado.Nombre;
        gato.Edad = gatoActualizado.Edad;
        gato.Color = gatoActualizado.Color;

        return NoContent(); //204, salio bien todo, pero como es un put, no se devuelve nada.
    }
      


    [HttpDelete ("{id}")]
    public IActionResult Delete(int id)
    {
        foreach (Mascota M in ListMascotas)
        {
            if(M.ID == id)
            {
                ListMascotas.Remove(M);
                return Ok("La Mascota se eliminó correctamente");
            }
        }
        return NotFound ("No se encontró la Mascota");
    }
}

