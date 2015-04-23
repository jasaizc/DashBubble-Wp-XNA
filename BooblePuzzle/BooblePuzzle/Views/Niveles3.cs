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
    class Niveles3 : View
    {
         private List<Button> buttons = new List<Button>();
      //  private View view;
        private Button Nivel1;
        private Button Nivel2;
        private Button Nivel3;
        private Button Nivel4;
        private Button Nivel5;
        private Button Nivel6;
        private Button Nivel7;
        private Button Nivel8;
        private Button Nivel9;
        private Button Nivel10;
        private Button Nivel11;
        private Button Nivel12;
        private Button Nivel13;
        private Button Nivel14;
        private Button Nivel15;
        private Button Nivel16;
        private Button Nivel18;
        private Button Menu;
        private Texture2D candado;
        private Texture2D estrella;
        public Variables variable = new Variables();
        public SpriteFont fuente;

        private const int spacing = 2;
        private Texture2D texture;
        private Texture2D puntuacion;

        private Vector2 pos = Vector2.Zero;
        private Vector2 pos0 = new Vector2(19, 150);
        private Vector2 pos1 = new Vector2(135, 150);
        private Vector2 pos2 = new Vector2(251, 150);
        private Vector2 pos3 = new Vector2(367, 150);
        private Vector2 pos4 = new Vector2(19, 270);
        private Vector2 pos5 = new Vector2(135, 270);
        private Vector2 pos6 = new Vector2(251, 270);
        private Vector2 pos7 = new Vector2(367, 270);
        private Vector2 pos8 = new Vector2(19, 390);
        private Vector2 pos9 = new Vector2(135, 390);
        private Vector2 pos10 = new Vector2(251, 390);
        private Vector2 pos11 = new Vector2(367, 390);
        private Vector2 pos12 = new Vector2(19, 510);
        private Vector2 pos13 = new Vector2(135, 510);
        private Vector2 pos14 = new Vector2(251, 510);
        private Vector2 pos18 = new Vector2(367, 510);
        private Vector2 pos15 = new Vector2(300, 640);
        public SpriteFont fuente1;
        /// <summary>
        /// Creates a new main menu view
        /// </summary>
        /// <param name="game">The Game instance that will show this view</param>
        public Niveles3(Game1 game)
            : base(game)
        {
            {
                texture = game.Content.Load<Texture2D>("Images/Nivel3");
                candado = game.Content.Load<Texture2D>("Images/Candado");
                estrella = game.Content.Load<Texture2D>("Images/Estrella");
                puntuacion = game.Content.Load<Texture2D>("Images/puntuacion");
                fuente = game.Content.Load<SpriteFont>("Letras/spriteFont3");
                fuente1 = game.Content.Load<SpriteFont>("Letras/NumerosNiveles");
                variable.cargar();
            }

            Vector2 pos0 = new Vector2(5, 5);
			Vector2 pos = new Vector2(16, 150);
            Vector2 pos1 = new Vector2(132, 150);
            Vector2 pos2 = new Vector2(248, 150);
            Vector2 pos3 = new Vector2(364, 150);
            Vector2 pos4 = new Vector2(16, 270);
            Vector2 pos5 = new Vector2(132, 270);
            Vector2 pos6 = new Vector2(248, 270);
            Vector2 pos7 = new Vector2(364, 270);
            Vector2 pos8 = new Vector2(16, 390);
            Vector2 pos9 = new Vector2(132, 390);
            Vector2 pos10 = new Vector2(248, 390);
            Vector2 pos11 = new Vector2(364, 390);
            Vector2 pos12 = new Vector2(16, 510);
            Vector2 pos13 = new Vector2(132, 510);
            Vector2 pos14 = new Vector2(248, 510);
            Vector2 pos18 = new Vector2(364, 510);
            Vector2 pos15 = new Vector2(300, 640);
           // Vector2 pos16 = new Vector2(80, 640);

            Menu = new Button("Menu",pos0,game.Content);
            Nivel1 = new Button("/Nivel3/97", pos, game.Content);
            Nivel2 = new Button("/Nivel3/98", pos1, game.Content);
            Nivel3 = new Button("/Nivel3/99", pos2, game.Content);
            Nivel4 = new Button("/Nivel3/100", pos3, game.Content);
            Nivel5 = new Button("/Nivel3/101", pos4, game.Content);
            Nivel6 = new Button("/Nivel3/102", pos5, game.Content);
            Nivel7 = new Button("/Nivel3/103", pos6, game.Content);
            Nivel8 = new Button("/Nivel3/104", pos7, game.Content);
            Nivel9 = new Button("/Nivel3/105", pos8, game.Content);
            Nivel10 = new Button("/Nivel3/106", pos9, game.Content);
            Nivel11 = new Button("/Nivel3/107", pos10, game.Content);
            Nivel12 = new Button("/Nivel3/108", pos11, game.Content);
            Nivel13 = new Button("/Nivel3/109", pos12, game.Content);
            Nivel14 = new Button("/Nivel3/110", pos13, game.Content);
            Nivel15 = new Button("/Nivel3/111", pos14, game.Content);
            Nivel18 = new Button("/Nivel3/112", pos18, game.Content);
            Nivel16 = new Button("ProxNivel",pos15, game.Content);
           // Nivel17 = new Button("AnteriorNivel", pos16, game.Content);

            Nivel1.ButtonPressed += (sender => Pantalla1());
            Nivel2.ButtonPressed += (sender => Pantalla2());
            Nivel3.ButtonPressed += (sender => Pantalla3());
            Nivel4.ButtonPressed += (sender => Pantalla4());
            Nivel5.ButtonPressed += (sender => Pantalla5());
            Nivel6.ButtonPressed += (sender => Pantalla6());
            Nivel7.ButtonPressed += (sender => Pantalla7());
            Nivel8.ButtonPressed += (sender => Pantalla8());
            Nivel9.ButtonPressed += (sender => Pantalla9());
            Nivel10.ButtonPressed += (sender => Pantalla10());
            Nivel11.ButtonPressed += (sender => Pantalla11());
            Nivel12.ButtonPressed += (sender => Pantalla12());
            Nivel13.ButtonPressed += (sender => Pantalla13());
            Nivel14.ButtonPressed += (sender => Pantalla14());
            Nivel15.ButtonPressed += (sender => Pantalla15());
            Nivel18.ButtonPressed += (sender => Pantalla16());

            Menu.ButtonPressed += (sender => fase());
            Nivel16.ButtonPressed += (sender => fase11());
           // Nivel17.ButtonPressed += (sender => fase11());
		}

        //Nos lo muestra para que lo valoremos
        public void fase()
        {


            game.fases();

        }
        public void fase11()
        {


            game.Nivel31();
        
        }
        public void fase12()
        {


            game.Nivel32();

        }
        public void Pantalla1()
        {
            Variables.nivelActual = 96;
            game.Comenzar();
        }
        public void Pantalla2()
        {
            Variables.nivelActual = 97;
            game.Comenzar();
        }
        public void Pantalla3()
        {
            Variables.nivelActual = 98;
            game.Comenzar();
        }
        public void Pantalla4()
        {
            Variables.nivelActual = 99;
            game.Comenzar();
        }
        public void Pantalla5()
        {
            Variables.nivelActual = 100;
            game.Comenzar();
        }
        public void Pantalla6()
        {
            Variables.nivelActual = 101;
            game.Comenzar();
        }
        public void Pantalla7()
        {
            Variables.nivelActual = 102;
            game.Comenzar();
        }
        public void Pantalla8()
        {
            Variables.nivelActual = 103;
            game.Comenzar();
        }
        public void Pantalla9()
        {
            Variables.nivelActual = 104;
            game.Comenzar();
        }
        public void Pantalla10()
        {
            Variables.nivelActual = 105;
            game.Comenzar();
        }
        public void Pantalla11()
        {
            Variables.nivelActual = 106;
            game.Comenzar();
        }
        public void Pantalla12()
        {
            Variables.nivelActual = 107;
            game.Comenzar();
        }
        public void Pantalla13()
        {
            Variables.nivelActual = 108;
            game.Comenzar();
        }
        public void Pantalla14()
        {
            Variables.nivelActual = 109;
            game.Comenzar();
        }
        public void Pantalla15()
        {
            Variables.nivelActual = 110;
            game.Comenzar();
        }
        public void Pantalla16()
        {
            Variables.nivelActual = 111;
            game.Comenzar();
        }

        /// <summary>
        /// Updates all the buttons in this view
        /// </summary>
        public override void Update()
        {
            base.Update();
     //       Menu.Update(touchLocation);
            if (Variables.NivelCorrecto[96] == 1)
            {
                Nivel1.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[97] == 1)
            {
                Nivel2.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[98] == 1)
            {
                Nivel3.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[99] == 1)
            {
                Nivel4.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[100] == 1)
            {
                Nivel5.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[101] == 1)
            {
                Nivel6.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[102] == 1)
            {
                Nivel7.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[103] == 1)
            {
                Nivel8.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[104] == 1)
            {
                Nivel9.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[105] == 1)
            {
                Nivel10.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[106] == 1)
            {
                Nivel11.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[107] == 1)
            {
                Nivel12.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[108] == 1)
            {
                Nivel13.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[109] == 1)
            {
                Nivel14.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[110] == 1)
            {
                Nivel15.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[111] == 1)
            {
                Nivel18.Update(touchLocation);
            }
            Nivel16.Update(touchLocation);
         //   Nivel17.Update(touchLocation);
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
            int h = 0;
   
            spriteBatch.Draw(texture, pos, Color.White);
          //  spriteBatch.Draw(texture, pos, Color.White);
            spriteBatch.DrawString(fuente, "Next", new Vector2(315, 740), Color.White);
            //spriteBatch.DrawString(fuente, "Prev", new Vector2(95, 720), Color.White);
            base.Draw(spriteBatch);
            
            Nivel1.Draw(spriteBatch);
            Nivel2.Draw(spriteBatch);
            Nivel3.Draw(spriteBatch);
            Nivel4.Draw(spriteBatch);
            Nivel5.Draw(spriteBatch);
            Nivel6.Draw(spriteBatch);
            Nivel7.Draw(spriteBatch);
            Nivel8.Draw(spriteBatch);
            Nivel9.Draw(spriteBatch);
            Nivel10.Draw(spriteBatch);
            Nivel11.Draw(spriteBatch);
            Nivel12.Draw(spriteBatch);
            Nivel13.Draw(spriteBatch);
            Nivel14.Draw(spriteBatch);
            Nivel15.Draw(spriteBatch);
            Nivel16.Draw(spriteBatch);
           // Nivel17.Draw(spriteBatch);
            Nivel18.Draw(spriteBatch);
         //   Menu.Draw(spriteBatch);

            spriteBatch.DrawString(fuente1, "97", pos0, Color.Black);
            spriteBatch.DrawString(fuente1, "98", pos1, Color.Black);
            spriteBatch.DrawString(fuente1, "99", pos2, Color.Black);
            spriteBatch.DrawString(fuente1, "100", pos3, Color.Black);
            spriteBatch.DrawString(fuente1, "101", pos4, Color.Black);
            spriteBatch.DrawString(fuente1, "102", pos5, Color.Black);
            spriteBatch.DrawString(fuente1, "103", pos6, Color.Black);
            spriteBatch.DrawString(fuente1, "104", pos7, Color.Black);
            spriteBatch.DrawString(fuente1, "105", pos8, Color.Black);
            spriteBatch.DrawString(fuente1, "106", pos9, Color.Black);
            spriteBatch.DrawString(fuente1, "107", pos10, Color.Black);
            spriteBatch.DrawString(fuente1, "108", pos11, Color.Black);
            spriteBatch.DrawString(fuente1, "109", pos12, Color.Black);
            spriteBatch.DrawString(fuente1, "110", pos13, Color.Black);
            spriteBatch.DrawString(fuente1, "111", pos14, Color.Black);
            spriteBatch.DrawString(fuente1, "112", pos18, Color.Black);
            spriteBatch.DrawString(fuente, "97", pos0, Color.White);
            spriteBatch.DrawString(fuente, "98", pos1, Color.White);
            spriteBatch.DrawString(fuente, "99", pos2, Color.White);
            spriteBatch.DrawString(fuente, "100", pos3, Color.White);
            spriteBatch.DrawString(fuente, "101", pos4, Color.White);
            spriteBatch.DrawString(fuente, "102", pos5, Color.White);
            spriteBatch.DrawString(fuente, "103", pos6, Color.White);
            spriteBatch.DrawString(fuente, "104", pos7, Color.White);
            spriteBatch.DrawString(fuente, "105", pos8, Color.White);
            spriteBatch.DrawString(fuente, "106", pos9, Color.White);
            spriteBatch.DrawString(fuente, "107", pos10, Color.White);
            spriteBatch.DrawString(fuente, "108", pos11, Color.White);
            spriteBatch.DrawString(fuente, "109", pos12, Color.White);
            spriteBatch.DrawString(fuente, "110", pos13, Color.White);
            spriteBatch.DrawString(fuente, "111", pos14, Color.White);
            spriteBatch.DrawString(fuente, "112", pos18, Color.White);

            spriteBatch.Draw(puntuacion,new Vector2(275,20),Color.White);
            if (Variables.puntuacion == 0)
            {
                spriteBatch.DrawString(fuente, Variables.puntuacion.ToString(), new Vector2(375, 25), Color.White);
            }
            if (Variables.puntuacion > 0 && Variables.puntuacion <= 1000)
            {
                spriteBatch.DrawString(fuente, Variables.puntuacion.ToString(), new Vector2(370, 25), Color.White);
            }
            if (Variables.puntuacion > 1000 && Variables.puntuacion <= 10000)
            {
                spriteBatch.DrawString(fuente, Variables.puntuacion.ToString(), new Vector2(360, 25), Color.White);
            }
            if (Variables.puntuacion > 10000 && Variables.puntuacion <= 100000)
            {
                spriteBatch.DrawString(fuente, Variables.puntuacion.ToString(), new Vector2(355, 25), Color.White);
            }
            if (Variables.puntuacion > 100000 && Variables.puntuacion <= 1000000)
            {
                spriteBatch.DrawString(fuente, Variables.puntuacion.ToString(), new Vector2(350, 25), Color.White);
            }
            if (Variables.puntuacion > 1000000 && Variables.puntuacion <= 10000000)
            {
                spriteBatch.DrawString(fuente, Variables.puntuacion.ToString(), new Vector2(345, 25), Color.White);
            }
            if (Variables.puntuacion > 10000000 && Variables.puntuacion <= 100000000)
            {
                spriteBatch.DrawString(fuente, Variables.puntuacion.ToString(), new Vector2(340, 25), Color.White);
            }
            for (int i = 96; i < 100; i++)
            {

                if (Variables.NivelCorrecto[i] == 0)
                {
                    spriteBatch.Draw(candado, new Vector2(16 + h, 150), Color.White);
                    
                }
                if (Variables.NivelTerminado[i] == 1)
                {
                    spriteBatch.Draw(estrella, new Vector2(16 + h, 150), Color.White);
                }
                h = h + 116;
            }
           
            h = 0;
            for (int i = 100; i < 104; i++)
            {

                if (Variables.NivelCorrecto[i] == 0)
                {
                    spriteBatch.Draw(candado, new Vector2(16 + h, 270), Color.White);
                }
                if (Variables.NivelTerminado[i] == 1)
                {
                    spriteBatch.Draw(estrella, new Vector2(16 + h, 270), Color.White);
                }
                h = h + 116;
            }
            h = 0;
            for (int i = 104; i < 108; i++)
            {

                if (Variables.NivelCorrecto[i] == 0)
                {
                    spriteBatch.Draw(candado, new Vector2(16 + h, 390), Color.White);
                }
                if (Variables.NivelTerminado[i] == 1)
                {
                    spriteBatch.Draw(estrella, new Vector2(16 + h, 390), Color.White);
                }
                h = h + 116;
            }
            h = 0;
            for (int i = 108; i < 112; i++)
            {

                if (Variables.NivelCorrecto[i] == 0)
                {
                    spriteBatch.Draw(candado, new Vector2(16 + h, 510), Color.White);
                }
                if (Variables.NivelTerminado[i] == 1)
                {
                    spriteBatch.Draw(estrella, new Vector2(16 + h, 510), Color.White);
                }
                h = h + 116;
            }





            foreach (Button but in buttons) 
            {
                
			but.Draw(spriteBatch);
            
            }
           
        }
    }
}
