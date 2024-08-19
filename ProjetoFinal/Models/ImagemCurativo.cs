namespace ProjetoFinal.Models
{
    public class ImagemCurativo
    {
        public int id { get; set; }
        public virtual Curativo Curativo { get; set; }

        //Imagem
    }
}
