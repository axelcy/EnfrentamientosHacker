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
    // -------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------------------------
    public IActionResult Index(string mensaje = "")
    {
        if(!Directory.Exists(this._environment.WebRootPath + @"\img\luchadores\"))
        {
            Directory.CreateDirectory(this._environment.WebRootPath + @"\img\luchadores");
        }
        ViewBag.ListaLuchadores = BD.ListarLuchadores();
        ViewBag.ListaRegistros = BD.ListarRegistros();
        
        ViewBag.mensaje = mensaje;
        return View("Index2");
    }
    public IActionResult Estadisticas()
    {
        ViewBag.ListaLuchadores = BD.ListarLuchadores();
        return View();
    }
    public IActionResult IniciarEnfrentamiento(string mensaje = "")
    {
        List<string> ListaRings = new List<string>();
        DirectoryInfo DirectorioRings = new DirectoryInfo(this._environment.WebRootPath + @"\img\rings\");
        foreach (var file in DirectorioRings.GetFiles()) ListaRings.Add(file.Name);

        List<string> RingsTexto = new List<string>();
        foreach (string item in ListaRings) RingsTexto.Add(item.Split('.')[0].Replace('-', ' '));

        ViewBag.ListaLuchadores = BD.ListarLuchadores();
        ViewBag.mensaje = mensaje;
        ViewBag.ListaRings = ListaRings;
        ViewBag.RingsTexto = RingsTexto;
        return View();
    }
    [HttpPost]
    public IActionResult Enfrentamiento(int idLuchador1, int idLuchador2, string ring)
    {
        Luchador luchador1 = BD.VerInfoLuchador(idLuchador1);
        Luchador luchador2 = BD.VerInfoLuchador(idLuchador2);
        if(idLuchador1 == -1 || idLuchador2 == -1){
            return RedirectToAction("IniciarEnfrentamiento", new {mensaje = "Es obligatorio elegir ambos luchadores!"});
        }
        if(idLuchador1 == idLuchador2){
            return RedirectToAction("IniciarEnfrentamiento", new {mensaje = $"<b>{luchador1.Nombre}</b> no quiere enfrentarse a sí mismo..."});
        }
        if(ring == null){
            return RedirectToAction("IniciarEnfrentamiento", new {mensaje = $"Es obligatorio elegir un ring!"});
        }

        int puntosGanador = 0, puntosPerdedor = 0;
        Luchador ganador = Funciones.ElegirGanador(luchador1, luchador2, ref puntosGanador, ref puntosPerdedor);
        Luchador perdedor = new Luchador();
        if (ganador == luchador1) perdedor = luchador2;
        else if (ganador == luchador2) perdedor = luchador1;
        else perdedor = ganador;

        ViewBag.Ring = ring;
        ViewBag.luchador1 = luchador1;
        ViewBag.luchador2 = luchador2;
        ViewBag.ganador = ganador;
        ViewBag.perdedor = perdedor;
        ViewBag.puntosGanador = puntosGanador;
        ViewBag.puntosPerdedor = puntosPerdedor;
        return View();
    }
    public IActionResult Registros()
    {
        ViewBag.ListaRegistros = BD.ListarRegistros();
        return View();
    }
    // -------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------------------------
    public IActionResult AñadirRegistro(int IdGanador, int IdPerdedor, int puntosGanador, int puntosPerdedor)
    {
        Luchador ganador = BD.VerInfoLuchador(IdGanador);
        Luchador perdedor = BD.VerInfoLuchador(IdPerdedor);
        
        Registro registro = new Registro();
        registro.Luchador1 = ganador.Nombre; registro.Luchador2 = perdedor.Nombre;
        registro.Puntuacion1 = puntosGanador; registro.Puntuacion2 = puntosPerdedor; 
        registro.Fecha = DateTime.Today;

        if (puntosGanador - puntosPerdedor == 0) registro.Diff = "0";
        else if (puntosGanador - puntosPerdedor == 1) registro.Diff = "1";
        else if (puntosGanador - puntosPerdedor <= 3) registro.Diff = "2";
        else registro.Diff = "3";

        string mensaje = "Enfrentamiento realizado con éxito! ";
        if (registro.Diff != "0")
        {
            mensaje += $"Ganador: <b>{ganador.Nombre}</b>";
            SumarVictoria(ganador.IdLuchador);
        }
        else mensaje += $"Fué un <b>Empate</b>!";

        BD.AñadirRegistro(registro);
        return RedirectToAction("IniciarEnfrentamiento", new {mensaje = mensaje});
    }
    public void SumarVictoria(int IdLuchador)
    {
        Luchador luchador = BD.VerInfoLuchador(IdLuchador);
        luchador.Victorias++;
        BD.ActualizarLuchador(luchador);
    }
    // -------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------------------------
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
            System.IO.File.Copy(wwwRootPath + @"\img\luchadores_iniciales\" + item.Foto, wwwRootPath + @"\img\luchadores\" + newName);
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
        Funciones.ActualizarRegistroDeModificacion(luchador.IdLuchador, true);
        return RedirectToAction("Index", new {mensaje = $"Luchador <b>{luchador.Nombre}</b> eliminado con éxito!"});
    }
    public IActionResult EliminarRegistro(int IdRegistro)
    {
        BD.EliminarRegistro(IdRegistro);
        return RedirectToAction("Index", new {mensaje = $"Registro #<b>{IdRegistro}</b> eliminado con éxito!"});
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
    public Registro DevolverRegistro(int IdRegistro)
    {
        Registro registro = BD.VerInfoRegistro(IdRegistro);
        return registro;
    }
    public Luchador[] DevolverGanadorPerdedor(int IdGanador, int IdPerdedor)
    {
        Luchador[] GanadorPerdedor = new Luchador[2];
        GanadorPerdedor[0] = BD.VerInfoLuchador(IdGanador);
        GanadorPerdedor[1] = BD.VerInfoLuchador(IdPerdedor);
        return GanadorPerdedor;
    }
    public List<Luchador> DevolverListaLuchadores()
    {
        List<Luchador> ListaLuchadores = BD.ListarLuchadores();
        return ListaLuchadores;
    }
    // -------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------------------------
    [HttpPost] public IActionResult ActualizarLuchador(Luchador luchador, IFormFile MyFile)
    {
        if(MyFile != null)
        {
            Luchador luchadorViejo = BD.VerInfoLuchador(luchador.IdLuchador);
            
            string wwwRootPath = this._environment.WebRootPath;
            string newName = luchador.IdLuchador + System.IO.Path.GetExtension(MyFile.FileName); // = id.* = 12.png

            System.IO.File.Delete(wwwRootPath + @"\img\luchadores\" + luchadorViejo.Foto);
            using (var stream = System.IO.File.Create(wwwRootPath + @"\img\luchadores\" + newName)) MyFile.CopyTo(stream);
            
            luchador.Foto = newName;
        }
        luchador = Funciones.LimitarEstadisticas(luchador, 250);
        BD.ActualizarLuchador(luchador);
        Funciones.ActualizarRegistroDeModificacion(luchador.IdLuchador);
        return RedirectToAction("Index", new {mensaje = "Luchador modificado con éxito!"});
    }
    public IActionResult LuchadorAutomatico()
    {
        string wwwRootPath = this._environment.WebRootPath;
        Luchador luchador = Funciones.AñadirLuchadorAutomatico();
        int id = BD.AgregarLuchador(luchador);
        string newName = id + ".png";
        System.IO.File.Copy(wwwRootPath + @"\img\no_profile_picture.png", wwwRootPath + @"\img\luchadores\" + newName);
        luchador = BD.VerInfoLuchador(id);
        luchador.Nombre = "Luchador aleatorio " + id;
        luchador.Foto = newName;
        BD.ActualizarLuchador(luchador);
        return RedirectToAction("Index", new {mensaje = "Luchador Automático añadido con éxito!"});
    }
    public IActionResult LuchadoresAutomaticos(int count) // PROBAR A VER Q ONDA
    {
        for (int i = 0; i < count; i++) LuchadorAutomatico();
        return RedirectToAction("Index", new {mensaje = $"<b>{count}</b> Luchadores Automáticos añadidos con éxito!"});
    }
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
        luchador = Funciones.LimitarEstadisticas(luchador, 250);
        BD.ActualizarLuchador(luchador);

        return RedirectToAction("Index", new {mensaje = "Luchador agregado con éxito!"});
    }
    // -------------------------------------------------------------------------------------------
    // -------------------------------------------------------------------------------------------
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
