using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class IceBlock1616State : IBlockState
    {
        private IAnimatedSprite iceBlockSprite;

        public IceBlock1616State()
        {
            iceBlockSprite = SpriteFactory.CreateIceBlock1616Sprite();
        }

        public void CollisionResponseWithPlayer(Block block, IPlayer player, CollisionDetector.CollisionType collision)
        {
            switch (collision)
            {
                case CollisionDetector.CollisionType.top:
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.bottom:
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.right:
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.left:
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.none:
                    break;
            }
        }

        public void GetBlock(Block block)
        {
        }

        public void CollisionResponseWithEnemy(Block block, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            enemy.CollisionResponseWithStaticObject(block, collision);
        }

        public void Update(GameTime gameTime)
        {
            iceBlockSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            iceBlockSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
