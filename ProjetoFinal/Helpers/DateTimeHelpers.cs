namespace ProjetoFinal.Helpers
{
    public static class DateTimeHelpers
    {
        public static DateTime ObterHoraBrasilia()
        {
            // Fuso horário de Brasília
            TimeZoneInfo fusoBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

            // Hora UTC atual
            DateTime utcNow = DateTime.UtcNow;

            // Converte a hora UTC para a hora de Brasília
            DateTime horaBrasilia = TimeZoneInfo.ConvertTimeFromUtc(utcNow, fusoBrasilia);

            return horaBrasilia;
        }
    }
}
