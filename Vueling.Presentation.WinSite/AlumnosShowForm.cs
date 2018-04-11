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
using Vueling.Common.Logic.Models;
using Vueling.Resources;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnosShowForm : Form
    {
        Logger logger = new Logger();
        private IAlumnoBL alumnoBL;

        public AlumnosShowForm()
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitializeComponent();
            this.alumnoBL = new AlumnoBL();
            this.CargarDatosDeLosAlumnos();
            this.MostrarLosAlumnosEnPantalla(TipoFichero.Texto);
            this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public AlumnosShowForm(Alumno alumno)
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitializeComponent();
            this.alumnoBL = new AlumnoBL();
            this.CargarDatosDeLosAlumnos();
            this.MostrarAlumnoEnPantalla(alumno);
            this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void MostrarAlumnoEnPantalla(Alumno alumno)
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(alumno);
            this.EscribirEnPantalla(alumnos);
            this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

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

        private void MostrarLosAlumnosEnPantalla(TipoFichero tipoFichero)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnos = this.alumnoBL.Leer(tipoFichero);
                this.EscribirEnPantalla(alumnos);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        private void btnTxtBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.MostrarLosAlumnosEnPantalla(TipoFichero.Texto);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FileNotFoundException exception)
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
                this.EscribirEnPantalla(this.alumnoBL.Leer(TipoFichero.Json));
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FileNotFoundException exception)
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
                this.EscribirEnPantalla(this.alumnoBL.Leer(TipoFichero.Xml));
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FileNotFoundException exception)
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
    }
}
