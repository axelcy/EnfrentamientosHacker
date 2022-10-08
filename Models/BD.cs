using System.Data.SqlClient;
using Dapper;

namespace EnfrentamientosHacker.Models;

public static class BD
{
    // Server=NombreMaquina\SQLEXPRESS;DataBase=NombreBase;Trusted_Connection=True
    private static string _connectionString = @"Server=localhost;DataBase=BD-Enfrentamientos;Trusted_Connection=True";
    public static void AgregarLuchador(Luchador luchador)
    {
        string sql = $"INSERT INTO Luchadores([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES({luchador.Nombre}, {luchador.FechaNacimiento}, {luchador.Foto}, {luchador.Victorias}, {luchador.IQ}, {luchador.Fuerza}, {luchador.Velocidad}, {luchador.Resistencia}, {luchador.BattleIQ}, {luchador.PoderDestructivo}, {luchador.Experiencia}, {luchador.Transformaciones})";
        using (SqlConnection bd = new SqlConnection(_connectionString)) bd.Execute(sql);
    }
    // TODAVÍA NO FUNCIONA | hacer el UPDATE - poner int id de parametro en vez de luchador
    public static void ModificarLuchador(Luchador luchador)
    {
        string sql = $"INSERT INTO Luchadores([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES({luchador.Nombre}, {luchador.FechaNacimiento}, {luchador.Foto}, {luchador.Victorias}, {luchador.IQ}, {luchador.Fuerza}, {luchador.Velocidad}, {luchador.Resistencia}, {luchador.BattleIQ}, {luchador.PoderDestructivo}, {luchador.Experiencia}, {luchador.Transformaciones})";
        using (SqlConnection bd = new SqlConnection(_connectionString)) bd.Execute(sql);
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
        sql[1] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Tilín', CAST(N'2014-03-07' AS Date), N'tilin.jfif', N'0', N'75-90', N'75-90', N'90-140', N'60-80', N'90-125', N'55-65', N'65-75', N'110-170')";
        sql[2] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Osito Perú', CAST(N'1998-07-16' AS Date), N'osito_peru.jpeg', N'0', N'80-90', N'90-110', N'60-75', N'100-120', N'90-105', N'120-150', N'70-80', N'140-190')";
        sql[3] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'El Pepe', CAST(N'2002-10-23' AS Date), N'elpepe.jfif', N'0', N'60-80', N'70-90', N'80-100', N'70-100', N'100-115', N'100-130', N'75-90', N'110-140')";
        sql[4] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Ete Sech', CAST(N'1992-11-02' AS Date), N'ete_sech.jfif', N'0', N'55-70', N'90-120', N'50-60', N'130-130', N'70-95', N'60-210', N'70-100', N'100-120')";
        sql[5] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Gokú', CAST(N'0737-01-15' AS Date), N'goku.jpg', N'0', N'40-75', N'100-115', N'90-100', N'100-110', N'90-130', N'90-175', N'90-120', N'0-250')";
        sql[6] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Jesús', CAST(N'0001-12-24' AS Date), N'jesus.jpg', N'0', N'70-90', N'50-150', N'50-80', N'60-95', N'100-120', N'999-999', N'100-110', N'70-105')";
        sql[7] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Wazaa', CAST(N'1992-01-30' AS Date), N'waza.jfif', N'0', N'40-95', N'70-100', N'70-100', N'70-100', N'75-110', N'70-100', N'95-110', N'100-120')";
        sql[8] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Grom', CAST(N'2000-03-15' AS Date), N'grom.png', N'0', N'50-90', N'90-110', N'70-80', N'50-75', N'70-120', N'110-140', N'80-90', N'100-125')";
        sql[9] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Among Us', CAST(N'2018-06-15' AS Date), N'amongus.png', N'0', N'80-100', N'70-80', N'55-75', N'50-80', N'50-130', N'55-65', N'60-70', N'90-110')";
        
        using (SqlConnection bd = new SqlConnection(_connectionString)) foreach (string item in sql) bd.Execute(item);        
    }
    public static void DuplicarRoster()
    {
        string[] sql = new string[9];
        sql[0] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Tilín', CAST(N'2014-03-07' AS Date), N'tilin.jfif', N'0', N'75-90', N'75-90', N'90-140', N'60-80', N'90-125', N'55-65', N'65-75', N'110-170')";
        sql[1] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Osito Perú', CAST(N'1998-07-16' AS Date), N'osito_peru.jpeg', N'0', N'80-90', N'90-110', N'60-75', N'100-120', N'90-105', N'120-150', N'70-80', N'140-190')";
        sql[2] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'El Pepe', CAST(N'2002-10-23' AS Date), N'elpepe.jfif', N'0', N'60-80', N'70-90', N'80-100', N'70-100', N'100-115', N'100-130', N'75-90', N'110-140')";
        sql[3] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Ete Sech', CAST(N'1992-11-02' AS Date), N'ete_sech.jfif', N'0', N'55-70', N'90-120', N'50-60', N'130-130', N'70-95', N'60-210', N'70-100', N'100-120')";
        sql[4] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Gokú', CAST(N'0737-01-15' AS Date), N'goku.jpg', N'0', N'40-75', N'100-115', N'90-100', N'100-110', N'90-130', N'90-175', N'90-120', N'0-250')";
        sql[5] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Jesús', CAST(N'0001-12-24' AS Date), N'jesus.jpg', N'0', N'70-90', N'50-150', N'50-80', N'60-95', N'100-120', N'999-999', N'100-110', N'70-105')";
        sql[6] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Wazaa', CAST(N'1992-01-30' AS Date), N'waza.jfif', N'0', N'40-95', N'70-100', N'70-100', N'70-100', N'75-110', N'70-100', N'95-110', N'100-120')";
        sql[7] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Grom', CAST(N'2000-03-15' AS Date), N'grom.png', N'0', N'50-90', N'90-110', N'70-80', N'50-75', N'70-120', N'110-140', N'80-90', N'100-125')";
        sql[8] = "INSERT [dbo].[Luchadores] ([Nombre], [FechaNacimiento], [Foto], [Victorias], [IQ], [Fuerza], [Velocidad], [Resistencia], [BattleIQ], [PoderDestructivo], [Experiencia], [Transformaciones]) VALUES (N'Among Us', CAST(N'2018-06-15' AS Date), N'amongus.png', N'0', N'80-100', N'70-80', N'55-75', N'50-80', N'50-130', N'55-65', N'60-70', N'90-110')";
        using (SqlConnection bd = new SqlConnection(_connectionString)) foreach (string item in sql) bd.Execute(item);
    }
}
