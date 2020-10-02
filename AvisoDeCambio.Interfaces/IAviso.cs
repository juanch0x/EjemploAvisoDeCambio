using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AvisoDeCambio.Interfaces
{
    public interface IAviso
    {
        string NotaDeVenta { get; set; }
        string Potencia { get; set; }
        IList<PlanoUI> Planos { get; set; }
        IEnumerable<string> To { get; }
    }

    public class Aviso : IAviso
    {
        public string NotaDeVenta { get; set; }
        public string Potencia { get; set; }
        public IList<PlanoUI> Planos { get; set; } = new List<PlanoUI>();
        public IEnumerable<string> To => new List<string> { "qhse@artrans.com.ar", "gpavetti@artrans.com.ar" };

        public override string ToString()
        {
            return $"Aviso de cambio! => NV: { NotaDeVenta }, Potencia: {Potencia} - {Planos.Count} cambiaron!";
        }

    }

}
