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
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnosShowForm : Form
    {
        Logger logger = new Logger();
        private IFicheroBL ficheroBL;
        private List<Alumno> alumnosJson;
        private List<Alumno> alumnosXml;

        public AlumnosShowForm()
        {
            this.logger.Debug("Entra en AlumnosShowForm");
            InitializeComponent();
            this.ficheroBL = new FicheroBL();
            this.CargarAlumnosFichero();
            this.MostrarAlumnosTextoEnPantalla();
            this.logger.Debug("Fin de AlumnosShowForm");
        }

        public AlumnosShowForm(Alumno alumno)
        {
            this.logger.Debug("Entra en AlumnosShowForm");
            InitializeComponent();
            this.ficheroBL = new FicheroBL();
            this.CargarAlumnosFichero();
            this.MostrarAlumnoEnPantalla(alumno);
            this.logger.Debug("Fin de AlumnosShowForm");
        }

        private void MostrarAlumnoEnPantalla(Alumno alumno)
        {
            this.logger.Debug("Entra en MostrarAlumnoEnPantalla");
            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(alumno);
            this.EscribirEnPantalla(alumnos);
            this.logger.Debug("Fin de MostrarAlumnoEnPantalla");
        }

        private void CargarAlumnosFichero()
        {
            try
            {
                this.logger.Debug("Entra en CargarAlumnosFichero");
                this.alumnosJson = this.ficheroBL.CargarDatosFichero(TipoFichero.Json);
                this.alumnosXml = this.ficheroBL.CargarDatosFichero(TipoFichero.Xml);
                this.logger.Debug("Fin de CargarAlumnosFichero");
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }

        private List<Alumno> LeerDeFicheroDeTexto()
        {
            try
            {
                this.logger.Debug("Entra en LeerDeFicheroDeTexto");
                this.logger.Debug("Fin de LeerDeFicheroDeTexto");
                return this.ficheroBL.Leer(TipoFichero.Texto);
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
        }

        private void EscribirEnPantalla(List<Alumno> alumnos)
        {
            this.logger.Debug("Entra en EscribirEnPantalla");
            this.dataGridAlumnos.DataSource = alumnos;
            this.dataGridAlumnos.Update();
            this.logger.Debug("Fin de EscribirEnPantalla");
        }

        private void MostrarAlumnosTextoEnPantalla()
        {
            try
            {
                this.logger.Debug("Entra en MostrarAlumnosTextoEnPantalla");
                List<Alumno> alumnos = this.LeerDeFicheroDeTexto();
                this.EscribirEnPantalla(alumnos);
                this.logger.Debug("Fin de MostrarAlumnosTextoEnPantalla");
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error(exception.Message);
                throw;
            }
        }

        private void btnTxtBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug("Entra en btnTxtBuscador_Click");
                this.MostrarAlumnosTextoEnPantalla();
                this.logger.Debug("Fin de btnTxtBuscador_Click");
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message);
                throw;
            }
        }

        private void btnJsonBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug("Entra en btnJsonBuscador_Click");
                this.EscribirEnPantalla(this.alumnosJson);
                this.logger.Debug("Fin de btnJsonBuscador_Click");
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error(exception.Message);
                throw;
            }
        }

        private void btnNombreBuscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.logger.Debug("Entra en btnNombreBuscador_Click");
                List<Alumno> alumnosFiltrados = this.ficheroBL.FiltrarFicheroJsonPorNombre(this.txtNombreBuscador.Text);
                this.EscribirEnPantalla(alumnosFiltrados);
                this.logger.Debug("Fin de btnNombreBuscador_Click");
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
                this.logger.Error("Referencia nula" + exception.Message);
                throw;
            }
        }

        private void btnXmlBuscador_Click(object sender, EventArgs e)
        {
            this.logger.Debug("Entra en btnXmlBuscador_Click");
            this.EscribirEnPantalla(this.alumnosXml);
            this.logger.Debug("Fin de btnXmlBuscador_Click");
        }
    }
}
