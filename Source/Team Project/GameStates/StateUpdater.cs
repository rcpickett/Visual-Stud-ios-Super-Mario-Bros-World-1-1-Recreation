using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Team_Project
{
    public class StateUpdater
    {
        private float ScreenOffset;
        private bool Paused = false;
        private bool pausable = false;
        private bool scoreProcessed = false;
        private GamePadState gpState, prevGpState;
        private KeyboardState keyState, prevkeyState;
        private Game1 game;
        private const int SINGLEPLAYER = GameScreen.SinglePlayerLoc;
        private const int MULTIPLAYER = GameScreen.MultiplayerLoc;
        private const int OPTIONS = GameScreen.OptionLoc;
        private const int EXIT = GameScreen.ExitLoc;
        private const int INCREMENT = GameScreen.IncrementValue;
        private const int LIVESLEFTSCREENOFFSET = GameScreen.LLScreenOffset;
        private const int GAMEOVERSCREENOFFSET = GameScreen.GOScreenOffset;
        private const int HIGHSCORESCREENOFFSET = GameScreen.HSScreenOffset;
        private int dotLoc = GameScreen.StartingDotLocation;
        private SpriteFont spriteFont, optionsFont, highScoreFont;
        private Texture2D startScreen, screenDot, livesLeftScreen, gameOverScreen,
                          highScoreScreen, pauseScreen, confirmationScreen, optionMenu, levelSelectScreen;
        private string playerCharacter, prevChar;
        private int gameState;

        public StateUpdater(Game1 g)
        {
            game = g;
            startScreen = SpriteFactory.CreateMainMenu();
            screenDot = SpriteFactory.CreateDot();
            livesLeftScreen = SpriteFactory.CreateLivesLeft();
            gameOverScreen = SpriteFactory.CreateGameOver();
            highScoreScreen = SpriteFactory.CreateHighScore();
            pauseScreen = SpriteFactory.CreatePause();
            confirmationScreen = SpriteFactory.CreateConfirmation();
            optionMenu = SpriteFactory.CreateOption();
            spriteFont = SpriteFactory.CreateLivesLeftFont();
            optionsFont = SpriteFactory.CreateOptionsFont();
            highScoreFont = SpriteFactory.CreateHighScoreFont();
            levelSelectScreen = SpriteFactory.CreateLevelSelectMenu();

            OptionMenuObjectGenerator.Initialize();

            playerCharacter = OptionMenu.DefaultPlayer;
            prevChar = playerCharacter;
        }

        public void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();
            gpState = GamePad.GetState(PlayerIndex.One);
            switch (game.state)
            {
                case Game1.GameStates.StartScreen:
                    ExecuteStartScreen();
                    break;
                case Game1.GameStates.Gameplay:
                    ExecuteGameplay(gameTime);
                    break;
                case Game1.GameStates.LivesLeftScreen:
                    ExecuteLivesLeft();
                    break;
                case Game1.GameStates.GameOverScreen:
                    ExecuteGameOver();
                    break;
                case Game1.GameStates.HighScoreScreen:
                    ExecuteHighScoreScreen();
                    break;
                case Game1.GameStates.EndAnimation:
                    ExecuteEndAnimation(gameTime);
                    break;
                case Game1.GameStates.OptionsMenu:
                    ExecuteOptionsMenu();
                    break;
                case Game1.GameStates.ConfirmationScreen:
                    ExecuteConfirmationScreen();
                    break;
                case Game1.GameStates.PauseScreen:
                    ExecutePauseScreen();
                    break;
                case Game1.GameStates.LevelSelectScreen:
                    ExecuteLevelSelectScreen();
                    break;
                default:
                    break;
            }
            prevkeyState = keyState;
            prevGpState = gpState;
        }
        public void Draw(SpriteBatch s)
        {
            int YPosition = 8;
            switch (game.state)
            {
                case Game1.GameStates.StartScreen:
                    s.Draw(startScreen, new Rectangle(Value.Zero, Value.Zero, Value.TwoHundredFiftyFour, Value.TwoHundredForty), Color.White);
                    s.Draw(screenDot, new Rectangle(Value.OneHundred, dotLoc, Value.Twenty, Value.Twenty), Color.White);
                    break;
                case Game1.GameStates.Gameplay:
                    game.Level.Draw(s);
                    game.Level.HUD.Draw(s);
                    break;
                case Game1.GameStates.LivesLeftScreen:
                    s.Draw(livesLeftScreen, new Rectangle((int)game.Camera.position.X, Value.Zero, Value.TwoHundredFiftyFour, Value.TwoHundredForty), Color.White);
                    s.DrawString(spriteFont, GameScreen.LivesLeft + game.currentPlayer.ScoreCard.NumLives, new Vector2(game.Camera.position.X + Value.OneHundredTwentyEight, game.Camera.position.Y + Value.OneHundredTen), Color.White);
                    game.Level.HUD.Draw(s);
                    break;
                case Game1.GameStates.GameOverScreen:
                    s.Draw(gameOverScreen, new Rectangle((int)game.Camera.position.X, Value.Zero, Value.TwoHundredFiftyFour, Value.TwoHundredForty), Color.White);
                    break;
                case Game1.GameStates.HighScoreScreen:
                    s.Draw(highScoreScreen, new Rectangle((int)game.Camera.position.X, Value.Zero, Value.TwoHundredFiftyFour, Value.TwoHundredForty), Color.White);
                    s.DrawString(highScoreFont, "HIGH SCORES", new Vector2(game.Camera.position.X + 88, game.Camera.position.Y + 16), Color.White);
                    for (int i = 0; i < game.scoreHelper.HighScores.Count; i++)
                    {
                        s.DrawString(highScoreFont, game.scoreHelper.HighScores[i].Score.ToString(),
                            new Vector2(game.Camera.position.X + 24, game.Camera.position.Y + YPosition + 16), Color.White);
                        s.DrawString(highScoreFont, game.scoreHelper.HighScores[i].Name.ToUpper(),
                            new Vector2(game.Camera.position.X + 88, game.Camera.position.Y + YPosition + 16), Color.White);
                        s.DrawString(highScoreFont, game.scoreHelper.HighScores[i].TimeStamp.ToString("yyyy-MM-dd"),
                            new Vector2(game.Camera.position.X + 152, game.Camera.position.Y + YPosition + 16), Color.White);
                        YPosition += 16;
                    }
                    break;
                case Game1.GameStates.EndAnimation:
                    game.Level.Draw(s);
                    game.Level.HUD.Draw(s);
                    break;
                case Game1.GameStates.LevelSelectScreen:
                    s.Draw(levelSelectScreen, new Rectangle(Value.Zero, Value.Zero, Value.TwoHundredFiftyFour, Value.TwoHundredForty), Color.White);
                    s.Draw(screenDot, new Rectangle(Value.OneHundred, dotLoc, Value.Twenty, Value.Twenty), Color.White);
                    break;
                case Game1.GameStates.OptionsMenu:
                    s.Draw(optionMenu, new Rectangle((int)game.Camera.position.X, Value.Zero, Value.TwoHundredFiftyFour, Value.TwoHundredForty), Color.White);
                    s.Draw(screenDot, new Rectangle((int)game.Camera.position.X + Value.Ten, dotLoc, Value.Twenty, Value.Twenty), Color.White);
                    s.DrawString(optionsFont, OptionMenuObjectGenerator.FlyingBlockOnOff, new Vector2(game.Camera.position.X + OptionMenu.StatusOffset, game.Camera.position.Y + OptionMenu.FlyingBlocksLoc), Color.White);
                    s.DrawString(optionsFont, OptionMenuObjectGenerator.FireBallOnOff, new Vector2(game.Camera.position.X + OptionMenu.StatusOffset, game.Camera.position.Y + OptionMenu.FireballsLoc), Color.White);
                    s.DrawString(optionsFont, OptionMenuObjectGenerator.WallOfFireOnOff, new Vector2(game.Camera.position.X + OptionMenu.StatusOffset, game.Camera.position.Y + OptionMenu.WallOfFireLoc), Color.White);
                    s.DrawString(optionsFont, OptionMenuObjectGenerator.GravityControllerOnOff, new Vector2(game.Camera.position.X + OptionMenu.StatusOffset, game.Camera.position.Y + OptionMenu.GravityControlLoc), Color.White);
                    s.DrawString(optionsFont, playerCharacter, new Vector2(game.Camera.position.X + OptionMenu.StatusOffset - Value.Fifteen, game.Camera.position.Y + OptionMenu.PlayerLoc), Color.White);
                    break;
                case Game1.GameStates.ConfirmationScreen:
                    s.Draw(confirmationScreen, new Rectangle((int)game.Camera.position.X, Value.Zero, Value.TwoHundredFiftyFour, Value.TwoHundredForty), Color.White);
                    s.Draw(screenDot, new Rectangle((int)game.Camera.position.X + Value.Eighty, dotLoc, Value.Twenty, Value.Twenty), Color.White);
                    break;
                case Game1.GameStates.PauseScreen:
                    game.Level.Draw(s);
                    game.Level.HUD.Draw(s);
                    s.Draw(pauseScreen, new Rectangle((int)game.Camera.position.X, Value.Zero, Value.TwoHundredFiftyFour, Value.TwoHundredForty), Color.White);
                    s.Draw(screenDot, new Rectangle((int)game.Camera.position.X + Value.SeventyThree, dotLoc, Value.Twenty, Value.Twenty), Color.White);
                    break;
                default:
                    break;
            }
        }
        public void ExecuteHighScoreScreen()
        {
            pausable = false;

            if (!scoreProcessed)
            {
                scoreProcessed = true;

                int score = game.currentPlayer.ScoreCard.Points;

                if (game.scoreHelper.CheckHighScore(score))
                {
                    // Add the new high score to the list
                    game.scoreHelper.AddScore(
                        game.playerChar.ToString(),
                        game.currentPlayer.ScoreCard.Points
                    );

                    // Save the updated high scores to the XML file
                    game.scoreHelper.Save(
                        "Content/HighScores.xml",
                        game.scoreHelper.HighScores
                    );
                }
            }

            ScreenOffset++;

            if (ScreenOffset > HIGHSCORESCREENOFFSET)
            {
                game.Level.Reset();
                dotLoc = GameScreen.StartingDotLocation;
                game.state = Game1.GameStates.StartScreen;
                game.currentPlayer = new Mario(game.Level.PlayerStartPosition, game);

                ScreenOffset = Value.Zero;

                // Ready for the NEXT game
                scoreProcessed = false;
            }
        }
        public void ExecutePauseScreen()
        {
            if (Paused == false && pausable == true)
            {
                Paused = true;
                SoundManager.PauseCurrentMusic();
                SoundManager.PlayPauseSound();
            }

            pausable = false;

            if ((keyState.IsKeyDown(Keys.Z) && !prevkeyState.IsKeyDown(Keys.Z)) ||
                (gpState.IsButtonDown(Buttons.A) && !prevGpState.IsButtonDown(Buttons.A)))
                switch (dotLoc)
                {
                    case PauseScreen.OptionLoc:
                        gameState = PauseScreen.State;
                        dotLoc = OptionMenu.DotLocation;
                        game.state = Game1.GameStates.OptionsMenu;
                        break;
                    case PauseScreen.ResumeLoc:
                        Paused = false;
                        SoundManager.PlayPauseSound();
                        SoundManager.ResumeMusic();
                        MarioMovement.IsGrounded = false;
                        game.state = Game1.GameStates.Gameplay;
                        break;
                    case PauseScreen.QuitLoc:
                        dotLoc = ConfirmationScreen.DotLocation;
                        game.state = Game1.GameStates.ConfirmationScreen;
                        break;
                    default:
                        break;
                }

            if ((keyState.IsKeyDown(Keys.Down) && !prevkeyState.IsKeyDown(Keys.Down)) ||
                (gpState.IsButtonDown(Buttons.LeftThumbstickDown) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickDown)))
            {
                if (dotLoc <= PauseScreen.QuitLoc - Value.One)
                    dotLoc += INCREMENT;
                else
                    dotLoc = PauseScreen.OptionLoc;
            }
            else if ((keyState.IsKeyDown(Keys.Up) && !prevkeyState.IsKeyDown(Keys.Up)) ||
                    (gpState.IsButtonDown(Buttons.LeftThumbstickUp) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickUp)))
            {
                if (dotLoc >= PauseScreen.OptionLoc + Value.One)
                    dotLoc -= INCREMENT;
                else
                    dotLoc = PauseScreen.QuitLoc;
            }
        }
        public void ExecuteStartScreen()
        {
            pausable = false;
            if ((keyState.IsKeyDown(Keys.Z) && !prevkeyState.IsKeyDown(Keys.Z)) ||
                (gpState.IsButtonDown(Buttons.A) && !prevGpState.IsButtonDown(Buttons.A)))
                switch (dotLoc)
                {
                    case SINGLEPLAYER:
                        dotLoc = MULTIPLAYER;
                        game.state = Game1.GameStates.LevelSelectScreen;
                        break;
                    case MULTIPLAYER:
                        break;
                    case OPTIONS:
                        gameState = GameScreen.State;
                        dotLoc = OptionMenu.DotLocation;
                        game.state = Game1.GameStates.OptionsMenu;
                        break;
                    case EXIT:
                        game.Exit();
                        break;
                    default:
                        break;
                }
            if ((keyState.IsKeyDown(Keys.Down) && !prevkeyState.IsKeyDown(Keys.Down)) ||
                 (gpState.IsButtonDown(Buttons.LeftThumbstickDown) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickDown)))
            {
                if (dotLoc <= EXIT - Value.One)
                    dotLoc += INCREMENT;
                else
                    dotLoc = SINGLEPLAYER;
            }
            else if ((keyState.IsKeyDown(Keys.Up) && !prevkeyState.IsKeyDown(Keys.Up)) ||
                (gpState.IsButtonDown(Buttons.LeftThumbstickUp) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickUp)))
            {
                if (dotLoc >= SINGLEPLAYER + Value.One)
                    dotLoc -= INCREMENT;
                else
                    dotLoc = EXIT;
            }
        }
        public void ExecuteLevelSelectScreen()
        {
            pausable = false;
            if ((keyState.IsKeyDown(Keys.Z) && !prevkeyState.IsKeyDown(Keys.Z)) ||
                (gpState.IsButtonDown(Buttons.A) && !prevGpState.IsButtonDown(Buttons.A)))
                switch (dotLoc)
                {
                    case LevelScreen.FirstWorldLoc:
                        game.Level = new Level(game, "World_1_1");
                        game.Level.LoadContent();
                        game.state = Game1.GameStates.LivesLeftScreen;
                        ScreenOffset = LIVESLEFTSCREENOFFSET;
                        break;
                    case LevelScreen.SecondWorldLoc:
                        game.Level = new Level(game, "World_1_2");
                        game.Level.LoadContent();
                        game.state = Game1.GameStates.LivesLeftScreen;
                        ScreenOffset = LIVESLEFTSCREENOFFSET;
                        break;
                    case LevelScreen.GoBackLoc:
                        dotLoc = GameScreen.StartingDotLocation;
                        game.state = Game1.GameStates.StartScreen;
                        break;
                    default:
                        break;
                }
            if ((keyState.IsKeyDown(Keys.Down) && !prevkeyState.IsKeyDown(Keys.Down)) ||
                 (gpState.IsButtonDown(Buttons.LeftThumbstickDown) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickDown)))
            {
                if (dotLoc <= LevelScreen.GoBackLoc - Value.One)
                    dotLoc += GameScreen.IncrementValueLSS;
                else
                    dotLoc = MULTIPLAYER;
            }
            else if ((keyState.IsKeyDown(Keys.Up) && !prevkeyState.IsKeyDown(Keys.Up)) ||
                (gpState.IsButtonDown(Buttons.LeftThumbstickUp) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickUp)))
            {
                if (dotLoc >= MULTIPLAYER + Value.One)
                    dotLoc -= GameScreen.IncrementValueLSS;
                else
                    dotLoc = LevelScreen.GoBackLoc;
            }
        }
        public void ExecuteGameplay(GameTime gameTime)
        {
            pausable = true;
            if ((keyState.IsKeyDown(Keys.Enter) && !prevkeyState.IsKeyDown(Keys.Enter)) ||
               (gpState.IsButtonDown(Buttons.Start) && !prevGpState.IsButtonDown(Buttons.Start)))
            {
                dotLoc = PauseScreen.DotLocation;
                game.state = Game1.GameStates.PauseScreen;
            }
            if (!Paused)
            {
                if (game.Camera.limits.Height <= game.currentPlayer.Location.Y)
                {
                    ScreenOffset++;
                    if (ScreenOffset > LIVESLEFTSCREENOFFSET)
                    {

                        if (game.currentPlayer.ScoreCard.NumLives <= Value.Zero)
                            game.state = Game1.GameStates.GameOverScreen;
                        else
                            game.state = Game1.GameStates.LivesLeftScreen;

                    }
                }

                if (Value.Zero >= game.currentPlayer.Location.Y)
                {
                    game.currentPlayer.Location = new Vector2(game.currentPlayer.Location.X, Value.Zero);
                }

                if (LevelEndAnimation.Ending == true)
                {
                    game.state = Game1.GameStates.EndAnimation;
                }

                game.currentPlayer.Update(gameTime);
                game.Level.Update(gameTime);

                foreach (IController controller in game.controllerList)
                {
                    controller.Update();
                }

            }
        }
        public void ExecuteLivesLeft()
        {
            pausable = false;
            ScreenOffset++;
            if (ScreenOffset > GAMEOVERSCREENOFFSET)
            {
                game.Level.Reset();
                game.state = Game1.GameStates.Gameplay;
                ScreenOffset = Value.Zero;
            }
        }
        public void ExecuteGameOver()
        {
            pausable = false;
            SoundManager.PlayGameOverTheme();
            ScreenOffset++;


            if (ScreenOffset > GAMEOVERSCREENOFFSET + LIVESLEFTSCREENOFFSET)
            {
                game.state = Game1.GameStates.HighScoreScreen;
                ScreenOffset = Value.Zero;
            }
        }
        public void ExecuteEndAnimation(GameTime gameTime)
        {
            if (LevelEndAnimation.GameEnded)
            {
                ScreenOffset++;
                if (ScreenOffset > LIVESLEFTSCREENOFFSET)
                {
                    game.state = Game1.GameStates.GameOverScreen;
                }
            }

            game.currentPlayer.Update(gameTime);
            game.Level.Update(gameTime);
        }
        public void ExecuteOptionsMenu()
        {
            pausable = false;

            if ((keyState.IsKeyDown(Keys.Z) && !prevkeyState.IsKeyDown(Keys.Z)) ||
                (gpState.IsButtonDown(Buttons.A) && !prevGpState.IsButtonDown(Buttons.A)))
                switch (dotLoc)
                {
                    case OptionMenu.GravityControlLoc:
                        break;
                    case OptionMenu.BackLoc:
                        game.playerChar = OptionMenu.Character(playerCharacter);

                        Mario player = (Mario)game.currentPlayer;

                        if (game.playerChar == Game1.Characters.Mario && prevChar != playerCharacter)
                        {
                            game.currentPlayer.State = new SmallMarioIdleRightState(player);
                        }
                        else if (game.playerChar == Game1.Characters.Luigi && prevChar != playerCharacter)
                        {
                            game.currentPlayer.State = new SmallMarioIdleRightState(player);
                        }
                        else if (game.playerChar == Game1.Characters.Bowser && prevChar != playerCharacter)
                        {
                            game.currentPlayer.State = new SmallBowserIdleRightState(player);
                            game.currentPlayer.Location = new Vector2(game.currentPlayer.Location.X, game.currentPlayer.Location.Y - Value.Sixteen);
                        }
                        prevChar = playerCharacter;

                        if (gameState == PauseScreen.State)
                        {
                            game.state = Game1.GameStates.PauseScreen;
                            dotLoc = PauseScreen.DotLocation;
                        }
                        else
                        {
                            game.state = Game1.GameStates.StartScreen;
                            dotLoc = GameScreen.StartingDotLocation;
                        }
                        break;
                    default:
                        break;
                }
            if ((keyState.IsKeyDown(Keys.Down) && !prevkeyState.IsKeyDown(Keys.Down)) ||
                 (gpState.IsButtonDown(Buttons.LeftThumbstickDown) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickDown)))
            {
                if (dotLoc <= OptionMenu.BackLoc - Value.One)
                    dotLoc += INCREMENT;
                else
                    dotLoc = OptionMenu.PlayerLoc;
            }
            else if ((keyState.IsKeyDown(Keys.Up) && !prevkeyState.IsKeyDown(Keys.Up)) ||
                (gpState.IsButtonDown(Buttons.LeftThumbstickUp) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickUp)))
            {
                if (dotLoc >= OptionMenu.PlayerLoc + Value.One)
                    dotLoc -= INCREMENT;
                else
                    dotLoc = OptionMenu.BackLoc;
            }
            else if ((keyState.IsKeyDown(Keys.Right) && !prevkeyState.IsKeyDown(Keys.Right)) ||
                (gpState.IsButtonDown(Buttons.LeftThumbstickRight) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickRight)))
            {
                switch (dotLoc)
                {
                    case OptionMenu.PlayerLoc:
                        playerCharacter = OptionMenu.SwitchCharacter(playerCharacter);
                        break;
                    case OptionMenu.FlyingBlocksLoc:
                        OptionMenuObjectGenerator.FlyingBlockOnOff = OptionMenu.SwitchOnOff(OptionMenuObjectGenerator.FlyingBlockOnOff);
                        break;
                    case OptionMenu.FireballsLoc:
                        OptionMenuObjectGenerator.FireBallOnOff = OptionMenu.SwitchOnOff(OptionMenuObjectGenerator.FireBallOnOff);
                        break;
                    case OptionMenu.WallOfFireLoc:
                        OptionMenuObjectGenerator.WallOfFireOnOff = OptionMenu.SwitchOnOff(OptionMenuObjectGenerator.WallOfFireOnOff);
                        break;
                    case OptionMenu.GravityControlLoc:
                        OptionMenuObjectGenerator.GravityControllerOnOff = OptionMenu.SwitchOnOff(OptionMenuObjectGenerator.GravityControllerOnOff);
                        break;
                    default:
                        break;
                }
            }

            else if ((keyState.IsKeyDown(Keys.Left) && !prevkeyState.IsKeyDown(Keys.Left)) ||
                (gpState.IsButtonDown(Buttons.LeftThumbstickLeft) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickLeft)))
            {
                switch (dotLoc)
                {
                    case OptionMenu.PlayerLoc:
                        playerCharacter = OptionMenu.SwitchCharacter(playerCharacter);
                        playerCharacter = OptionMenu.SwitchCharacter(playerCharacter);
                        break;
                    case OptionMenu.FlyingBlocksLoc:
                        OptionMenuObjectGenerator.FlyingBlockOnOff = OptionMenu.SwitchOnOff(OptionMenuObjectGenerator.FlyingBlockOnOff);
                        break;
                    case OptionMenu.FireballsLoc:
                        OptionMenuObjectGenerator.FireBallOnOff = OptionMenu.SwitchOnOff(OptionMenuObjectGenerator.FireBallOnOff);
                        break;
                    case OptionMenu.WallOfFireLoc:
                        OptionMenuObjectGenerator.WallOfFireOnOff = OptionMenu.SwitchOnOff(OptionMenuObjectGenerator.WallOfFireOnOff);
                        break;
                    case OptionMenu.GravityControlLoc:
                        OptionMenuObjectGenerator.GravityControllerOnOff = OptionMenu.SwitchOnOff(OptionMenuObjectGenerator.GravityControllerOnOff);
                        break;
                    default:
                        break;
                }
            }
        }
        public void ExecuteConfirmationScreen()
        {
            pausable = false;

            if ((keyState.IsKeyDown(Keys.Z) && !prevkeyState.IsKeyDown(Keys.Z)) ||
                (gpState.IsButtonDown(Buttons.A) && !prevGpState.IsButtonDown(Buttons.A)))
                switch (dotLoc)
                {
                    case ConfirmationScreen.YesLoc:
                        game.Exit();
                        break;
                    case ConfirmationScreen.NoLoc:
                        dotLoc = PauseScreen.DotLocation;
                        game.state = Game1.GameStates.PauseScreen;
                        break;
                    default:
                        break;
                }
            if ((keyState.IsKeyDown(Keys.Down) && !prevkeyState.IsKeyDown(Keys.Down)) ||
                 (gpState.IsButtonDown(Buttons.LeftThumbstickDown) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickDown)))
            {
                if (dotLoc <= ConfirmationScreen.NoLoc - Value.One)
                    dotLoc += INCREMENT;
                else
                    dotLoc = ConfirmationScreen.YesLoc;
            }
            else if ((keyState.IsKeyDown(Keys.Up) && !prevkeyState.IsKeyDown(Keys.Up)) ||
                (gpState.IsButtonDown(Buttons.LeftThumbstickUp) && !prevGpState.IsButtonDown(Buttons.LeftThumbstickUp)))
            {
                if (dotLoc >= ConfirmationScreen.YesLoc + Value.One)
                    dotLoc -= INCREMENT;
                else
                    dotLoc = ConfirmationScreen.NoLoc;
            }

        }

    }
}