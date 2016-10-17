using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    class Map
    {
        private List<CollisionTile> tileList = new List<CollisionTile>();
        Room[] tunnelList;

        public Room[] Tunnels
        {
            get { return tunnelList; }
        }

        public List<CollisionTile> TileList
        {
            get { return tileList; }
        }

        private int width, height;

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Map()
        {

        }


        public void Generate(int[,] map, int size)
        {
            for(int i = 0; i < map.GetLength(1); i++)
            {
                for(int j = 0; j < map.GetLength(0); j++)
                {
                    int number = map[j, i];

                    tileList.Add(new CollisionTile(number, new Microsoft.Xna.Framework.Rectangle(i * size, j * size, size, size)));
                    

                    width = (i + 1) * size;
                    height = (j + 1) * size;
                }
            }

            tunnelList = new Room[Constants.NUM_OF_ROOMS];

            tunnelList[0] = new Room(1, 4, 5);
            tunnelList[1] = new Room(0, 2, 6);
            tunnelList[2] = new Room(1, 3, 7);
            tunnelList[3] = new Room(2, 4, 8);
            tunnelList[4] = new Room(3, 0, 9);
            tunnelList[5] = new Room(0, 10, 14);
            tunnelList[6] = new Room(1, 10, 11);
            tunnelList[7] = new Room(2, 11, 12);
            tunnelList[8] = new Room(3, 12, 13);
            tunnelList[9] = new Room(4, 13, 14);
            tunnelList[10] = new Room(5, 6, 15);
            tunnelList[11] = new Room(6, 7, 16);
            tunnelList[12] = new Room(7, 8, 17);
            tunnelList[13] = new Room(8, 9, 18);
            tunnelList[14] = new Room(9, 5, 19);
            tunnelList[15] = new Room(10, 16, 19);
            tunnelList[16] = new Room(11, 15, 17);
            tunnelList[17] = new Room(12, 16, 18);
            tunnelList[18] = new Room(13, 17, 19);
            tunnelList[19] = new Room(14, 18, 15);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(CollisionTile tile in tileList)
            {
                tile.Draw(spriteBatch);
            }
        }

    }
}
