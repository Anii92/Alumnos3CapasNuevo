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
            InitializeComponent();
            this.ficheroBL = new FicheroBL();
            this.CargarAlumnosFichero();
            this.MostrarAlumnosTextoEnPantalla();
        }

        public AlumnosShowForm(Alumno alumno)
        {
            InitializeComponent();
            this.ficheroBL = new FicheroBL();
            this.CargarAlumnosFichero();
            this.MostrarAlumnoEnPantalla(alumno);
        }

        private void MostrarAlumnoEnPantalla(Alumno alumno)
        {
            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(alumno);
            this.EscribirEnPantalla(alumnos);
        }

        private void CargarAlumnosFichero()
        {
            try
            {
                this.alumnosJson = this.ficheroBL.CargarDatosFichero(TipoFichero.Json);
                this.alumnosXml = this.ficheroBL.CargarDatosFichero(TipoFichero.Xml);
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
            this.dataGridAlumnos.DataSource = alumnos;
            this.dataGridAlumnos.Update();
        }

        private void MostrarAlumnosTextoEnPantalla()
        {
            try
            {
                List<Alumno> alumnos = this.LeerDeFicheroDeTexto();
                this.EscribirEnPantalla(alumnos);
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
                this.MostrarAlumnosTextoEnPantalla();
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
                this.EscribirEnPantalla(this.alumnosJson);
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
                List<Alumno> alumnosFiltrados = this.ficheroBL.FiltrarFicheroJsonPorNombre(this.txtNombreBuscador.Text);
                this.EscribirEnPantalla(alumnosFiltrados);
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
            this.EscribirEnPantalla(this.alumnosXml);
        }
    }
}
