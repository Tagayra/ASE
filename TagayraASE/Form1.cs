using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagayraASE
{

    /// <summary>
    /// Main form for the TagayraASE application.
    /// </summary>
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
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            penposition = new Point(10, 10);
            InitializeComponent();
            g = Graphics.FromImage(bitmap1);
            g.Clear(Color.Gray);   

        }


        /// <summary>
        /// Event handler for painting the PictureBox.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g =e.Graphics;
            g.DrawImageUnscaled(bitmap1, 0, 0);
            g.DrawImageUnscaled(bitmap2 , 0, 0);
            e.Graphics.DrawEllipse(pen, penposition.X, penposition.Y, 10,10);

        }

        /// <summary>
        /// Event handler for the button click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing commands: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        /// <summary>
        /// Processes the commands provided in the command line.
        /// </summary>
        /// <param name="listForCommands">The list of commands to be processed.</param>

        public void CommandsInCommandLine(string[] listForCommands)
        {

            try
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
                        else
                        {
                           MessageBox.Show("try entering these colors yellow purple red orange");

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
                else
                {
                    throw new FormatException("wrong command ");
                }

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input format: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// Event handler for the button click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "\"Text Files (.txt)|*.txt|All Files|*.*";  
            openFileDialog.DefaultExt = "txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        while (!reader.EndOfStream)
                        {

                            string command = reader.ReadLine();
                            string[] singlecommand = command.Split(' ');
                            g.Clear(Color.SlateGray);  //clear pictureboard
                            CommandsInCommandLine(singlecommand);
                        }
                    }
                    MessageBox.Show("LOADED COMMAND");
                }
                catch
                {
                    MessageBox.Show("ERROR LOADING THE FILE");

                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file dialog: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Event handler for the button click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                string[] storeLineInFile = textBox1.Lines;

                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (string commandline in storeLineInFile)
                        {
                            writer.WriteLine(commandline);
                        }
                    }

                    MessageBox.Show("File Has Been Saved");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There Was An Error in Saving The File");
                }

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening save file dialog: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
        
    }
    }
