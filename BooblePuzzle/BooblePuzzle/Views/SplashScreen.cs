/**
 * DashBubble Creado Por Jesus Alberto Saiz Cano Noviembre 2014
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DashBubble
{
    /// <summary>
    /// The class for the splash screen view that is shown when the application is started.
    /// Derives from View.
    /// </summary>
    class SplashScreen : View
    {
        
        private Texture2D texture;
        private Vector2 pos = Vector2.Zero;
        private int counter = 0;
        private int viewingTime = 50;
        public Variables variable = new Variables();
        /// <summary>
        /// Creates a new splash screen view
        /// </summary>
        /// <param name="game">The Game instance that will show this view</param>
        public SplashScreen(Game1 game)
            : base(game)
        {
            texture = game.Content.Load<Texture2D>("Images/splash");
            Variables.Inicializar = 1;
            variable.cargar();
        }

        /// <summary>
        /// Updates the counter of the view.
        /// When the view is shown for two seconds, it's closed.
        /// </summary>
        public override void Update()
        {
            base.Update();
            counter++;
            if (counter == viewingTime)
               
               game.OpenMenu(); 
        }

        /// <summary>
        /// Draws the splash screen view
        /// </summary>
		public override void Draw(SpriteBatch spriteBatch)
        {
			base.Draw(spriteBatch);
            spriteBatch.Draw(texture, pos, Color.White);
        }
    }
}
