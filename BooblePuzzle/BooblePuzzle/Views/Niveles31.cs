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
    class Niveles31 : View
    {
        private List<Button> buttons = new List<Button>();
        //private View view;
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
        private Button Nivel17;
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
        public Niveles31(Game1 game)
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
            Vector2 pos16 = new Vector2(80, 640);

            Menu = new Button("Menu",pos0,game.Content);
            Nivel1 = new Button("/Nivel3/113", pos, game.Content);
            Nivel2 = new Button("/Nivel3/114", pos1, game.Content);
            Nivel3 = new Button("/Nivel3/115", pos2, game.Content);
            Nivel4 = new Button("/Nivel3/116", pos3, game.Content);
            Nivel5 = new Button("/Nivel3/117", pos4, game.Content);
            Nivel6 = new Button("/Nivel3/118", pos5, game.Content);
            Nivel7 = new Button("/Nivel3/119", pos6, game.Content);
            Nivel8 = new Button("/Nivel3/120", pos7, game.Content);
            Nivel9 = new Button("/Nivel3/121", pos8, game.Content);
            Nivel10 = new Button("/Nivel3/122", pos9, game.Content);
            Nivel11 = new Button("/Nivel3/123", pos10, game.Content);
            Nivel12 = new Button("/Nivel3/124", pos11, game.Content);
            Nivel13 = new Button("/Nivel3/125", pos12, game.Content);
            Nivel14 = new Button("/Nivel3/126", pos13, game.Content);
            Nivel15 = new Button("/Nivel3/127", pos14, game.Content);
            Nivel18 = new Button("/Nivel3/128", pos18, game.Content);
            Nivel16 = new Button("ProxNivel",pos15, game.Content);
            Nivel17 = new Button("AnteriorNivel", pos16, game.Content);

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
            Nivel16.ButtonPressed += (sender => fase12());
            Nivel17.ButtonPressed += (sender => fase11());
		}

        //Nos lo muestra para que lo valoremos
        public void fase()
        {


            game.fases();

        }
        public void fase11()
        {


            game.Nivel3();
        
        }
        public void fase12()
        {


            game.Nivel32();

        }
        public void Pantalla1()
        {
            Variables.nivelActual = 112;
            game.Comenzar();
        }
        public void Pantalla2()
        {
            Variables.nivelActual = 113;
            game.Comenzar();
        }
        public void Pantalla3()
        {
            Variables.nivelActual = 114;
            game.Comenzar();
        }
        public void Pantalla4()
        {
            Variables.nivelActual = 115;
            game.Comenzar();
        }
        public void Pantalla5()
        {
            Variables.nivelActual = 116;
            game.Comenzar();
        }
        public void Pantalla6()
        {
            Variables.nivelActual = 117;
            game.Comenzar();
        }
        public void Pantalla7()
        {
            Variables.nivelActual = 118;
            game.Comenzar();
        }
        public void Pantalla8()
        {
            Variables.nivelActual = 119;
            game.Comenzar();
        }
        public void Pantalla9()
        {
            Variables.nivelActual = 120;
            game.Comenzar();
        }
        public void Pantalla10()
        {
            Variables.nivelActual = 121;
            game.Comenzar();
        }
        public void Pantalla11()
        {
            Variables.nivelActual = 122;
            game.Comenzar();
        }
        public void Pantalla12()
        {
            Variables.nivelActual = 123;
            game.Comenzar();
        }
        public void Pantalla13()
        {
            Variables.nivelActual = 124;
            game.Comenzar();
        }
        public void Pantalla14()
        {
            Variables.nivelActual = 125;
            game.Comenzar();
        }
        public void Pantalla15()
        {
            Variables.nivelActual = 126;
            game.Comenzar();
        }
        public void Pantalla16()
        {
            Variables.nivelActual = 127;
            game.Comenzar();
        }

        /// <summary>
        /// Updates all the buttons in this view
        /// </summary>
        public override void Update()
        {
            base.Update();
      //      Menu.Update(touchLocation);
            if (Variables.NivelCorrecto[112] == 1)
            {
                Nivel1.Update(touchLocation);
            }            
            if (Variables.NivelCorrecto[113] == 1)
            {
                Nivel2.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[114] == 1)
            {
                Nivel3.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[115] == 1)
            {
                Nivel4.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[116] == 1)
            {
                Nivel5.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[117] == 1)
            {
                Nivel6.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[118] == 1)
            {
                Nivel7.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[119] == 1)
            {
                Nivel8.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[120] == 1)
            {
                Nivel9.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[121] == 1)
            {
                Nivel10.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[122] == 1)
            {
                Nivel11.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[123] == 1)
            {
                Nivel12.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[124] == 1)
            {
                Nivel13.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[125] == 1)
            {
                Nivel14.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[126] == 1)
            {
                Nivel15.Update(touchLocation);
            }
            if (Variables.NivelCorrecto[127] == 1)
            {
                Nivel18.Update(touchLocation);
            }
            Nivel16.Update(touchLocation);
            Nivel17.Update(touchLocation);
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
            spriteBatch.DrawString(fuente, "Prev", new Vector2(95, 740), Color.White);
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
            Nivel17.Draw(spriteBatch);
            Nivel18.Draw(spriteBatch);
       //     Menu.Draw(spriteBatch);

            spriteBatch.DrawString(fuente1, "113", pos0, Color.Black);
            spriteBatch.DrawString(fuente1, "114", pos1, Color.Black);
            spriteBatch.DrawString(fuente1, "115", pos2, Color.Black);
            spriteBatch.DrawString(fuente1, "116", pos3, Color.Black);
            spriteBatch.DrawString(fuente1, "117", pos4, Color.Black);
            spriteBatch.DrawString(fuente1, "118", pos5, Color.Black);
            spriteBatch.DrawString(fuente1, "119", pos6, Color.Black);
            spriteBatch.DrawString(fuente1, "120", pos7, Color.Black);
            spriteBatch.DrawString(fuente1, "121", pos8, Color.Black);
            spriteBatch.DrawString(fuente1, "122", pos9, Color.Black);
            spriteBatch.DrawString(fuente1, "123", pos10, Color.Black);
            spriteBatch.DrawString(fuente1, "124", pos11, Color.Black);
            spriteBatch.DrawString(fuente1, "125", pos12, Color.Black);
            spriteBatch.DrawString(fuente1, "126", pos13, Color.Black);
            spriteBatch.DrawString(fuente1, "127", pos14, Color.Black);
            spriteBatch.DrawString(fuente1, "128", pos18, Color.Black);
            spriteBatch.DrawString(fuente, "113", pos0, Color.White);
            spriteBatch.DrawString(fuente, "114", pos1, Color.White);
            spriteBatch.DrawString(fuente, "115", pos2, Color.White);
            spriteBatch.DrawString(fuente, "116", pos3, Color.White);
            spriteBatch.DrawString(fuente, "117", pos4, Color.White);
            spriteBatch.DrawString(fuente, "118", pos5, Color.White);
            spriteBatch.DrawString(fuente, "119", pos6, Color.White);
            spriteBatch.DrawString(fuente, "120", pos7, Color.White);
            spriteBatch.DrawString(fuente, "121", pos8, Color.White);
            spriteBatch.DrawString(fuente, "122", pos9, Color.White);
            spriteBatch.DrawString(fuente, "123", pos10, Color.White);
            spriteBatch.DrawString(fuente, "124", pos11, Color.White);
            spriteBatch.DrawString(fuente, "125", pos12, Color.White);
            spriteBatch.DrawString(fuente, "126", pos13, Color.White);
            spriteBatch.DrawString(fuente, "127", pos14, Color.White);
            spriteBatch.DrawString(fuente, "128", pos18, Color.White);

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
            for (int i = 112; i < 116; i++)
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
            for (int i = 116; i < 120; i++)
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
            for (int i = 120; i < 124; i++)
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
            for (int i = 124; i <128; i++)
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
