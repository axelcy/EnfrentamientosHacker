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
        ViewBag.ListaLuchadores = BD.ListarLuchadores(); // String.Empty
        ViewBag.mensaje = mensaje;
        return View();
    }
    public IActionResult IniciarEnfrentamiento()
    {
        return View();
    }
    public IActionResult Registros()
    {
        ViewBag.ListaRegistros = BD.ListarRegistros();
        return View();
    }
    // ------------------------------------------------------------
    public IActionResult ReiniciarJuego()
    {
        BD.ReiniciarJuego();
        return RedirectToAction("Index", new {mensaje = "Juego reiniciado con éxito!"});
    }
    public IActionResult DuplicarRoster()
    {
        BD.DuplicarRoster();
        return RedirectToAction("Index", new {mensaje = "Roster inicial duplicado con éxito!"});
    }
    public IActionResult EliminarLuchador(int IdLuchador)
    {
        Luchador luchador = BD.VerInfoLuchador(IdLuchador);
        BD.EliminarLuchador(IdLuchador);
        return RedirectToAction("Index", new {mensaje = $"Luchador <b>{luchador.Nombre}</b> eliminado éxito!"});
    }
    
    public IActionResult ElimiarListaLuchadores()
    {
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
