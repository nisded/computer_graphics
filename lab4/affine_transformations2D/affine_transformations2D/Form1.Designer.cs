﻿namespace affine_transformations2D
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
            this.polygonRB = new System.Windows.Forms.RadioButton();
            this.clearBtn = new System.Windows.Forms.Button();
            this.segmentRB = new System.Windows.Forms.RadioButton();
            this.pointRB = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.biasBtn = new System.Windows.Forms.Button();
            this.biasYNumUD = new System.Windows.Forms.NumericUpDown();
            this.biasXNumUD = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.scaleAroundPointCB = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.scaleBtn = new System.Windows.Forms.Button();
            this.scaleYNumUD = new System.Windows.Forms.NumericUpDown();
            this.scaleXNumUD = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.intersectionPointLabel = new System.Windows.Forms.Label();
            this.posRelativeToPolygonLabel = new System.Windows.Forms.Label();
            this.posRelativeToSegmentLabel = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rotationAroundPointCB = new System.Windows.Forms.CheckBox();
            this.angle90Btn = new System.Windows.Forms.Button();
            this.rotationBtn = new System.Windows.Forms.Button();
            this.angleNumUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.biasYNumUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.biasXNumUD)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleYNumUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleXNumUD)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleNumUD)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(4, 132);
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
            this.groupBox1.Controls.Add(this.polygonRB);
            this.groupBox1.Controls.Add(this.clearBtn);
            this.groupBox1.Controls.Add(this.segmentRB);
            this.groupBox1.Controls.Add(this.pointRB);
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 126);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Примитив";
            // 
            // polygonRB
            // 
            this.polygonRB.AutoSize = true;
            this.polygonRB.Location = new System.Drawing.Point(6, 66);
            this.polygonRB.Name = "polygonRB";
            this.polygonRB.Size = new System.Drawing.Size(68, 17);
            this.polygonRB.TabIndex = 3;
            this.polygonRB.TabStop = true;
            this.polygonRB.Text = "Полигон";
            this.polygonRB.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(6, 87);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 33);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = "Очистить";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(122, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(91, 126);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Смещение";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "x";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.scaleAroundPointCB);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.scaleBtn);
            this.groupBox3.Controls.Add(this.scaleYNumUD);
            this.groupBox3.Controls.Add(this.scaleXNumUD);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(244, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 126);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Масштабирование(%)";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "y";
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.intersectionPointLabel);
            this.groupBox6.Controls.Add(this.posRelativeToPolygonLabel);
            this.groupBox6.Controls.Add(this.posRelativeToSegmentLabel);
            this.groupBox6.Location = new System.Drawing.Point(602, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(195, 126);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            // 
            // intersectionPointLabel
            // 
            this.intersectionPointLabel.AutoSize = true;
            this.intersectionPointLabel.Location = new System.Drawing.Point(6, 16);
            this.intersectionPointLabel.Name = "intersectionPointLabel";
            this.intersectionPointLabel.Size = new System.Drawing.Size(105, 13);
            this.intersectionPointLabel.TabIndex = 9;
            this.intersectionPointLabel.Text = "Точка пересечения";
            // 
            // posRelativeToPolygonLabel
            // 
            this.posRelativeToPolygonLabel.AutoSize = true;
            this.posRelativeToPolygonLabel.Location = new System.Drawing.Point(6, 89);
            this.posRelativeToPolygonLabel.Name = "posRelativeToPolygonLabel";
            this.posRelativeToPolygonLabel.Size = new System.Drawing.Size(174, 13);
            this.posRelativeToPolygonLabel.TabIndex = 24;
            this.posRelativeToPolygonLabel.Text = "Принадлежность точки полигону";
            // 
            // posRelativeToSegmentLabel
            // 
            this.posRelativeToSegmentLabel.AutoSize = true;
            this.posRelativeToSegmentLabel.Location = new System.Drawing.Point(6, 51);
            this.posRelativeToSegmentLabel.Name = "posRelativeToSegmentLabel";
            this.posRelativeToSegmentLabel.Size = new System.Drawing.Size(164, 13);
            this.posRelativeToSegmentLabel.TabIndex = 29;
            this.posRelativeToSegmentLabel.Text = "Положение точки отн-но ребра";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rotationAroundPointCB);
            this.groupBox5.Controls.Add(this.angle90Btn);
            this.groupBox5.Controls.Add(this.rotationBtn);
            this.groupBox5.Controls.Add(this.angleNumUD);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(419, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(149, 126);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Поворот";
            // 
            // rotationAroundPointCB
            // 
            this.rotationAroundPointCB.AutoSize = true;
            this.rotationAroundPointCB.Location = new System.Drawing.Point(24, 56);
            this.rotationAroundPointCB.Name = "rotationAroundPointCB";
            this.rotationAroundPointCB.Size = new System.Drawing.Size(92, 17);
            this.rotationAroundPointCB.TabIndex = 6;
            this.rotationAroundPointCB.Text = "Вокруг точки";
            this.rotationAroundPointCB.UseVisualStyleBackColor = true;
            // 
            // angle90Btn
            // 
            this.angle90Btn.Location = new System.Drawing.Point(105, 21);
            this.angle90Btn.Name = "angle90Btn";
            this.angle90Btn.Size = new System.Drawing.Size(31, 23);
            this.angle90Btn.TabIndex = 1;
            this.angle90Btn.Text = "90";
            this.angle90Btn.UseVisualStyleBackColor = true;
            this.angle90Btn.Click += new System.EventHandler(this.Angle90_Click);
            // 
            // rotationBtn
            // 
            this.rotationBtn.Location = new System.Drawing.Point(24, 86);
            this.rotationBtn.Name = "rotationBtn";
            this.rotationBtn.Size = new System.Drawing.Size(100, 34);
            this.rotationBtn.TabIndex = 5;
            this.rotationBtn.Text = "Применить";
            this.rotationBtn.UseVisualStyleBackColor = true;
            this.rotationBtn.Click += new System.EventHandler(this.RotationBtn_Click);
            // 
            // angleNumUD
            // 
            this.angleNumUD.Location = new System.Drawing.Point(44, 23);
            this.angleNumUD.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.angleNumUD.Name = "angleNumUD";
            this.angleNumUD.Size = new System.Drawing.Size(49, 20);
            this.angleNumUD.TabIndex = 0;
            this.angleNumUD.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Угол";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
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
            ((System.ComponentModel.ISupportInitialize)(this.biasYNumUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.biasXNumUD)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleYNumUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleXNumUD)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleNumUD)).EndInit();
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
        private System.Windows.Forms.NumericUpDown scaleXNumUD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button biasBtn;
        private System.Windows.Forms.Button scaleBtn;
        private System.Windows.Forms.CheckBox scaleAroundPointCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label posRelativeToPolygonLabel;
        private System.Windows.Forms.Label posRelativeToSegmentLabel;
        private System.Windows.Forms.Label intersectionPointLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox rotationAroundPointCB;
        private System.Windows.Forms.Button angle90Btn;
        private System.Windows.Forms.Button rotationBtn;
        private System.Windows.Forms.NumericUpDown angleNumUD;
        private System.Windows.Forms.Label label1;
    }
}

