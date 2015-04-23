/**
 * DashBubble Creado Por Jesus Alberto Saiz Cano Noviembre 2014
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Reflection;
using System.IO;

namespace DashBubble
{
	public class AdministradorNiveles
	{
		public List<Nivel> Niveles { get; private set; }
		
		public AdministradorNiveles(string nombreArchivo)
		{
			Niveles = new List<Nivel>();
			String datos = leerArchivo(nombreArchivo);
         String[] niveles = datos.Split(new char[] { '-' });
         
			Int32 fila = 0;
         List<Burbuja> datosNivel = new List<Burbuja>();
         // se recorre cada nivel
         foreach (string nivel in niveles)
         {
            // se recorre cada línea
            string[] lineas = nivel.Split(new char[] { '\n' });
            foreach (string linea in lineas)
            {
               if (!String.IsNullOrEmpty(linea))
               {
                  int columna = 0;
                  // se recorre la línea y se van a adicionando las burbujas
                  foreach (string item in linea.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                  {
                     // si es un 0 se ignora y se pasa a otra columna
                     if (item != "0")
                     {
                        Burbuja b =  new Burbuja(Vector2.Zero, Game1.Colores[Int32.Parse(item)]);
                        b.posicionCasilla = new Vector2(columna, fila);
                        datosNivel.Add(b);
                     }
                     columna++;
                  }
                  fila++;
               }
            }
            // Se adiciona un nuevo nivel
            Niveles.Add(new Nivel(datosNivel));
            datosNivel = new List<Burbuja>();
            fila = 0;
         }
		}

		private string leerArchivo(string ruta)
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			StringBuilder sb = new StringBuilder();
			StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(ruta));
			string line = reader.ReadLine();
         // Se deja todo el archivo como una sola línea
			while (line != null)
			{
				sb.Append(line);
				sb.Append("\n");
				line = reader.ReadLine();
			}
			reader.Close();
			return sb.ToString();
		}
	}

	public class Nivel
	{
		public List<Burbuja> Burbujas { get; private set; }

      public Nivel(List<Burbuja> burbujas)
		{
			Burbujas = burbujas;
		}
	}

	public struct InformacionBurbuja
	{
		public int posX;
		public int posY;
		public int numColor;
	}
}
