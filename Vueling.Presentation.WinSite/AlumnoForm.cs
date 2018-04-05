using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
        private Alumno alumno;
        private IAlumnoBL alumnoBL;

        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AlumnoForm()
        {
            Log.Debug("Algo da igual");
            InitializeComponent();
            alumno = new Alumno();
            alumnoBL = new AlumnoBL();
            Log.Debug("Fin del constructor AlumnoForm");
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            Log.Debug("Inicio de la función btnTxt_Click");
            this.LoadAlumnoData();
            alumnoBL.Add(alumno, TipoFichero.Texto);
            MessageBox.Show("El alumno se ha guardado correctamente!");
            Log.Debug("Fin de la función btnTxt_Click");
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            Log.Debug("Inicio de la función btnJson_Click");
            this.LoadAlumnoData();
            alumnoBL.Add(alumno, TipoFichero.Json);
            MessageBox.Show("El alumno se ha guardado correctamente!");
            Log.Debug("Inicio de la función btnJson_Click");
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            Log.Debug("Inicio de la función btnXml_Click");
            this.LoadAlumnoData();
            alumnoBL.Add(alumno, TipoFichero.Xml);
            MessageBox.Show("El alumno se ha guardado correctamente!");
            Log.Debug("Inicio de la función btnXml_Click");
        }

        private void LoadAlumnoData()
        {
            Log.Debug("Inicio de la función LoadAlumnoData");
            alumno.Id = Convert.ToInt32(txtId.Text);
            alumno.Nombre = txtNombre.Text;
            alumno.Apellidos = txtApellidos.Text;
            alumno.Dni = txtDni.Text;
            alumno.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            Log.Debug(FileUtils.ToJson(alumno));
            Log.Debug("Fin de la función LoadAlumnoData");
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.LoadAlumnoData();
            AlumnosShowForm alumnosShowForm = new AlumnosShowForm(alumno);
            alumnosShowForm.Show();
            this.Hide();
        }
    }
}
