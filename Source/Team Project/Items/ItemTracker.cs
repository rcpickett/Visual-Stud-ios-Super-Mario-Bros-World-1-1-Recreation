using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Team_Project
{
    public static class ItemTracker
    {
        private static ArrayList itemList = new ArrayList();

        public static void CreateSuperMushroom(Vector2 location, Block block)
        {
            itemList.Add(new SuperMushroom(location, block));
        }

        public static void Create1UpMushroom(Vector2 location, Block block)
        {
            itemList.Add(new OneUpMushroom(location, block));
        }

        public static void CreateStarman(Vector2 location, Block block)
        {
            itemList.Add(new Starman(location, block));
        }

        public static void CreateFireFlower(Vector2 location, Block block)
        {
            itemList.Add(new FireFlower(location, block));
        }

        public static void CreateIceFlower(Vector2 location, Block block)
        {
            itemList.Add(new IceFlower(location, block));
        }

        public static void CreateBlockCoin(Vector2 location)
        {
            itemList.Add(new BlockCoin(location));
        }

        public static void CreateFloatingCoin(Vector2 location)
        {
            itemList.Add(new FloatingCoin(location));
        }

        public static void ClearItemList()
        {
            itemList.Clear();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public static ArrayList GetItemList()
        {
            return itemList;
        }
    }
}
