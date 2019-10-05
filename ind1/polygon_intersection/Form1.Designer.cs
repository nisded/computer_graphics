namespace polygon_intersection
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
            this.intersectBtn = new System.Windows.Forms.Button();
            this.polygon2RB = new System.Windows.Forms.RadioButton();
            this.polygon1RB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 410);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // intersectBtn
            // 
            this.intersectBtn.Location = new System.Drawing.Point(661, -1);
            this.intersectBtn.Name = "intersectBtn";
            this.intersectBtn.Size = new System.Drawing.Size(127, 29);
            this.intersectBtn.TabIndex = 1;
            this.intersectBtn.Text = "Найти пересечение";
            this.intersectBtn.UseVisualStyleBackColor = true;
            // 
            // polygon2RB
            // 
            this.polygon2RB.AutoSize = true;
            this.polygon2RB.Location = new System.Drawing.Point(527, 5);
            this.polygon2RB.Name = "polygon2RB";
            this.polygon2RB.Size = new System.Drawing.Size(74, 17);
            this.polygon2RB.TabIndex = 2;
            this.polygon2RB.TabStop = true;
            this.polygon2RB.Text = "Полигон2";
            this.polygon2RB.UseVisualStyleBackColor = true;
            this.polygon2RB.CheckedChanged += new System.EventHandler(this.Polygon2RB_CheckedChanged);
            // 
            // polygon1RB
            // 
            this.polygon1RB.AutoSize = true;
            this.polygon1RB.Checked = true;
            this.polygon1RB.Location = new System.Drawing.Point(417, 5);
            this.polygon1RB.Name = "polygon1RB";
            this.polygon1RB.Size = new System.Drawing.Size(74, 17);
            this.polygon1RB.TabIndex = 2;
            this.polygon1RB.TabStop = true;
            this.polygon1RB.Text = "Полигон1";
            this.polygon1RB.UseVisualStyleBackColor = true;
            this.polygon1RB.CheckedChanged += new System.EventHandler(this.Polygon1RB_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.polygon1RB);
            this.Controls.Add(this.polygon2RB);
            this.Controls.Add(this.intersectBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Polygon intersection";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button intersectBtn;
        private System.Windows.Forms.RadioButton polygon2RB;
        private System.Windows.Forms.RadioButton polygon1RB;
        private System.Windows.Forms.Label label1;
    }
}

