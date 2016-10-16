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

                    if(number > 0)
                    {
                        tileList.Add(new CollisionTile(number, new Microsoft.Xna.Framework.Rectangle(i * size, j * size, size, size)));
                    }

                    width = (i + 1) * size;
                    height = (j + 1) * size;
                }
            }
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
