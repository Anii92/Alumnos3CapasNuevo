using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Enums;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;
using Vueling.Presentation.WinSite.Resources;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnosShowForm : Form
    {
        #region Attributes
        Logger logger = new Logger();
        private IAlumnoBL alumnoBL; 
        #endregion

        #region Constructors
        public AlumnosShowForm()
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitializeComponent();
            this.Init(null);
            this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public AlumnosShowForm(Alumno alumno)
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitializeComponent();
            this.Init(alumno);
            this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
        #endregion

        #region Initialize
        private void Init(Alumno alumno)
        {
            this.alumnoBL = new AlumnoBL();
            this.CargarDatosDeLosAlumnos();
            if (alumno == null)
            {
                this.EscribirEnPantalla(this.alumnoBL.Leer());
            }
            else
            {
                this.EscribirEnPantalla(new List<Alumno> { alumno });
            }
        }
        #endregion

        #region Methods
        private void CargarDatosDeLosAlumnos()
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.alumnoBL.CargarDatosDeLosAlumnos(TipoFichero.Json);
                this.alumnoBL.CargarDatosDeLosAlumnos(TipoFichero.Xml);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private void EscribirEnPantalla(List<Alumno> alumnos)
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            this.dataGridAlumnos.DataSource = alumnos;
            this.dataGridAlumnos.Update();
            this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
        } 
        #endregion

        #region Buttons
        private void btnTxtBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Configuraciones.GuardarFormatoFichero(TipoFichero.Texto);
                this.EscribirEnPantalla(this.alumnoBL.Leer());
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (ConfigurationErrorsException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private void btnJsonBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Configuraciones.GuardarFormatoFichero(TipoFichero.Json);
                this.EscribirEnPantalla(this.alumnoBL.Leer());
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (ConfigurationErrorsException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private void btnXmlBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Configuraciones.GuardarFormatoFichero(TipoFichero.Xml);
                this.EscribirEnPantalla(this.alumnoBL.Leer());
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (ConfigurationErrorsException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private void btnIdBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnosFiltrados = this.alumnoBL.Filtrar(this.lblIdBuscador.Text, this.txtIdBuscador.Text);
                this.EscribirEnPantalla(alumnosFiltrados);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (ConfigurationErrorsException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private void btnNombreBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnosFiltrados = this.alumnoBL.Filtrar(this.lblNombreBuscador.Text, this.txtNombreBuscador.Text);
                this.EscribirEnPantalla(alumnosFiltrados);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private void btnApellidosBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnosFiltrados = this.alumnoBL.Filtrar(this.lblApellidosBuscador.Text, this.txtApellidosBuscador.Text);
                this.EscribirEnPantalla(alumnosFiltrados);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private void btnDniBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnosFiltrados = this.alumnoBL.Filtrar(this.lblDniBuscador.Text, this.txtDniBuscador.Text);
                this.EscribirEnPantalla(alumnosFiltrados);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private void btnFechaNacimientoBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                DateTime fecha = Convert.ToDateTime(this.txtFechaNacimientoBuscador.Text);
                List<Alumno> alumnosFiltrados = this.alumnoBL.Filtrar(this.lblFechaNacimientoBuscador.Text, fecha.ToString());
                this.EscribirEnPantalla(alumnosFiltrados);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private void btnGuidBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnosFiltrados = this.alumnoBL.Filtrar(this.lblGuidBuscador.Text, this.txtGuidBuscador.Text);
                this.EscribirEnPantalla(alumnosFiltrados);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
        #endregion

        #region Language
        private void UpdateControls()
        {
            var resources = new ComponentResourceManager(this.GetType());
            GetChildren(this).ToList().ForEach(c =>
            {
                resources.ApplyResources(c, c.Name);
            });
            this.Text = resources.GetString("$this.Text");
        }

        public IEnumerable<Control> GetChildren(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetChildren(ctrl)).Concat(controls);
        }

        public IEnumerable<Control> GetParent(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetParent(ctrl)).Concat(controls);
        }
        #endregion

        #region Menu
        private void castellanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Idiomas.CambiarIdioma(Resources.ResourcesIdiomas.Castellano);

            this.menuItemCastellano.Checked = true;
            this.menuItemIngles.Checked = false;

            this.UpdateControls();
        }

        private void inglésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Idiomas.CambiarIdioma(Resources.ResourcesIdiomas.Ingles);

            this.menuItemIngles.Checked = true;
            this.menuItemCastellano.Checked = false;

            this.UpdateControls();
        }

        private void catalánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Idiomas.CambiarIdioma(Resources.ResourcesIdiomas.Catalan);

            this.menuItemCastellano.Checked = true;
            this.menuItemIngles.Checked = false;

            this.UpdateControls();
        }
        #endregion

        private void crearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                AlumnoForm alumnoForm = new AlumnoForm();
                alumnoForm.Show();
                this.Hide();
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
            }
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                AlumnosShowForm alumnoShowForm = new AlumnosShowForm();
                alumnoShowForm.Show();
                this.Hide();
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
            }
        }
    }
}
