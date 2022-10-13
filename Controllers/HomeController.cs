using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EnfrentamientosHacker.Models;

namespace EnfrentamientosHacker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IWebHostEnvironment _environment;
    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }
    // ------------------------------------------------------------
    public IActionResult Index(string mensaje = "")
    {
        if(!Directory.Exists(this._environment.WebRootPath + @"\img\luchadores\"))
        {
            Directory.CreateDirectory(this._environment.WebRootPath + @"\img\luchadores");
        }
        ViewBag.ListaLuchadores = BD.ListarLuchadores();
        ViewBag.mensaje = mensaje;
        return View();
    }
    public IActionResult IniciarEnfrentamiento(string mensaje = "")
    {
        List<string> ListaRings = new List<string>();
        DirectoryInfo DirectorioRings = new DirectoryInfo(this._environment.WebRootPath + @"\img\rings\");
        foreach (var file in DirectorioRings.GetFiles()) ListaRings.Add(file.Name); // foreach file in folder Add file.name

        List<string> RingsTexto = new List<string>();
        //foreach (var file in DirectorioRings.GetFiles()) RingsTexto.Add(System.IO.Path.GetFileNameWithoutExtension(file))
        // esto para el nombre en el texto del carrusel
        ViewBag.ListaLuchadores = BD.ListarLuchadores();
        ViewBag.mensaje = mensaje;
        ViewBag.Rings = ListaRings;
        return View();
    }
    public IActionResult Registros()
    {
        ViewBag.ListaRegistros = BD.ListarRegistros();
        return View();
    }
    public IActionResult Enfrentamiento(Luchador luchador1, Luchador luchador2, string ring = "Ring_1.png")
    {
        if(luchador1 == null || luchador2 == null){
            return RedirectToAction("IniciarEnfrentamiento", new {mensaje = "Es obligatorio ingresar ambos luchadores!"});
        }
        ViewBag.Ring = ring;
        ViewBag.luchador1 = luchador1;
        ViewBag.luchador2 = luchador2;
        return View();
    }
    // ------------------------------------------------------------
    public IActionResult ReiniciarJuego()
    {
        List<Luchador> ListaLuchadores = BD.ListarLuchadores();
        string wwwRootPath = this._environment.WebRootPath;
        foreach (Luchador item in ListaLuchadores) System.IO.File.Delete(wwwRootPath + @"\img\luchadores\" + item.Foto);

        BD.ReiniciarJuego();
        ListaLuchadores = BD.ListarLuchadores();
        string newName = String.Empty;
        foreach (Luchador item in ListaLuchadores)
        {
            newName = item.IdLuchador + System.IO.Path.GetExtension(item.Foto);
            System.IO.File.Copy(wwwRootPath + @"\img\luchadores_iniciales\" + item.Foto, wwwRootPath + @"\img\luchadores\" + newName);
            item.Foto = newName;
            BD.ActualizarLuchador(item);
        }
        
        return RedirectToAction("Index", new {mensaje = "Juego reiniciado con éxito!"});
    }
    public IActionResult DuplicarRoster()
    {
        List<Luchador> LuchadoresDuplicados = BD.DuplicarRoster();
        string wwwRootPath = this._environment.WebRootPath;
        string newName = String.Empty;
        foreach (Luchador item in LuchadoresDuplicados)
        {
            newName = item.IdLuchador + System.IO.Path.GetExtension(item.Foto);
            System.IO.File.Copy(wwwRootPath + @"\img\luchadores_iniciales/" + item.Foto, wwwRootPath + @"\img\luchadores\" + newName);
            item.Foto = newName;
            BD.ActualizarLuchador(item);
        }

        return RedirectToAction("Index", new {mensaje = "Roster inicial duplicado con éxito!"});
    }
    public IActionResult EliminarLuchador(int IdLuchador)
    {
        Luchador luchador = BD.VerInfoLuchador(IdLuchador);
        System.IO.File.Delete(this._environment.WebRootPath + @"\img\luchadores\" + luchador.Foto);
        BD.EliminarLuchador(IdLuchador);
        return RedirectToAction("Index", new {mensaje = $"Luchador <b>{luchador.Nombre}</b> eliminado éxito!"});
    }
    
    public IActionResult ElimiarListaLuchadores()
    {
        List<Luchador> ListaLuchadores = BD.ListarLuchadores();
        string wwwRootPath = this._environment.WebRootPath;
        foreach (Luchador item in ListaLuchadores) System.IO.File.Delete(wwwRootPath + @"\img\luchadores\" + item.Foto);
        BD.ElimiarListaLuchadores();
        return RedirectToAction("Index", new {mensaje = "Lista de luchadores eliminada con éxito!"});
    }
    // ------------------------------------------------------------
    public Luchador DevolverLuchador(int IdLuchador)
    {
        Luchador luchador = BD.VerInfoLuchador(IdLuchador);
        return luchador;
    }
    // ------------------------------------------------------------
    [HttpPost] public IActionResult GuardarLuchador(Luchador luchador, IFormFile MyFile)
    {
        DateTime defaultDate = new DateTime(0001, 01, 01);
        if(luchador.Nombre == null || luchador.FechaNacimiento == defaultDate){
            return RedirectToAction("Index", new {mensaje = "Es obligatorio ingresar <b>nombre</b> y <b>fecha de nacimiento</b>!"});
        }
        DateTime minDate = new DateTime(1753, 01, 01), maxDate = new DateTime(9999, 12, 31);
        if (luchador.FechaNacimiento > maxDate || luchador.FechaNacimiento < minDate){
            return RedirectToAction("Index", new {mensaje = $"La fecha ingresada debe estar entre los valores <b>{minDate.ToShortDateString()}</b> y <b>{maxDate.ToShortDateString()}</b>!"});
        }

        if(MyFile != null) luchador.Foto = MyFile.FileName;
        else luchador.Foto = "no_profile_picture.png";

        int id = BD.AgregarLuchador(luchador);

        string wwwRootPath = this._environment.WebRootPath;
        string newName = String.Empty;
        if(MyFile != null)
        {
            newName = id + System.IO.Path.GetExtension(MyFile.FileName); // = id.* = 12.png
            using (var stream = System.IO.File.Create(wwwRootPath + @"\img\luchadores\" + newName)) MyFile.CopyToAsync(stream);            
        }
        else {
            newName = id + ".png";
            System.IO.File.Copy(wwwRootPath + @"\img\no_profile_picture.png", wwwRootPath + @"\img\luchadores\" + newName);
        }
        luchador = BD.VerInfoLuchador(id);
        luchador.Foto = newName;
        
        BD.ActualizarLuchador(luchador);
        return RedirectToAction("Index", new {mensaje = "Luchador agregado con éxito!"});
    }
    // ------------------------------------------------------------------------------------------------------------
    // ------------------------------------------------------------------------------------------------------------
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
