using DataTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.IO;

namespace Team_Project
{
    public class Level
    {
        private ObjectList[] objectList;
        private Game1 game;
        private int timeRemaining = Value.Zero, timeDelay = Value.TwentyFive, timerReset = Value.TwentyFive;
        private String fileName;
        private bool IsEndOfGame = false;
        private ArrayList backgroundObjectList = new ArrayList();
        private ArrayList blockList = new ArrayList();
        private ArrayList pipeList = new ArrayList();
        private ArrayList endGameObjectList = new ArrayList();
        private ArrayList itemList = new ArrayList();
        private ArrayList enemyList = new ArrayList();
        private ArrayList projectileList = new ArrayList();
        private ArrayList optionProjectileList = new ArrayList();
        private ArrayList fireWallList = new ArrayList();
        private ArrayList flyingBlockList = new ArrayList();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
        public IHUD HUD;
        public bool PauseGameTime { get; set; }
        public Vector2 PlayerStartPosition { get; set; }
        public Vector2 WorldNumber { get; set; }
        public Rectangle Limits { get; set; }
        public int TimeRemaining { get { return timeRemaining; } }

        public Level(Game1 Game, String FileName)
        {
            game = Game;
            fileName = FileName;

            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Content",
                fileName + ".xml");

            objectList = LevelLoader.Load(path);

            SoundManager.PlayLevelEndingSound = false;
        }

        public void LoadContent()
        {
            HUD = new InGameHUD(game);
            LevelEndAnimation.LoadGame(game);
            SpriteFactory.LoadStaticSprites();
            SoundManager.CurrentBackgroundTheme = SoundFactory.CreateSilence();

            // 1. Process and unpack all structural parameters from parsed file structures
            foreach (ObjectList item in objectList)
            {
                if (item.Type == PlayerAndHUDStringConstant.PlayerStartPosition) PlayerStartPosition = item.Location;
                else if (item.Type == PlayerAndHUDStringConstant.WorldNumber) WorldNumber = item.Location;
                else if (item.Type == PlayerAndHUDStringConstant.Limits)
                {
                    Limits = new Rectangle((int)item.Location.X,
                                           (int)item.Location.Y,
                                           int.Parse(item.AdditionalInfo.Substring(Value.Zero, item.AdditionalInfo.IndexOf(GeneralString.BlankSpace))),
                                           int.Parse(item.AdditionalInfo.Substring(item.AdditionalInfo.IndexOf(GeneralString.BlankSpace),
                                                                                     item.AdditionalInfo.Length - item.AdditionalInfo.IndexOf(GeneralString.BlankSpace))));
                }
                else if (item.Type == PlayerAndHUDStringConstant.Time) timeRemaining = int.Parse(item.AdditionalInfo);
                else if (item.Type == PlayerAndHUDStringConstant.FloatingCoin) ItemTracker.CreateFloatingCoin(item.Location);

                LoadBackgroundObject(item);
                LoadBlock(item);
                LoadPipe(item);
                LoadEndingLevelObject(item);
                LoadEnemy(item);
            }

            // 2. Clear camera tracking and synchronize active file constraints
            game.Camera.limits = Limits;
            game.Camera.Reset();
        }

        private void LoadBackgroundObject(ObjectList item)
        {
            if (item.Type == BackgroundStringConstant.BigHill) backgroundObjectList.Add(new BigHill(item.Location));
            else if (item.Type == BackgroundStringConstant.SmallHill) backgroundObjectList.Add(new SmallHill(item.Location));
            else if (item.Type == BackgroundStringConstant.OneBush) backgroundObjectList.Add(new OneBush(item.Location));
            else if (item.Type == BackgroundStringConstant.TwoBush) backgroundObjectList.Add(new TwoBush(item.Location));
            else if (item.Type == BackgroundStringConstant.ThreeBush) backgroundObjectList.Add(new ThreeBush(item.Location));
            else if (item.Type == BackgroundStringConstant.OneCloud) backgroundObjectList.Add(new OneCloud(item.Location));
            else if (item.Type == BackgroundStringConstant.TwoClouds) backgroundObjectList.Add(new TwoClouds(item.Location));
            else if (item.Type == BackgroundStringConstant.ThreeClouds) backgroundObjectList.Add(new ThreeClouds(item.Location));
        }

        private void LoadBlock(ObjectList item)
        {
            if (item.Type == BlockStringConstant.HiddenBlock) blockList.Add(new Block(item.Location, new HiddenBlockState()));
            else if (item.Type == BlockStringConstant.QuestionBlock) blockList.Add(new Block(item.Location, new QuestionBlockMushFlowerState()));
            else if (item.Type == BlockStringConstant.QuestionIceBlock) blockList.Add(new Block(item.Location, new QuestionBlockMushIceFlowerState()));
            else if (item.Type == BlockStringConstant.QuestionCoinBlock) blockList.Add(new Block(item.Location, new QuestionBlockCoinState()));
            else if (item.Type == BlockStringConstant.RedBlock) blockList.Add(new Block(item.Location, new BrickBlockEmptyState()));
            else if (item.Type == BlockStringConstant.RedCoinBlock) blockList.Add(new Block(item.Location, new BrickBlockCoinState()));
            else if (item.Type == BlockStringConstant.RedStarBlock) blockList.Add(new Block(item.Location, new BrickBlockStarmanState()));
            else if (item.Type == BlockStringConstant.RegularFloorBlock) blockList.Add(new Block(item.Location, new FloorBlockState()));
            else if (item.Type == BlockStringConstant.StepPyramidBlock) blockList.Add(new Block(item.Location, new StepPyramidBlockState()));
            else if (item.Type == BlockStringConstant.UndergroundBlock) blockList.Add(new Block(item.Location, new UndergroundBrickBlockState()));
            else if (item.Type == BlockStringConstant.UndergroundFloorBlock) blockList.Add(new Block(item.Location, new UndergroundFloorBlockState()));
            else if (item.Type == BlockStringConstant.UsedBlock) blockList.Add(new Block(item.Location, new UsedBlockState()));
            else if (item.Type == BlockStringConstant.SnowUsedBlock) blockList.Add(new Block(item.Location, new SnowyBlock(new UsedBlockState())));
            else if (item.Type == BlockStringConstant.SnowQuestionBlock) blockList.Add(new Block(item.Location, new SnowyBlock(new QuestionBlockMushFlowerState())));
            else if (item.Type == BlockStringConstant.SnowQuestionCoinBlock) blockList.Add(new Block(item.Location, new SnowyBlock(new QuestionBlockCoinState())));
            else if (item.Type == BlockStringConstant.SnowRedBlock) blockList.Add(new Block(item.Location, new SnowyBlock(new BrickBlockEmptyState())));
            else if (item.Type == BlockStringConstant.SnowRedCoinBlock) blockList.Add(new Block(item.Location, new SnowyBlock(new BrickBlockCoinState())));
            else if (item.Type == BlockStringConstant.SnowRedStarBlock) blockList.Add(new Block(item.Location, new SnowyBlock(new BrickBlockStarmanState())));
            else if (item.Type == BlockStringConstant.SnowRegularFloorBlock) blockList.Add(new Block(item.Location, new SnowyBlock(new FloorBlockState())));
            else if (item.Type == BlockStringConstant.SnowStepPyramidBlock) blockList.Add(new Block(item.Location, new SnowyBlock(new StepPyramidBlockState())));
            else if (item.Type == BlockStringConstant.SnowHiddenBlock) blockList.Add(new Block(item.Location, new SnowyBlock(new HiddenBlockState())));
            else if (item.Type == BlockStringConstant.SnowQuestionIceBlock) blockList.Add(new Block(item.Location, new SnowyBlock(new QuestionBlockMushIceFlowerState())));
        }

        private void LoadPipe(ObjectList item)
        {
            if (item.Type == PipeStringConstant.SmallPipe) pipeList.Add(new SmallPipe(item.Location));
            else if (item.Type == PipeStringConstant.MediumPipe) pipeList.Add(new MediumPipe(item.Location));
            else if (item.Type == PipeStringConstant.LargePipe) pipeList.Add(new LargePipe(item.Location));
            else if (item.Type == PipeStringConstant.LargePipeIn) pipeList.Add(new LargePipeIn(item.Location, item.AdditionalInfo, this));
            else if (item.Type == PipeStringConstant.HorizontalPipeRight)
            {
                pipeList.Add(new LPipeRightIn(item.Location + SecondObjectLocation.RightInPipe(), item.AdditionalInfo, this));
                pipeList.Add(new LPipeStandingRight(item.Location));
            }
        }

        private void LoadEndingLevelObject(ObjectList item)
        {
            if (item.Type == EndLevelStringConstant.Pole)
            {
                endGameObjectList.Add(new Pole(item.Location));
                blockList.Add(new Block(item.Location + SecondObjectLocation.FlagPoleBlock(), new StepPyramidBlockState()));
            }
            else if (item.Type == EndLevelStringConstant.Flag) endGameObjectList.Add(new PoleFlag(item.Location));
            else if (item.Type == EndLevelStringConstant.CastleFlag) endGameObjectList.Add(new CastleFlag(item.Location));
            else if (item.Type == EndLevelStringConstant.Castle) endGameObjectList.Add(new SmallCastle(item.Location));
        }

        private void LoadEnemy(ObjectList item)
        {
            if (item.Type == EnemyStringConstant.GoombaSprite) enemyList.Add(new Goomba(item.Location));
            else if (item.Type == EnemyStringConstant.KoopaSprite) enemyList.Add(new Koopa(item.Location));
            else if (item.Type == EnemyStringConstant.PiranhaSprite) enemyList.Add(new Piranha(item.Location));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public void Update(GameTime gameTime)
        {
            CollisionDetector.CollisionType collision;
            projectileList.Clear();
            ProjectileTracker.GetFireballs(projectileList);
            itemList = ItemTracker.GetItemList();

            if (OptionMenuObjectGenerator.WallOfFireOnOff == Status.Off)
            {
                fireWallList.Clear();
                OptionMenuObjectGenerator.FireWallOn = false;
            }

            if (IsEndOfGame)
            {
                optionProjectileList.Clear();
                fireWallList.Clear();
                flyingBlockList.Clear();
            }

            OptionMenuObjectGenerator.ObjectGenerator(gameTime, game);
            OptionMenuObjectGenerator.GetFlameWall(fireWallList);
            OptionMenuObjectGenerator.GetProjectile(optionProjectileList);
            OptionMenuObjectGenerator.GetFlyingBlock(flyingBlockList);

            LevelEndAnimation.GetFireWork(projectileList);

            if (!IsEndOfGame) timeDelay--;
            else if (timeRemaining > Value.Zero && LevelEndAnimation.MarioInCastle)
            {
                timeRemaining--;
                game.currentPlayer.ScoreCard.AddPoints(Value.Fifty);
                SoundManager.PlayEndingScoreFromTimerSound();
            }
            if (timeDelay == Value.Zero)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining--;
                    timeDelay = timerReset;
                }
                else if (timeRemaining == 0) game.currentPlayer.Die();
            }
            if (timeRemaining == Value.OneHundred && !IsEndOfGame) SoundManager.PlayHurrySound();

            SoundManager.ChooseBackgroundMusic(game.currentPlayer, gameTime, IsEndOfGame);

            foreach (Block block in blockList) block.Update(gameTime);
            foreach (IItem item in itemList) item.Update(gameTime);
            foreach (IEnemy enemy in enemyList) enemy.Update(gameTime);
            foreach (IProjectile p in projectileList) p.Update(game, gameTime);
            foreach (IObjectsEffectPlayer projec in optionProjectileList) projec.Update(gameTime);
            foreach (IObjectsEffectPlayer wall in fireWallList) wall.Update(gameTime);
            foreach (Block blk in flyingBlockList) blk.Update(gameTime);

            // Collision Detection & Handling
            collision = CollisionDetector.DetectCollision(game.currentPlayer.Rectangle,
                                                          new Rectangle(game.Camera.viewport.X,
                                                                        game.Camera.viewport.Y,
                                                                        game.Camera.viewport.Width,
                                                                        game.Camera.viewport.Height));
            game.Camera.CollisionResponseWithPlayer(game.currentPlayer, collision);

            foreach (IEndGameObject endGameObject in endGameObjectList)
            {
                endGameObject.Wins = IsEndOfGame;
                collision = CollisionDetector.DetectCollision(game.currentPlayer.Rectangle, endGameObject.Rectangle);
                endGameObject.EndGameCollisionResponse(game.currentPlayer, collision);
                IsEndOfGame = endGameObject.Wins;
            }
            foreach (Block block in blockList)
            {
                collision = CollisionDetector.DetectCollision(game.currentPlayer.Rectangle, block.Rectangle);
                block.CollisionResponseWithPlayer(game.currentPlayer, collision);
                foreach (IEnemy enemy in enemyList)
                {
                    collision = CollisionDetector.DetectCollision(enemy.Rectangle, block.Rectangle);
                    block.CollisionResponseWithEnemy(game.currentPlayer, enemy, collision);
                }
                foreach (IItem item in itemList)
                {
                    collision = CollisionDetector.DetectCollision(item.Rectangle, block.Rectangle);
                    item.CollisionResponseWithStaticObject(block, collision);
                }
                foreach (IProjectile p in projectileList)
                {
                    collision = CollisionDetector.DetectCollision(p.Rectangle, block.Rectangle);
                    p.CollisionResponseWithStaticObject(block, collision);
                }
            }
            foreach (IPipe pipe in pipeList)
            {
                collision = CollisionDetector.DetectCollision(game.currentPlayer.Rectangle, pipe.Rectangle);
                pipe.CollisionResponse(game.currentPlayer, collision);
                foreach (IEnemy enemy in enemyList)
                {
                    collision = CollisionDetector.DetectCollision(enemy.Rectangle, pipe.Rectangle);
                    pipe.CollisionResponseWithEnemy(enemy, collision);
                }
                foreach (IItem item in itemList)
                {
                    collision = CollisionDetector.DetectCollision(item.Rectangle, pipe.Rectangle);
                    item.CollisionResponseWithStaticObject(pipe, collision);
                }
                foreach (IProjectile p in projectileList)
                {
                    collision = CollisionDetector.DetectCollision(p.Rectangle, pipe.Rectangle);
                    p.CollisionResponseWithStaticObject(pipe, collision);
                }
            }
            foreach (IItem item in itemList)
            {
                collision = CollisionDetector.DetectCollision(game.currentPlayer.Rectangle, item.Rectangle);
                item.CollisionResponseWithPlayer(game.currentPlayer, collision);
            }
            foreach (IEnemy enemy in enemyList)
            {
                collision = CollisionDetector.DetectCollision(game.currentPlayer.Rectangle, enemy.Rectangle);
                enemy.CollisionResponseWithPlayer(game.currentPlayer, collision);
                enemy.StartMoving(game.currentPlayer);
                foreach (IEnemy secondEnemy in enemyList)
                {
                    if (enemy != secondEnemy)
                    {
                        collision = CollisionDetector.DetectCollision(enemy.Rectangle, secondEnemy.Rectangle);
                        enemy.CollisionResponseWithEnemy(game.currentPlayer, secondEnemy, collision);
                    }
                }
                foreach (IProjectile p in projectileList)
                {
                    collision = CollisionDetector.DetectCollision(p.Rectangle, enemy.Rectangle);
                    p.CollisionResponseWithEnemy(game.currentPlayer, enemy, collision);
                }
            }
            foreach (IObjectsEffectPlayer projec in optionProjectileList)
            {
                collision = CollisionDetector.DetectCollision(game.currentPlayer.Rectangle, projec.Rectangle);
                projec.CollisionResponseWithPlayer(game.currentPlayer, collision);
            }
            foreach (IObjectsEffectPlayer wall in fireWallList)
            {
                collision = CollisionDetector.DetectCollision(game.currentPlayer.Rectangle, wall.Rectangle);
                wall.CollisionResponseWithPlayer(game.currentPlayer, collision);
            }
            foreach (Block blk in flyingBlockList)
            {
                collision = CollisionDetector.DetectCollision(game.currentPlayer.Rectangle, blk.Rectangle);
                blk.CollisionResponseWithPlayer(game.currentPlayer, collision);
            }

            HUD.Update(gameTime);
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            SpriteBatch spriteBatch = SpriteBatch;

            foreach (IBackgroundItem backgroundObject in backgroundObjectList) backgroundObject.Draw(spriteBatch);
            foreach (IItem item in itemList) item.Draw(spriteBatch);
            foreach (Block block in blockList) block.Draw(spriteBatch);
            foreach (IEnemy enemy in enemyList) enemy.Draw(spriteBatch);
            foreach (IEndGameObject endGameObject in endGameObjectList) endGameObject.Draw(spriteBatch);

            if (!(game.currentPlayer.GetPower() == Mario.Power.Dead))
            {
                game.currentPlayer.Draw(spriteBatch, Color.White);
            }
            foreach (IPipe pipe in pipeList) pipe.Draw(spriteBatch);
            foreach (IProjectile p in projectileList) p.Draw(spriteBatch);
            foreach (IObjectsEffectPlayer projec in optionProjectileList) projec.Draw(SpriteBatch);
            foreach (IObjectsEffectPlayer wall in fireWallList) wall.Draw(SpriteBatch);
            foreach (Block blk in flyingBlockList) blk.Draw(SpriteBatch);

            if (game.currentPlayer.GetPower() == Mario.Power.Dead)
            {
                game.currentPlayer.Draw(spriteBatch, Color.White);
            }
            HUD.Draw(spriteBatch);
        }

        public void Reset()
        {
            backgroundObjectList.Clear();
            blockList.Clear();
            pipeList.Clear();
            endGameObjectList.Clear();
            itemList.Clear();
            ItemTracker.ClearItemList();
            enemyList.Clear();
            projectileList.Clear();
            optionProjectileList.Clear();
            fireWallList.Clear();
            flyingBlockList.Clear();
            IsEndOfGame = false;
            OptionMenuObjectGenerator.FireWallOn = false;
            LevelEndAnimation.EndingAnimationReset();
            SoundManager.ResetHurryTimer();
            SoundManager.PlayLevelEndingSound = false;

            game.BackgroundColor = Color.CornflowerBlue;
            game.Camera = new Camera1(game.GraphicsDevice.Viewport, game.zoom, Limits);

            string path = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Content",
                fileName + ".xml");
            objectList = LevelLoader.Load(path);

            this.LoadContent();
            Mario mario = (Mario)game.currentPlayer;
            if (game.playerChar == Game1.Characters.Mario || game.playerChar == Game1.Characters.Luigi)
                game.currentPlayer.State = new SmallMarioIdleRightState(mario);
            else if (game.playerChar == Game1.Characters.Bowser)
                game.currentPlayer.State = new SmallBowserIdleRightState(mario);

            // Set Mario's location smoothly from file configs
            game.currentPlayer.Location = PlayerStartPosition;
        }
    }
}