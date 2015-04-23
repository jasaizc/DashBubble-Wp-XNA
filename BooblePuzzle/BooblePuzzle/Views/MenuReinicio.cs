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
    class MenuReinicio : View
    {

        public static Int32 limiteDerecho = 460;
        public static Int32 limiteIzquierdo = 20;
        public static Int32 limiteArriba = 80;
        public static Int32 limiteAbajo = 720;
        public static Int32 tamanoBurbuja = 42;
        public Variables variable = new Variables();

        private Button Reiniciar;
        private Button MenuInicio;
       // private Button PasarNivel; 
        private Texture2D texture;
        private Vector2 pos = Vector2.Zero;
        private Vector2 pos1 = Vector2.Zero;
        private Vector2 pos2 = Vector2.Zero;
        private Vector2 pos3 = new Vector2(80,350);
        public SpriteFont fuente;
        Texture2D Perder;
     
        /// <summary>
        /// Creates a new main menu view
        /// </summary>
        /// <param name="game">The Game instance that will show this view</param>
        public MenuReinicio(Game1 game)
            : base(game)
        {
            {
                texture = game.Content.Load<Texture2D>("Images/MenuReinicio");
               // launcher = game.Content.Load<Texture2D>("arrow");
                  Perder = game.Content.Load<Texture2D>("Images/MenuReinicio1");
                  fuente = game.Content.Load<SpriteFont>("Letras/Reinicio");

            }
        
			Vector2 pos = new Vector2(150, 500);
            Vector2 pos1 = new Vector2(105, 430);
            Vector2 pos2 = new Vector2(255, 430);

            Reiniciar = new Button("Ok", pos1, game.Content);
            Reiniciar.ButtonPressed += (sender => Reinicio());

            
            MenuInicio = new Button("Cancel", pos2, game.Content);
            MenuInicio.ButtonPressed += (sender => Opcions());

		}


 

        public void Reinicio()
        {

            variable.Reset();
            variable.guardar();
            game.Opciones();
        
        }

        public void Opcions()
        {
            game.Opciones();
        
        }
        /// <summary>
        /// Updates all the buttons in this view
        /// </summary>
        public override void Update()
        {
            base.Update();
            Reiniciar.Update(touchLocation);
       //     PasarNivel.Update(touchLocation);
            MenuInicio.Update(touchLocation);

        }

        /// <summary>
        /// Draws all the buttons in this view
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture,pos,Color.White);
            
            base.Draw(spriteBatch);
           // spriteBatch.Draw(game.textTecho, new Vector2(limiteIzquierdo - 20, (limiteArriba + (game.posTecho * tamanoBurbuja)) - 705), null, Color.White);
            spriteBatch.Draw(Perder, new Vector2(20, 250), Color.White);
            spriteBatch.DrawString(fuente, "YOU SURE?", pos3, Color.Black);
            Reiniciar.Draw(spriteBatch);
      //      PasarNivel.Draw(spriteBatch);
            MenuInicio.Draw(spriteBatch);
      
        }
    }
}
