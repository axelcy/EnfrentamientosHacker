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
        // hacer un modal estatico con una funcion para comprobar si el luchador ingresado está correcto
        if(MyFile.Length>0)
        {
            luchador.Foto = MyFile.FileName;
            string wwwRootFile = this._environment.WebRootPath + @"\img\luchadores\" + MyFile.FileName;
            using (var stream = System.IO.File.Create(wwwRootFile)) MyFile.CopyToAsync(stream);
        }
        else luchador.Foto = "no_profile_picture";

        BD.AgregarLuchador(luchador);
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
