/**
 * DashBubble Creado Por Jesus Alberto Saiz Cano Noviembre 2014
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DashBubble
{
   /// <summary>
   /// Clase que respresenta las particulas
   /// </summary>
   public class Particula
   {
      public Texture2D Textura { get; set; }
      public Vector2 Posicion { get; set; }
      public Vector2 Velocidad { get; set; }
      public float Angulo { get; set; }
      public float VelocidadAngular { get; set; }
      public Color Color { get; set; }
      public float Tamano { get; set; }
      public Int16 TiempodeVida { get; set; }

      /// <summary>
      /// Constructor de la clase
      /// </summary>
      /// <param name="textura"></param>
      /// <param name="posicion"></param>
      /// <param name="velocidad"></param>
      /// <param name="angulo"></param>
      /// <param name="velocidadAngular"></param>
      /// <param name="color"></param>
      /// <param name="tamano"></param>
      /// <param name="tiempodeVida"></param>
      public Particula(Texture2D textura, Vector2 posicion, Vector2 velocidad, float angulo, float velocidadAngular,
      Color color, float tamano, Int16 tiempodeVida)
      {
         Textura = textura;
         Posicion = posicion;
         Velocidad = velocidad;
         VelocidadAngular = velocidadAngular;
         Angulo = angulo;
         Color = color;
         Tamano = tamano;
         TiempodeVida = tiempodeVida;
      }

      /// <summary>
      /// Disminuye el tiempo de Vida, y aumenta la Posición y la Velocidad Angular para la rotación
      /// </summary>
      public void Update()
      {
         TiempodeVida--;
         Posicion += Velocidad;
         Angulo += VelocidadAngular;
          if (TiempodeVida == 0)
          {
          
          
          }
      }

      /// <summary>
      /// Dibuja cada partícula
      /// </summary>
      /// <param name="spriteBatch"></param>
      public void Draw(SpriteBatch spriteBatch)
      {
         Rectangle rectanguloFuente = new Rectangle(0, 0, Textura.Width, Textura.Height);
         Vector2 origen = new Vector2(Textura.Width / 2, Textura.Height / 2);
         spriteBatch.Draw(Textura, Posicion, rectanguloFuente, Color, Angulo, origen, Tamano, SpriteEffects.None, 0f);
      }
   }
}
