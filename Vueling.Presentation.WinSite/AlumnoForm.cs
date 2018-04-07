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
        Logger logger = new Logger();
        private Alumno alumno;
        private IAlumnoBL alumnoBL;

        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AlumnoForm()
        {
            this.logger.Debug("Inicia la aplicación.");
            InitializeComponent();
            alumno = new Alumno();
            alumnoBL = new AlumnoBL();
            this.logger..Debug("Fin del constructor AlumnoForm");
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug("Inicio de la función btnTxt_Click");
                this.LoadAlumnoData();
                alumnoBL.Add(alumno, TipoFichero.Texto);
                MessageBox.Show("El alumno se ha guardado correctamente!");
                this.logger.Debug("Fin de la función btnTxt_Click");
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error("Referencia nula" + exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error("Agumento nulo" + exception.Message);
            }
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug("Inicio de la función btnJson_Click");
                this.LoadAlumnoData();
                alumnoBL.Add(alumno, TipoFichero.Json);
                MessageBox.Show("El alumno se ha guardado correctamente!");
                this.logger.Debug("Inicio de la función btnJson_Click");
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error("Referencia nula" + exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error("Agumento nulo" + exception.Message);
            }
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug("Inicio de la función btnXml_Click");
                this.LoadAlumnoData();
                alumnoBL.Add(alumno, TipoFichero.Xml);
                MessageBox.Show("El alumno se ha guardado correctamente!");
                this.logger.Debug("Inicio de la función btnXml_Click");
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error("Referencia nula" + exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error("Agumento nulo" + exception.Message);
            }
        }

        private void LoadAlumnoData()
        {
            try
            {
                this.logger.Debug("Inicio de la función LoadAlumnoData");
                alumno.Id = Convert.ToInt32(txtId.Text);
                alumno.Nombre = txtNombre.Text;
                alumno.Apellidos = txtApellidos.Text;
                alumno.Dni = txtDni.Text;
                alumno.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                this.logger.Debug(FileUtils.ToJson(alumno));
                this.logger.Debug("Fin de la función LoadAlumnoData");
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error("Referencia nula" + exception.Message);
                throw;
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadAlumnoData();
                AlumnosShowForm alumnosShowForm = new AlumnosShowForm(alumno);
                alumnosShowForm.Show();
                this.Hide();
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error("Referencia nula" + exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error("Agumento nulo" + exception.Message);
            }
        }
    }
}
