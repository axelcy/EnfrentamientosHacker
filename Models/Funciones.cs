namespace EnfrentamientosHacker.Models;

public static class Funciones
{
    public static Luchador EstadisticasRandom(Luchador luchador) // SIN HACER
    {
        Random random = new Random();
        luchador.IQ_min = random.Next(0, 250);
        luchador.IQ_max = random.Next(luchador.IQ_min, 250);
        luchador.Fuerza_min = random.Next(0, 250);
        luchador.Fuerza_max = random.Next(luchador.Fuerza_min, 250);
        luchador.Velocidad_min = random.Next(0, 250);
        luchador.Velocidad_max = random.Next(luchador.Velocidad_min, 250);
        luchador.Resistencia_min = random.Next(0, 250);
        luchador.Resistencia_max = random.Next(luchador.Resistencia_min, 250);
        luchador.BattleIQ_min = random.Next(0, 250);
        luchador.BattleIQ_max = random.Next(luchador.BattleIQ_min, 250);
        luchador.PoderDestructivo_min = random.Next(0, 250);
        luchador.PoderDestructivo_max = random.Next(luchador.PoderDestructivo_min, 250);
        luchador.Experiencia_min = random.Next(0, 250);
        luchador.Experiencia_max = random.Next(luchador.Experiencia_min, 250);
        luchador.Transformaciones_min = random.Next(0, 250);
        luchador.Transformaciones_max = random.Next(luchador.Transformaciones_min, 250);

        return luchador;
    }
}