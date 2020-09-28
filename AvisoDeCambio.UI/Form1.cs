using AvisoDeCambio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AvisoDeCambio.UI
{
    public partial class Form1 : Form
    {
        private List<PlanoUI> _planos = new List<PlanoUI>();
        private TipoDeCambio _tipoDeCambio;
        public Form1(List<IPlano> planos, TipoDeCambio tipoDeCambio)
        {

            foreach (var plano in planos)
            {
                _planos.Add(new PlanoUI(plano));
            }

            _tipoDeCambio = tipoDeCambio;

            Load += Form1_Load;

            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            btnEnviar.Click += BtnEnviar_Click;
            switch (_tipoDeCambio)
            {
                case TipoDeCambio.Inicial:
                    label1.Text = "Comienza el proceso de aviso de cambio";
                    break;
                case TipoDeCambio.Confirmado:
                    label1.Text = "Se confirmo el cambio para los siguientes planos";
                    break;
                case TipoDeCambio.Retirado:
                    label1.Text = "Se rechazo la modificacion de plano";
                    break;
            }

            var codigoDePlano = new DataGridViewTextBoxColumn
            {
                Name = "codigo",
                HeaderText = "Codigo",
                ReadOnly = true
            };

            var titleColumn = new DataGridViewTextBoxColumn
            {
                Name = "title",
                HeaderText = "Titulo",
                ReadOnly = true
            };

            var revisionColumn = new DataGridViewTextBoxColumn
            {
                Name = "rev",
                HeaderText = "Revision",
                ReadOnly = true
            };

            var nuevaRevisionColumn = new DataGridViewTextBoxColumn
            {
                Name = "newRev",
                HeaderText = "Nueva Revision",
                ReadOnly = true
            };

            //editables
            var modificacionRealizada = new DataGridViewTextBoxColumn
            {
                Name = "modificacionRealizada",
                HeaderText = "Modificacion"
            };

            var accionASeguir = new DataGridViewComboBoxColumn
            {
                Name = "accionASeguir",
                HeaderText = "Accion a Seguir",
            };

            //leo la lista
            foreach (var accionAseguir in AvisoDeCambioInfo.AccionASeguir)
            {
                accionASeguir.Items.Add(accionAseguir);
            }

            tablaPlano.AllowUserToAddRows = false;
            tablaPlano.Columns.Add(codigoDePlano);
            tablaPlano.Columns.Add(titleColumn);
            tablaPlano.Columns.Add(revisionColumn);
            tablaPlano.Columns.Add(nuevaRevisionColumn);
            tablaPlano.Columns.Add(modificacionRealizada);
            tablaPlano.Columns.Add(accionASeguir);
            loadData();
        }
        private void loadData()
        {
            foreach (var plano in _planos)
            {
                tablaPlano.Rows.Add(plano.Codigo, plano.Title, plano.Revision, plano.NextRevision);
            }
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            List<PlanoUI> resultadoPlanoUI = new List<PlanoUI>();

            foreach (DataGridViewRow fila in tablaPlano.Rows)
            {
                var planoUi = new PlanoUI();
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    if (celda.OwningColumn.Name == "codigo")
                    {
                        planoUi.Codigo = celda.Value.ToString();
                    }

                    if (celda.OwningColumn.Name == "title")
                    {
                        planoUi.Title = celda.Value.ToString();
                    }

                    if (celda.OwningColumn.Name == "rev")
                    {
                        planoUi.Revision = int.Parse(celda.Value.ToString());
                    }


                    if (celda.OwningColumn.Name == "modificacionRealizada")
                    {
                        if (celda.Value == null)
                        {
                            MessageBox.Show("La modificacion es obligatoria");
                            return;
                        }
                        planoUi.Modificaciones = celda.Value.ToString();
                    }

                    if (celda.OwningColumn.Name == "accionASeguir")
                    {
                        if (celda.Value == null)
                        {
                            MessageBox.Show("La accion a seguir es null");
                            return;
                        }
                        planoUi.AccionASeguir = celda.Value.ToString();
                    }
                }
                resultadoPlanoUI.Add(planoUi);
                Console.WriteLine(planoUi);
            }
        }
    }

}
