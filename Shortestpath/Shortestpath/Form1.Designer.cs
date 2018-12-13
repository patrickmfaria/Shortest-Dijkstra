namespace Shortestpath
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxlabel = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxOrigin = new System.Windows.Forms.ComboBox();
            this.comboBoxDestination = new System.Windows.Forms.ComboBox();
            this.buttonAddConn = new System.Windows.Forms.Button();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonShortestPath = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxreport = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelcoord = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonDelConnection = new System.Windows.Forms.Button();
            this.buttonDelVertex = new System.Windows.Forms.Button();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(834, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(887, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(834, 42);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(43, 20);
            this.textBoxX.TabIndex = 1;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(890, 42);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(43, 20);
            this.textBoxY.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(752, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Label";
            // 
            // textBoxlabel
            // 
            this.textBoxlabel.Location = new System.Drawing.Point(752, 42);
            this.textBoxlabel.Name = "textBoxlabel";
            this.textBoxlabel.Size = new System.Drawing.Size(65, 20);
            this.textBoxlabel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Location = new System.Drawing.Point(950, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add Vertex";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxOrigin
            // 
            this.comboBoxOrigin.FormattingEnabled = true;
            this.comboBoxOrigin.Location = new System.Drawing.Point(750, 115);
            this.comboBoxOrigin.Name = "comboBoxOrigin";
            this.comboBoxOrigin.Size = new System.Drawing.Size(183, 21);
            this.comboBoxOrigin.TabIndex = 4;
            this.comboBoxOrigin.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrigin_SelectedIndexChanged);
            // 
            // comboBoxDestination
            // 
            this.comboBoxDestination.FormattingEnabled = true;
            this.comboBoxDestination.Location = new System.Drawing.Point(750, 158);
            this.comboBoxDestination.Name = "comboBoxDestination";
            this.comboBoxDestination.Size = new System.Drawing.Size(183, 21);
            this.comboBoxDestination.TabIndex = 5;
            this.comboBoxDestination.SelectedIndexChanged += new System.EventHandler(this.comboBoxDestination_SelectedIndexChanged);
            // 
            // buttonAddConn
            // 
            this.buttonAddConn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonAddConn.Location = new System.Drawing.Point(950, 156);
            this.buttonAddConn.Name = "buttonAddConn";
            this.buttonAddConn.Size = new System.Drawing.Size(104, 23);
            this.buttonAddConn.TabIndex = 7;
            this.buttonAddConn.Text = "Add Connection";
            this.buttonAddConn.UseVisualStyleBackColor = false;
            this.buttonAddConn.Click += new System.EventHandler(this.buttonAddConn_Click);
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(837, 202);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.Size = new System.Drawing.Size(43, 20);
            this.textBoxCost.TabIndex = 6;
            this.textBoxCost.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(835, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Cost";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FloralWhite;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(729, 509);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.MistyRose;
            this.buttonSave.Location = new System.Drawing.Point(948, 481);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(104, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(747, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Origin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(747, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Destination";
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.MistyRose;
            this.buttonLoad.Location = new System.Drawing.Point(838, 481);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(104, 23);
            this.buttonLoad.TabIndex = 17;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonShortestPath
            // 
            this.buttonShortestPath.BackColor = System.Drawing.Color.NavajoWhite;
            this.buttonShortestPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShortestPath.Location = new System.Drawing.Point(750, 242);
            this.buttonShortestPath.Name = "buttonShortestPath";
            this.buttonShortestPath.Size = new System.Drawing.Size(304, 23);
            this.buttonShortestPath.TabIndex = 18;
            this.buttonShortestPath.Text = "Find Shortest Path";
            this.buttonShortestPath.UseVisualStyleBackColor = false;
            this.buttonShortestPath.Click += new System.EventHandler(this.buttonShortestPath_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(838, 511);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(104, 23);
            this.buttonClear.TabIndex = 19;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(948, 511);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(104, 23);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxreport
            // 
            this.textBoxreport.Location = new System.Drawing.Point(752, 292);
            this.textBoxreport.Multiline = true;
            this.textBoxreport.Name = "textBoxreport";
            this.textBoxreport.Size = new System.Drawing.Size(302, 183);
            this.textBoxreport.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "0,0";
            // 
            // labelcoord
            // 
            this.labelcoord.AutoSize = true;
            this.labelcoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelcoord.ForeColor = System.Drawing.Color.Red;
            this.labelcoord.Location = new System.Drawing.Point(716, 538);
            this.labelcoord.Name = "labelcoord";
            this.labelcoord.Size = new System.Drawing.Size(25, 13);
            this.labelcoord.TabIndex = 23;
            this.labelcoord.Text = "0,0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(752, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Report:";
            // 
            // buttonDelConnection
            // 
            this.buttonDelConnection.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonDelConnection.Location = new System.Drawing.Point(950, 199);
            this.buttonDelConnection.Name = "buttonDelConnection";
            this.buttonDelConnection.Size = new System.Drawing.Size(104, 23);
            this.buttonDelConnection.TabIndex = 25;
            this.buttonDelConnection.Text = "Del Connection";
            this.buttonDelConnection.UseVisualStyleBackColor = false;
            this.buttonDelConnection.Click += new System.EventHandler(this.buttonDelConnection_Click);
            // 
            // buttonDelVertex
            // 
            this.buttonDelVertex.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonDelVertex.Location = new System.Drawing.Point(950, 113);
            this.buttonDelVertex.Name = "buttonDelVertex";
            this.buttonDelVertex.Size = new System.Drawing.Size(104, 23);
            this.buttonDelVertex.TabIndex = 26;
            this.buttonDelVertex.Text = "Del Vertex";
            this.buttonDelVertex.UseVisualStyleBackColor = false;
            this.buttonDelVertex.Click += new System.EventHandler(this.buttonDelVertex_Click);
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(750, 202);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(65, 20);
            this.textBoxDistance.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(747, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Distance";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 559);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.buttonDelVertex);
            this.Controls.Add(this.buttonDelConnection);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelcoord);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxreport);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonShortestPath);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAddConn);
            this.Controls.Add(this.comboBoxDestination);
            this.Controls.Add(this.comboBoxOrigin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxlabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Shortest Path";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxlabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxOrigin;
        private System.Windows.Forms.ComboBox comboBoxDestination;
        private System.Windows.Forms.Button buttonAddConn;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonShortestPath;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxreport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelcoord;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonDelConnection;
        private System.Windows.Forms.Button buttonDelVertex;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.Label label9;
    }
}

