namespace EnfrentamientosHacker.Models;

public class Registro
{
    private int _idRegistro;
    private string _luchador1;
    private int _puntuacion1;
    private string _luchador2;
    private int _puntuacion2;
    private string _diff;
    private DateTime _fecha;
    
    public Registro(int idRegistro, string luchador1, int puntuacion1, string luchador2, int puntuacion2, string diff, DateTime fecha, string puntuaciones)
    {
        _idRegistro = idRegistro;
        _luchador1 = luchador1;
        _luchador2 = luchador2;
        _diff = diff;
        _fecha = fecha;
        _puntuacion1 = puntuacion1;
        _puntuacion2 = puntuacion2;
    }
    public Registro(){}
    public int IdRegistro     { get{return _idRegistro;} set{_idRegistro = value;} }
    public string Luchador1   { get{return _luchador1;} set{_luchador1 = value;} }
    public int Puntuacion1    { get{return _puntuacion1;} set{_puntuacion1 = value;} }
    public string Luchador2   { get{return _luchador2;} set{_luchador2 = value;} }
    public int Puntuacion2    { get{return _puntuacion2;} set{_puntuacion2 = value;} }
    public string Diff        { get{return _diff;} set{_diff = value;} }
    public DateTime Fecha     { get{return _fecha;} set{_fecha = value;} }

}