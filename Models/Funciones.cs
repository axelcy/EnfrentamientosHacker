namespace EnfrentamientosHacker.Models;

public static class Funciones
{
    public static Luchador EstadisticasRandom(Luchador luchador) // SIN HACER
    {
        Random random = new Random();
        luchador.IQ_min = random.Next(0, 125);
        luchador.IQ_max = random.Next(125, 250);
        luchador.Fuerza_min = random.Next(0, 125);
        luchador.Fuerza_max = random.Next(125, 250);
        luchador.Velocidad_min = random.Next(0, 125);
        luchador.Velocidad_max = random.Next(125, 250);
        luchador.Resistencia_min = random.Next(0, 125);
        luchador.Resistencia_max = random.Next(125, 250);
        luchador.BattleIQ_min = random.Next(0, 125);
        luchador.BattleIQ_max = random.Next(125, 250);
        luchador.PoderDestructivo_min = random.Next(0, 125);
        luchador.PoderDestructivo_max = random.Next(125, 250);
        luchador.Experiencia_min = random.Next(0, 125);
        luchador.Experiencia_max = random.Next(125, 250);
        luchador.Transformaciones_min = random.Next(0, 125);
        luchador.Transformaciones_max = random.Next(125, 250);

        return luchador;
    }
}