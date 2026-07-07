using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Team_Project
{
    class StepPyramidBlockState : IBlockState
    {
        private IAnimatedSprite stepBlockSprite;


        public StepPyramidBlockState(){
            stepBlockSprite = SpriteFactory.CreateStepPyramidBlock();
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
                case CollisionDetector.CollisionType.left:
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.right:
                    player.BlockCollision(block, collision);
                    break;
                case CollisionDetector.CollisionType.none:
                    break;
            } 
        }

        public void CollisionResponseWithEnemy(Block block, IEnemy enemy, CollisionDetector.CollisionType collision)
        {
            enemy.CollisionResponseWithStaticObject(block, collision);
        }

        public void GetBlock(Block block)
        {
        }

        public void Update(GameTime gameTime)
        {
            stepBlockSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            stepBlockSprite.Draw(spriteBatch, location, Color.White);
        }
    }
}
