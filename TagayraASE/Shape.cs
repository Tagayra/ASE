﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagayraASE
{
    public abstract class Shape
    {
       public Graphics g;
       public  Pen pen;
       public int positionx;
       public  int positiony;
       public Brush brush;

        public Shape(Graphics g, Pen pen,int positionx ,int positiony ,Brush brush) 
        {
            this.g = g;
            this.pen = pen;
            this.positionx = positionx;
            this.positiony = positiony;
            this.brush = brush;

          
        
        }

    }
}
