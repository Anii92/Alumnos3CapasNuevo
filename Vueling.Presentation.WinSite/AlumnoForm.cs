using log4net;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Vueling.Resources;
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
            this.logger.Debug(Resources.ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitializeComponent();
            alumnoBL = new AlumnoBL();
            this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void btnTxt_Click(object sender, EventArgs e)
        {
            try
            {
                //Utilizar multilenguaje
                //Thread.CurrentThread.CurrentUICulture = new CultureInfo("EN-US");
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.LoadAlumnoData();
                alumnoBL.Add(alumno, TipoFichero.Texto);
                MessageBox.Show(Vueling.Resources.Resources.studentAddSuccess);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
            }
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.LoadAlumnoData();
                alumnoBL.Add(alumno, TipoFichero.Json);
                MessageBox.Show(Vueling.Resources.Resources.studentAddSuccess);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
            }
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.LoadAlumnoData();
                alumnoBL.Add(alumno, TipoFichero.Xml);
                MessageBox.Show(Vueling.Resources.Resources.studentAddSuccess);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
            }
        }

        private void LoadAlumnoData()
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.alumno = new Alumno();
                this.alumno.Id = Convert.ToInt32(txtId.Text);
                this.alumno.Nombre = txtNombre.Text;
                this.alumno.Apellidos = txtApellidos.Text;
                this.alumno.Dni = txtDni.Text;
                this.alumno.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                this.logger.Debug(FileUtils.ToJson(alumno));
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.LoadAlumnoData();
                AlumnosShowForm alumnosShowForm = new AlumnosShowForm(alumno);
                alumnosShowForm.Show();
                this.Hide();
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
            }
            catch (ArgumentNullException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message + exception.StackTrace);
            }
        }
    }
}
