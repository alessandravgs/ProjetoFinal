namespace ProjetoFinal.Requests.Paciente
{
    public class AlergiaComorbidadeResumoResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public AlergiaComorbidadeResumoResult()
        {
            Nome = string.Empty;
        }
    }
}
