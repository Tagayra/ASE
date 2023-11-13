using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace TagayraASE
{
    
    public class Command : Shape
    {
        Boolean give = false;
        int xaxis2, yaxis2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="g">The graphics object used for drawing.</param>
        /// <param name="pen">The pen used for drawing outlines.</param>
        /// <param name="positionx">The initial x-coordinate of the drawing position.</param>
        /// <param name="positiony">The initial y-coordinate of the drawing position.</param>
        /// <param name="brush">The brush used for filling shapes.</param>
        public Command(Graphics g, Pen pen, int positionx, int positiony, Brush brush) : base(g, pen, positionx, positiony,brush)
        {

        }

        /// <summary>
        /// Draws a line from the current position to the specified coordinates.
        /// </summary>
        /// <param name="command">The Command object.</param>
        /// <param name="xaxis2">The x-coordinate to draw the line to.</param>
        /// <param name="yaxis2">The y-coordinate to draw the line to.</param>

        public void DrawTo(Command command, int xaxis2, int yaxis2)
        {
            g = command.g;
            g.DrawLine(command.pen, command.positionx, command.positiony, xaxis2, yaxis2);

        }

        /// <summary>
        /// Sets the fill state based on the provided command.
        /// </summary>
        /// <param name="command">The command ('on' or 'off').</param>
        /// <returns>True if the fill state is 'on', false if 'off'.</returns>
        public Boolean Fill(string command)
        {

            if (command.Equals("on"))   //IF ON
            {
                give = true;


            }
            else if (command.Equals("off")) //ELSE IF OFF
            {
                give = false;

            }

            return give;
        }

        /// <summary>
        /// Sets the pen color based on the provided color name.
        /// </summary>
        /// <param name="getcolor">The color name.</param>
        /// <param name="pen">The pen object to modify.</param>
        /// <returns>The updated color of the pen.</returns>
        public Color PenColor(string getcolor, Pen pen)
        {
            if (getcolor.Equals("yellow"))
            {
                pen.Color = Color.Yellow;

            }

            else if (getcolor.Equals("red"))
            {
                pen.Color = Color.Red;



            }
            else if (getcolor.Equals("purple"))
            {
                pen.Color = Color.Purple;


            }
            else if (getcolor.Equals("orange"))
            {
                pen.Color = Color.Orange;


            }
            return pen.Color;
        }


        /// <summary>
        /// Draws a circle on the canvas.
        /// </summary>
        /// <param name="command">The Command object.</param>
        /// <param name="onoroff">True to fill the circle, false to draw the outline.</param>
        /// <param name="radius">The radius of the circle.</param>
        public void DrawCircle(Command command, Boolean onoroff, int radius)
        {
            if (onoroff.Equals(false))
            {

                g.DrawEllipse(command.pen, command.positionx - radius, command.positiony - radius, 2 * radius, 2 * radius);    //graphics to draw a circle

            }
            else if (onoroff.Equals(true))
            {

                g.FillEllipse(command.brush, command.positionx - radius, command.positiony - radius, 2 * radius, 2 * radius);
                //pictureBox1.Refresh();
            }

        }

        /// <summary>
        /// Draws a rectangle on the canvas.
        /// </summary>
        /// <param name="command">The Command object.</param>
        /// <param name="onandoff">True to fill the rectangle, false to draw the outline.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        public void DrawRectangle(Command command, Boolean onandoff, int height, int width)
        {
            if (onandoff.Equals(true))
            {
                g.FillRectangle(command.brush, command.positionx - (width / 2), command.positiony - (height / 2), width, height);
            }
            else if (onandoff.Equals(false))
            {

                g.DrawRectangle(command.pen, command.positionx - (width / 2), command.positiony - (height / 2), width, height);

            }
        }
        /// <summary>
        /// Draws an equilateral triangle on the canvas.
        /// </summary>
        /// <param name="command">The Command object.</param>
        /// <param name="onoroff">True to fill the triangle, false to draw the outline.</param>
        /// <param name="sidelength">The side length of the triangle.</param>
      
        public void DrawTriangle(Command command, Boolean onoroff, int sidelength)
        {
            if (onoroff.Equals(true))
            {
                float height = (float)(sidelength + Math.Sqrt(3) / 2);
                double halfSide = sidelength / 2.0;

                // Calculate the coordinates of the vertices based on the midpoint
                Point vertex1 = new Point((int)(command.positionx - halfSide), (int)(command.positiony - halfSide / Math.Sqrt(3)));
                Point vertex2 = new Point((int)(command.positionx + halfSide), (int)(command.positiony - halfSide / Math.Sqrt(3)));
                Point vertex3 = new Point(command.positionx, (int)(command.positiony + 2 * halfSide / Math.Sqrt(3)));

                Point[] trianglePoints = new Point[]
            {
            vertex1,vertex2,vertex3

            };
                g = command.g;
                g.FillPolygon(command.brush, trianglePoints);
            }
            else if (onoroff.Equals(false))
            {
                float height = (float)(sidelength + Math.Sqrt(3) / 2);
                double halfSide = sidelength / 2.0;

                // Calculate the coordinates of the vertices based on the midpoint
                Point vertex1 = new Point((int)(command.positionx - halfSide), (int)(command.positiony - halfSide / Math.Sqrt(3)));
                Point vertex2 = new Point((int)(command.positionx + halfSide), (int)(command.positiony - halfSide / Math.Sqrt(3)));
                Point vertex3 = new Point(command.positionx, (int)(command.positiony + 2 * halfSide / Math.Sqrt(3)));

                Point[] trianglePoints = new Point[]
            {
                vertex1,vertex2,vertex3

            };

                g = command.g;
                g.DrawPolygon(command.pen, trianglePoints);

            }




        }



    }
}     


