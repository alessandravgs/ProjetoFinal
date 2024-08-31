namespace ProjetoFinal.Requests
{
    public class PaginacaoResult<T> where T : class
    {
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public IList<T> Items { get; set; }

        public PaginacaoResult()
        {
            Items = new List<T>();
        }

        public PaginacaoResult(IList<T> items)
        {
            Items = items;
        }
    }
}
