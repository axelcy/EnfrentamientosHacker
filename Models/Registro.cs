namespace EnfrentamientosHacker.Models;

public class Registro
{
    private int _idRegistro;
    private int _idLuchador1;
    private int _puntuacion1;
    private int _idLuchador2;
    private int _puntuacion2;
    private string _diff;
    private DateTime _fecha;
    
    public Registro(int idRegistro, int idLuchador1, int puntuacion1, int idLuchador2, int puntuacion2, string diff, DateTime fecha, string puntuaciones)
    {
        _idRegistro = idRegistro;
        _idLuchador1 = idLuchador1;
        _idLuchador2 = idLuchador2;
        _diff = diff;
        _fecha = fecha;
        _puntuacion1 = puntuacion1;
        _puntuacion2 = puntuacion2;
    }
    public Registro(){}
    public int IdRegistro     { get{return _idRegistro;} set{_idRegistro = value;} }
    public int IdLuchador1    { get{return _idLuchador1;} set{_idLuchador1 = value;} }
    public int Puntuacion1    { get{return _puntuacion1;} set{_puntuacion1 = value;} }
    public int IdLuchador2    { get{return _idLuchador2;} set{_idLuchador2 = value;} }
    public int Puntuacion2    { get{return _puntuacion2;} set{_puntuacion2 = value;} }
    public string Diff        { get{return _diff;} set{_diff = value;} }
    public DateTime Fecha     { get{return _fecha;} set{_fecha = value;} }

}