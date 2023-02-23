namespace Proiect.Models
{
    public class ListaPrioritati
    {
        public static List<Prioritate> GetAll()
        {
            return new List<Prioritate>();
            {
                new Prioritate() { Id = "1", Nume = "urgent" };
                new Prioritate() { Id = "2", Nume = "mare" };
                new Prioritate() { Id = "3", Nume = "madie" };
                new Prioritate() { Id = "4", Nume = "mică" };
            }
        }
    }
}