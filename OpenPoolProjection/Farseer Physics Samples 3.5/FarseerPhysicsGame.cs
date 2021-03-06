using System;
using FarseerPhysics.Samples.Demos;
using FarseerPhysics.Samples.ScreenSystem;
using Microsoft.Xna.Framework;

namespace FarseerPhysics.Samples
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class FarseerPhysicsGame : Game
    {
        private GraphicsDeviceManager _graphics;

        public FarseerPhysicsGame()
        {
            Window.Title = "OpenPoolProjection with Farseer Physics and MonoGame";
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferMultiSampling = true;
#if WINDOWS || XBOX
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            ConvertUnits.SetDisplayUnitToSimUnitRatio(24f);
            IsFixedTimeStep = true;
#elif WINDOWS_PHONE
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 480;
            ConvertUnits.SetDisplayUnitToSimUnitRatio(16f);
            IsFixedTimeStep = false;
#endif
#if WINDOWS
            _graphics.IsFullScreen = false;
#elif XBOX || WINDOWS_PHONE
            _graphics.IsFullScreen = true;
#endif

            Content.RootDirectory = "Content";

            //new-up components and add to Game.Components
            ScreenManager = new ScreenManager(this);
            Components.Add(ScreenManager);

            var frameRateCounter = new FrameRateCounter(ScreenManager);
            frameRateCounter.DrawOrder = 101;
            Components.Add(frameRateCounter);
        }

        public ScreenManager ScreenManager { get; set; }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            var simple5 = new SimpleDemo5();

            var menuScreen = new MenuScreen("Open Pool Projection");
            menuScreen.AddMenuItem("", EntryType.Separator, null);
            menuScreen.AddMenuItem(simple5.GetTitle(), EntryType.Screen, simple5);


            menuScreen.AddMenuItem("Exit", EntryType.ExitItem, null);

            ScreenManager.AddScreen(new BackgroundScreen());
            ScreenManager.AddScreen(menuScreen);
        }
    }
}