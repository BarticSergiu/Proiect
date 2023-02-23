namespace Proiect.Models
{
    public class ListaTipSarcini
    {
        public static List<TipSarcina> GetAll()
        {
            return new List<TipSarcina>();
            {
                new TipSarcina() { Id = "1", Nume = "dezvoltare" };
                new TipSarcina() { Id = "2", Nume = "debug" };
                new TipSarcina() { Id = "3", Nume = "suport" };
            }
        }
    }
}