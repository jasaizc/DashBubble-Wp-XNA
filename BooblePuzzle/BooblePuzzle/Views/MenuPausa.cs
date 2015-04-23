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
    class MenuPausa : View
    {

        public static Int32 limiteDerecho = 460;
        public static Int32 limiteIzquierdo = 20;
        public static Int32 limiteArriba = 80;
        public static Int32 limiteAbajo = 720;
        public static Int32 tamanoBurbuja = 42;
        public Variables variable = new Variables();

        private Button Reiniciar;
        private Button MenuInicio;
        private Button Continuar; 
        private Texture2D texture;
        private Vector2 pos = Vector2.Zero;
        private Vector2 pos1 = Vector2.Zero;
        private Vector2 pos2 = Vector2.Zero;
        Texture2D launcher;
        Texture2D Pausa;
        /// <summary>
        /// Creates a new main menu view
        /// </summary>
        /// <param name="game">The Game instance that will show this view</param>
        public MenuPausa(Game1 game)
            : base(game)
        {
            {
            //    texture = game.Content.Load<Texture2D>("fondoPantalla");
               // launcher = game.Content.Load<Texture2D>("arrow");
                Pausa = game.Content.Load<Texture2D>("Images/Pausa");

            }
        
			Vector2 pos = new Vector2(40, 430);
            Vector2 pos1 = new Vector2(180, 430);
            Vector2 pos2 = new Vector2(320, 430);

            Reiniciar = new Button("Reiniciar", pos, game.Content);
            Reiniciar.ButtonPressed += (sender => Reinicio());

            
            MenuInicio = new Button("MenuInicio", pos2, game.Content);
            MenuInicio.ButtonPressed += (sender => fases());

            Continuar = new Button("continuar", pos1, game.Content);
            Continuar.ButtonPressed += (sender => ContinuarNivel());
           
            
            // Guardar Puntuacion, y variable de nivel pasado Cuando ganamos

         //   variable.guardar();
		}


        public void fases()
        {
           // Variables.GanarPantalla = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.Burbujas = 0;

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

        public void ContinuarNivel()
        {

            game.Reanudar();
        
        }
        /// <summary>
        /// Updates all the buttons in this view
        /// </summary>
        public override void Update()
        {
            base.Update();
            Reiniciar.Update(touchLocation);
            Continuar.Update(touchLocation);
            MenuInicio.Update(touchLocation);
           
        }

        /// <summary>
        /// Draws all the buttons in this view
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {

           // spriteBatch.Draw(texture,pos,Color.White);
            base.Draw(spriteBatch);
           // spriteBatch.Draw(game.textTecho, new Vector2(limiteIzquierdo - 20, (limiteArriba + (game.posTecho * tamanoBurbuja)) - 705), null, Color.White);
            spriteBatch.Draw(Pausa, new Vector2(20, 250), Color.White);
            Reiniciar.Draw(spriteBatch);
            Continuar.Draw(spriteBatch);
            MenuInicio.Draw(spriteBatch);
      
        }
    }
}
