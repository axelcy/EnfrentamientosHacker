namespace EnfrentamientosHacker.Models;

public class Luchador
{
    private int _idLuchador; 
    private string _nombre;
    private DateTime _fechaNacimiento;
    private string _foto;
    private int _victorias;
    private int _iq_min, _fuerza_min, _velocidad_min, _resistencia_min, _battleIQ_min, _poderDestructivo_min, _experiencia_min, _transformaciones_min;
    private int _iq_max, _fuerza_max, _velocidad_max, _resistencia_max, _battleIQ_max, _poderDestructivo_max, _experiencia_max, _transformaciones_max;
    public Luchador(int idLuchador, string nombre, DateTime fechaNacimiento, string foto, int victorias, int iq_min, int iq_max, int fuerza_min, int fuerza_max, int velocidad_min, int velocidad_max, int resistencia_min, int resistencia_max, int battleIQ_min, int battleIQ_max, int poderDestructivo_min, int poderDestructivo_max, int experiencia_min, int experiencia_max, int transformaciones_min, int transformaciones_max)
    {
        _idLuchador = idLuchador;
        _nombre = nombre;
        _fechaNacimiento = fechaNacimiento;
        _foto = foto;
        _victorias = victorias;
        //------------------------------------
        _iq_min = iq_min;                               _iq_max = iq_max;
        _fuerza_min = fuerza_min;                       _fuerza_max = fuerza_max;
        _velocidad_min = velocidad_min;                 _velocidad_max = velocidad_max;
        _resistencia_min = resistencia_min;             _resistencia_max = resistencia_max;
        _battleIQ_min = battleIQ_min;                   _battleIQ_max = battleIQ_max;
        _poderDestructivo_min = poderDestructivo_min;   _poderDestructivo_max = poderDestructivo_max;
        _experiencia_min = experiencia_min;             _experiencia_max = experiencia_max;
        _transformaciones_min = transformaciones_min;   _transformaciones_max = transformaciones_max;
    }
    public Luchador(){}
    public Luchador(int idLuchador, string nombre, DateTime fechaNacimiento, string foto, int victorias)
    {

    }
    public int IdLuchador           { get{return _idLuchador;} set{_idLuchador = value;} }
    public string Nombre            { get{return _nombre;} set{_nombre = value;} }
    public DateTime FechaNacimiento { get{return _fechaNacimiento;} set{_fechaNacimiento = value;} }
    public string Foto              { get{return _foto;} set{_foto = value;} }
    public int Victorias            { get{return _victorias;} set{_victorias = value;} }
    //----------------------------------------------------------------------------------------------------
    public int IQ_min                { get{return _iq_min;} set{_iq_min = value;} }
    public int IQ_max                { get{return _iq_max;} set{_iq_max = value;} }

    public int Fuerza_min            { get{return _fuerza_min;} set{_fuerza_min = value;} }
    public int Fuerza_max            { get{return _fuerza_max;} set{_fuerza_max = value;} }

    public int Velocidad_min         { get{return _velocidad_min;} set{_velocidad_min = value;} }
    public int Velocidad_max         { get{return _velocidad_max;} set{_velocidad_max = value;} }

    public int Resistencia_min       { get{return _resistencia_min;} set{_resistencia_min = value;} }
    public int Resistencia_max       { get{return _resistencia_max;} set{_resistencia_max = value;} }

    public int BattleIQ_min          { get{return _battleIQ_min;} set{_battleIQ_min = value;} }
    public int BattleIQ_max          { get{return _battleIQ_max;} set{_battleIQ_max = value;} }

    public int PoderDestructivo_min  { get{return _poderDestructivo_min;} set{_poderDestructivo_min = value;} }
    public int PoderDestructivo_max  { get{return _poderDestructivo_max;} set{_poderDestructivo_max = value;} }

    public int Experiencia_min       { get{return _experiencia_min;} set{_experiencia_min = value;} }
    public int Experiencia_max       { get{return _experiencia_max;} set{_experiencia_max = value;} }

    public int Transformaciones_min  { get{return _transformaciones_min;} set{_transformaciones_min = value;} }
    public int Transformaciones_max  { get{return _transformaciones_max;} set{_transformaciones_max = value;} }

}