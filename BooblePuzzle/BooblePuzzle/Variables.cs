
/**
 * DashBubble Creado Por Jesus Alberto Saiz Cano Noviembre 2014
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;

namespace DashBubble
{
   public class Variables
    {
        static int pantallas = 200;
        public static int Inicializar = 0;

        public static int[] NivelCorrecto = new int[pantallas];
        public static int[] NivelTerminado = new int[pantallas];
        public static int puntuacion;
        public static int puntuacionparcial;
        public static int nivelActual = 0; // Sabemos en que pantalla estamos.


        public static bool JuegoIniciado = false;  //La utilizamos para indicar que estamos jugando una partida.   
        public static int Burbujas = 0;                    // Lo utilizaremos para continuar la animacion de las burbujas cuando se gana.
        public static bool Musica = true;           // La Utilizaremos para indicar si queremos escuhcar la musica  del juego o no.
        public static bool Efectos = true;          // La Utilizaremos para indicar si queremos escuchar los efectos del juego o no.
        public static bool Ayuda = true;            // La Utilizaremos para indicar si queremos utilizar la ayuda en el juego.
        public static int Ganar = 0;                // La utilizamos para que suene la cancion de ganar o de perder una unica vez.
        
       
       // Variables para controlar las pantallas del menu y los distintos menus desplegables para poder gestionarlos con el
        // boton back (<--) de Windows Phone.

        public static bool EstoyEnInicio = false;
        public static bool EstoyEnFases = false;
        public static bool EstoyEnNiveles = false;
        public static bool EstoyEnOpciones = false;
        public static bool EstoyEnMenuPausa = false;
        public static bool EstoyEnMenuGanar = false;
        public static bool EstoyEnMenuPerder = false;
        public static bool EstoyEnMenuResetear = false;
        public static bool EstoyEnMenuMusica = false;
        public static bool EstoyEnFinDeJuego = false;
        public static bool EstoyEnInformacion = false;
        public static bool EstoyEnAsia = false;
        public static bool EstoyEnEuropa = false;
        public static bool EstoyEnAfrica = false;
        public static bool EstoyEnAmerica = false;
        public static bool EstoyEnRecords = false;


        public static bool fases = false;
        public static bool fase1 = false;
        public static bool PauseJuego = true;
        public static bool Pause = true;
        public static bool HighScore = false;
        public static bool Informacion = false;
        public static bool Win = false;

        public static bool Record = false;
        public static int Bonus = 1;
        public bool paused = false;


       // RESETEO EN EL QUE PONEMOS TODOS LOS VALORES A 0

        public void Reset()
        {
            puntuacion = 0;
            for (int i = 0; i < pantallas; i++)
            {
                NivelCorrecto[i] = 0;
                NivelTerminado[i] = 0;
            }
            guardar();
        }

       //  RESETEO EN EL QUE DESBLOQUEAMOS TODOS LOS NIVELES

        public void Reset1()
        {
            puntuacion = 0;
            for (int i = 0; i < pantallas; i++)
            {
                NivelCorrecto[i] = 1;
                NivelTerminado[i] = 0;
            }
            Game1.ZuneFuncionando = true;
            guardar();
        }

       // RESETO EN EL QUE NOS PASAMOS TODOS LOS NIVELES

        public void Reset2()
        {
            puntuacion = 0;
            for (int i = 0; i < pantallas; i++)
            {
                NivelCorrecto[i] = 1;
                NivelTerminado[i] = 1;
            }
            guardar();
        }


       //AQUI GUARDAMOS LOS DATOS


        public void guardar()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (settings.Contains("Musica"))
            {

                settings["Musica"] = Musica;

            }
            else
            {
                settings.Add("Musica", Musica);
            }

            if (settings.Contains("Efectos"))
            {

                settings["Efectos"] = Efectos;

            }
            else
            {
                settings.Add("Efectos", Efectos);
            }


            if (settings.Contains("Ayuda"))
            {

                settings["Ayuda"] = Ayuda;

            }
            else
            {
                settings.Add("Ayuda", Ayuda);
            }

            if (settings.Contains("Puntuacion"))
            {
                settings["Puntuacion"] = puntuacion;
            }
            else
            {
                settings.Add("Puntuacion", puntuacion);
            }
            for (int i = 0; i < pantallas; i++)
            {
                if (settings.Contains("Nivel" + i))
                {
                    settings["Nivel" + i] = NivelCorrecto[i];
                }
                else
                {
                    settings.Add("Nivel" + i, NivelCorrecto[i]);
                }
                if (settings.Contains("NivelTerminado" + i))
                {
                    settings["NivelTerminado" + i] = NivelTerminado[i];
                }
                else
                {
                    settings.Add("NivelTerminado" + i, NivelTerminado[i]);
                }
            }
        }


       // AQUI ES DONDE CARGAMOS TODOS LOS VALORES DE REFERERNCIA DEL JUEGO


        public void cargar()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("Musica"))
            {
                Musica = (bool)settings["Musica"];
            }
            else
            {
                Musica = true;

            }

            if (settings.Contains("Efectos"))
            {
                Efectos = (bool)settings["Efectos"];
            }
            else
            {
                Efectos = true;

            }

            if (settings.Contains("Ayuda"))
            {
                Ayuda = (bool)settings["Ayuda"];
            }
            else
            {
                Ayuda = true;

            }


            if (settings.Contains("Puntuacion"))
            {
                puntuacion = (int)settings["Puntuacion"];
            }
            else
            {
                puntuacion = 0;

            }
            for (int i = 0; i < pantallas; i++)
            {

                if (settings.Contains("Nivel" + i))
                {
                    NivelCorrecto[i] = (int)settings["Nivel" + i];
                }
                else
                {
                    NivelCorrecto[i] = 0;
                }
                if (settings.Contains("NivelTerminado" + i))
                {
                    NivelTerminado[i] = (int)settings["NivelTerminado" + i];
                }
                else
                {
                    NivelTerminado[i] = 0;
                }
            }
        }


    }
}
