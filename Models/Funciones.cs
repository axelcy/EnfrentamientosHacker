namespace EnfrentamientosHacker.Models;

public static class Funciones
{
    public static Luchador LimitarEstadisticas(Luchador luchador, int max)
    {
        if (luchador.IQ_min > max) luchador.IQ_min = max;
        if (luchador.IQ_max > max) luchador.IQ_max = max;
        else if (luchador.IQ_max < luchador.IQ_min) luchador.IQ_max = luchador.IQ_min;

        if (luchador.Fuerza_min > max) luchador.Fuerza_min = max;
        if (luchador.Fuerza_max > max) luchador.Fuerza_max = max;
        else if (luchador.Fuerza_max < luchador.Fuerza_min) luchador.Fuerza_max = luchador.Fuerza_min;

        if (luchador.Velocidad_min > max) luchador.Velocidad_min = max;
        if (luchador.Velocidad_max > max) luchador.Velocidad_max = max;
        else if (luchador.Velocidad_max < luchador.Velocidad_min) luchador.Velocidad_max = luchador.Velocidad_min;

        if (luchador.Resistencia_min > max) luchador.Resistencia_min = max;
        if (luchador.Resistencia_max > max) luchador.Resistencia_max = max;
        else if (luchador.Resistencia_max < luchador.Resistencia_min) luchador.Resistencia_max = luchador.Resistencia_min;

        if (luchador.BattleIQ_min > max) luchador.BattleIQ_min = max;
        if (luchador.BattleIQ_max > max) luchador.BattleIQ_max = max;
        else if (luchador.BattleIQ_max < luchador.BattleIQ_min) luchador.BattleIQ_max = luchador.BattleIQ_min;

        if (luchador.PoderDestructivo_min > max) luchador.PoderDestructivo_min = max;
        if (luchador.PoderDestructivo_max > max) luchador.PoderDestructivo_max = max;
        else if (luchador.PoderDestructivo_max < luchador.PoderDestructivo_min) luchador.PoderDestructivo_max = luchador.PoderDestructivo_min;

        if (luchador.Experiencia_min > max) luchador.Experiencia_min = max;
        if (luchador.Experiencia_max > max) luchador.Experiencia_max = max;
        else if (luchador.Experiencia_max < luchador.Experiencia_min) luchador.Experiencia_max = luchador.Experiencia_min;

        if (luchador.Transformaciones_min > max) luchador.Transformaciones_min = max;
        if (luchador.Transformaciones_max > max) luchador.Transformaciones_max = max;
        else if (luchador.Transformaciones_max < luchador.Transformaciones_min) luchador.Transformaciones_max = luchador.Transformaciones_min;

        return luchador;
    }
}