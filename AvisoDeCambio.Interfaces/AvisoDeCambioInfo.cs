using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisoDeCambio.Interfaces
{
    public static class AvisoDeCambioInfo
    {
        public static List<string> AccionASeguir => new List<string> { 
            "Retrabajo",
            "Putear a GP",
            "Putear de nuevo a GP"
        };
    }
}
