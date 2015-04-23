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
using OpenXLive;
using OpenXLive.Features;
using OpenXLive.Form;
using Microsoft.Phone.Tasks;
using OpenXLive.Forms;

namespace DashBubble
{
    /// <summary>
    /// This class defines the main menu view
    /// Derives from View.
    /// </summary>
    class Menu : View
    {
        private List<Button> buttons = new List<Button>();
        private Button NewButton;
        private Button OpcionButton;
        private Button ExitButton; 
        private Button RateButton;
        private Button VideoButton;
        private Button Podium;
        private const int spacing = 2;
        private Texture2D texture;
        private Vector2 pos = Vector2.Zero;
        private Vector2 pos1 = Vector2.Zero;
        private Vector2 pos2 = Vector2.Zero;
        private Vector2 pos3 = Vector2.Zero;
        private Vector2 pos4 = Vector2.Zero;
        public Variables variable = new Variables();
        /// <summary>
        /// Creates a new main menu view
        /// </summary>
        /// <param name="game">The Game instance that will show this view</param>
        public Menu(Game1 game)
            : base(game)
        {
            {
                texture = game.Content.Load<Texture2D>("Images/FondoMenu");

            }
        
			Vector2 pos = new Vector2(game.getWidth() * 0.18f, 300);
            Vector2 pos1 = new Vector2(game.getWidth() * 0.18f, 380);
            Vector2 pos2 = new Vector2(game.getWidth() * 0.18f, 460);
            Vector2 pos3 = new Vector2(game.getWidth() * 0.08f, 600);
            Vector2 pos4 = new Vector2(game.getWidth() * 0.70f, 600);
            Vector2 pos5 = new Vector2(game.getWidth() * 0.39f, 590);

            NewButton = new Button("newGame", pos, game.Content);
            NewButton.ButtonPressed += (sender => fases());
           // infoButton.ButtonPressed += (sender => VariablesJuego.Pause = true);
            
            OpcionButton = new Button("Opcion", pos1, game.Content);
            OpcionButton.ButtonPressed += (sender => MenuOpciones());
            ExitButton = new Button("exit", pos2, game.Content);
            RateButton = new Button("rate", pos3, game.Content);
            RateButton.ButtonPressed += (sender => ShowMarket());
            VideoButton = new Button("video", pos4, game.Content);
            VideoButton.ButtonPressed += (sender => VideoGame());
            ExitButton.ButtonPressed += (sender => game.Exit());

            Podium = new Button("Podium", pos5, game.Content);
            Podium.ButtonPressed += (sender => Records());

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

        public void Records()
        {
            Variables.EstoyEnRecords = true;
            XLiveFormFactory.Factory.ShowGameCenterPage();
        
        }

        public void ShowMarket()
        {
            var task = new MarketplaceReviewTask();
            task.Show();
            
        }

        // Nos muestra el juego en el market para descargar

        public void VideoGame()
        {
            //variable.Reset2();
            var task = new MarketplaceDetailTask();
            task.ContentIdentifier = "e8bfb811-ef46-4297-a559-88f9c6d03f99";
            task.ContentType = MarketplaceContentType.Applications;
            task.Show();

        }
        public void MenuOpciones()
        {

            game.Opciones();
        
        }
        public void Reset1()
        {

            variable.Reset1();

        }
        public void fases()
        {
            game.fases();

        }
        /// <summary>
        /// Updates all the buttons in this view
        /// </summary>
        public override void Update()
        {
            base.Update();

            NewButton.Update(touchLocation);
            OpcionButton.Update(touchLocation);
            ExitButton.Update(touchLocation);
            RateButton.Update(touchLocation);
            VideoButton.Update(touchLocation);
            Podium.Update(touchLocation);
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
            NewButton.Draw(spriteBatch);
            OpcionButton.Draw(spriteBatch);
            ExitButton.Draw(spriteBatch);
            RateButton.Draw(spriteBatch);
            VideoButton.Draw(spriteBatch);
            Podium.Draw(spriteBatch);
           foreach (Button but in buttons) 
            {
                
			but.Draw(spriteBatch);
            
            }
           
        }
    }
}
