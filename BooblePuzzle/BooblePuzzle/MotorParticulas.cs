/**
 * DashBubble Creado Por Jesus Alberto Saiz Cano Noviembre 2014
 * 
 */
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DashBubble
{
   public class MotorParticulas
   {
      private Random random;
      public Vector2 PosicionEmisor { get; set; }
      public List<Particula> particulas;
      private List<Texture2D> texturas;
      public Boolean aleatorias = false;
      public bool terminado = false;

      /// <summary>
      /// Constructor de la clase
      /// </summary>
      /// <param name="texturas"></param>
      /// <param name="posicion"></param>
      public MotorParticulas(List<Texture2D> texturas, Vector2 posicion)
      {
         PosicionEmisor = posicion;
         this.texturas = texturas;
         this.particulas = new List<Particula>();
         random = new Random();
      }

      public MotorParticulas()
      {
         //PosicionEmisor = posicion;
         this.particulas = new List<Particula>();
         this.texturas = new List<Texture2D>();
         random = new Random();


      }

      /// <summary>
      /// Genera partículas con propiedades aleatorias
      /// </summary>
      /// <returns></returns>
      private Particula GenerarParticulasAleatorias(float maxTamano, Int32 maxTiempoVida, Color color)
      {
         Texture2D textura = texturas[random.Next(texturas.Count)];
         Vector2 posicion = PosicionEmisor;
         Vector2 velocidad = new Vector2(1f * (float)(random.NextDouble() * 2 - 1),
         1f * (float)(random.NextDouble() * 2 - 1));
         float angulo = 0;
         float velocidadangular = 0.1f * (float)(random.NextDouble() * 2 - 1);
         float tamano = (float)random.NextDouble() * maxTamano;
         Int16 tiempodeVida = Convert.ToInt16(random.Next(maxTiempoVida));
         return new Particula(textura, posicion, velocidad, angulo, velocidadangular, color, tamano, tiempodeVida);
      }

      public void adicionarParticula(Texture2D textura, Vector2 posicion, Vector2 velocidad, float angulo, float velocidadAngular,
          Color color, float tamano, Int16 tiempodeVida)
      {
         particulas.Add(new Particula(textura, posicion, velocidad, angulo, velocidadAngular, color, tamano, tiempodeVida));
      }

      public void iniciarParticulas(Int32 cantidadTexturas, float maxTamano, Int32 maxTiempoVida, Color color)
      {
         for (int i = 0; i < cantidadTexturas; i++)
         {
            particulas.Add(GenerarParticulasAleatorias(maxTamano, maxTiempoVida, color));
         }
      }
      public void adicionarTextura(Texture2D textura)
      {
         texturas.Add(textura);
      }


      /// <summary>
      /// Añade y elimina partículas dependiendo del tiempo de Vida
      /// </summary>
      public void Update()
      {
         for (Int32 particula = 0; particula < particulas.Count; particula++)
         {
            particulas[particula].Update();
            if (particulas[particula].TiempodeVida <= 0)
            {
                particulas.RemoveAt(particula);
                particula--;
                
            }
           
                
                
         }
      }

      /// <summary>
      /// Dibuja cada partícula
      /// </summary>
      /// <param name="spriteBatch"></param>
      public void Draw(SpriteBatch spriteBatch)
      {
         //spriteBatch.Begin();
         for (Int32 indice = 0; indice < particulas.Count; indice++)
         {
            particulas[indice].Draw(spriteBatch);
         }
         //spriteBatch.End();
      }
   }
}
