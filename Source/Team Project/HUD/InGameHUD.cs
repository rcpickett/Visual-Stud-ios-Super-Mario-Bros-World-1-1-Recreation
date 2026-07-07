using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTypes;

namespace Team_Project
{
    public class InGameHUD : IHUD
    {
        SpriteFont spriteFont;
        SpriteBatch spriteBatch;
        IAnimatedSprite coinSprite;
        Game1 game;

        public InGameHUD(Game1 g)
        {
            spriteFont = SpriteFactory.CreateHUDSpriteFont();
            spriteBatch = g.spriteBatch;
            coinSprite = SpriteFactory.CreateHUDCoinSprite();
            game = g;
        }

        public void Update(GameTime gameTime)
        {
            coinSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, HUDString.Mario, new Vector2(game.Camera.position.X + Value.Eight, game.Camera.position.Y + Value.Eight), Color.White);
            spriteBatch.DrawString(spriteFont, HUDString.World, new Vector2(game.Camera.position.X + Value.OneHundredFifty, game.Camera.position.Y + Value.Eight), Color.White);
            spriteBatch.DrawString(spriteFont, HUDString.Time, new Vector2(game.Camera.position.X + Value.TwoHundredTwenty, game.Camera.position.Y + Value.Eight), Color.White);
            spriteBatch.DrawString(spriteFont, LeadingZeros(game.currentPlayer.ScoreCard.Points) + game.currentPlayer.ScoreCard.Points, new Vector2(game.Camera.position.X + Value.Eight, game.Camera.position.Y + Value.Twenty), Color.White);
            coinSprite.Draw(spriteBatch, new Vector2(game.Camera.position.X + Value.SixtyEight, game.Camera.position.Y + Value.TwentySix), Color.White);
            spriteBatch.DrawString(spriteFont, HUDString.X + LeadingZeroCoin(game.currentPlayer.ScoreCard.Coins) + game.currentPlayer.ScoreCard.Coins, new Vector2(game.Camera.position.X + Value.SeventyThree, game.Camera.position.Y + Value.Twenty), Color.White);
            spriteBatch.DrawString(spriteFont, game.Level.WorldNumber.X + HUDString.Dash + game.Level.WorldNumber.Y, new Vector2(game.Camera.position.X + Value.OneHundredSixtyFive, game.Camera.position.Y + Value.Twenty), Color.White);
            spriteBatch.DrawString(spriteFont, LeadingZerosTime(game.Level.TimeRemaining) + game.Level.TimeRemaining.ToString(), new Vector2(game.Camera.position.X + Value.TwoHundredTwentyFive, game.Camera.position.Y + Value.Twenty), Color.White);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private string LeadingZerosTime(int p)
        {
            switch (p.ToString().Length)
            {
                case 1:
                    return HUDString.DoubleZero;
                case 2:
                    return HUDString.Zero;
                default:
                    return HUDString.Blank;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private string LeadingZeros(int score)
        {
            switch (score.ToString().Length)
            {
                case 1:
                    return HUDString.FiveZeros;
                case 2:
                    return HUDString.QuadZero;
                case 3:
                    return HUDString.TripleZero;
                case 4:
                    return HUDString.DoubleZero;
                case 5:
                    return HUDString.Zero;
                default:
                    return HUDString.Blank;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private string LeadingZeroCoin(int coins) {
            if (coins <= Value.Nine)
            {
                return HUDString.Zero;
            }
            else
            {
                return HUDString.Blank;
            }
        }

        public void DrawPoints(IEnemy enemy)
        {
            Vector2 position = new Vector2(enemy.Location.X, enemy.Location.Y - 8);
            for(int i = 0; i < 36; i++)
            {
                spriteBatch.DrawString(spriteFont, enemy.PointValue.ToString(), new Vector2(position.X, position.Y), Color.White);
            }
        }
    }
}
