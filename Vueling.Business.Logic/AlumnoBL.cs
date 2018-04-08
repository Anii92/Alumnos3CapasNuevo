using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao;
using static Vueling.Common.Logic.Enums.TiposFichero;

namespace Vueling.Business.Logic
{
    public class AlumnoBL : IAlumnoBL
    {
        public TipoFichero TipoFichero { get; set; }

        Logger logger = new Logger();
        private IAlumnoDao alumnoDao;

        public AlumnoBL()
        {
            this.logger.Debug("Entra AlumnoBL");
            alumnoDao = new AlumnoDao();
            this.TipoFichero = TipoFichero.Texto;
            this.logger.Debug("Entra AlumnoBL");
        }

        public Alumno Add(Alumno alumno, TipoFichero tipoFichero)
        {
            try
            {
                alumno.Edad = CalcularEdad(alumno.FechaNacimiento);
                alumno.FechaHora = CalcularFechaRegistro();
                Alumno alumnoInsertado = alumnoDao.Add(alumno, tipoFichero);
                return alumnoInsertado;
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error("Agumento nulo" + exception.Message);
                throw;
            }
        }

        public DateTime CalcularFechaRegistro()
        {
            this.logger.Debug("Entra CalcularFechaRegistro");
            this.logger.Debug("Sale CalcularFechaRegistro");
            return DateTime.Now;
        }

        public int CalcularEdad(DateTime fechaNacimiento)
        {
            try
            {
                DateTime now = DateTime.Today;
                int age = now.Year - fechaNacimiento.Year;
                if (now < fechaNacimiento.AddYears(age))
                {
                    --age;
                }
                return age;
            }
            catch (ArgumentNullException exception)
            {
                this.logger.Error("Referencia nula" + exception.Message);
                throw;
            }
        }

        public void CargarDatosDeLosAlumnos(TipoFichero tipoFichero)
        {
            try
            {
                this.alumnoDao.CargarDatosDeLosAlumnos(tipoFichero);
            }
            catch (FileNotFoundException exception)
            {
                this.logger.Error("No se ha podido cargar el fichero" + exception.Message);
                throw;
            }
        }

        public List<Alumno> Leer(TipoFichero tipoFichero)
        {
            try
            {
                this.TipoFichero = tipoFichero;
                return this.alumnoDao.Leer(tipoFichero);
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error("No se han cargado datos del fichero" + exception.Message);
                throw;
            }
        }

        public List<Alumno> Filtrar(string clave, string valor)
        {
            try
            {
                List<Alumno> alumnos = this.alumnoDao.Leer(this.TipoFichero);
                return this.FiltrarLosAlumnos(alumnos, clave, valor);
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error("No se han cargado datos del fichero" + exception.Message);
                throw;
            }
        }

        public List<Alumno> FiltrarLosAlumnos(List<Alumno> alumnos, string clave, object valor)
        {
            try
            {
                this.logger.Debug("Entra Filtrar");
                var alumnosFiltrados =
                    from alumno in alumnos
                    where alumno.GetType().GetProperty(clave).GetValue(alumno).ToString() == valor.ToString()
                    select alumno;
                this.logger.Debug("Sale Filtrar");
                return alumnosFiltrados.ToList();
            }
            catch (NullReferenceException exception)
            {
                this.logger.Error("Referencia nula" + exception.Message);
                throw;
            }
        }
    }
}
