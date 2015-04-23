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
    /// The class for the splash screen view that is shown when the application is started.
    /// Derives from View.
    /// </summary>
    class Informacion : View
    {
        
        private Texture2D texture;
        public SpriteFont fuente;
        private Button Final;
        public SpriteFont fuente1;
        private Vector2 pos = Vector2.Zero;
        public Variables variable = new Variables();
        /// <summary>
        /// Creates a new splash screen view
        /// </summary>
        /// <param name="game">The Game instance that will show this view</param>
        public Informacion(Game1 game)
            : base(game)
        {


            {
                texture = game.Content.Load<Texture2D>("Images/FondoOpciones");
                fuente = game.Content.Load<SpriteFont>("Letras/Reinicio");
                fuente1 = game.Content.Load<SpriteFont>("Letras/Final");

            }

            Final = new Button("ProxNivel", new Vector2(210,400), game.Content);
            Final.ButtonPressed += (sender => game.OpenMenu());

            Variables.NivelCorrecto[Variables.nivelActual + 1] = 1;
            Variables.NivelTerminado[Variables.nivelActual] = 1;
            variable.guardar();
        }


        
        /// <summary>
        /// Updates the counter of the view.
        /// When the view is shown for two seconds, it's closed.
        /// </summary>
        public override void Update()
        {
            base.Update();
         //   Final.Update(touchLocation);
        }

        /// <summary>
        /// Draws the splash screen view
        /// </summary>
		public override void Draw(SpriteBatch spriteBatch)
        {
			base.Draw(spriteBatch);
            spriteBatch.Draw(texture, pos, Color.White);
            spriteBatch.DrawString(fuente, "ABOUT", new Vector2(160,230), Color.Black);
            spriteBatch.DrawString(fuente1, "Version: ", new Vector2(40, 320), Color.Black);
            spriteBatch.DrawString(fuente1, "v.1.0", new Vector2(280, 320), Color.Black);
            spriteBatch.DrawString(fuente1, "Denveloper: ", new Vector2(40, 390), Color.Black);
            spriteBatch.DrawString(fuente1, "Jas_19", new Vector2(280, 390), Color.Black);
          //  spriteBatch.DrawString(fuente1, "updates with more stages", new Vector2(10, 250), Color.Black);
           // Final.Draw(spriteBatch);
        }
    }
}
