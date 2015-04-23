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
    class Fases : View
    {
        private List<Button> buttons = new List<Button>();
        private Button Asia;
        private Button Africa;
        private Button Europa; 
        private Button America;
        //private Button VideoButton;
        private const int spacing = 2;
        private Texture2D texture;
        private Vector2 pos = Vector2.Zero;
        private Vector2 pos1 = Vector2.Zero;
        private Vector2 pos2 = Vector2.Zero;
        private Vector2 pos3 = Vector2.Zero;

        /// <summary>
        /// Creates a new main menu view
        /// </summary>
        /// <param name="game">The Game instance that will show this view</param>
        public Fases(Game1 game)
            : base(game)
        {
            {
                texture = game.Content.Load<Texture2D>("Images/FondoOpciones");
            }
        
			Vector2 pos = new Vector2(90, 280);
            Vector2 pos1 = new Vector2(90, 380);
            Vector2 pos2 = new Vector2(90, 480);
            Vector2 pos3 = new Vector2(90, 580);
           
            
            Asia = new Button("fase1", pos, game.Content);
            Asia.ButtonPressed += (sender => fase1());
           // infoButton.ButtonPressed += (sender => VariablesJuego.Pause = true);
            
            Africa = new Button("fase2", pos1, game.Content);
            Africa.ButtonPressed += (sender => fase2());
           
            Europa = new Button("fase3", pos2, game.Content);
            Europa.ButtonPressed += (sender => fase3());
            
            America = new Button("fase4", pos3, game.Content);
            America.ButtonPressed += (sender => fase4());
            
			int menuHeight = (buttons.Count - 1) * spacing;
            foreach (Button but in buttons) 
            {
			    menuHeight += but.Height;
			}

			pos.Y = game.getHeight() * 0.01f - menuHeight * 0.01f;

			for (int i = 0; i < buttons.Count; i++)
			{
				pos.X = game.getWidth() * 0.01f - buttons[i].Width * 0.01f;
				buttons[i].Position = pos;
				pos.Y += (buttons[i].Height + spacing);
			}
      
		}

        //Nos lo muestra para que lo valoremos

       
        public void fase1()
        {
            
            game.Nivel1();

        }
        public void fase2()
        {
            game.Nivel2();
        }
        public void fase3()
        {
            game.Nivel3();
        }
        public void fase4()
        {
            game.Nivel4();
        }
        /// <summary>
        /// Updates all the buttons in this view
        /// </summary>
        public override void Update()
        {
            base.Update();

            Asia.Update(touchLocation);
            Africa.Update(touchLocation);
            Europa.Update(touchLocation);
            America.Update(touchLocation);
            //VideoButton.Update(touchLocation);
            foreach (Button but in buttons)
            {
                but.Update(touchLocation);
            }
            
        }

        /// <summary>
        /// Draws all the buttons in this view
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
          //  spriteBatch.Draw(texture, pos, Color.White);
            base.Draw(spriteBatch);
            Asia.Draw(spriteBatch);
            Africa.Draw(spriteBatch);
            Europa.Draw(spriteBatch);
            America.Draw(spriteBatch);
          //  VideoButton.Draw(spriteBatch);
           foreach (Button but in buttons) 
            {
                
			but.Draw(spriteBatch);
            
            }
           
        }
    }
}
