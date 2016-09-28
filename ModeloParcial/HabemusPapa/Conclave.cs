using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabemusPapa
{
    public class Conclave
    {
        private int _cantMaxCardenales;
        private List<Cardenal> _cardenales;
        private bool _habemusPapa;
        private string _lugarEleccion;
        private Cardenal _papa;
        public static int cantidadVotaciones;
        public static DateTime fechaVotacion;

        public static Random randomVotos;

        #region "Constructores"

        private Conclave()
        {
            this._cantMaxCardenales = 1;
            this._lugarEleccion = "Capilla Sixtina";

            this._cardenales = new List<Cardenal>();
            this._habemusPapa = false;
        }

        private Conclave(int cantidadCardenales)
            : this()
        {
            this._cantMaxCardenales = cantidadCardenales;
        }

        public Conclave(int cantidadCardenales, string lugarVotacion)
            : this(cantidadCardenales)
        {
            this._lugarEleccion = lugarVotacion;            
        }

        static Conclave()
        {
            cantidadVotaciones = 0;
            fechaVotacion = DateTime.Now;

            randomVotos = new Random();
        }

        #endregion

        #region "Metodos"

        private bool HayLugar()
        {
            if (this._cardenales.Count < this._cantMaxCardenales)
                return true;
            Console.WriteLine("No hay mas lugar!");
            return false;
        }

        private string MostrarCardenales()
        {
            StringBuilder mySb = new StringBuilder();

            foreach (Cardenal item in this._cardenales)
            {
                mySb.AppendLine(Cardenal.Mostrar(item));
            }

            return mySb.ToString();
        }

        public string Mostrar()
        {
            StringBuilder mySb = new StringBuilder();

            mySb.AppendLine("Lugar de la eleccion: " + this._lugarEleccion);
            mySb.AppendLine("Fecha: " + fechaVotacion.ToString());
            mySb.AppendLine("Cantidad de votaciones : " + cantidadVotaciones);
            if (this._habemusPapa)
            {
                mySb.AppendLine("HABEMUS PAPA!!!");
                mySb.AppendLine(this._papa.ObtenerNombreYNombrePapal());
            }
                
            else
                mySb.AppendLine("NO HABEMUS PAPA.");

            mySb.AppendLine(this.MostrarCardenales());

            return mySb.ToString();
        }


        public static void VotarPapa(Conclave unConclave)
        {
            int indicePapal;

            for (int i = 0; i < unConclave._cardenales.Count ; i++)
            {
                indicePapal = randomVotos.Next(0, unConclave._cardenales.Count);
                unConclave._cardenales[indicePapal]++;
            }

            Conclave.ContarVotos(unConclave);
        }

        private static void ContarVotos(Conclave unConclave)
        {
            Cardenal mayor = unConclave._cardenales[0];
            int cont = 0;

            for (int i = 0; i < unConclave._cardenales.Count; i++)
            {
                if (unConclave._cardenales[i].getCantidadVotosRecibidos() > mayor.getCantidadVotosRecibidos())
                    mayor = unConclave._cardenales[i];
            }

            foreach (Cardenal item in unConclave._cardenales)
            {
                if (item.getCantidadVotosRecibidos() == mayor.getCantidadVotosRecibidos())
                    cont++;
            }

            if (cont == 1)
            {
                unConclave._papa = mayor;
                unConclave._habemusPapa = true;
            }
        }

        #endregion

        #region "Operadores"

        public static implicit operator Conclave(int cantCardenales)
        {
            return new Conclave(cantCardenales);
        }

        public static explicit operator bool(Conclave unConclave)
        {
            return unConclave._habemusPapa;
        }

        public static bool operator ==(Conclave unConclave, Cardenal unCardenal)
        {
            foreach (Cardenal item in unConclave._cardenales)
            {
                if (item == unCardenal)
                {
                    Console.WriteLine("El cardenal ya existe!");
                    return true;
                }
                    
            }
            return false;
        }

        public static bool operator !=(Conclave unConclave, Cardenal unCardenal)
        {
            foreach (Cardenal item in unConclave._cardenales)
            {
                if (item == unCardenal)
                    return false;
            }
            return true;
        }

        public static Conclave operator +(Conclave unConclave, Cardenal unCardenal)
        {
            if(unConclave.HayLugar())
                if(!(unConclave == unCardenal))
                    unConclave._cardenales.Add(unCardenal);                

            return unConclave;
        }

        #endregion
    }
}
