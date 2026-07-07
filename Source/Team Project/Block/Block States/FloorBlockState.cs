using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class FloorBlockState : IBlockState
    {
        private IAnimatedSprite floorBlockSprite;

        public FloorBlockState(){
            floorBlockSprite = SpriteFactory.CreateRegularFloorBlock();
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
            floorBlockSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            floorBlockSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
