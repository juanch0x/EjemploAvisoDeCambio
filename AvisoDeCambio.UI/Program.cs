using AvisoDeCambio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvisoDeCambio.UI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string edad = "15";
            int edadInt;
            if(int.TryParse(edad, out edadInt)){
                Console.WriteLine(edadInt+1);
            }
            else
            {
                Console.WriteLine("no se pudo convertir");
            }





            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<IPlano> planos = new List<IPlano> { 
                new PlanoPDM { Codigo="02-CM-CE", Revision=1, Title="PLANO DE CUBA" },
                new PlanoPDM { Codigo="02-CM-CD", Revision=0, Title="PLANO DE TAPA" }
            };

            Application.Run(new Form1(planos, TipoDeCambio.Inicial));
        }
    }
}
