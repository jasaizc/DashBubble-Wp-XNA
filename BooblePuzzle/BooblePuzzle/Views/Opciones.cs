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
    class Opciones : View
    {
       
        private Button Musica;
        private Button Mail;
        private Button Efectos; 
        private Button Reseteo;
        private Button Info;
        private Button Ayuda;
        private const int spacing = 2;
        private Texture2D texture;
        public SpriteFont fuente;
        private Vector2 pos = Vector2.Zero;
        private Vector2 pos1 = new Vector2(80, 390);
        private Vector2 pos2 = new Vector2(290, 390);

        private Vector2 pos3 = new Vector2(80, 570);
        private Vector2 pos6 = new Vector2(290, 570);
        private Vector2 pos4 = new Vector2(80, 750);
        private Vector2 pos5 = new Vector2(290, 750);
        public Variables variable = new Variables();
        /// <summary>
        /// Creates a new main menu view
        /// </summary>
        /// <param name="game">The Game instance that will show this view</param>
        public Opciones(Game1 game)
            : base(game)
        {
            {
                texture = game.Content.Load<Texture2D>("Images/FondoOpciones");
                fuente = game.Content.Load<SpriteFont>("Letras/Opciones");

               
            }
        
			Vector2 pos = new Vector2(80, 260);
            Vector2 posMail = new Vector2(280, 260);
            Vector2 posEfectos = new Vector2(80, 440);
            Vector2 posReseteo = new Vector2(80, 620);
            Vector2 posInfo = new Vector2(280, 620);
            Vector2 posAyuda = new Vector2(280, 440);
            if (Variables.Musica == true)
            {
                Musica = new Button("Music", pos, game.Content);
                Musica.ButtonPressed += (sender => MusicaNo());
            }
            if (Variables.Musica == false)
            {
                Musica = new Button("NoMusic", pos, game.Content);
                Musica.ButtonPressed += (sender => MusicaSi());
            }
           // infoButton.ButtonPressed += (sender => VariablesJuego.Pause = true);
            
             Mail = new Button("Mail", posMail, game.Content);
             Mail.ButtonPressed += (sender => Correo());

             if (Variables.Efectos == true)
             {
                 Efectos = new Button("Efectos", posEfectos, game.Content);
                 Efectos.ButtonPressed += (sender => EfectosNo());
             }
             if (Variables.Efectos == false)
             {
                 Efectos = new Button("NoEfectos", posEfectos, game.Content);
                 Efectos.ButtonPressed += (sender => EfectosSi());
             }

             Reseteo = new Button("Reset", posReseteo, game.Content);
             Reseteo.ButtonPressed += (sender => Reset());
 
            Info = new Button("Info", posInfo, game.Content);
            Info.ButtonPressed += (sender => game.Info());

            if (Variables.Ayuda == true)
            {
                Ayuda = new Button("Ayuda", posAyuda, game.Content);
                Ayuda.ButtonPressed += (sender => AyudaNo());
            }
            if (Variables.Ayuda == false)
            {
                Ayuda = new Button("NoAyuda", posAyuda, game.Content);
                Ayuda.ButtonPressed += (sender => AyudaSi());
            }
			
		}


        // Nos muestra el juego en el market para descargar

        public void Reset()
        {

            game.Resetear();
        
        }

        public void Correo()
        {
            
            var task = new EmailComposeTask();
            task.To = "jas_n19@hotmail.com";
            task.Subject = "DashBubble";
            task.Show();
        
        
        }
        public void AyudaSi()
        {

            Variables.Ayuda = true;
            variable.guardar();
            game.Opciones();

        }
        public void AyudaNo()
        {

            Variables.Ayuda = false;
            variable.guardar();
            game.Opciones();

        }
        public void MusicaSi()
        {
            if (Game1.ZuneFuncionando == true)
            {

                game.Musica();
            
            }
            else if(Game1.ZuneFuncionando == false)
            {

            Variables.Musica = true;
            variable.guardar();
            game.Opciones();
            }

        }
        public void EfectosSi()
        {

            Variables.Efectos = true;
            variable.guardar();
            game.Opciones();

        }
        public void MusicaNo()
        {

            Variables.Musica = false;
            variable.guardar();
            game.Opciones();

        }
        public void EfectosNo()
        {

            Variables.Efectos = false;
            variable.guardar();
            game.Opciones();

        }
        /// <summary>
        /// Updates all the buttons in this view
        /// </summary>
        public override void Update()
        {
            base.Update();
            variable.cargar();

            Musica.Update(touchLocation);
            Mail.Update(touchLocation);
            Efectos.Update(touchLocation);
            Reseteo.Update(touchLocation);
            Info.Update(touchLocation);
            Ayuda.Update(touchLocation);
        }

        /// <summary>
        /// Draws all the buttons in this view
        /// </summary>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
          //  spriteBatch.Draw(texture, pos, Color.White);
            base.Draw(spriteBatch);
            spriteBatch.DrawString(fuente,"SOUND", pos1, Color.Black);
            spriteBatch.DrawString(fuente, "MAIL", pos2, Color.Black);
            spriteBatch.DrawString(fuente, "EFECTS", pos3, Color.Black);
            spriteBatch.DrawString(fuente, "RESET", pos4, Color.Black);
            spriteBatch.DrawString(fuente, "INFO", pos5, Color.Black);
            spriteBatch.DrawString(fuente, "HELP", pos6, Color.Black);
            Musica.Draw(spriteBatch);
            Mail.Draw(spriteBatch);
            Efectos.Draw(spriteBatch);
            Reseteo.Draw(spriteBatch);
            Info.Draw(spriteBatch);
            Ayuda.Draw(spriteBatch);

           
        }
    }
}
