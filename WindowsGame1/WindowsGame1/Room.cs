using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuntTheWumpus
{
    public class Room
    {
        private int conn_1;
        private int conn_2;
        private int conn_3;

        public Room(int r1, int r2, int r3)
        {
            this.conn_1 = r1;
            this.conn_2 = r2;
            this.conn_3 = r3;
        }

        public bool isConnectedRoom(int room)
        {
            if (room == this.conn_1 || room == this.conn_2 || room == this.conn_3)
            {
                return true;
            }
            return false;
        }

        public int RoomOne
        {
            get { return conn_1; }
        }

        public int RoomTwo
        {
            get { return conn_2; }
        }

        public int RoomThree
        {
            get { return conn_3; }
        }
    }
}
