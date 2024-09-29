namespace ProjetoFinal.Requests.Coberturas
{
    public class CoberturaResumoResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public CoberturaResumoResult()
        {
            Nome = string.Empty;
            Descricao = string.Empty;
        }
    }
}
