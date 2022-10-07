using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EnfrentamientosHacker.Models;

namespace EnfrentamientosHacker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    // ------------------------------------------------------------
    public IActionResult Index()
    {
        ViewBag.ListaLuchadores = BD.ListarLuchadores();
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
        return RedirectToAction("Index");
    }
    public IActionResult DuplicarRoster()
    {
        BD.DuplicarRoster();
        return RedirectToAction("Index");
    }
    public IActionResult EliminarLuchador(int IdLuchador)
    {
        BD.EliminarLuchador(IdLuchador);
        return RedirectToAction("Index");
    }
    public IActionResult AgregarLuchador(Luchador luchador)
    {
        BD.AgregarLuchador(luchador);
        return RedirectToAction("Index");
    }
    
    public IActionResult ElimiarListaLuchadores()
    {
        BD.ElimiarListaLuchadores();
        return RedirectToAction("Index");
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
        /* if(MyFile.Length>0)
        {
            jugador.Foto = MyFile.FileName;
            string wwwRootFile = this.Environment.ContentRootPath + @"\wwwroot\bd\fotos\" + MyFile.FileName;
            using (var stream = System.IO.File.Create(wwwRootFile))
            {
                MyFile.CopyToAsync(stream);
            }
        }
        BD.AgregarJugador(jugador);
        return RedirectToAction("VerDetalleEquipo","Home", new {idEquipo = jugador.IdEquipo}); */
        
        
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
