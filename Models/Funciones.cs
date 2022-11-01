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
    public static Luchador AñadirLuchadorAutomatico()
    {
        Luchador luchador = new Luchador();
        luchador.Nombre = " ";
        luchador.Foto = "no_profile_picture.png";
        luchador.FechaNacimiento = DateTime.Today;

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
    public static Luchador ElegirGanador(Luchador luchador1, Luchador luchador2)
    {
        int puntos1 = 0, puntos2 = 0;
        Random random = new Random();
        if      (random.Next(luchador1.IQ_min, luchador1.IQ_max)                              > random.Next(luchador2.IQ_min, luchador2.IQ_max)) puntos1++;
        else if (random.Next(luchador1.IQ_min, luchador1.IQ_max)                              < random.Next(luchador2.IQ_min, luchador2.IQ_max)) puntos2++;
        if      (random.Next(luchador1.Fuerza_min, luchador1.Fuerza_max)                      > random.Next(luchador2.Fuerza_min, luchador2.Fuerza_max)) puntos1++;
        else if (random.Next(luchador1.Fuerza_min, luchador1.Fuerza_max)                      < random.Next(luchador2.Fuerza_min, luchador2.Fuerza_max)) puntos2++;
        if      (random.Next(luchador1.Velocidad_min, luchador1.Velocidad_max)                > random.Next(luchador2.Velocidad_min, luchador2.Velocidad_max)) puntos1++;
        else if (random.Next(luchador1.Velocidad_min, luchador1.Velocidad_max)                < random.Next(luchador2.Velocidad_min, luchador2.Velocidad_max)) puntos2++;
        if      (random.Next(luchador1.Resistencia_min, luchador1.Resistencia_max)            > random.Next(luchador2.Resistencia_min, luchador2.Resistencia_max)) puntos1++;
        else if (random.Next(luchador1.Resistencia_min, luchador1.Resistencia_max)            < random.Next(luchador2.Resistencia_min, luchador2.Resistencia_max)) puntos2++;
        if      (random.Next(luchador1.BattleIQ_min, luchador1.BattleIQ_max)                  > random.Next(luchador2.BattleIQ_min, luchador2.BattleIQ_max)) puntos1++;
        else if (random.Next(luchador1.BattleIQ_min, luchador1.BattleIQ_max)                  < random.Next(luchador2.BattleIQ_min, luchador2.BattleIQ_max)) puntos2++;
        if      (random.Next(luchador1.PoderDestructivo_min, luchador1.PoderDestructivo_max)  > random.Next(luchador2.PoderDestructivo_min, luchador2.PoderDestructivo_max)) puntos1++;
        else if (random.Next(luchador1.PoderDestructivo_min, luchador1.PoderDestructivo_max)  < random.Next(luchador2.PoderDestructivo_min, luchador2.PoderDestructivo_max)) puntos2++;
        if      (random.Next(luchador1.Experiencia_min, luchador1.Experiencia_max)            > random.Next(luchador2.Experiencia_min, luchador2.Experiencia_max)) puntos1++;
        else if (random.Next(luchador1.Experiencia_min, luchador1.Experiencia_max)            < random.Next(luchador2.Experiencia_min, luchador2.Experiencia_max)) puntos2++;
        if      (random.Next(luchador1.Transformaciones_min, luchador1.Transformaciones_max)  > random.Next(luchador2.Transformaciones_min, luchador2.Transformaciones_max)) puntos1++;
        else if (random.Next(luchador1.Transformaciones_min, luchador1.Transformaciones_max)  < random.Next(luchador2.Transformaciones_min, luchador2.Transformaciones_max)) puntos2++;

        if (puntos1 > puntos2) return luchador1;
        else if (puntos2 > puntos1) return luchador2;

        Luchador luchadorEmpate = new Luchador();
        luchadorEmpate.Nombre = "Empate!";
        luchadorEmpate.Foto = "foto_empate.jfif";
        return luchadorEmpate;
    }
}