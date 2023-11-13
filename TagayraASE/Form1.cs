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
        Bitmap bitmap1 = new Bitmap(400, 400);
        Bitmap bitmap2 = new Bitmap(400, 400);
        Pen pen = new Pen(Color.HotPink, 2);
        Brush brush = new SolidBrush(Color.Black);
        Boolean GiveBoolForFillColor = false;
        Color Backgroudcolor = Color.Gray;
        Graphics g;
        Point penposition;
        


        /// <summary>
        /// 
        /// </summary>
        public Form1()
        {
            penposition = new Point(10, 10);
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
            e.Graphics.DrawEllipse(pen, penposition.X, penposition.Y, 10,10);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text) & string.IsNullOrEmpty(textBox2.Text))
            {
                
                string[] converttostring = textBox1.Lines;
                foreach (string commandline in converttostring)
                {
                    string stroreSinglelineCode = Convert.ToString(commandline);
                    string[] addCommandToList = stroreSinglelineCode.Split(' ');
                    CommandsInCommandLine(addCommandToList);          //function that runs all command 
                }


            }

            else if (!string.IsNullOrEmpty(textBox2.Text) & string.IsNullOrEmpty(textBox1.Text))
            {
                string converttostring = textBox2.Text.ToString();
               // converttostring = converttostring.ToLower();
                string[] getcommand = converttostring.Split(' ');
                CommandsInCommandLine(getcommand);


            }


        }

        


        public void CommandsInCommandLine(string[] listForCommands)
        {
            
            Command command = new Command(g,pen,penposition.X, penposition.Y,brush);
           
                
                 if (listForCommands[0].Equals("rectangle"))
                {
                   
                    Boolean width = (int.TryParse(listForCommands[1], out int valueforwidth));
                    Boolean height = (int.TryParse(listForCommands[2], out int valueforheight));
            
                    if (width && height)
                    {

                       
                        command.DrawRectangle(command, GiveBoolForFillColor, valueforheight, valueforwidth);
                        pictureBox1.Refresh();
                    }
                   
                }


                


                else if (listForCommands[0].Equals("triangle"))
                {

                    Boolean SideLength = (int.TryParse(listForCommands[1], out int valueforsidelength));

                    if (SideLength)
                    {
                        
                        command.DrawTriangle(command, GiveBoolForFillColor, valueforsidelength);
                        pictureBox1.Refresh();
                    }
                   
                }


                else if (listForCommands[0].Equals("circle"))
                {

                    Boolean Radius = (int.TryParse(listForCommands[1], out int valueforradius));

                    if (Radius)
                    {

                        command.DrawCircle(command, GiveBoolForFillColor, valueforradius);
                        pictureBox1.Refresh();

                    }
                    
                }

                else if (listForCommands[0].Equals("move"))

                {
               
                    Boolean xaxis = (int.TryParse(listForCommands[1], out int valueforxaxis));
                    Boolean yaxis = (int.TryParse(listForCommands[2], out int valueforyaxis));
                    

                    if (xaxis == true && yaxis == true)
                    {
                        //set position of the pen
                        penposition = new Point(valueforxaxis, valueforyaxis);
                        pictureBox1.Refresh();

                    }
                   

                }


                else if (listForCommands[0].Equals("DrawTo"))
                {
                    Boolean xaxis = (int.TryParse(listForCommands[1], out int valueforxaxis));
                    Boolean yaxis = (int.TryParse(listForCommands[2], out int valueforyaxis));

                    if (xaxis && yaxis)
                    {
                        //call the DrawToPosition method of Cursor Class
                        command.DrawTo(command, valueforyaxis, valueforyaxis);
                        pictureBox1.Refresh();
                    }
                    
                }


                else if (listForCommands[0].Equals("pen"))

                {
     

                        command.PenColor(listForCommands[1], pen);

                      
                        if (listForCommands[1].Equals("yellow") || listForCommands[1].Equals("red")
                            || listForCommands[1].Equals("purple") || listForCommands[1].Equals("orange"))
                        {

                            
                            if (!string.IsNullOrEmpty(textBox1.Text) & string.IsNullOrEmpty(textBox2.Text))
                            {
                                MessageBox.Show("PEN COLOR CHANGED");
                            }

                        }

                       

                 }


                


                else if (listForCommands[0].Equals("fill"))
                {

                    //turn fill on or off

                    if (command.Fill(listForCommands[1]))
                    {
                        GiveBoolForFillColor = true;

                    }
                    else
                    {
                        GiveBoolForFillColor = false;
                    }

                    
                }




                else if (listForCommands[0].Equals("reset"))
                {
                    // Reset the pen position

                    penposition = new Point(10, 10);
                    g.DrawRectangle(pen, penposition.X, penposition.Y, 10, 10);
                    pictureBox1.Refresh();

                }


                else if (listForCommands[0].Equals("clear"))
                {
                    // Clear the canvas

                    g.Clear(Color.Gray);
                    pictureBox1.Refresh();
                }

    

            
        }


        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {

        }

    }
    }
