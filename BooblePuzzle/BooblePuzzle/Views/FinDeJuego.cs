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
    class FinDeJuego : View
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
        public FinDeJuego(Game1 game)
            : base(game)
        {


            {
                texture = game.Content.Load<Texture2D>("Images/FinalJuego");
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
            Final.Update(touchLocation);
        }

        /// <summary>
        /// Draws the splash screen view
        /// </summary>
		public override void Draw(SpriteBatch spriteBatch)
        {
			base.Draw(spriteBatch);
            spriteBatch.Draw(texture, pos, Color.White);
            spriteBatch.DrawString(fuente, "WIN!!!", new Vector2(150,30), Color.Black);
            spriteBatch.DrawString(fuente1, "Congratulation!!", new Vector2(100, 90), Color.Black);
            spriteBatch.DrawString(fuente1, "The Earth is now save", new Vector2(40, 130), Color.Black);
            spriteBatch.DrawString(fuente1, "Thanks, for download ", new Vector2(40, 170), Color.Black);
            spriteBatch.DrawString(fuente1, "the game and wait more", new Vector2(40, 210), Color.Black);
            spriteBatch.DrawString(fuente1, "updates with more stages", new Vector2(10, 250), Color.Black);
            Final.Draw(spriteBatch);
        }
    }
}
