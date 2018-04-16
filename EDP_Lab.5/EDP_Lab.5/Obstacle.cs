using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP_Lab._5
{
    public class Obstacle
    {
        public static int count = 0;

        public int Id { get; set; }

        public float DimensionX { get; set; }
        public float DimensionY { get; set; }

        public float PositionX { get; set; }
        public float PositionY { get; set; }

        public SolidBrush brush { get; set; }

        public Obstacle(float positionX, float positionY, float dimensionX, float dimensionY)
        {
            count++;
            Id = count;

            PositionX = positionX;
            PositionY = positionY;

            DimensionX = dimensionX;
            DimensionY = dimensionY;

            brush = new SolidBrush(Color.Black);
        }

        public void ChangeColor()
        {
            this.brush.Color = this.brush.Color == Color.Black ? this.brush.Color = Color.Yellow : this.brush.Color = Color.Black;
        }
    }
}
