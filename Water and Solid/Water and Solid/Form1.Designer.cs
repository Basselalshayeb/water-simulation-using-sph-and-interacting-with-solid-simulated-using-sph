namespace Water_and_Solid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.Reset_btn = new System.Windows.Forms.Button();
            this.NewPar_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Push_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Inc_btn = new System.Windows.Forms.Button();
            this.Dic_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.Cube_btn = new System.Windows.Forms.Button();
            this.Surface_Ten = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Cameras = new System.Windows.Forms.GroupBox();
            this.radioCam2 = new System.Windows.Forms.RadioButton();
            this.radioCam1 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.Cameras.SuspendLayout();
            this.SuspendLayout();
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Black;
            this.simpleOpenGlControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("simpleOpenGlControl1.BackgroundImage")));
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(12, 12);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(471, 395);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint_1);
            this.simpleOpenGlControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simpleOpenGlControl1_KeyDown);
            // 
            // Reset_btn
            // 
            this.Reset_btn.Location = new System.Drawing.Point(157, 47);
            this.Reset_btn.Name = "Reset_btn";
            this.Reset_btn.Size = new System.Drawing.Size(108, 23);
            this.Reset_btn.TabIndex = 1;
            this.Reset_btn.Text = "Reset";
            this.Reset_btn.UseVisualStyleBackColor = true;
            this.Reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // NewPar_btn
            // 
            this.NewPar_btn.Location = new System.Drawing.Point(12, 45);
            this.NewPar_btn.Name = "NewPar_btn";
            this.NewPar_btn.Size = new System.Drawing.Size(110, 23);
            this.NewPar_btn.TabIndex = 2;
            this.NewPar_btn.Text = "Add New Particile";
            this.NewPar_btn.UseVisualStyleBackColor = true;
            this.NewPar_btn.Click += new System.EventHandler(this.NewPar_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Felix Titling", 7.7F);
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "number of particiles";
            // 
            // Push_btn
            // 
            this.Push_btn.Location = new System.Drawing.Point(202, 14);
            this.Push_btn.Name = "Push_btn";
            this.Push_btn.Size = new System.Drawing.Size(63, 23);
            this.Push_btn.TabIndex = 6;
            this.Push_btn.Text = "Push";
            this.Push_btn.UseVisualStyleBackColor = true;
            this.Push_btn.Click += new System.EventHandler(this.Push_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(144, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 23);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(87, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(55, 23);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Felix Titling", 10F);
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Row0 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Felix Titling", 10F);
            this.label3.Location = new System.Drawing.Point(11, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "meo :";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(87, 62);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(55, 23);
            this.textBox3.TabIndex = 11;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(210, 25);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(55, 23);
            this.textBox4.TabIndex = 12;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 10F);
            this.label4.Location = new System.Drawing.Point(166, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "K :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Inc_btn
            // 
            this.Inc_btn.Font = new System.Drawing.Font("Segoe Print", 8F);
            this.Inc_btn.Location = new System.Drawing.Point(6, 19);
            this.Inc_btn.Name = "Inc_btn";
            this.Inc_btn.Size = new System.Drawing.Size(75, 45);
            this.Inc_btn.TabIndex = 14;
            this.Inc_btn.Text = "Faster";
            this.Inc_btn.UseVisualStyleBackColor = true;
            this.Inc_btn.Click += new System.EventHandler(this.Inc_btn_Click);
            // 
            // Dic_btn
            // 
            this.Dic_btn.Font = new System.Drawing.Font("Segoe Print", 8F);
            this.Dic_btn.Location = new System.Drawing.Point(96, 19);
            this.Dic_btn.Name = "Dic_btn";
            this.Dic_btn.Size = new System.Drawing.Size(75, 45);
            this.Dic_btn.TabIndex = 15;
            this.Dic_btn.Text = "Slower";
            this.Dic_btn.UseVisualStyleBackColor = true;
            this.Dic_btn.Click += new System.EventHandler(this.Dic_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 10F);
            this.label5.Location = new System.Drawing.Point(166, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "h :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(210, 62);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(55, 23);
            this.textBox5.TabIndex = 17;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // Cube_btn
            // 
            this.Cube_btn.Location = new System.Drawing.Point(127, 63);
            this.Cube_btn.Name = "Cube_btn";
            this.Cube_btn.Size = new System.Drawing.Size(105, 23);
            this.Cube_btn.TabIndex = 18;
            this.Cube_btn.Text = "Add Cube";
            this.Cube_btn.UseVisualStyleBackColor = true;
            this.Cube_btn.Click += new System.EventHandler(this.Cube_btn_Click);
            // 
            // Surface_Ten
            // 
            this.Surface_Ten.AutoSize = true;
            this.Surface_Ten.Font = new System.Drawing.Font("Felix Titling", 8F);
            this.Surface_Ten.Location = new System.Drawing.Point(14, 101);
            this.Surface_Ten.Name = "Surface_Ten";
            this.Surface_Ten.Size = new System.Drawing.Size(127, 17);
            this.Surface_Ten.TabIndex = 19;
            this.Surface_Ten.Text = "Surface Tension";
            this.Surface_Ten.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.Surface_Ten);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Font = new System.Drawing.Font("Felix Titling", 10F);
            this.groupBox1.Location = new System.Drawing.Point(498, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 130);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Particile Parameters";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(210, 101);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(55, 23);
            this.textBox6.TabIndex = 19;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 10F);
            this.label6.Location = new System.Drawing.Point(153, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 24);
            this.label6.TabIndex = 18;
            this.label6.Text = "Mass :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.Push_btn);
            this.groupBox2.Controls.Add(this.NewPar_btn);
            this.groupBox2.Controls.Add(this.Reset_btn);
            this.groupBox2.Font = new System.Drawing.Font("Felix Titling", 10F);
            this.groupBox2.Location = new System.Drawing.Point(498, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 74);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reset Or Add New";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Inc_btn);
            this.groupBox3.Controls.Add(this.Dic_btn);
            this.groupBox3.Font = new System.Drawing.Font("Felix Titling", 10F);
            this.groupBox3.Location = new System.Drawing.Point(498, 229);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 80);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time Scaling";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.textBox7);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.Cube_btn);
            this.groupBox4.Font = new System.Drawing.Font("Felix Titling", 10F);
            this.groupBox4.Location = new System.Drawing.Point(498, 315);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 92);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Solid";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(76, 22);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(55, 23);
            this.textBox7.TabIndex = 20;
            this.textBox7.Visible = false;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mass :";
            this.label7.Visible = false;
            // 
            // Cameras
            // 
            this.Cameras.Controls.Add(this.radioCam2);
            this.Cameras.Controls.Add(this.radioCam1);
            this.Cameras.Location = new System.Drawing.Point(708, 229);
            this.Cameras.Name = "Cameras";
            this.Cameras.Size = new System.Drawing.Size(93, 80);
            this.Cameras.TabIndex = 25;
            this.Cameras.TabStop = false;
            this.Cameras.Text = "Cameras";
            this.Cameras.Enter += new System.EventHandler(this.Cameras_Enter);
            // 
            // radioCam2
            // 
            this.radioCam2.AutoSize = true;
            this.radioCam2.Font = new System.Drawing.Font("Felix Titling", 9F);
            this.radioCam2.Location = new System.Drawing.Point(6, 46);
            this.radioCam2.Name = "radioCam2";
            this.radioCam2.Size = new System.Drawing.Size(88, 18);
            this.radioCam2.TabIndex = 1;
            this.radioCam2.Text = "Camera 2";
            this.radioCam2.UseVisualStyleBackColor = true;
            // 
            // radioCam1
            // 
            this.radioCam1.AutoSize = true;
            this.radioCam1.Checked = true;
            this.radioCam1.Font = new System.Drawing.Font("Felix Titling", 9F);
            this.radioCam1.Location = new System.Drawing.Point(6, 19);
            this.radioCam1.Name = "radioCam1";
            this.radioCam1.Size = new System.Drawing.Size(84, 18);
            this.radioCam1.TabIndex = 0;
            this.radioCam1.TabStop = true;
            this.radioCam1.Text = "Camera 1";
            this.radioCam1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 20);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "light";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(76, 25);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 20);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Medium";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(160, 25);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(72, 20);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Heavy";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 419);
            this.Controls.Add(this.Cameras);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.Cameras.ResumeLayout(false);
            this.Cameras.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.Button Reset_btn;
        private System.Windows.Forms.Button NewPar_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Push_btn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Inc_btn;
        private System.Windows.Forms.Button Dic_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button Cube_btn;
        private System.Windows.Forms.CheckBox Surface_Ten;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox Cameras;
        private System.Windows.Forms.RadioButton radioCam2;
        private System.Windows.Forms.RadioButton radioCam1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

