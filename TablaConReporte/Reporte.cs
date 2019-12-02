using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region NewUsing
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
#endregion

namespace TablaConReporte
{
    public partial class Reporte : Form
    {
        public Reporte(String cantidad)
        {
            InitializeComponent();
            parametro(cantidad);

        }

        public void parametro(String parametro)
        {
            ReportDocument crystalrpt = new ReportDocument();
            crystalrpt.Load(@"B:\0 Jean\C#\TablaConReporte\ReportProduct.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = parametro;
            crParameterFieldDefinitions = crystalrpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["cantidad"];
            crParameterValues.Add(crParameterDiscreteValue);
            //crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterValues.Clear();

            crystalReportViewer1.ReportSource = crystalrpt;
            crystalReportViewer1.Refresh();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            
        }
    }
}
