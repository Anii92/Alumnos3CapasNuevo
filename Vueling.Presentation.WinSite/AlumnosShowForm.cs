using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IFicheroBL ficheroBL;
        private List<Alumno> alumnosJson;
        private List<Alumno> alumnosXml;

        public AlumnosShowForm()
        {
            Log.Debug("Entra en AlumnosShowForm");
            InitializeComponent();
            this.ficheroBL = new FicheroBL();
            this.CargarAlumnosFichero();
            this.MostrarAlumnosTextoEnPantalla();
            Log.Debug("Fin de AlumnosShowForm");
        }

        public AlumnosShowForm(Alumno alumno)
        {
            Log.Debug("Entra en AlumnosShowForm");
            InitializeComponent();
            this.ficheroBL = new FicheroBL();
            this.CargarAlumnosFichero();
            this.MostrarAlumnoEnPantalla(alumno);
            Log.Debug("Fin de AlumnosShowForm");
        }

        private void MostrarAlumnoEnPantalla(Alumno alumno)
        {
            Log.Debug("Entra en MostrarAlumnoEnPantalla");
            List<Alumno> alumnos = new List<Alumno>();
            alumnos.Add(alumno);
            this.EscribirEnPantalla(alumnos);
            Log.Debug("Fin de MostrarAlumnoEnPantalla");
        }

        private void CargarAlumnosFichero()
        {
            Log.Debug("Entra en CargarAlumnosFichero");
            this.alumnosJson = this.ficheroBL.CargarDatosFichero(TipoFichero.Json);
            this.alumnosXml = this.ficheroBL.CargarDatosFichero(TipoFichero.Xml);
            Log.Debug("Fin de CargarAlumnosFichero");
        }

        private List<Alumno> LeerDeFicheroDeTexto()
        {
            Log.Debug("Entra en LeerDeFicheroDeTexto");
            Log.Debug("Fin de LeerDeFicheroDeTexto");
            return this.ficheroBL.Leer(TipoFichero.Texto);
            
        }

        private void EscribirEnPantalla(List<Alumno> alumnos)
        {
            Log.Debug("Entra en EscribirEnPantalla");
            this.dataGridAlumnos.DataSource = alumnos;
            this.dataGridAlumnos.Update();
            Log.Debug("Fin de EscribirEnPantalla");
        }

        private void MostrarAlumnosTextoEnPantalla()
        {
            Log.Debug("Entra en MostrarAlumnosTextoEnPantalla");
            List<Alumno> alumnos = this.LeerDeFicheroDeTexto();
            this.EscribirEnPantalla(alumnos);
            Log.Debug("Fin de MostrarAlumnosTextoEnPantalla");
        }

        private void btnTxtBuscador_Click(object sender, EventArgs e)
        {
            Log.Debug("Entra en btnTxtBuscador_Click");
            this.MostrarAlumnosTextoEnPantalla();
            Log.Debug("Fin de btnTxtBuscador_Click");
        }

        private void btnJsonBuscador_Click(object sender, EventArgs e)
        {
            Log.Debug("Entra en btnJsonBuscador_Click");
            this.EscribirEnPantalla(this.alumnosJson);
            Log.Debug("Fin de btnJsonBuscador_Click");
        }

        private void btnNombreBuscador_Click(object sender, EventArgs e)
        {
            Log.Debug("Entra en btnNombreBuscador_Click");
            List<Alumno> alumnosFiltrados = this.ficheroBL.FiltrarFicheroJsonPorNombre(this.txtNombreBuscador.Text);
            this.EscribirEnPantalla(alumnosFiltrados);
            Log.Debug("Fin de btnNombreBuscador_Click");
        }

        private void btnXmlBuscador_Click(object sender, EventArgs e)
        {
            Log.Debug("Entra en btnXmlBuscador_Click");
            this.EscribirEnPantalla(this.alumnosXml);
            Log.Debug("Fin de btnXmlBuscador_Click");
        }
    }
}
