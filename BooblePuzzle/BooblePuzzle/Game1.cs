/**
 * DashBubble Creado Por Jesus Alberto Saiz Cano Noviembre 2014
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Advertising.Mobile.Xna;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;
using System.Diagnostics;
using OpenXLive;
using OpenXLive.Features;
using DashBubble.UI;
using OpenXLive.Form;
using OpenXLive.Forms;
namespace DashBubble
{
	public enum EstadoJuego
	{
		Jugar,
		Perder,
		Ganar
	}

	/// <summary>
	/// This is the main type for your game
	/// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Texture2D launcher;
        Texture2D Reloj;
        float elapsed;
        public float rotacion;

       public Texture2D bubble;
        Burbuja burbujaLanzada;
        Texture2D pointText;

        public Vector2 ubicacionPuntero;

        //Publicidad
        private static readonly string ApplicationId = "b239acea-f7f6-41cd-bc8d-2a69f1899dd4";
        private static readonly string AdUnitId = "138413"; //other test values: Image480_80, Image300_50, TextAd
        private DrawableAd bannerAd;

       public  SpriteFont fuente;
       public  SpriteFont fuente2;
        SpriteFont fuenteGrande;

        Vector2 MousePos;

        EstadoJuego Estado = EstadoJuego.Jugar;
        public static List<Color> Colores;
        public static Int32 limiteDerecho = 460;
        public static Int32 limiteIzquierdo = 20;
        public static Int32 limiteArriba = 80;
        public static Int32 limiteAbajo = 720;

        Vector2 posicionBurbuja;
        public static List<Burbuja> burbujasPegadas { get; private set; }

        public static Int32 tamanoBurbuja = 42;
        public static bool ZuneFuncionando;

        public List<Burbuja> burbujasCayendo { get; private set; }

        MotorParticulas particulas;
        Texture2D textParticula;

        public Burbuja proximaBurbuja;
        AdministradorNiveles Niveles;
        Int32 nivelActual;

        float tiempoDisparar;
        Boolean mostrarTextoApresurar = false;
        protected TouchLocation touchLocation;
        protected bool touchChanged = false;

        Texture2D textBurbujaAyuda;
        Texture2D textBurbujaAyuda1;
        Boolean mostrarAyuda = false;
        Burbuja burbujaAyuda;

        public static GraphicsDeviceManager Graphics { get; private set; }
        Int32 bajarBurbujasTiempo;
        public static Int32 posTecho;
       public Texture2D textTecho;
        Texture2D textRectJuego;
        Texture2D fondo;
        public Texture2D Letrero;
        public float puntuacion;
        private Stopwatch stopwatch = new Stopwatch();

        public Variables variable = new Variables();

        private SoundEffect disparar;
        private SoundEffect rebotar;
        private SoundEffect chocar;
        private SoundEffect explotar;
        private SoundEffect superarnivel;
        private SoundEffect perdernivel;
        private SoundEffect FinalJuego;
        private View view;
        private Texture2D PasarPantalla;
        private Texture2D PerderPantalla;
        private Texture2D GanarFase;

        private Song soundTrack;
        public int getWidth()
        {
            return GraphicsDevice.Viewport.Width;
        }

        public int getHeight()
        {
            return GraphicsDevice.Viewport.Height;
        }
        public float relativeX(float xin)
        {
            return xin / 480.0f * (float)getWidth();
        }

        public float relativeY(float yin)
        {
            return yin / 800.0f * (float)getHeight();
        }
        public Game1()
        {
            if (MediaPlayer.State == MediaState.Playing)
            {
                ZuneFuncionando = true;
            }
            else 
            { 
                ZuneFuncionando = false; 
            }

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 800;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            GameSession session = XLiveGameManager.CreateSession("GDW7xwRHdqt4ug6FQpET3eSN");
            NavigationService.Initialize(this);
            XLiveSettings.Initialize(this, session);
            session.Open();
            XLiveSettings.Settings.Background = Content.Load<Texture2D>("Images/FondoOpciones");

            AdGameComponent.Initialize(this, ApplicationId);
            Components.Add(AdGameComponent.Current);
            CreateAd();

           
            if (ZuneFuncionando == true)
            {

                Variables.Musica = false;
                variable.guardar();

            
            }
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 
        public void InicializarNivel()
        { 
        
            rotacion = 0f;
            elapsed = 0f;
           
            posicionBurbuja = new Vector2(240 - 21, 757 - 21);
            //burbujaLanzada = new Burbuja(posicionBurbuja, Color.White);\
            //GenerarNuevaBurbuja();
            burbujasPegadas = new List<Burbuja>();
            burbujasCayendo = new List<Burbuja>();
            ubicacionPuntero = new Vector2(240, 755);

            //burbujaAyuda = new Burbuja(ubicacionPuntero, Color.White);

            IsMouseVisible = true;

            Colores = new List<Color>();
            Colores.Add(Color.White);
            Colores.Add(Color.Red);
            Colores.Add(Color.GreenYellow);
            Colores.Add(Color.Aquamarine);
            Colores.Add(Color.Yellow);
            Colores.Add(Color.Pink);
            Colores.Add(Color.Yellow);
            Colores.Add(Color.LightGray);
            Colores.Add(Color.Red);
            Colores.Add(Color.Red);

            //Niveles
            Niveles = new AdministradorNiveles("DashBubble.Niveles.txt");
            //Variables.nivelActual = 0;
            posTecho = 0;
            bajarBurbujasTiempo = 0;
            tiempoDisparar = 0;
           
            //puntuacion = 0;
            variable.cargar();
            if (Variables.Ayuda == true)
            {
                mostrarAyuda = true;
            }
            if (Variables.Ayuda == false)
            {
                mostrarAyuda = false;
            }  
        
        }


        public void OpenMenu()
        {
            Estado = EstadoJuego.Jugar;
            Variables.fases = false;
            Variables.EstoyEnInicio = true;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;
            Variables.JuegoIniciado = false;
            Variables.EstoyEnRecords = false;
            if (Variables.NivelTerminado[0] == 1)
            {
                Achievement item = new Achievement(XLiveGameManager.CurrentSession, "4e9bc8e6-b4f0-4a0e-a2a5-41df11f8a062");
                item.AwardCompleted += new AsyncEventHandler(item_AwardCompleted);
                item.Award();

            }
            if (Variables.NivelTerminado[47] == 1)
            {
                Achievement item = new Achievement(XLiveGameManager.CurrentSession, "e8d2b83b-8533-4b30-a144-f9d2db33344b");
                item.AwardCompleted += new AsyncEventHandler(item_AwardCompleted);
                item.Award();

            }
            if (Variables.NivelTerminado[95] == 1)
            {
                Achievement item = new Achievement(XLiveGameManager.CurrentSession, "d0a1380f-0245-4723-b61b-38274e70d6ca");
                item.AwardCompleted += new AsyncEventHandler(item_AwardCompleted);
                item.Award();

            }
            if (Variables.NivelTerminado[143] == 1)
            {
                Achievement item = new Achievement(XLiveGameManager.CurrentSession, "8a4589a8-6aa5-4f1a-b186-e0f73f20d8ae");
                item.AwardCompleted += new AsyncEventHandler(item_AwardCompleted);
                item.Award();

            }
            if (Variables.NivelTerminado[191] == 1)
            {
                Achievement item = new Achievement(XLiveGameManager.CurrentSession, "efb1dae6-0527-416c-b3b9-827c5843404d");
                item.AwardCompleted += new AsyncEventHandler(item_AwardCompleted);
                item.Award();

            }
            if (Variables.NivelTerminado[191] == 1)
            {
                Achievement item = new Achievement(XLiveGameManager.CurrentSession, "6e9ce6b6-7277-4f87-b83c-5868183432d7");
                item.AwardCompleted += new AsyncEventHandler(item_AwardCompleted);
                item.Award();

            }
            Leaderboard score = new Leaderboard(XLiveGameManager.CurrentSession, "ade12baf-fe11-4fe2-9a3d-820b4f256343");
            score.SubmitScore(Variables.puntuacion);
            Leaderboard level = new Leaderboard(XLiveGameManager.CurrentSession, "8f45b950-931e-4acd-bdae-625c25c03728");
            level.SubmitScore((Variables.nivelActual + 1));
            view = new Menu(this);

        }
        public void Opciones()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnOpciones = true;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;
            Variables.EstoyEnMenuResetear = false;
            Variables.EstoyEnMenuMusica = false;
            Variables.JuegoIniciado = false;
            view = new Opciones(this);        
        }
        public void Reanudar()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;
            Variables.JuegoIniciado = true;
            if (Variables.Musica == true)
            {
                MediaPlayer.Resume();
            }
                stopwatch.Start();
        }
        public void Ganar()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = true;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;
  //          Variables.JuegoIniciado = false;


            if (Variables.Efectos == true && Variables.Ganar == 1)
            {
                PlaySoundEffect(superarnivel);
                Variables.Ganar = 0;
            }
            
            if (Variables.Musica == true)
            {
                MediaPlayer.Stop();
            }
            
                view = new MenuGanar(this);
            
            
        }
        public void FinJuego()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;
            Variables.EstoyEnFinDeJuego = true; 
            Variables.JuegoIniciado = false;

            if (Variables.Musica == true)
            {
                MediaPlayer.Stop();
            }
            if (Variables.Efectos == true)
            {
                PlaySoundEffect(FinalJuego);
            }

                view = new FinDeJuego(this);
        
        }
        public void Resetear()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnMenuResetear = true;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;
            Variables.JuegoIniciado = false;
            view = new MenuReinicio(this);
        
        
        }
        public void Musica()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnMenuResetear = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;
            Variables.JuegoIniciado = false;
            Variables.EstoyEnMenuMusica = true;
            view = new MenuMusica(this);


        }
        public void Perder()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = true;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;
            Variables.JuegoIniciado = false;
            if (Variables.Musica == true)
            {
                MediaPlayer.Stop();
            }
            view = new MenuPerder(this);
        }
        public void Info()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnMenuResetear = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;
            Variables.JuegoIniciado = false;
            Variables.EstoyEnMenuMusica = false;
            Variables.EstoyEnInformacion = true;

            view = new Informacion(this);
        
        
        
        }
        public void Pausa()
        {
            stopwatch.Stop();
            if (Variables.Musica == true)
            {
                MediaPlayer.Pause();
            }
                 Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = true;
            Variables.EstoyEnNiveles = false;
            Variables.JuegoIniciado = false;

            view = new MenuPausa(this); 
        }
        public void Comenzar()
        {
           
            Variables.JuegoIniciado = true;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;
            CargarContenido();
            InicializarNivel();
            cargarNivel();
        
        
        }

        void item_AwardCompleted(object sender, AsyncEventArgs e)
        {
            if (e.Result.ReturnValue)
            {
                // Success
            }
            else
            {
                Debug.WriteLine(e.Result.ErrorMessage);
            }
        }

        public void fases()
        {

            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnFases = true;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = false;
            Variables.JuegoIniciado = false;
            Variables.EstoyEnAsia = false;
            Variables.EstoyEnEuropa = false;
            Variables.EstoyEnAfrica = false;
            Variables.EstoyEnAmerica = false;
            if (Variables.Musica == true)
            {
                MediaPlayer.Stop();
            }
                 view = new Fases(this);
        }
        public void Nivel1()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = true;
            Variables.JuegoIniciado = false;
            Variables.EstoyEnAsia = true;
            if (Variables.Musica == true)
            {
                MediaPlayer.Stop();
            }

                 view = new Niveles1(this);

        }
        public void Nivel11()
        {
            
            view = new Niveles11(this);
        }
        public void Nivel12()
        {
            view = new Niveles12(this);
        }
        public void Nivel2()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = true;
            Variables.JuegoIniciado = false;
            Variables.EstoyEnAfrica = true;
            if (Variables.Musica == true)
            {
                MediaPlayer.Stop();
            }
            view = new Niveles2(this);
        }
        public void Nivel21()
        {
            view = new Niveles21(this);
        }
        public void Nivel22()
        {
            view = new Niveles22(this);
        }
        public void Nivel3()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = true;
            Variables.JuegoIniciado = false;
            Variables.EstoyEnEuropa = true;
            if (Variables.Musica == true)
            {
                MediaPlayer.Stop();
            }
            view = new Niveles3(this);

        }
        public void Nivel31()
        {
            view = new Niveles31(this);
        }
        public void Nivel32()
        {
            view = new Niveles32(this);
        }
        public void Nivel4()
        {
            Variables.EstoyEnInicio = false;
            Variables.EstoyEnOpciones = false;
            Variables.EstoyEnFases = false;
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.EstoyEnMenuPausa = false;
            Variables.EstoyEnNiveles = true;
            Variables.JuegoIniciado = false;
            Variables.EstoyEnAmerica = true;
            if (Variables.Musica == true)
            {
                MediaPlayer.Stop();
            }
            view = new Niveles4(this);

        }
        public void Nivel41()
        {
            view = new Niveles41(this);
        }
        public void Nivel42()
        {
            view = new Niveles42(this);
        }
        private void CreateAd()
        {
            int width = 480;
            int height = 80;
            int x = 0; // centered on the display
            int y = 0;
            bannerAd = AdGameComponent.Current.CreateAd(AdUnitId, new Rectangle(x, y, width, height), true);
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            if (Variables.Inicializar == 0)
            {
                view = new SplashScreen(this);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (!NavigationService.Service.Visible)
            {
                if (view != null)
                {
                    view.Update();
                }
                if (Variables.JuegoIniciado == true)
                {
                    view = null;
                }
                // Allows the game to exit
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)

                    if (Variables.EstoyEnInicio == true &&
                        Variables.EstoyEnFases == false &&
                        Variables.EstoyEnMenuGanar == false &&
                        Variables.EstoyEnMenuPerder == false &&
                        Variables.EstoyEnOpciones == false &&
                        Variables.EstoyEnMenuPausa == false &&
                        Variables.EstoyEnNiveles == false &&
                        Variables.JuegoIniciado == false)
                    {
                        this.Exit();
                    }

                    else if (Variables.EstoyEnInicio == false &&
                            Variables.EstoyEnFases == true &&
                            Variables.EstoyEnOpciones == false &&
                            Variables.EstoyEnMenuGanar == false &&
                            Variables.EstoyEnMenuPerder == false &&
                            Variables.EstoyEnMenuPausa == false &&
                            Variables.EstoyEnNiveles == false &&
                            Variables.JuegoIniciado == false)
                    {
                        OpenMenu();
                    }
                    else if (Variables.EstoyEnInicio == false &&
                            Variables.EstoyEnFases == false &&
                            Variables.EstoyEnOpciones == false &&
                            Variables.EstoyEnMenuGanar == false &&
                            Variables.EstoyEnMenuPerder == false &&
                            Variables.EstoyEnMenuPausa == false &&
                            Variables.EstoyEnNiveles == false &&
                            Variables.EstoyEnRecords == true &&
                            Variables.JuegoIniciado == false)
                    {
                        OpenMenu();
                    }


                    else if (Variables.EstoyEnInicio == false &&
                            Variables.EstoyEnFases == false &&
                            Variables.EstoyEnOpciones == false &&
                            Variables.EstoyEnMenuGanar == false &&
                            Variables.EstoyEnMenuPerder == false &&
                            Variables.EstoyEnMenuPausa == false &&
                            Variables.EstoyEnNiveles == false &&
                            Variables.EstoyEnFinDeJuego == true &&
                            Variables.JuegoIniciado == false)
                    {
                        OpenMenu();
                    }

                    else if (Variables.EstoyEnInicio == false &&
                             Variables.EstoyEnFases == false &&
                             Variables.EstoyEnOpciones == true &&
                             Variables.EstoyEnMenuGanar == false &&
                             Variables.EstoyEnMenuPerder == false &&
                             Variables.EstoyEnMenuPausa == false &&
                             Variables.EstoyEnNiveles == false &&
                             Variables.JuegoIniciado == false)
                    {
                        OpenMenu();
                    }

                    else if (Variables.EstoyEnInicio == false &&
                             Variables.EstoyEnFases == false &&
                             Variables.EstoyEnOpciones == false &&
                             Variables.EstoyEnMenuGanar == false &&
                             Variables.EstoyEnMenuResetear == true &&
                             Variables.EstoyEnMenuPausa == false &&
                             Variables.EstoyEnNiveles == false &&
                             Variables.JuegoIniciado == false)
                    {
                        Opciones();
                    }

                    else if (Variables.EstoyEnInicio == false &&
                             Variables.EstoyEnFases == false &&
                             Variables.EstoyEnOpciones == false &&
                             Variables.EstoyEnMenuGanar == false &&
                             Variables.EstoyEnMenuResetear == false &&
                             Variables.EstoyEnInformacion == true &&
                             Variables.EstoyEnMenuPausa == false &&
                             Variables.EstoyEnNiveles == false &&
                             Variables.JuegoIniciado == false)
                    {
                        Opciones();
                    }

                    else if (Variables.EstoyEnInicio == false &&
                             Variables.EstoyEnFases == false &&
                             Variables.EstoyEnOpciones == false &&
                             Variables.EstoyEnMenuGanar == false &&
                             Variables.EstoyEnMenuResetear == false &&
                             Variables.EstoyEnMenuMusica == true &&
                             Variables.EstoyEnMenuPausa == false &&
                             Variables.EstoyEnNiveles == false &&
                             Variables.JuegoIniciado == false)
                    {
                        Opciones();
                    }

                    else if (Variables.EstoyEnInicio == false &&
                             Variables.EstoyEnFases == false &&
                             Variables.EstoyEnOpciones == false &&
                             Variables.EstoyEnMenuGanar == false &&
                             Variables.EstoyEnMenuPerder == false &&
                             Variables.EstoyEnMenuPausa == false &&
                             Variables.EstoyEnNiveles == false &&
                             Variables.JuegoIniciado == true)
                    {
                        Pausa();
                    }

                    else if (Variables.EstoyEnInicio == false &&
                             Variables.EstoyEnFases == false &&
                             Variables.EstoyEnOpciones == false &&
                             Variables.EstoyEnMenuGanar == false &&
                             Variables.EstoyEnMenuPerder == false &&
                             Variables.EstoyEnMenuPausa == true &&
                             Variables.EstoyEnNiveles == false &&
                             Variables.JuegoIniciado == false)
                    {
                        Reanudar();
                    }

                    else if (Variables.EstoyEnInicio == false &&
                             Variables.EstoyEnFases == false &&
                             Variables.EstoyEnOpciones == false &&
                             Variables.EstoyEnMenuGanar == true &&
                             Variables.EstoyEnMenuPerder == false &&
                             Variables.EstoyEnMenuPausa == false &&
                             Variables.EstoyEnNiveles == false &&
                             Variables.JuegoIniciado == false)
                    {
                        if (Variables.EstoyEnAsia == true)
                        {
                            Nivel1();
                        }

                        if (Variables.EstoyEnAfrica == true)
                        {
                            Nivel2();
                        }
                        if (Variables.EstoyEnEuropa == true)
                        {
                            Nivel3();
                        }
                        if (Variables.EstoyEnAmerica == true)
                        {
                            Nivel4();
                        }
                    }
                    else if (Variables.EstoyEnInicio == false &&
                           Variables.EstoyEnFases == false &&
                           Variables.EstoyEnOpciones == false &&
                           Variables.EstoyEnMenuGanar == false &&
                           Variables.EstoyEnMenuPerder == false &&
                           Variables.EstoyEnMenuPausa == false &&
                           Variables.EstoyEnNiveles == true &&
                           Variables.JuegoIniciado == false)
                    {
                        fases();
                    }

                    else if (Variables.EstoyEnInicio == false &&
                                      Variables.EstoyEnFases == false &&
                                      Variables.EstoyEnMenuGanar == false &&
                                      Variables.EstoyEnOpciones == false &&
                                      Variables.EstoyEnMenuPerder == true &&
                                      Variables.EstoyEnMenuPausa == false &&
                                      Variables.EstoyEnNiveles == false &&
                                      Variables.JuegoIniciado == false)
                    {
                        if (Variables.EstoyEnAsia == true)
                        {
                            Nivel1();
                        }

                        if (Variables.EstoyEnAfrica == true)
                        {
                            Nivel2();
                        }
                        if (Variables.EstoyEnEuropa == true)
                        {
                            Nivel3();
                        }
                        if (Variables.EstoyEnAmerica == true)
                        {
                            Nivel4();
                        }
                    }

                elapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                MousePos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

                if (Variables.JuegoIniciado == true)
                {
                    if (Estado == EstadoJuego.Jugar)
                    {
                        tiempoDisparar += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (tiempoDisparar > 5 && tiempoDisparar < 5.5f)
                        {
                            //Mostrar Texto o hacer algo para informar que se debe apresurar
                            mostrarTextoApresurar = true;
                        }
                        else if (tiempoDisparar > 7 && tiempoDisparar < 7.5f)
                        {
                            //Mostrar Texto o hacer algo para informar que se debe apresurar
                            mostrarTextoApresurar = true;
                        }
                        else if (tiempoDisparar > 9 && tiempoDisparar < 9.5f)
                        {
                            //Mostrar Texto o hacer algo para informar que se debe apresurar
                            mostrarTextoApresurar = true;
                        }
                        else if (tiempoDisparar > 10)
                        {
                            // si no se ha disparado y ha pasado el tiempo, se dispara la burbuja
                            DispararBurbuja();
                        }
                        else
                        {
                            mostrarTextoApresurar = false;
                        }

                        if (mostrarAyuda)
                        {
                            if (burbujaAyuda != null)
                            {
                                burbujaAyuda.Mover();
                                //Mostrar la ayuda para apuntar
                                if (burbujaAyuda.Posicion.X <= limiteIzquierdo || burbujaAyuda.Posicion.X >= limiteDerecho - 42) // choca
                                {
                                    burbujaAyuda.Direccion.X *= -1;
                                }
                                if (burbujaAyuda.Posicion.Y <= limiteArriba + (posTecho * tamanoBurbuja))
                                {
                                    // choca en el techo, detenerla y pegarla
                                    burbujaAyuda = null;
                                }
                                else
                                {
                                    // verificar colisión con todas las burbujas pegadas
                                    for (int i = 0; i <= burbujasPegadas.Count - 1; i++)
                                    {
                                        if (ChoqueBurbujas(burbujaAyuda, burbujasPegadas[i]))
                                        {
                                            burbujaAyuda = null;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                burbujaAyuda = new Burbuja(posicionBurbuja, Color.White);
                                if (burbujaAyuda != null && !burbujaAyuda.moviendo)
                                {
                                    burbujaAyuda.moviendo = true;
                                    Matrix m = Matrix.CreateRotationZ(rotacion);
                                    burbujaAyuda.Direccion.X += m.M12 * 25f;
                                    burbujaAyuda.Direccion.Y -= m.M11 * 25f;
                                }
                            }
                        }

                        if (burbujaLanzada != null)
                        {
                            if (burbujaLanzada.moviendo)
                            {
                                burbujaLanzada.Mover();
                                if (burbujaLanzada.Posicion.X <= limiteIzquierdo || burbujaLanzada.Posicion.X >= limiteDerecho - 42) // choca
                                {
                                    burbujaLanzada.Direccion.X *= -1;
                                    if (Variables.Efectos == true)
                                    {
                                        PlaySoundEffect(rebotar);
                                    }
                                }
                                if (burbujaLanzada.Posicion.Y <= limiteArriba + (posTecho * tamanoBurbuja))
                                {
                                    // choca en el techo, detenerla y pegarla
                                    burbujaLanzada.encontrarCasillaMasCercana();
                                    pegarBurbuja(burbujaLanzada);
                                    burbujaLanzada = null;
                                }
                                else
                                {
                                    // verificar colisión con todas las burbujas pegadas
                                    for (int i = 0; i <= burbujasPegadas.Count - 1; i++)
                                    {
                                        if (burbujasPegadas[i] != burbujaLanzada)
                                        {
                                            if (ChoqueBurbujas(burbujaLanzada, burbujasPegadas[i]))
                                            {
                                                burbujaLanzada.encontrarCasillaMasCercana();
                                                pegarBurbuja(burbujaLanzada);
                                                burbujaLanzada = null;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (burbujaLanzada == null)
                        {
                            GenerarNuevaBurbuja();
                        }
                        verificarFinJuego();
                    }

                    else if (Estado == EstadoJuego.Ganar)
                    {
                        if (Variables.nivelActual < (Niveles.Niveles.Count - 1))
                        {
                            {
                                if (Variables.nivelActual < 191)
                                {
                                    Ganar();
                                }
                                else
                                {
                                    FinJuego();
                                }
                            }

                        }
                        else
                        {
                            mostrarAyuda = false;
                        }
                    }

                    else if (Estado == EstadoJuego.Perder)
                    {
                        foreach (Burbuja b in burbujasPegadas)
                        {
                            b.Color = Color.Gray;
                            if (Variables.Efectos == true && Variables.Ganar == 1)
                            {
                                PlaySoundEffect(perdernivel);
                                Variables.Ganar = 0;
                            }
                            Perder();
                        }
                    }
                    DestruirBurbujas();
                }
            }
            base.Update(gameTime);
        }

        public void DestruirBurbujas()
        {
            List<Burbuja> burbujasdestruidas = new List<Burbuja>();
            foreach (Burbuja burb in burbujasCayendo)
            {
                particulas.PosicionEmisor = burb.Posicion;
                particulas.iniciarParticulas(50, 1.5f, 20, burb.Color);
                if (Variables.Efectos == true)
                {
                    PlaySoundEffect(explotar);
                }
                burbujasdestruidas.Add(burb);
            }

            foreach (Burbuja burb in burbujasdestruidas)
            {
                burbujasCayendo.Remove(burb);
            }

            particulas.Update();
            HandleInput(TouchPanel.GetState());
        }

        public bool HandleInput(TouchCollection touchInfo)
        {
            {
                    bool buttonTouched = false;
                    bool buttonMoved = false;
                    TouchPanel.EnabledGestures = GestureType.FreeDrag;
                    //interpret touch screen presses
                    foreach (TouchLocation location in touchInfo)
                    {
                        switch (location.State)
                        {
                            case TouchLocationState.Pressed:

                                break;
                            case TouchLocationState.Moved:
                                buttonMoved = true;
                                break;

                            case TouchLocationState.Released:
                                buttonTouched = true;
                                break;
                        }
                        if (buttonTouched == true)
                        {
                            DispararBurbuja();
                        }
                            while (TouchPanel.IsGestureAvailable)
                            {
                                GestureSample gesture = TouchPanel.ReadGesture();
                                if (gesture.GestureType == GestureType.FreeDrag && Variables.EstoyEnMenuGanar == false && Variables.EstoyEnMenuPerder == false && Variables.EstoyEnMenuPausa == false)
                                {
                                    if (rotacion >= -1.10f)
                                    {
                                        if (gesture.Delta.X < 0f)
                                        {
                                            rotacion -= 0.015f;
                                        }
                                    }
                                    if (rotacion <= 1.10f)
                                    {
                                        if (gesture.Delta.X > 0f)
                                        {
                                            rotacion += 0.015f;
                                        }
                                    }
                                }
                            }          
                }
                    return false;
                }
        }

        public void GanarPantalla()
        {
            Variables.nivelActual++;
            cargarNivel();
            Estado = EstadoJuego.Jugar;
        }

        private void DispararBurbuja()
        {
            if (burbujaLanzada != null && !burbujaLanzada.moviendo)
            {
                if (Variables.Efectos == true)
                {
                    PlaySoundEffect(disparar);
                }
                    burbujaLanzada.moviendo = true;
                // disparar burbuja
                //dependiendo de la rotación
                Matrix m = Matrix.CreateRotationZ(rotacion);
                burbujaLanzada.Direccion.X += m.M12 * 8f;
                burbujaLanzada.Direccion.Y -= m.M11 * 8f;
                tiempoDisparar = 0;
            }
        }

        public void pegarBurbuja(Burbuja burbuja)
        {

            List<Burbuja> grupoIguales = burbuja.encontrarIguales();
            bajarBurbujasTiempo++;
            if (grupoIguales.Count < 3)
            {
                if (Variables.Efectos == true)
                {
                    PlaySoundEffect(chocar);
                }
                burbuja.Posicion = posicionDeCasilla((Int32)burbuja.posicionCasilla.X,
                    (Int32)burbuja.posicionCasilla.Y);
                burbujasPegadas.Add(burbuja);

            }
            else
            {
                if (Variables.Ayuda == true)
                {
                    Variables.puntuacionparcial += 10 * grupoIguales.Count;
                }

                if (Variables.Ayuda == false)
                {
                    Variables.puntuacionparcial += 25 * grupoIguales.Count;
                }

                // agregamos las burbujas del mismo color
                burbujasCayendo = grupoIguales;

                // eliminamos de la lista de burbujas pegadas a las burbujas que formaron el grupo
                burbujasPegadas = new List<Burbuja>(burbujasPegadas.Except(grupoIguales));


                List<Burbuja> flotando = new List<Burbuja>();
                List<Burbuja> conectadas = new List<Burbuja>();

                // reiniciamos el flag que indica que la burbuja se va a caer
                foreach (Burbuja buble in burbujasPegadas)
                {
                    buble.destruir = false;
                }

                // sirve para saber si la burbuja se encuentra conectada a al techo
                Boolean raiz = false;

                foreach (Burbuja buble in burbujasPegadas)
                {
                    raiz = false;
                    // si la burbuja no es de las que estan conectadas ya al techo
                    if (buble.posicionCasilla.Y > posTecho)
                    {
                        // buscar las burbujas conectadas
                        conectadas = buble.encontrarBurbujasConectadas();
                        foreach (Burbuja burb in conectadas)
                        {
                            //verificar que una de ellas esta pegada al techo
                            if (burb.posicionCasilla.Y == posTecho)
                            {
                                raiz = true;
                                break;
                            }
                        }

                        // si no hay ninguna conectada al techo, se cae la burbuja
                        if (!raiz)
                        {
                            buble.destruir = true;
                            flotando.Add(buble);
                        }
                    }
                }

                if (Variables.Ayuda == true)
                {
                    Variables.puntuacionparcial += 20 * flotando.Count;
                }
                if (Variables.Ayuda == false)
                {
                    Variables.puntuacionparcial += 40 * flotando.Count;
                }
                // eliminamos de las burbujas pegadas, las que se van a caer por no
                // andar pegadas a ninguna otra
                burbujasPegadas = new List<Burbuja>(burbujasPegadas.Except(flotando));

                // agregamos las burbujas a la lista, toca una por una para no
                // borrar la lista de las que formaron el grupo del mismo color
                foreach (Burbuja burb in flotando)
                {
                    burbujasCayendo.Add(burb);
                }

            }

            if (bajarBurbujasTiempo == 5) //bajar techo
            {
                posTecho++;
                //limiteArriba += tamanoBurbuja;
                bajarBurbujasTiempo = 0;
                foreach (Burbuja burb in burbujasPegadas)
                {
                    burb.posicionCasilla = new Vector2(burb.posicionCasilla.X, burb.posicionCasilla.Y + 1);
                    burb.Posicion = posicionDeCasilla((Int32)burb.posicionCasilla.X,
                    (Int32)burb.posicionCasilla.Y);
                }
            }


        }

        private Vector2 posicionDeCasilla(int cx, int cy)
        {
            Rectangle dRect = new Rectangle((cx * tamanoBurbuja) + limiteIzquierdo +
                (((cy + posTecho) % 2) * (tamanoBurbuja / 2)),
                (int)cy * tamanoBurbuja + limiteArriba, tamanoBurbuja, tamanoBurbuja);

            return new Vector2(dRect.X, dRect.Y);
        }

        public Boolean ChoqueBurbujas(Burbuja objetoActual, Burbuja objeto2)
        {
            float dx = objeto2.Posicion.X - objetoActual.Posicion.X;
            float dy = objeto2.Posicion.Y - objetoActual.Posicion.Y;
            Int32 radio1 = bubble.Width / 2;
            Int32 radio2 = bubble.Width / 2;
            Int32 radioTotal = radio1 + radio2;
            double diff1 = Math.Pow(dx, 2) + Math.Pow(dy, 2);
            double radioE = Math.Pow(radioTotal, 2);
            if (diff1 <= radioE)
            {
                return true;
            }
            return false;
        }

        public void GenerarNuevaBurbuja()
        {
            if (proximaBurbuja != null)
            {
                burbujaLanzada = proximaBurbuja;
                burbujaLanzada.Posicion = posicionBurbuja;
            }
            Color colorBurbuja = new Color();
            if (burbujasPegadas.Count > 0)
            {
                // seleccionar solo los colores de las burbujas faltantes
                List<Color> coloresFaltan = new List<Color>((from c in burbujasPegadas select c.Color).Distinct());
                Int32 color = new Random().Next(coloresFaltan.Count);

                if (coloresFaltan.Count <= 0)
                {
                    colorBurbuja = Colores[new Random().Next(7)];
                }
                else
                {
                    colorBurbuja = coloresFaltan[color];
                }
            }
            else
            {
                colorBurbuja = Colores[new Random().Next(7)];
            }

            proximaBurbuja = new Burbuja(posicionBurbuja - new Vector2(tamanoBurbuja * 1.25f, -20), colorBurbuja);
        }

        private void verificarFinJuego()
        {
            if (burbujasPegadas.Count == 0)
            {
                Estado = EstadoJuego.Ganar;
            }
            else
            {
                foreach (Burbuja b in burbujasPegadas)
                {
                    if (b.posicionCasilla.Y > 13)
                    {
                        Estado = EstadoJuego.Perder;
                        return;
                    }
                }
            }
        }

        public void CargarContenido()
        {

            //Cargamos Tipo de Letras
           
            fuente = Content.Load<SpriteFont>("Letras/spriteFont1");
            fuente2 = Content.Load<SpriteFont>("Letras/spriteFont2");
            fuenteGrande = Content.Load<SpriteFont>("Letras/LetraGrande");
            

            //Cargamos Imagenes

            bubble = Content.Load<Texture2D>("Images/bubble-1");
            launcher = Content.Load<Texture2D>("Images/arrow");
            Reloj = Content.Load<Texture2D>("Images/Reloj");
            pointText = Content.Load<Texture2D>("Images/1x1");
            textParticula = Content.Load<Texture2D>("Images/ParticulaBurbuja");
            textBurbujaAyuda = Content.Load<Texture2D>("Images/BurbujaAyuda");
            textBurbujaAyuda1 = Content.Load<Texture2D>("Images/BurbujaAyuda");
            textTecho = Content.Load<Texture2D>("Images/techo");            
            Letrero = Content.Load<Texture2D>("Images/Letrero");
            
            particulas = new MotorParticulas();
            particulas.adicionarTextura(textParticula);
            particulas.aleatorias = true;

            if (Niveles != null)
            {
                cargarNivel();
            }

            //Cargamos Musica

            disparar = Content.Load<SoundEffect>("Musica/Jump");
            rebotar = Content.Load<SoundEffect>("Musica/Boing");
            chocar = Content.Load<SoundEffect>("Musica/pop1");
            explotar = Content.Load<SoundEffect>("Musica/pop2");
            superarnivel = Content.Load<SoundEffect>("Musica/next_level");
            //perdernivel = Content.Load<SoundEffect>("Musica/game_over");
            perdernivel = Content.Load<SoundEffect>("Musica/Lose");
            FinalJuego = Content.Load<SoundEffect>("Musica/Final");
        
        
        }
        public void cargarNivel()
        {
            
            //limpio todo
            burbujasPegadas.Clear();
            burbujasCayendo.Clear();
            Variables.EstoyEnMenuGanar = false;
            Variables.EstoyEnMenuPerder = false;
            Variables.JuegoIniciado = true;
            Variables.Burbujas = 0;
            Estado = EstadoJuego.Jugar;
            burbujaLanzada = null;
            proximaBurbuja = null;
            rotacion = 0;
            posTecho = 0;
            bajarBurbujasTiempo = 0;
            Variables.Ganar = 1;
            Nivel nivel = Niveles.Niveles[Variables.nivelActual];
            Variables.puntuacionparcial = 0;

            if (Variables.nivelActual >= 0 && Variables.nivelActual < 12)
            {
                fondo = Content.Load<Texture2D>("Images/fondo1");
            }
            if (Variables.nivelActual >= 12 && Variables.nivelActual < 24)
            {
                fondo = Content.Load<Texture2D>("Images/fondo11");
            }
            if (Variables.nivelActual >= 24 && Variables.nivelActual < 36)
            {
                fondo = Content.Load<Texture2D>("Images/fondo12");
            }
            if (Variables.nivelActual >= 36 && Variables.nivelActual < 48)
            {
                fondo = Content.Load<Texture2D>("Images/fondo13");
            }
            if (Variables.nivelActual >= 48 && Variables.nivelActual < 60)
            {
                fondo = Content.Load<Texture2D>("Images/fondo2");
            }
            if (Variables.nivelActual >= 60 && Variables.nivelActual < 72)
            {
                fondo = Content.Load<Texture2D>("Images/fondo21");
            }
            if (Variables.nivelActual >= 72 && Variables.nivelActual < 84)
            {
                fondo = Content.Load<Texture2D>("Images/fondo22");
            }
            if (Variables.nivelActual >= 84 && Variables.nivelActual < 96)
            {
                fondo = Content.Load<Texture2D>("Images/fondo23");
            }
            if (Variables.nivelActual >= 96 && Variables.nivelActual < 108)
            {
                fondo = Content.Load<Texture2D>("Images/fondo3");
            }
            if (Variables.nivelActual >= 108 && Variables.nivelActual < 120)
            {
                fondo = Content.Load<Texture2D>("Images/fondo31");
            }
            if (Variables.nivelActual >= 120 && Variables.nivelActual < 132)
            {
                fondo = Content.Load<Texture2D>("Images/fondo32");
            }
            if (Variables.nivelActual >= 132 && Variables.nivelActual < 144)
            {
                fondo = Content.Load<Texture2D>("Images/fondo33");
            }
            if (Variables.nivelActual >= 144 && Variables.nivelActual < 156)
            {
                fondo = Content.Load<Texture2D>("Images/fondo4");
            }
            if (Variables.nivelActual >= 156 && Variables.nivelActual < 168)
            {
                fondo = Content.Load<Texture2D>("Images/fondo41");
            }
            if (Variables.nivelActual >= 168 && Variables.nivelActual < 180)
            {
                fondo = Content.Load<Texture2D>("Images/fondo42");
            }
            if (Variables.nivelActual >= 180 && Variables.nivelActual < 192)
            {
                fondo = Content.Load<Texture2D>("Images/fondo43");
            }

                //cargar Burbujas

            foreach (Burbuja b in nivel.Burbujas)
            {
                Vector2 posicionBurbuja = posicionDeCasilla((int)b.posicionCasilla.X, (int)b.posicionCasilla.Y);
                b.Posicion = posicionBurbuja;
                burbujasPegadas.Add(b);
            }

            if (Variables.Musica == true)
            {
                soundTrack = Content.Load<Song>("Musica/Puzzle-Boble_theme");
                MediaPlayer.Play(soundTrack);
                MediaPlayer.IsRepeating = true;
            }
      }

        public static void PlaySoundEffect(SoundEffect sonido)
        {

            //if (soundList.ContainsKey(soundName))
            {
                try
                {
                    //instance = efectoSonido.CreateInstance();
                    if (sonido != null)
                    {
                        //efectoSonido.IsLooped = looped;
                        sonido.Play();
                    }
                    
                }
                catch (InstancePlayLimitException)
                {
                    // silently fail (returns null instance) if instance limit reached
                }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (!NavigationService.Service.Visible)
            {
                spriteBatch.Begin();
                if (view != null)
                    view.Draw(spriteBatch);
                spriteBatch.End();

                if (Variables.JuegoIniciado == true || Variables.EstoyEnMenuGanar == true || Variables.EstoyEnMenuPerder == true || Variables.EstoyEnMenuPausa == true)
                {
                    //GraphicsDevice.Clear(Color.White);

                    Vector2 pos = Vector2.Zero;
                    spriteBatch.Begin();

                    //dibujar fondo de pantalla

                    spriteBatch.Draw(fondo, pos, Color.White);

                    //dibujar techo

                    spriteBatch.Draw(textTecho, new Vector2(limiteIzquierdo - 20, (limiteArriba + (posTecho * tamanoBurbuja)) - 705), null, Color.White);


                    if (proximaBurbuja != null)
                    {
                        spriteBatch.Draw(bubble, proximaBurbuja.Posicion, null, proximaBurbuja.Color, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 1);
                    }

                    foreach (Burbuja burb in burbujasPegadas)
                    {
                        spriteBatch.Draw(bubble, burb.Posicion, null, burb.Color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1);
                    }

                    foreach (Burbuja burb in burbujasCayendo)
                    {
                        spriteBatch.Draw(bubble, burb.Posicion, null, burb.Color, 0f,
                            Vector2.Zero, 1f, SpriteEffects.None, 1);
                    }

                    if (mostrarAyuda)
                    {
                        if (burbujaAyuda != null)
                        {
                            spriteBatch.Draw(textBurbujaAyuda, burbujaAyuda.Posicion + new Vector2(21 - 5, 21 - 5), Color.White);
                            //  spriteBatch.Draw(textBurbujaAyuda1, burbujaAyuda.Posicion + new Vector2(30, 30), Color.White);
                        }
                    }

                    spriteBatch.Draw(launcher, ubicacionPuntero, null, Color.White, rotacion, new Vector2(launcher.Width / 2, launcher.Height / 1.33f), 1f, SpriteEffects.None, 1);

                    if (burbujaLanzada != null)
                    {
                        spriteBatch.Draw(bubble, burbujaLanzada.Posicion, burbujaLanzada.Color);
                    }

                    //Textos

                    spriteBatch.Draw(Letrero, new Vector2(10, 680), Color.White);
                    spriteBatch.DrawString(fuente2, "LEVEL", new Vector2(25, 701), Color.Black);
                    spriteBatch.DrawString(fuente2, (Variables.nivelActual + 1).ToString(), new Vector2(60, 728), Color.Black);
                    spriteBatch.Draw(Letrero, new Vector2(360, 680), Color.White);
                    spriteBatch.DrawString(fuente2, "SCORE", new Vector2(375, 701), Color.Black);
                    spriteBatch.DrawString(fuente, Variables.puntuacionparcial.ToString(), new Vector2(397, 728), Color.Black);

                    if (mostrarTextoApresurar)
                    {
                        spriteBatch.Draw(Reloj, new Vector2(195, 400), Color.White);
                    }

                    particulas.Draw(spriteBatch);
                    spriteBatch.End();
                    spriteBatch.Begin();
                    if (view != null)
                        view.Draw(spriteBatch);

                    spriteBatch.End();

                    base.Draw(gameTime);

                }
            }
            base.Draw(gameTime);
        }
    }
}
