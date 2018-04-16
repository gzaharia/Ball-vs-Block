using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP_Lab._5
{
    public class Racket
    {
        public static int count = 0;

        public float CenterX { get; set; }
        public float CenterY { get; set; }

        public int Id { get; set; }

        public float DimensionX { get; set; }
        public float DimensionY { get; set; }

        public float PositionX { get; set; }
        public float PositionY { get; set; }

        public SolidBrush brush { get; set; }

        public Racket(float positionX, float positionY, float dimensionX, float dimensionY)
        {
            count++;
            Id = count;

            PositionX = positionX;
            PositionY = positionY;

            DimensionX = dimensionX;
            DimensionY = dimensionY;

            CenterX = PositionX + DimensionX / 2;
            CenterY = PositionY + DimensionY / 2;

            brush = new SolidBrush(Color.Blue);
        }

        public void MoveToLeft()
        {
            PositionX -= 10;
            //PositionY += MoveY;

            CenterX = PositionX + DimensionX / 2;
            CenterY = PositionY + DimensionY / 2;
        }

        public void MoveToRight()
        {
            PositionX += 10;

            CenterX = PositionX + DimensionX / 2;
            CenterY = PositionY + DimensionY / 2;
        }
    }
}
