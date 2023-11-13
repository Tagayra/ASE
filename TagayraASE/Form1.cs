using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagayraASE
{
    public partial class Form1 : Form
    {
        Bitmap bitmap1 = new Bitmap(458, 400);
        Bitmap bitmap2 = new Bitmap(458, 400);
        Pen pen = new Pen(Color.HotPink, 2);
        Brush brush = new SolidBrush(Color.Black);
        Boolean GiveBoolForFillColor = false;
        Color Backgroudcolor = Color.SlateGray;
        Graphics g;
        Point penposition;
        

        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(bitmap1);
            g.Clear(Color.Gray);   

        }
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g =e.Graphics;
            g.DrawImageUnscaled(bitmap1, 0, 0);
            g.DrawImageUnscaled(bitmap2 , 0, 0);
            g.DrawEllipse(pen,10,10,10,10);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string converttostring = textBox1.Lines.ToString();


            }

            else if (!string.IsNullOrEmpty(textBox2.Text))
            {
                string converttostring = textBox1.Text.ToString();
                converttostring=converttostring.ToLower();


            }


        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {

        }


        public void CommandsInCommandLine(string[] storesplitcommands)
        {
            //creating instances
            Command command = new Command(g,pen,penposition.X, penposition.Y,brush);
           
                
                 if (storesplitcommands[0].Equals("rectangle"))
                {
                    string[] splitnumber = storesplitcommands[1].Split(',');
                    Boolean width = (int.TryParse(splitnumber[0], out int valueforwidth));
                    Boolean height = (int.TryParse(splitnumber[1], out int valueforheight));

                    if (width && height)
                    {

                        //call the DrawRectangle method of Cursor Class
                        command.DrawRectangle(command, GiveBoolForFillColor, valueforheight, valueforwidth);
                        pictureBox1.Refresh();
                    }
                   
                }


                


                else if (storesplitcommands[0].Equals("triangle"))
                {

                    Boolean SideLength = (int.TryParse(storesplitcommands[1], out int valueforsidelength));

                    if (SideLength)
                    {
                        //call the DrawTriangle method of Cursor Class
                        command.DrawTriangle(command, GiveBoolForFillColor, valueforsidelength);
                        pictureBox1.Refresh();
                    }
                   
                }


                else if (storesplitcommands[0].Equals("circle"))
                {

                    Boolean Radius = (int.TryParse(storesplitcommands[1], out int valueforradius));

                    if (Radius)
                    {

                        //call the DrawCircle method of Cursor Class
                        command.DrawCircle(command, GiveBoolForFillColor, valueforradius);
                        pictureBox1.Refresh();

                    }
                    
                }

                else if (storesplitcommands[0].Equals("moveTo"))

                {
                    //perform moveTo
                    string[] splitnumber = storesplitcommands[1].Split(',');
                    Boolean xaxis = (int.TryParse(splitnumber[0], out int valueforxaxis));
                    Boolean yaxis = (int.TryParse(splitnumber[1], out int valueforyaxis));

                    if (xaxis == true && yaxis == true)
                    {
                        //set position of the pen
                        penposition = new Point(valueforxaxis, valueforyaxis);
                        pictureBox1.Refresh();

                    }
                   

                }


                else if (storesplitcommands[0].Equals("DrawTo"))
                {

                    //darw a line

                    string[] splitnumber = storesplitcommands[1].Split(',');
                    Boolean xaxis = (int.TryParse(splitnumber[0], out int valueforxaxis));
                    Boolean yaxis = (int.TryParse(splitnumber[1], out int valueforyaxis));

                    if (xaxis && yaxis)
                    {
                        //call the DrawToPosition method of Cursor Class
                        command.DrawTo(command, valueforyaxis, valueforyaxis);
                        pictureBox1.Refresh();
                    }
                    
                }


                else if (storesplitcommands[0].Equals("pen"))

                {
                    if (storesplitcommands.Length == 2)
                    {

                        //set pen color

                        command.PenColor(storesplitcommands[1], pen);

                        //if pen color out of given color
                        if (storesplitcommands[1].Equals("red") || storesplitcommands[1].Equals("blue")
                            || storesplitcommands[1].Equals("green") || storesplitcommands[1].Equals("yellow"))
                        {

                            //
                            if (!string.IsNullOrEmpty(textBox1.Text) & string.IsNullOrEmpty(textBox2.Text))
                            {
                                MessageBox.Show("PEN COLOR CHANGED");
                            }

                        }

                       

                    }


                }


                else if (storesplitcommands[0].Equals("fill"))
                {

                    //turn fill on or off

                    if (command.Fill(storesplitcommands[1]))
                    {
                        GiveBoolForFillColor = true;

                    }
                    else
                    {
                        GiveBoolForFillColor = false;
                    }

                    
                }




                else if (storesplitcommands[0].Equals("reset"))
                {
                    // Reset the pen position

                    penposition = new Point(10, 10);
                    g.DrawRectangle(pen, penposition.X, penposition.Y, 10, 10);
                    pictureBox1.Refresh();

                }


                else if (storesplitcommands[0].Equals("clear"))
                {
                    // Clear the canvas

                    g.Clear(Color.SlateGray);
                    pictureBox1.Refresh();
                }

                


            

            
        }

        }
    }
