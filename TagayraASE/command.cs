﻿using System;
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

        public Command(Graphics g, Pen pen, int positionx, int positiony) : base(g, pen, positionx, positiony)
        {

        }


        public void DrawTo(Command command, int xaxis2, int yaxis2)
        {
            g = command.g;
            g.DrawLine(command.pen, command.positionx, command.positiony, xaxis2, yaxis2);

        }

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


        public void DrawCircle(Command command, Boolean onoroff, int radius)
        {
            if (onoroff.Equals(true))
            {
                g = command.g;
                g.DrawEllipse(command.pen, command.positionx - radius, command.positiony - radius, 2 * radius, 2 * radius);    //graphics to draw a circle
            
        }
            else if (onoroff.Equals(false))
            {
                g = command.g;
                g.FillEllipse(command.brush, command.positionx - radius, command.positiony - radius, 2 * radius, 2 * radius);
                //pictureBox1.Refresh();
            }

        }


    }



}     


