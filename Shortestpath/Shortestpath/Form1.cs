using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shortestpath
{
    public partial class Form1 : Form
    {
        Dijkstra dj = new Dijkstra();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Print maximum dimension of the picturebox
            // it will be used to limite the Vertices coordinators
            labelcoord.Text = pictureBox1.Width + "," + pictureBox1.Height;
        }

        //
        // Verif if a string just contains numeric characters
        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            //
            // Check if the label is empty
            //
            if(textBoxlabel.Text.Trim() == "")
            {
                MessageBox.Show("You must enter the label", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //
            // Check if the X is empty
            //
            if (!IsNumeric(textBoxX.Text.Trim()))
            {
                MessageBox.Show("The X mmust be numeric", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //
            // Check if the Y is empty
            //
            if (!IsNumeric(textBoxY.Text.Trim()))
            {
                MessageBox.Show("The Y must be numeric", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //
            // Check if X and Y are inside of the pictuebox dimensions
            //
            if (float.Parse(textBoxX.Text) > pictureBox1.Width || float.Parse(textBoxY.Text) > pictureBox1.Height)
            {
                MessageBox.Show("The coordnates are outside of the valid region", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create Vertex
            Vertex tmp = dj.CreateVertex(textBoxlabel.Text, float.Parse(textBoxX.Text), float.Parse(textBoxY.Text));

            // Add to the combobox
            comboBoxOrigin.Items.Add(tmp);
            comboBoxDestination.Items.Add(tmp);

            // Clear the fields for the next entering
            textBoxlabel.Text = "";
            textBoxX.Text = "";
            textBoxY.Text = "";
            textBoxlabel.Focus();

        }

        //
        // Add a connection between two Vertices
        //
        private void buttonAddConn_Click(object sender, EventArgs e)
        {

            //
            // Check if origin is empty
            //
            if (comboBoxOrigin.SelectedIndex == -1)
            {
                MessageBox.Show("You must select one origin point", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //
            // Check if destination is empty
            //
            if (comboBoxDestination.SelectedIndex == -1)
            {
                MessageBox.Show("You must select one destination point", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //
            // Check if cost is numeric
            //
            if (textBoxCost.Text.Trim() != "" && !IsNumeric(textBoxCost.Text.Trim()))
            {
                MessageBox.Show("The Cos must be numeric", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxOrigin.SelectedIndex == comboBoxDestination.SelectedIndex)
            {
                MessageBox.Show("You must select different Vertices", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            // get origin Vertex
            Vertex origin = (Vertex)comboBoxOrigin.Items[comboBoxOrigin.SelectedIndex];
            // get destination Vertex
            Vertex destination = (Vertex)comboBoxOrigin.Items[comboBoxDestination.SelectedIndex];

            // Verify if connection already exists
            if(dj.Connected(origin, destination))
            {
                MessageBox.Show("Connection already exists", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // cost default is 1
            float cost = 1; 
            // if the user fullfill get the value
            if((textBoxCost.Text.Trim() != ""))
                cost = float.Parse(textBoxCost.Text);

            // Create the connection
            float distance = float.Parse(textBoxDistance.Text);

            Edge e1 = dj.CreateEdge(origin, destination, cost, distance);

            // Refresh the panel
            pictureBox1.Invalidate();
            dj.PrintVertices(this.pictureBox1);
            
        }

        // Always re-paint the points
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            dj.PrintVertices(this.pictureBox1);

        }

        //
        //
        // Save Vertices
        private void buttonSave_Click(object sender, EventArgs e)
        {
            dj.SaveVertices("Vertices.txt");
            MessageBox.Show("Vertices and Connections have been saved sucessfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //
        //
        // Load Vertices from file
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            // Clear everything before
            clear();
            pictureBox1.Invalidate();
            try
            {
                dj.LoadVertices("Vertices.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Vertices and Connections have been loaded sucessfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Add the Vertices to the combox
    	        int size = dj.Vertices.Count;
                for (int i = 0; i < size; ++i)
                {
                    comboBoxOrigin.Items.Add(dj.Vertices[i]);
                    comboBoxDestination.Items.Add(dj.Vertices[i]);
                }

            }

        }

        //
        //
        // Calculate the path
        private void buttonShortestPath_Click(object sender, EventArgs e)
        {

            //
            // Verify minimum number of Vertices
            //
            if (dj.Vertices.Count < 2)
            {
                MessageBox.Show("You must have at least two Vertices", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //
            // Verify minimum number of connections
            //
            if (dj.edges.Count < 1)
            {
                MessageBox.Show("You must have at least one connection", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //
            // Check if origin and destinations were selected
            //
            if (comboBoxOrigin.SelectedIndex == -1)
            {
                MessageBox.Show("You must select one origin point", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxDestination.SelectedIndex == -1)
            {
                MessageBox.Show("You must select one destination point", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // clear report
            textBoxreport.Text = "";

            // Get Vertices
            Vertex origin = (Vertex)comboBoxOrigin.Items[comboBoxOrigin.SelectedIndex];
            Vertex destination = (Vertex)comboBoxOrigin.Items[comboBoxDestination.SelectedIndex];

            // Calculate and print
            origin.distanceFromStart = 0;
            dj.Execute();
            textBoxreport.Text = dj.PrintShortestRouteTo(destination, this.pictureBox1);

            // Leave ready to next calculation
            dj.Renew();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Clear everything
        void clear()
        {
            dj.Dispose();
            dj = null;
            dj = new Dijkstra();
            comboBoxDestination.Items.Clear();
            comboBoxOrigin.Items.Clear();
            comboBoxDestination.Text = "";
            comboBoxOrigin.Text = "";
            textBoxreport.Text = "";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear();
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxX.Text = e.X.ToString();
            textBoxY.Text = e.Y.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelConnection_Click(object sender, EventArgs e)
        {
            //
            // Check if origin is empty
            //
            if (comboBoxOrigin.SelectedIndex == -1)
            {
                MessageBox.Show("You must select one origin point", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //
            // Check if destination is empty
            //
            if (comboBoxDestination.SelectedIndex == -1)
            {
                MessageBox.Show("You must select one destination point", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxOrigin.SelectedIndex == comboBoxDestination.SelectedIndex)
            {
                MessageBox.Show("You must select different Vertices", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // get origin Vertex
            Vertex origin = (Vertex)comboBoxOrigin.Items[comboBoxOrigin.SelectedIndex];
            // get destination Vertex
            Vertex destination = (Vertex)comboBoxOrigin.Items[comboBoxDestination.SelectedIndex];

            // Verify if connection already exists
            if (!dj.Connected(origin, destination))
            {
                MessageBox.Show("There is not connection between these Vertices", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Delete the connection
            dj.DeleteEdge(origin, destination);

            // Refresh the panel
            pictureBox1.Invalidate();
            dj.PrintVertices(this.pictureBox1);

        }

        private void comboBoxOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxOrigin.SelectedIndex != -1 && comboBoxDestination.SelectedIndex != -1)
            {
                // get origin Vertex
                Vertex origin = (Vertex)comboBoxOrigin.Items[comboBoxOrigin.SelectedIndex];
                // get destination Vertex
                Vertex target = (Vertex)comboBoxOrigin.Items[comboBoxDestination.SelectedIndex];
                // Calculate the distance between two points
                // sqrt( (x2-x1)^2 + (y2-y1)^2)
                float distance = (float)Math.Sqrt((double)(Math.Pow(target.x - origin.x, 2) + Math.Pow(target.y - origin.y, 2)));
                textBoxDistance.Text = distance.ToString();

            }

        }

        private void comboBoxDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrigin.SelectedIndex != -1 && comboBoxDestination.SelectedIndex != -1)
            {
                // get origin Vertex
                Vertex origin = (Vertex)comboBoxOrigin.Items[comboBoxOrigin.SelectedIndex];
                // get destination Vertex
                Vertex target = (Vertex)comboBoxOrigin.Items[comboBoxDestination.SelectedIndex];
                // Calculate the distance between two points
                // sqrt( (x2-x1)^2 + (y2-y1)^2)
                float distance = (float)Math.Sqrt((double)(Math.Pow(target.x - origin.x, 2) + Math.Pow(target.y - origin.y, 2)));
                textBoxDistance.Text = distance.ToString();

            }

        }

        private void buttonDelVertex_Click(object sender, EventArgs e)
        {
            if (comboBoxOrigin.SelectedIndex != -1)
            {
                // get origin Vertex
                Vertex origin = (Vertex)comboBoxOrigin.Items[comboBoxOrigin.SelectedIndex];
                dj.DeleteVertex(origin);
                comboBoxOrigin.Items.RemoveAt(comboBoxOrigin.SelectedIndex);
                // Refresh the panel
                pictureBox1.Invalidate();
                dj.PrintVertices(this.pictureBox1);
            }
            else
                MessageBox.Show("There is not connection between these Vertices", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

    }

}
