namespace AvisoDeCambio.Interfaces
{
    public class PlanoPDM : IPlano
    {
        public string Codigo { get; set; }
        public string Title { get; set; }
        public int Revision { get; set; }        
    }
}
