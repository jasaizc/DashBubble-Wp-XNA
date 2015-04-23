
/**
 * DashBubble Creado Por Jesus Alberto Saiz Cano Noviembre 2014
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DashBubble
{
	public class Burbuja
	{
		public Vector2 Posicion;
		public Vector2 Direccion;
       // Game1 game;
		public List<Burbuja> Vecinos { get; set; }
		public Color Color { get; set; }

		public Vector2 posicionCasilla { get; set; }

		public Boolean moviendo = false;
		public Boolean destruir = false;

		public Burbuja(Vector2 posicion, Color color)
		{
			Posicion = posicion;
			this.Direccion = Vector2.Zero;
			Vecinos = new List<Burbuja>();
			Color = color;
		}

		public void Mover()
		{
			if (moviendo)
			{
				this.Posicion += Direccion * 1.4f;
			}
		}

		public void encontrarCasillaMasCercana()
		{
         int fy = (int)(Posicion.Y - Game1.limiteArriba + (Game1.tamanoBurbuja / 2)) 
            / Game1.tamanoBurbuja;
         int fx = (int)((Posicion.X - Game1.limiteIzquierdo + (Game1.tamanoBurbuja / 2) - (((fy + Game1.posTecho) % 2) * 
            (Game1.tamanoBurbuja / 2))) / Game1.tamanoBurbuja);

			posicionCasilla = new Vector2(fx, fy);
		}

		public void encontrarVecinos()
		{
			Vecinos.Clear();

			foreach (Burbuja bubble in Game1.burbujasPegadas)
			{
				// buscar si hay burbujas cerca
				if (proximoA(bubble))
				{
					Vecinos.Add(bubble);
				}
			}
		}

		public bool proximoA(Burbuja bubble)
		{
			if (bubble.posicionCasilla == new Vector2(posicionCasilla.X - ((posicionCasilla.Y + 1 + Game1.posTecho) % 2), posicionCasilla.Y - 1))
			{
				// verificar arriba izq
				return true;
			}
			else if (bubble.posicionCasilla == new Vector2(posicionCasilla.X - ((posicionCasilla.Y + 1 + Game1.posTecho) % 2) + 1, posicionCasilla.Y - 1))
			{
				// verificar arriba der
				return true;
			}
			else if (bubble.posicionCasilla == new Vector2(posicionCasilla.X - 1, posicionCasilla.Y))
			{
				// verificar izq
				return true;
			}
			else if (bubble.posicionCasilla == new Vector2(posicionCasilla.X + 1, posicionCasilla.Y))
			{
				// verificar der
				return true;
			}
			else if (bubble.posicionCasilla == new Vector2(posicionCasilla.X - ((posicionCasilla.Y + 1 + Game1.posTecho) % 2), posicionCasilla.Y + 1))
			{
				// verificar abajo izq 
				return true;
			}
			else if (bubble.posicionCasilla == new Vector2(posicionCasilla.X + 1 - ((posicionCasilla.Y + 1 + Game1.posTecho) % 2), posicionCasilla.Y + 1))
			{
				// verificar abajo der 
				return true;
			}
			return false;
		}

		public List<Burbuja> encontrarIguales()
		{
         List<Burbuja> lista = new List<Burbuja>();
			lista.Add(this);
			this.destruir = true;
			// encontrar iguales recursivamente
			encontrarIguales(lista, this);

			return lista;
		}

      public void encontrarIguales(List<Burbuja> lista, Burbuja burbuja)
		{
			burbuja.encontrarVecinos();
			foreach (Burbuja bubble in burbuja.Vecinos)
			{
				// si es igual el color y no se ha agregado anteriormente a la lista
				if (Color == bubble.Color && !lista.Contains(bubble))
				{
					bubble.destruir = true;
					lista.Add(bubble);
					encontrarIguales(lista, bubble);
				}
			}
		}

      public List<Burbuja> encontrarBurbujasConectadas()
		{
         List<Burbuja> lista = new List<Burbuja>();
			lista.Add(this);
			// encontrar burbujas conectadas recursivamente
			encontrarBurbujasConectadas(lista, this);

			return lista;
		}

      public void encontrarBurbujasConectadas(List<Burbuja> lista, Burbuja burbuja)
		{
			burbuja.encontrarVecinos();
			foreach (Burbuja bubble in burbuja.Vecinos)
			{
				// si no se ha agregado anteriormente
				if (!bubble.destruir && !lista.Contains(bubble))
				{
					lista.Add(bubble);
               //si es raiz nos salimos para evitar buscar en todas las burbujas
					if (bubble.posicionCasilla.Y == Game1.posTecho) 
                  break;
					encontrarBurbujasConectadas(lista, bubble);
				}
			}
		}
		
	}
}
