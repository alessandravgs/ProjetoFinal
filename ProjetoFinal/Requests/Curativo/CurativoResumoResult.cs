namespace ProjetoFinal.Requests.Curativo
{
    public class CurativoResumoResult
    {
        public int Id { get; set; }
        public string Lesao { get; set; }
        public string Paciente { get; set; }
        public DateTime Data { get; set; }

        public CurativoResumoResult()
        {
            Lesao = string.Empty;
            Paciente = string.Empty;
        }
    }
}
