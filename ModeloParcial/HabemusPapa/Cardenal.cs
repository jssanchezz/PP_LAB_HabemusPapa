using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabemusPapa
{
    public class Cardenal
    {
        private int _cantVotosRecibidos;
        private eNacionalidades _nacionalidad;
        private string _nombre;
        private string _nombrePapal;

        #region "Constructores"

        private Cardenal()
        {
            this._cantVotosRecibidos = 0;
            this._nacionalidad = eNacionalidades.Italiano;
        }

        public Cardenal(string nombre, string nombrePapal)
            : this()
        {
            this._nombre = nombre;
            this._nombrePapal = nombrePapal;
        }

        public Cardenal(string nombre, string nombrePapal, eNacionalidades nacionalidad)
            : this(nombre, nombrePapal)
        {
            this._nacionalidad = nacionalidad;
        }

        #endregion

        #region "Métodos"

        public int getCantidadVotosRecibidos()
        {
            return this._cantVotosRecibidos;
        }

        public string ObtenerNombreYNombrePapal()
        {
            return "El cardenal " + this._nombre + " se llamará ``" + this._nombrePapal + "´´ ";
        }

        private string Mostrar()
        {
            return this.ObtenerNombreYNombrePapal() + "\nNacionalidad: " + this._nacionalidad.ToString() + "\nCantidad de votos: " + this._cantVotosRecibidos;
        }

        public static string Mostrar(Cardenal unCardenal)
        {
            return unCardenal.Mostrar();
        }

        #endregion

        #region "Operadores"

        public static bool operator ==(Cardenal unCardenal, Cardenal otroCardenal)
        {
            if (unCardenal._nombre == otroCardenal._nombre && unCardenal._nombrePapal == otroCardenal._nombrePapal && unCardenal._nacionalidad == otroCardenal._nacionalidad)
                return true;
            return false;
        }

        public static bool operator !=(Cardenal unCardenal, Cardenal otroCardenal)
        {
            if (unCardenal._nombre == otroCardenal._nombre && unCardenal._nombrePapal == otroCardenal._nombrePapal && unCardenal._nacionalidad == otroCardenal._nacionalidad)
                return false;
            return true;
        }

        public static Cardenal operator ++(Cardenal unCardenal)
        {
            unCardenal._cantVotosRecibidos++;
            return unCardenal;
        }

        #endregion
    }
}
