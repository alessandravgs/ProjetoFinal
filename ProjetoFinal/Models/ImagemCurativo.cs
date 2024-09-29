namespace ProjetoFinal.Models
{
    public class ImagemCurativo
    {
        public int Id { get; set; }
        public virtual Curativo Curativo { get; set; }
        public byte[] Foto { get; set; }

        public ImagemCurativo()
        {
            Foto = [];
            Curativo = new Curativo();
        }
    }
}
