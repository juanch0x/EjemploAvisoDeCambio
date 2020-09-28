namespace AvisoDeCambio.Interfaces
{
    public interface IPlano
    {
        string Codigo { get; set; }
        string Title { get; set; }
        int Revision { get; set; }
    }
}
