using DataTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Team_Project
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;

        public HighScoreList[] highScoreList { get; set; }
        public HighScoreHelper scoreHelper { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Color BackgroundColor { get; set; }
        public ICamera Camera { get; set; }
        public IPlayer currentPlayer { get; set; }
        public Level Level { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public float zoom = GraphicValue.Zoom;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public StateUpdater stateManager;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public ArrayList controllerList;
        public enum GameStates
        {
            StartScreen, Gameplay, LivesLeftScreen, GameOverScreen, HighScoreScreen,
            EndAnimation, OptionsMenu, ConfirmationScreen, PauseScreen, LevelSelectScreen
        };
        public GameStates state = GameStates.StartScreen;
        public IList playerList = new List<IPlayer>();
        public enum Characters { Mario, Luigi, Bowser };
        public Characters playerChar = Characters.Mario;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = (int)(GraphicValue.BufferWidth * zoom);
            graphics.PreferredBackBufferHeight = (int)(GraphicValue.BufferHeight * zoom);
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            SoundFactory.LoadGame(this);
            String LevelFileName = "World_1_1";
            String HighScoreFileName = "High_Scores";
            Level = new Level(this, LevelFileName);
            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Content",
                HighScoreFileName + ".xml");
            highScoreList = HighScoreLoader.Load(path);

            scoreHelper = new HighScoreHelper(highScoreList);
            Camera = new Camera1(GraphicsDevice.Viewport, zoom, Level.Limits);
            BackgroundColor = Color.CornflowerBlue;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteFactory.LoadGame(this);
            SpriteFactory.LoadPlayerSprites();
            stateManager = new StateUpdater(this);
            Level.LoadContent();

            playerList.Add(PlayerFactory.createMario(this));
            currentPlayer = (IPlayer)playerList[0];

            KeyboardDictionary.AddToKeyMap(Keys.Escape, new Quit(this));
            KeyboardDictionary.AddToKeyMap(Keys.Right, new PlayerRight(this));
            KeyboardDictionary.AddToKeyMap(Keys.Left, new PlayerLeft(this));
            KeyboardDictionary.AddToKeyMap(Keys.Down, new PlayerDown(this));
            KeyboardDictionary.AddToKeyMap(Keys.Z, new PlayerUp(this));
            KeyboardDictionary.AddToKeyMap(Keys.None, new PlayerNoCommand(this));
            KeyboardDictionary.AddToKeyMap(Keys.X, new PlayerB(this));
            KeyboardDictionary.AddToKeyMap(Keys.C, new UseGravityControl());

            GamePadDictionary.AddToButtonMap(Buttons.Back, new Quit(this));
            GamePadDictionary.AddToButtonMap(Buttons.A, new PlayerUp(this));
            GamePadDictionary.AddToButtonMap(Buttons.B, new PlayerB(this));
            GamePadDictionary.AddToButtonMap(Buttons.LeftThumbstickDown, new PlayerDown(this));
            GamePadDictionary.AddToButtonMap(Buttons.LeftThumbstickLeft, new PlayerLeft(this));
            GamePadDictionary.AddToButtonMap(Buttons.LeftThumbstickRight, new PlayerRight(this));
            GamePadDictionary.AddToButtonMap(Buttons.X, new UseGravityControl());

            controllerList = new ArrayList();
            controllerList.Add(new KeyboardController());
            controllerList.Add(new GamePadController());
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            stateManager.Update(gameTime);
            Camera.Update(this);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackgroundColor);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Camera.GetViewMatrix());
            stateManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
