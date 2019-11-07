namespace ComputerGraphics7
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
            this.PerspectiveBox = new System.Windows.Forms.PictureBox();
            this.PerspectiveLabel = new System.Windows.Forms.Label();
            this.ApplyPerspective = new System.Windows.Forms.Button();
            this.PerspectiveComboBox = new System.Windows.Forms.ComboBox();
            this.ApplyAffin = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.ApplyPrimitive = new System.Windows.Forms.Button();
            this.PrimitiveLabel = new System.Windows.Forms.Label();
            this.PrimitiveComboBox = new System.Windows.Forms.ComboBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown14 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown15 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown16 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown17 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown18 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PerspectiveBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown18)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PerspectiveBox
            // 
            this.PerspectiveBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PerspectiveBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PerspectiveBox.Location = new System.Drawing.Point(12, 7);
            this.PerspectiveBox.Name = "PerspectiveBox";
            this.PerspectiveBox.Size = new System.Drawing.Size(700, 425);
            this.PerspectiveBox.TabIndex = 1;
            this.PerspectiveBox.TabStop = false;
            // 
            // PerspectiveLabel
            // 
            this.PerspectiveLabel.AutoSize = true;
            this.PerspectiveLabel.Location = new System.Drawing.Point(12, 449);
            this.PerspectiveLabel.Name = "PerspectiveLabel";
            this.PerspectiveLabel.Size = new System.Drawing.Size(149, 19);
            this.PerspectiveLabel.TabIndex = 13;
            this.PerspectiveLabel.Text = "Выберите проекцию";
            // 
            // ApplyPerspective
            // 
            this.ApplyPerspective.Location = new System.Drawing.Point(208, 469);
            this.ApplyPerspective.Name = "ApplyPerspective";
            this.ApplyPerspective.Size = new System.Drawing.Size(190, 29);
            this.ApplyPerspective.TabIndex = 11;
            this.ApplyPerspective.Text = "Применить";
            this.ApplyPerspective.UseVisualStyleBackColor = true;
            this.ApplyPerspective.Click += new System.EventHandler(this.ApplyPerspective_Click);
            // 
            // PerspectiveComboBox
            // 
            this.PerspectiveComboBox.FormattingEnabled = true;
            this.PerspectiveComboBox.Items.AddRange(new object[] {
            "Перспективная",
            "Изометрическая"});
            this.PerspectiveComboBox.Location = new System.Drawing.Point(12, 471);
            this.PerspectiveComboBox.Name = "PerspectiveComboBox";
            this.PerspectiveComboBox.Size = new System.Drawing.Size(190, 27);
            this.PerspectiveComboBox.TabIndex = 9;
            // 
            // ApplyAffin
            // 
            this.ApplyAffin.Location = new System.Drawing.Point(831, 376);
            this.ApplyAffin.Name = "ApplyAffin";
            this.ApplyAffin.Size = new System.Drawing.Size(190, 38);
            this.ApplyAffin.TabIndex = 42;
            this.ApplyAffin.Text = "Применить";
            this.ApplyAffin.UseVisualStyleBackColor = true;
            this.ApplyAffin.Click += new System.EventHandler(this.ApplyAffin_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(745, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 19);
            this.label6.TabIndex = 41;
            this.label6.Text = "Масштаб";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(745, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 40;
            this.label5.Text = "Поворот";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.DecimalPlaces = 1;
            this.numericUpDown7.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown7.Location = new System.Drawing.Point(833, 344);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown7.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(54, 26);
            this.numericUpDown7.TabIndex = 39;
            this.numericUpDown7.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.DecimalPlaces = 1;
            this.numericUpDown8.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown8.Location = new System.Drawing.Point(893, 344);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown8.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown8.TabIndex = 38;
            this.numericUpDown8.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.DecimalPlaces = 1;
            this.numericUpDown9.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown9.Location = new System.Drawing.Point(955, 344);
            this.numericUpDown9.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown9.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown9.TabIndex = 37;
            this.numericUpDown9.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown4.Location = new System.Drawing.Point(833, 312);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(54, 26);
            this.numericUpDown4.TabIndex = 36;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown5.Location = new System.Drawing.Point(893, 312);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown5.TabIndex = 35;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown6.Location = new System.Drawing.Point(955, 312);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown6.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(745, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 33;
            this.label4.Text = "Смещение";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 2;
            this.numericUpDown3.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown3.Location = new System.Drawing.Point(955, 280);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(54, 26);
            this.numericUpDown3.TabIndex = 32;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown2.Location = new System.Drawing.Point(893, 280);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown2.TabIndex = 31;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(831, 280);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown1.TabIndex = 30;
            // 
            // ApplyPrimitive
            // 
            this.ApplyPrimitive.Location = new System.Drawing.Point(831, 177);
            this.ApplyPrimitive.Name = "ApplyPrimitive";
            this.ApplyPrimitive.Size = new System.Drawing.Size(190, 38);
            this.ApplyPrimitive.TabIndex = 29;
            this.ApplyPrimitive.Text = "Применить";
            this.ApplyPrimitive.UseVisualStyleBackColor = true;
            this.ApplyPrimitive.Click += new System.EventHandler(this.ApplyPrimitive_Click);
            // 
            // PrimitiveLabel
            // 
            this.PrimitiveLabel.AutoSize = true;
            this.PrimitiveLabel.Location = new System.Drawing.Point(827, 17);
            this.PrimitiveLabel.Name = "PrimitiveLabel";
            this.PrimitiveLabel.Size = new System.Drawing.Size(142, 19);
            this.PrimitiveLabel.TabIndex = 28;
            this.PrimitiveLabel.Text = "Выберите функцию";
            // 
            // PrimitiveComboBox
            // 
            this.PrimitiveComboBox.FormattingEnabled = true;
            this.PrimitiveComboBox.Items.AddRange(new object[] {
            "(x * x * y) / ((x * x * x * x + y * y) - 0.01)",
            "(x * x) + (y * y)",
            "x + y"});
            this.PrimitiveComboBox.Location = new System.Drawing.Point(831, 48);
            this.PrimitiveComboBox.Name = "PrimitiveComboBox";
            this.PrimitiveComboBox.Size = new System.Drawing.Size(190, 27);
            this.PrimitiveComboBox.TabIndex = 27;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(848, 469);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(190, 29);
            this.SaveButton.TabIndex = 43;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(652, 469);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(190, 29);
            this.LoadButton.TabIndex = 44;
            this.LoadButton.Text = "Загрузить";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(969, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 19);
            this.label3.TabIndex = 51;
            this.label3.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(910, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 50;
            this.label2.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(845, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 19);
            this.label7.TabIndex = 49;
            this.label7.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(767, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 19);
            this.label8.TabIndex = 62;
            this.label8.Text = "f(x,y) = ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(767, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 19);
            this.label11.TabIndex = 63;
            this.label11.Text = "Шаг";
            // 
            // numericUpDown14
            // 
            this.numericUpDown14.DecimalPlaces = 2;
            this.numericUpDown14.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown14.Location = new System.Drawing.Point(831, 146);
            this.numericUpDown14.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown14.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            131072});
            this.numericUpDown14.Name = "numericUpDown14";
            this.numericUpDown14.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown14.TabIndex = 64;
            this.numericUpDown14.Value = new decimal(new int[] {
            3,
            0,
            0,
            131072});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(771, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(206, 19);
            this.label12.TabIndex = 65;
            this.label12.Text = "X        [                  ,                 ]";
            // 
            // numericUpDown15
            // 
            this.numericUpDown15.DecimalPlaces = 2;
            this.numericUpDown15.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown15.Location = new System.Drawing.Point(831, 81);
            this.numericUpDown15.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown15.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown15.Name = "numericUpDown15";
            this.numericUpDown15.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown15.TabIndex = 66;
            this.numericUpDown15.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numericUpDown16
            // 
            this.numericUpDown16.DecimalPlaces = 2;
            this.numericUpDown16.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown16.Location = new System.Drawing.Point(904, 81);
            this.numericUpDown16.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown16.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown16.Name = "numericUpDown16";
            this.numericUpDown16.Size = new System.Drawing.Size(54, 26);
            this.numericUpDown16.TabIndex = 67;
            this.numericUpDown16.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(771, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(205, 19);
            this.label13.TabIndex = 68;
            this.label13.Text = "Y        [                  ,                 ]";
            // 
            // numericUpDown17
            // 
            this.numericUpDown17.DecimalPlaces = 2;
            this.numericUpDown17.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown17.Location = new System.Drawing.Point(833, 114);
            this.numericUpDown17.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown17.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown17.Name = "numericUpDown17";
            this.numericUpDown17.Size = new System.Drawing.Size(54, 26);
            this.numericUpDown17.TabIndex = 69;
            this.numericUpDown17.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numericUpDown18
            // 
            this.numericUpDown18.DecimalPlaces = 2;
            this.numericUpDown18.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown18.Location = new System.Drawing.Point(904, 114);
            this.numericUpDown18.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown18.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown18.Name = "numericUpDown18";
            this.numericUpDown18.Size = new System.Drawing.Size(54, 26);
            this.numericUpDown18.TabIndex = 70;
            this.numericUpDown18.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(742, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 211);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(742, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 198);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Преобразования";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 512);
            this.Controls.Add(this.numericUpDown18);
            this.Controls.Add(this.numericUpDown17);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numericUpDown16);
            this.Controls.Add(this.numericUpDown15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numericUpDown14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ApplyAffin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown7);
            this.Controls.Add(this.numericUpDown8);
            this.Controls.Add(this.numericUpDown9);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.numericUpDown6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.ApplyPrimitive);
            this.Controls.Add(this.PrimitiveLabel);
            this.Controls.Add(this.PrimitiveComboBox);
            this.Controls.Add(this.PerspectiveLabel);
            this.Controls.Add(this.ApplyPerspective);
            this.Controls.Add(this.PerspectiveComboBox);
            this.Controls.Add(this.PerspectiveBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Построение графика 3D";
            ((System.ComponentModel.ISupportInitialize)(this.PerspectiveBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown18)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PerspectiveBox;
        private System.Windows.Forms.Label PerspectiveLabel;
        private System.Windows.Forms.Button ApplyPerspective;
        private System.Windows.Forms.ComboBox PerspectiveComboBox;
        private System.Windows.Forms.Button ApplyAffin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown7;
        private System.Windows.Forms.NumericUpDown numericUpDown8;
        private System.Windows.Forms.NumericUpDown numericUpDown9;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button ApplyPrimitive;
        private System.Windows.Forms.Label PrimitiveLabel;
        private System.Windows.Forms.ComboBox PrimitiveComboBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDown15;
        private System.Windows.Forms.NumericUpDown numericUpDown16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDown17;
        private System.Windows.Forms.NumericUpDown numericUpDown18;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}

