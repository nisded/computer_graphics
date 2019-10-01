namespace affine_transformations2D
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.polygonRB = new System.Windows.Forms.RadioButton();
            this.segmentRB = new System.Windows.Forms.RadioButton();
            this.pointRB = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.biasXNumUD = new System.Windows.Forms.NumericUpDown();
            this.biasYNumUD = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.scaleXNumUD = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.scaleYNumUD = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.biasBtn = new System.Windows.Forms.Button();
            this.scaleBtn = new System.Windows.Forms.Button();
            this.scaleAroundPointCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.biasXNumUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.biasYNumUD)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleXNumUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleYNumUD)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(4, 131);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(793, 335);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearBtn);
            this.groupBox1.Controls.Add(this.polygonRB);
            this.groupBox1.Controls.Add(this.segmentRB);
            this.groupBox1.Controls.Add(this.pointRB);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 125);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Примитив";
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(6, 86);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 33);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = "Очистить";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // polygonRB
            // 
            this.polygonRB.AutoSize = true;
            this.polygonRB.Location = new System.Drawing.Point(6, 65);
            this.polygonRB.Name = "polygonRB";
            this.polygonRB.Size = new System.Drawing.Size(68, 17);
            this.polygonRB.TabIndex = 3;
            this.polygonRB.TabStop = true;
            this.polygonRB.Text = "Полигон";
            this.polygonRB.UseVisualStyleBackColor = true;
            // 
            // segmentRB
            // 
            this.segmentRB.AutoSize = true;
            this.segmentRB.Location = new System.Drawing.Point(6, 42);
            this.segmentRB.Name = "segmentRB";
            this.segmentRB.Size = new System.Drawing.Size(68, 17);
            this.segmentRB.TabIndex = 3;
            this.segmentRB.TabStop = true;
            this.segmentRB.Text = "Отрезок";
            this.segmentRB.UseVisualStyleBackColor = true;
            // 
            // pointRB
            // 
            this.pointRB.AutoSize = true;
            this.pointRB.Location = new System.Drawing.Point(6, 19);
            this.pointRB.Name = "pointRB";
            this.pointRB.Size = new System.Drawing.Size(55, 17);
            this.pointRB.TabIndex = 3;
            this.pointRB.TabStop = true;
            this.pointRB.Text = "Точка";
            this.pointRB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.biasBtn);
            this.groupBox2.Controls.Add(this.biasYNumUD);
            this.groupBox2.Controls.Add(this.biasXNumUD);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(105, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 126);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Смещение";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "x";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "y";
            // 
            // biasXNumUD
            // 
            this.biasXNumUD.Location = new System.Drawing.Point(29, 21);
            this.biasXNumUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.biasXNumUD.Name = "biasXNumUD";
            this.biasXNumUD.Size = new System.Drawing.Size(46, 20);
            this.biasXNumUD.TabIndex = 2;
            this.biasXNumUD.ValueChanged += new System.EventHandler(this.BiasXNumUD_ValueChanged);
            // 
            // biasYNumUD
            // 
            this.biasYNumUD.Location = new System.Drawing.Point(29, 45);
            this.biasYNumUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.biasYNumUD.Name = "biasYNumUD";
            this.biasYNumUD.Size = new System.Drawing.Size(46, 20);
            this.biasYNumUD.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.scaleAroundPointCB);
            this.groupBox3.Controls.Add(this.scaleBtn);
            this.groupBox3.Controls.Add(this.scaleYNumUD);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.scaleXNumUD);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(202, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 125);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Масштабирование(%)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(77, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "y";
            // 
            // scaleXNumUD
            // 
            this.scaleXNumUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.scaleXNumUD.Location = new System.Drawing.Point(25, 23);
            this.scaleXNumUD.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.scaleXNumUD.Name = "scaleXNumUD";
            this.scaleXNumUD.Size = new System.Drawing.Size(46, 20);
            this.scaleXNumUD.TabIndex = 2;
            this.scaleXNumUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "x";
            // 
            // scaleYNumUD
            // 
            this.scaleYNumUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.scaleYNumUD.Location = new System.Drawing.Point(91, 23);
            this.scaleYNumUD.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.scaleYNumUD.Name = "scaleYNumUD";
            this.scaleYNumUD.Size = new System.Drawing.Size(46, 20);
            this.scaleYNumUD.TabIndex = 2;
            this.scaleYNumUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(476, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // biasBtn
            // 
            this.biasBtn.Location = new System.Drawing.Point(6, 86);
            this.biasBtn.Name = "biasBtn";
            this.biasBtn.Size = new System.Drawing.Size(79, 34);
            this.biasBtn.TabIndex = 5;
            this.biasBtn.Text = "Применить";
            this.biasBtn.UseVisualStyleBackColor = true;
            this.biasBtn.Click += new System.EventHandler(this.BiasBtn_Click);
            // 
            // scaleBtn
            // 
            this.scaleBtn.Location = new System.Drawing.Point(23, 84);
            this.scaleBtn.Name = "scaleBtn";
            this.scaleBtn.Size = new System.Drawing.Size(100, 34);
            this.scaleBtn.TabIndex = 5;
            this.scaleBtn.Text = "Применить";
            this.scaleBtn.UseVisualStyleBackColor = true;
            this.scaleBtn.Click += new System.EventHandler(this.ScaleBtn_Click);
            // 
            // scaleAroundPointCB
            // 
            this.scaleAroundPointCB.AutoSize = true;
            this.scaleAroundPointCB.Location = new System.Drawing.Point(25, 56);
            this.scaleAroundPointCB.Name = "scaleAroundPointCB";
            this.scaleAroundPointCB.Size = new System.Drawing.Size(92, 17);
            this.scaleAroundPointCB.TabIndex = 6;
            this.scaleAroundPointCB.Text = "Вокруг точки";
            this.scaleAroundPointCB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Affine transformations";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.biasXNumUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.biasYNumUD)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleXNumUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleYNumUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton polygonRB;
        private System.Windows.Forms.RadioButton segmentRB;
        private System.Windows.Forms.RadioButton pointRB;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown biasYNumUD;
        private System.Windows.Forms.NumericUpDown biasXNumUD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown scaleYNumUD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown scaleXNumUD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button biasBtn;
        private System.Windows.Forms.Button scaleBtn;
        private System.Windows.Forms.CheckBox scaleAroundPointCB;
    }
}

