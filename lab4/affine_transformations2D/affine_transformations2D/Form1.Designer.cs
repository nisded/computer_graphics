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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Affine transformations";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton polygonRB;
        private System.Windows.Forms.RadioButton segmentRB;
        private System.Windows.Forms.RadioButton pointRB;
        private System.Windows.Forms.Button clearBtn;
    }
}

