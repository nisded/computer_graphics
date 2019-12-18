namespace RayTracing
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
            this.button1 = new System.Windows.Forms.Button();
            this.cubeSpecularCB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sphereSpecularCB = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.refractSphereCB = new System.Windows.Forms.CheckBox();
            this.refractCubeCB = new System.Windows.Forms.CheckBox();
            this.twoLightsCB = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.downWallSpecularCB = new System.Windows.Forms.CheckBox();
            this.upWallSpecularCB = new System.Windows.Forms.CheckBox();
            this.rightWallSpecularCB = new System.Windows.Forms.CheckBox();
            this.leftWallSpecularCB = new System.Windows.Forms.CheckBox();
            this.backWallSpecularCB = new System.Windows.Forms.CheckBox();
            this.frontWallSpecularCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 564);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(665, 405);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ray Trace";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cubeSpecularCB
            // 
            this.cubeSpecularCB.AutoSize = true;
            this.cubeSpecularCB.Location = new System.Drawing.Point(6, 19);
            this.cubeSpecularCB.Name = "cubeSpecularCB";
            this.cubeSpecularCB.Size = new System.Drawing.Size(44, 17);
            this.cubeSpecularCB.TabIndex = 2;
            this.cubeSpecularCB.Text = "Куб";
            this.cubeSpecularCB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sphereSpecularCB);
            this.groupBox1.Controls.Add(this.cubeSpecularCB);
            this.groupBox1.Location = new System.Drawing.Point(664, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 79);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Зеркальность";
            // 
            // sphereSpecularCB
            // 
            this.sphereSpecularCB.AutoSize = true;
            this.sphereSpecularCB.Location = new System.Drawing.Point(6, 42);
            this.sphereSpecularCB.Name = "sphereSpecularCB";
            this.sphereSpecularCB.Size = new System.Drawing.Size(47, 17);
            this.sphereSpecularCB.TabIndex = 2;
            this.sphereSpecularCB.Text = "Шар";
            this.sphereSpecularCB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.refractSphereCB);
            this.groupBox2.Controls.Add(this.refractCubeCB);
            this.groupBox2.Location = new System.Drawing.Point(664, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(94, 79);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Прозрачность";
            // 
            // refractSphereCB
            // 
            this.refractSphereCB.AutoSize = true;
            this.refractSphereCB.Location = new System.Drawing.Point(6, 42);
            this.refractSphereCB.Name = "refractSphereCB";
            this.refractSphereCB.Size = new System.Drawing.Size(47, 17);
            this.refractSphereCB.TabIndex = 2;
            this.refractSphereCB.Text = "Шар";
            this.refractSphereCB.UseVisualStyleBackColor = true;
            // 
            // refractCubeCB
            // 
            this.refractCubeCB.AutoSize = true;
            this.refractCubeCB.Location = new System.Drawing.Point(6, 19);
            this.refractCubeCB.Name = "refractCubeCB";
            this.refractCubeCB.Size = new System.Drawing.Size(44, 17);
            this.refractCubeCB.TabIndex = 2;
            this.refractCubeCB.Text = "Куб";
            this.refractCubeCB.UseVisualStyleBackColor = true;
            // 
            // twoLightsCB
            // 
            this.twoLightsCB.AutoSize = true;
            this.twoLightsCB.Location = new System.Drawing.Point(670, 369);
            this.twoLightsCB.Name = "twoLightsCB";
            this.twoLightsCB.Size = new System.Drawing.Size(87, 17);
            this.twoLightsCB.TabIndex = 4;
            this.twoLightsCB.Text = "2 источника";
            this.twoLightsCB.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.downWallSpecularCB);
            this.groupBox3.Controls.Add(this.upWallSpecularCB);
            this.groupBox3.Controls.Add(this.rightWallSpecularCB);
            this.groupBox3.Controls.Add(this.leftWallSpecularCB);
            this.groupBox3.Controls.Add(this.backWallSpecularCB);
            this.groupBox3.Controls.Add(this.frontWallSpecularCB);
            this.groupBox3.Location = new System.Drawing.Point(664, 182);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(94, 168);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Зеркальность стен";
            // 
            // downWallSpecularCB
            // 
            this.downWallSpecularCB.AutoSize = true;
            this.downWallSpecularCB.Location = new System.Drawing.Point(6, 145);
            this.downWallSpecularCB.Name = "downWallSpecularCB";
            this.downWallSpecularCB.Size = new System.Drawing.Size(66, 17);
            this.downWallSpecularCB.TabIndex = 0;
            this.downWallSpecularCB.Text = "Нижняя";
            this.downWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // upWallSpecularCB
            // 
            this.upWallSpecularCB.AutoSize = true;
            this.upWallSpecularCB.Location = new System.Drawing.Point(6, 122);
            this.upWallSpecularCB.Name = "upWallSpecularCB";
            this.upWallSpecularCB.Size = new System.Drawing.Size(68, 17);
            this.upWallSpecularCB.TabIndex = 0;
            this.upWallSpecularCB.Text = "Верхняя";
            this.upWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // rightWallSpecularCB
            // 
            this.rightWallSpecularCB.AutoSize = true;
            this.rightWallSpecularCB.Location = new System.Drawing.Point(6, 99);
            this.rightWallSpecularCB.Name = "rightWallSpecularCB";
            this.rightWallSpecularCB.Size = new System.Drawing.Size(64, 17);
            this.rightWallSpecularCB.TabIndex = 0;
            this.rightWallSpecularCB.Text = "Правая";
            this.rightWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // leftWallSpecularCB
            // 
            this.leftWallSpecularCB.AutoSize = true;
            this.leftWallSpecularCB.Location = new System.Drawing.Point(6, 76);
            this.leftWallSpecularCB.Name = "leftWallSpecularCB";
            this.leftWallSpecularCB.Size = new System.Drawing.Size(58, 17);
            this.leftWallSpecularCB.TabIndex = 0;
            this.leftWallSpecularCB.Text = "Левая";
            this.leftWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // backWallSpecularCB
            // 
            this.backWallSpecularCB.AutoSize = true;
            this.backWallSpecularCB.Location = new System.Drawing.Point(6, 53);
            this.backWallSpecularCB.Name = "backWallSpecularCB";
            this.backWallSpecularCB.Size = new System.Drawing.Size(63, 17);
            this.backWallSpecularCB.TabIndex = 0;
            this.backWallSpecularCB.Text = "Задняя";
            this.backWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // frontWallSpecularCB
            // 
            this.frontWallSpecularCB.AutoSize = true;
            this.frontWallSpecularCB.Location = new System.Drawing.Point(6, 30);
            this.frontWallSpecularCB.Name = "frontWallSpecularCB";
            this.frontWallSpecularCB.Size = new System.Drawing.Size(76, 17);
            this.frontWallSpecularCB.TabIndex = 0;
            this.frontWallSpecularCB.Text = "Передняя";
            this.frontWallSpecularCB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(770, 585);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.twoLightsCB);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Ray Tracing";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cubeSpecularCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox sphereSpecularCB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox refractSphereCB;
        private System.Windows.Forms.CheckBox refractCubeCB;
        private System.Windows.Forms.CheckBox twoLightsCB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox frontWallSpecularCB;
        private System.Windows.Forms.CheckBox rightWallSpecularCB;
        private System.Windows.Forms.CheckBox leftWallSpecularCB;
        private System.Windows.Forms.CheckBox backWallSpecularCB;
        private System.Windows.Forms.CheckBox downWallSpecularCB;
        private System.Windows.Forms.CheckBox upWallSpecularCB;
    }
}

