using System.Data.SqlClient;
using Dapper;

namespace EnfrentamientosHacker.Models;

public static class BD
{
    // DESKTOP-8SGST9S\SQLEXPRESS | localhost
    private static string _connectionString = @"Server=localhost;DataBase=BD-Enfrentamientos;Trusted_Connection=True";
    // private static SqlConnection bd = new SqlConnection(_connectionString);
    public static int AgregarLuchador(Luchador luchador) // luchador.FechaNacimiento.ToShortDateString() = 23/10/2002 || CAST({luchador.FechaNacimiento.ToShortDateString()}' AS Date)
    {
        string sql = $"INSERT INTO Luchadores([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES('{luchador.Nombre}', @FechaNacimiento, '{luchador.Foto}', {luchador.Victorias}, {luchador.IQ_min}, {luchador.IQ_max}, {luchador.Fuerza_min}, {luchador.Fuerza_max}, {luchador.Velocidad_min}, {luchador.Velocidad_max}, {luchador.Resistencia_min}, {luchador.Resistencia_max}, {luchador.BattleIQ_min}, {luchador.BattleIQ_max}, {luchador.PoderDestructivo_min}, {luchador.PoderDestructivo_max}, {luchador.Experiencia_min}, {luchador.Experiencia_max}, {luchador.Transformaciones_min}, {luchador.Transformaciones_max})";
        int id = 0;
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            bd.Execute(sql, new {FechaNacimiento = luchador.FechaNacimiento});
            sql = $"select top 1 IdLuchador from Luchadores where Nombre = '{luchador.Nombre}' order by IdLuchador desc";
            id = bd.QueryFirstOrDefault<int>(sql);
        }
        return id;
        }
    // TODAVÍA NO FUNCIONA | hacer el UPDATE - poner int id de parametro en vez de luchador
    public static void ActualizarLuchador(Luchador luchador)
    {
        string sql = $"UPDATE Luchadores SET Nombre = '{luchador.Nombre}', FechaNacimiento = @FechaNacimiento, Foto = '{luchador.Foto}', Victorias = {luchador.Victorias}, IQ_min = {luchador.IQ_min}, IQ_max = {luchador.IQ_max}, Fuerza_min = {luchador.Fuerza_min}, Fuerza_max = {luchador.Fuerza_max}, Velocidad_min = {luchador.Velocidad_min}, Velocidad_max = {luchador.Velocidad_max}, Resistencia_min = {luchador.Resistencia_min}, Resistencia_max = {luchador.Resistencia_max}, BattleIQ_min = {luchador.BattleIQ_min}, BattleIQ_max = {luchador.BattleIQ_max}, PoderDestructivo_min = {luchador.PoderDestructivo_min}, PoderDestructivo_max = {luchador.PoderDestructivo_max}, Experiencia_min = {luchador.Experiencia_min}, Experiencia_max = {luchador.Experiencia_max}, Transformaciones_min = {luchador.Transformaciones_min}, Transformaciones_max = {luchador.Transformaciones_max} WHERE IdLuchador = {luchador.IdLuchador}";
        using (SqlConnection bd = new SqlConnection(_connectionString)) bd.Execute(sql, new {FechaNacimiento = luchador.FechaNacimiento});
    }
    public static void EliminarLuchador(int idLuchador)
    {
        string sql = $"DELETE FROM Luchadores WHERE IdLuchador = {idLuchador}";
        using (SqlConnection bd = new SqlConnection(_connectionString)) bd.Execute(sql);
    }
    public static Luchador VerInfoLuchador(int idLuchador)
    {
        Luchador luchador;
        string sql = $"SELECT * FROM Luchadores WHERE IdLuchador = {idLuchador}";
        using (SqlConnection bd = new SqlConnection(_connectionString)) luchador = bd.QueryFirstOrDefault<Luchador>(sql);
        return luchador;
    }
    public static List<Luchador> ListarLuchadores()
    {
        List<Luchador> ListaLuchadores = new List<Luchador>();
        string sql = $"SELECT * FROM Luchadores";
        using (SqlConnection bd = new SqlConnection(_connectionString)) ListaLuchadores = bd.Query<Luchador>(sql).ToList();
        return ListaLuchadores;
    }
    public static List<Registro> ListarRegistros()
    {
        List<Registro> ListaRegistros = new List<Registro>();
        string sql = $"SELECT * FROM Registros";
        using (SqlConnection bd = new SqlConnection(_connectionString)) ListaRegistros = bd.Query<Registro>(sql).ToList();
        foreach (Registro item in ListaRegistros)
        {
            if (item.Diff == "0") item.Diff = "Empate";
            if (item.Diff == "1") item.Diff = "Low";
            else if (item.Diff == "2") item.Diff = "High";
            else if (item.Diff == "3") item.Diff = "Extreme";
            else item.Diff = "-";
        }
        return ListaRegistros;
    }
    public static void ElimiarListaLuchadores()
    {
        string sql = "truncate table Luchadores";
        using (SqlConnection bd = new SqlConnection(_connectionString)) bd.Execute(sql);        
    }
    public static void ReiniciarJuego()
    {
        string[] sql = new string[10];
        sql[0] = "truncate table Luchadores";
        sql[1] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Tilín', CAST(N'2014-03-07' AS Date), N'tilin.jfif', N'0', N'75', 90, 75, 90, 90, 140, 60, 80, 90, 125, 55, 65, 65, 75, 110, 170)";
        sql[2] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Osito Perú', CAST(N'1998-07-16' AS Date), N'osito_peru.jpeg', N'0', N'80', 90, 90, 110, 60, 75, 100, 120, 90, 105, 120, 150, 70, 80, 140, 190)";
        sql[3] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'El Pepe', CAST(N'2002-10-23' AS Date), N'elpepe.jfif', N'0', N'60', 80, 70, 90, 80, 100, 70, 100, 100, 115, 100, 130, 75, 90, 110, 140)";
        sql[4] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Ete Sech', CAST(N'1992-11-02' AS Date), N'ete_sech.jfif', N'0', N'55', 70, 90, 120, 50, 60, 120, 130, 70, 95, 60, 210, 70, 100, 100, 120)";
        sql[5] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Gokú', CAST(N'3737-01-15' AS Date), N'goku.jpg', N'0', N'40', 75, 100, 115, 90, 100, 100, 110, 90, 130, 90, 175, 90, 120, 0, 250)";
        sql[6] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Jesús', CAST(N'3000-12-24' AS Date), N'jesus.jpg', N'0', N'70', 90, 50, 150, 50, 80, 60, 95, 100, 120, 999, 999, 100, 110, 70, 105)";
        sql[7] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Wazaa', CAST(N'1992-01-30' AS Date), N'waza.jfif', N'0', N'40', 95, 70, 100, 70, 100, 70, 100, 75, 110, 70, 100, 95, 110, 100, 120)";
        sql[8] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Grom', CAST(N'2000-03-15' AS Date), N'grom.png', N'0', N'50', 90, 90, 110, 70, 80, 50, 75, 70, 120, 110, 140, 80, 90, 100, 125)";
        sql[9] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Among Us', CAST(N'2018-06-15' AS Date), N'amongus.png', N'0', N'80', 100, 70, 80, 55, 75, 50, 80, 50, 130, 55, 65, 60, 70, 90, 110)";
        using (SqlConnection bd = new SqlConnection(_connectionString)) bd.Execute(string.Join(";", sql));
    }
    public static List<Luchador> DuplicarRoster()
    {
        List<Luchador> ListaLuchadores = new List<Luchador>();
        string[] sql = new string[10];
        sql[0] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Tilín', CAST(N'2014-03-07' AS Date), N'tilin.jfif', N'0', N'75', 90, 75, 90, 90, 140, 60, 80, 90, 125, 55, 65, 65, 75, 110, 170)";
        sql[1] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Osito Perú', CAST(N'1998-07-16' AS Date), N'osito_peru.jpeg', N'0', N'80', 90, 90, 110, 60, 75, 100, 120, 90, 105, 120, 150, 70, 80, 140, 190)";
        sql[2] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'El Pepe', CAST(N'2002-10-23' AS Date), N'elpepe.jfif', N'0', N'60', 80, 70, 90, 80, 100, 70, 100, 100, 115, 100, 130, 75, 90, 110, 140)";
        sql[3] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Ete Sech', CAST(N'1992-11-02' AS Date), N'ete_sech.jfif', N'0', N'55', 70, 90, 120, 50, 60, 120, 130, 70, 95, 60, 210, 70, 100, 100, 120)";
        sql[4] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Gokú', CAST(N'3737-01-15' AS Date), N'goku.jpg', N'0', N'40', 75, 100, 115, 90, 100, 100, 110, 90, 130, 90, 175, 90, 120, 0, 250)";
        sql[5] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Jesús', CAST(N'3001-12-24' AS Date), N'jesus.jpg', N'0', N'70', 90, 50, 150, 50, 80, 60, 95, 100, 120, 999, 999, 100, 110, 70, 105)";
        sql[6] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Wazaa', CAST(N'1992-01-30' AS Date), N'waza.jfif', N'0', N'40', 95, 70, 100, 70, 100, 70, 100, 75, 110, 70, 100, 95, 110, 100, 120)";
        sql[7] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Grom', CAST(N'2000-03-15' AS Date), N'grom.png', N'0', N'50', 90, 90, 110, 70, 80, 50, 75, 70, 120, 110, 140, 80, 90, 100, 125)";
        sql[8] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ_min], [IQ_max], [Fuerza_min], [Fuerza_max], [Velocidad_min], [Velocidad_max], [Resistencia_min], [Resistencia_max], [BattleIQ_min], [BattleIQ_max], [PoderDestructivo_min], [PoderDestructivo_max], [Experiencia_min], [Experiencia_max], [Transformaciones_min], [Transformaciones_max]) VALUES (N'Among Us', CAST(N'2018-06-15' AS Date), N'amongus.png', N'0', N'80', 100, 70, 80, 55, 75, 50, 80, 50, 130, 55, 65, 60, 70, 90, 110)";
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            bd.Execute(string.Join(";", sql));
            sql[9] = $"select top 8 * from Luchadores order by IdLuchador desc";
            ListaLuchadores = bd.Query<Luchador>(sql[9]).ToList();
        }
        return ListaLuchadores;
    }
}
