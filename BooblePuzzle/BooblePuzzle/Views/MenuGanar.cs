/**
 * DashBubble Creado Por Jesus Alberto Saiz Cano Noviembre 2014
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using DashBubble.UI;
using Microsoft.Phone.Tasks;

namespace DashBubble
{
    /// <summary>
    /// This class defines the main menu view
    /// Derives from View.
    /// </summary>
    class MenuGanar : View
    {

        public static Int32 limiteDerecho = 460;
        public static Int32 limiteIzquierdo = 20;
        public static Int32 limiteArriba = 80;
        public static Int32 limiteAbajo = 720;
        public static Int32 tamanoBurbuja = 42;
        public Variables variable = new Variables();

        private Button Reiniciar;
        private Button MenuInicio;
        private Button PasarNivel; 
        private Texture2D texture;
        private Vector2 pos = Vector2.Zero;
        private Vector2 pos1 = Vector2.Zero;
        private Vector2 pos2 = Vector2.Zero;
        Texture2D Ganar;
     
        /// <summary>
        /// Creates a new main menu view
        /// </summary>
        /// <param name="game">The Game instance that will show this view</param>
        public MenuGanar(Game1 game)
            : base(game)
        {
            {
            //    texture = game.Content.Load<Texture2D>("fondoPantalla");
               // launcher = game.Content.Load<Texture2D>("arrow");
                Ganar = game.Content.Load<Texture2D>("Images/Ganar");

            }
        
			Vector2 pos = new Vector2(150, 435);
            Vector2 pos1 = new Vector2(115, 435);
            Vector2 pos2 = new Vector2(245, 435);

       //     Reiniciar = new Button("Reiniciar", pos, game.Content);
       //     Reiniciar.ButtonPressed += (sender => Reinicio());

            
            MenuInicio = new Button("MenuInicio", pos1, game.Content);
            MenuInicio.ButtonPressed += (sender => fases());

            PasarNivel = new Button("PasarNivel", pos2, game.Content);
            PasarNivel.ButtonPressed += (sender => ProximoNivel());
           
            
            // Guardar Puntuacion, y variable de nivel pasado Cuando ganamos
            
            Variables.NivelCorrecto[Variables.nivelActual + 1] = 1;
            Variables.NivelTerminado[Variables.nivelActual] = 1;
            variable.guardar();

		}


        public void fases()
        {
           // Variables.GanarPantalla = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.Burbujas = 0;
            Variables.puntuacion = Variables.puntuacion + Variables.puntuacionparcial;
            variable.guardar();
            if (Variables.EstoyEnAsia == true)
            {
                game.Nivel1();
            }
            else if (Variables.EstoyEnAfrica == true)
            {
                game.Nivel2();
            }
            else if (Variables.EstoyEnEuropa == true)
            {
                game.Nivel3();
            }
            else if (Variables.EstoyEnAmerica == true)
            {
                game.Nivel4();
            }
           

        }

        public void Reinicio()
        {

            Variables.JuegoIniciado = true;

            Variables.EstoyEnInicio = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;

            //  game.CargarContenido();
              game.InicializarNivel();
           
            game.cargarNivel();
        
        
        }

        public void ProximoNivel()
        {

            Variables.JuegoIniciado = true;

            Variables.EstoyEnInicio = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;

          //  game.CargarContenido();
            Variables.puntuacion = Variables.puntuacion + Variables.puntuacionparcial;
            variable.guardar();
            Variables.nivelActual = Variables.nivelActual + 1;
            game.cargarNivel();
        
        }
        /// <summary>
        /// Updates all the buttons in this view
        /// </summary>
        public override void Update()
        {
            base.Update();

            Variables.Burbujas = Variables.Burbujas + 1;
       //     Reiniciar.Update(touchLocation);
            PasarNivel.Update(touchLocation);
            MenuInicio.Update(touchLocation);
            if (Variables.Burbujas == 18)
            {

                Variables.JuegoIniciado = false;
            
            }
        }

        /// <summary>
        /// Draws all the buttons in this view
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {

           // spriteBatch.Draw(texture,pos,Color.White);
            base.Draw(spriteBatch);
           // spriteBatch.Draw(game.textTecho, new Vector2(limiteIzquierdo - 20, (limiteArriba + (game.posTecho * tamanoBurbuja)) - 705), null, Color.White);
            spriteBatch.Draw(Ganar, new Vector2(20, 250), Color.White);
      //      Reiniciar.Draw(spriteBatch);
            PasarNivel.Draw(spriteBatch);
            MenuInicio.Draw(spriteBatch);
      
        }
    }
}
