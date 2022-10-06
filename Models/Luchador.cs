namespace EnfrentamientosHacker.Models;

public class Luchador
{
    private int _idLuchador; 
    private string _nombre;
    private DateTime _fechaNacimiento;
    private string _foto;
    private int _victorias;
    private string _iq, _fuerza, _velocidad, _resistencia, _battleIQ, _poderDestructivo, _experiencia, _transformaciones;
    public Luchador(int idLuchador, string nombre, DateTime fechaNacimiento, string foto, int victorias, string iq, string fuerza, string velocidad, string resistencia, string battleIQ, string poderDestructivo, string experiencia, string transformaciones)
    {
        _idLuchador = idLuchador;
        _nombre = nombre;
        _fechaNacimiento = fechaNacimiento;
        _foto = foto;
        _victorias = victorias;
        //------------------------------------
        _iq = iq;
        _fuerza = fuerza;
        _velocidad = velocidad;
        _resistencia = resistencia;
        _battleIQ = battleIQ;
        _poderDestructivo = poderDestructivo;
        _experiencia = experiencia;
        _transformaciones = transformaciones;
    }
    public Luchador(){}
    public int IdLuchador           { get{return _idLuchador;} set{_idLuchador = value;} }
    public string Nombre            { get{return _nombre;} set{_nombre = value;} }
    public DateTime FechaNacimiento { get{return _fechaNacimiento;} set{_fechaNacimiento = value;} }
    public string Foto              { get{return _foto;} set{_foto = value;} }
    public int Victorias            { get{return _victorias;} set{_victorias = value;} }
    //----------------------------------------------------------------------------------------------------
    public string IQ                { get{return _iq;} set{_iq = value;} }
    public string Fuerza            { get{return _fuerza;} set{_fuerza = value;} }
    public string Velocidad         { get{return _velocidad;} set{_velocidad = value;} }
    public string Resistencia       { get{return _resistencia;} set{_resistencia = value;} }
    public string BattleIQ          { get{return _battleIQ;} set{_battleIQ = value;} }
    public string PoderDestructivo  { get{return _poderDestructivo;} set{_poderDestructivo = value;} }
    public string Experiencia       { get{return _experiencia;} set{_experiencia = value;} }
    public string Transformaciones  { get{return _transformaciones;} set{_transformaciones = value;} }
}