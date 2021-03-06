﻿using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Exceptions;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;
using Vueling.Presentation.WinSite.Resources;
using static Vueling.Common.Logic.Enums.Formatos;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
        #region Attributes
        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private Alumno alumno;
        private IAlumnoBL alumnoBL;
        #endregion

        #region Constructor
        public AlumnoForm()
        {
            this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitializeComponent();
            this.Init();
            this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void Init()
        {
            this.alumnoBL = new AlumnoBL();
        } 
        #endregion

        #region Buttons
        public void btnTxt_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.LoadAlumnoData();
                Configuraciones.GuardarFormatoFichero(Formato.Texto);
                alumnoBL.Add(alumno);
                MessageBox.Show(ResourcesPresentation.studentAddSuccess);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (VuelingBusinessException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                MessageBox.Show(exception.Message);
            }
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.LoadAlumnoData();
                Configuraciones.GuardarFormatoFichero(Formato.Json);
                alumnoBL.Add(alumno);
                MessageBox.Show(ResourcesPresentation.studentAddSuccess);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (VuelingBusinessException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                MessageBox.Show(exception.Message);
            }
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.LoadAlumnoData();
                Configuraciones.GuardarFormatoFichero(Formato.Xml);
                alumnoBL.Add(alumno);
                MessageBox.Show(ResourcesPresentation.studentAddSuccess);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (VuelingBusinessException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                MessageBox.Show(exception.Message);
            }
        }

        private void btnBaseDatos_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.LoadAlumnoData();
                Configuraciones.GuardarFormatoFichero(Formato.Sql);
                alumnoBL.Add(alumno);
                MessageBox.Show(ResourcesPresentation.studentAddSuccess);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (VuelingBusinessException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                MessageBox.Show(exception.Message);
            }
        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                this.LoadAlumnoData();
                Configuraciones.GuardarFormatoFichero(Formato.Procedure);
                alumnoBL.Add(alumno);
                MessageBox.Show(ResourcesPresentation.studentAddSuccess);
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (VuelingBusinessException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                MessageBox.Show(exception.Message);
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
            catch (VuelingBusinessException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region Menu
        private void menuItemIngles_Click(object sender, EventArgs e)
        {
            Idiomas.CambiarIdioma(Resources.ResourcesIdiomas.Ingles);

            this.menuItemIngles.Checked = true;
            this.menuItemCastellano.Checked = false;

            this.UpdateControls();
        }

        private void menuItemCastellano_Click(object sender, EventArgs e)
        {
            Idiomas.CambiarIdioma(Resources.ResourcesIdiomas.Castellano);

            this.menuItemCastellano.Checked = true;
            this.menuItemIngles.Checked = false;

            this.UpdateControls();
        }

        private void menuItemCatalan_Click(object sender, EventArgs e)
        {
            Idiomas.CambiarIdioma(Resources.ResourcesIdiomas.Catalan);

            this.menuItemCastellano.Checked = true;
            this.menuItemIngles.Checked = false;

            this.UpdateControls();
        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                AlumnoForm alumnoForm = new AlumnoForm();
                alumnoForm.Show();
                this.Hide();
                this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (VuelingBusinessException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                MessageBox.Show(exception.Message);
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
            catch (VuelingBusinessException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                MessageBox.Show(exception.Message);
            }
        }
        #endregion

        #region LoadDataForm
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
            catch (VuelingBusinessException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                MessageBox.Show(exception.Message);
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

        
    }
}
