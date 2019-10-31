namespace RotationFigure
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
            this.projectionComboBox = new System.Windows.Forms.ComboBox();
            this.ApplyProjection = new System.Windows.Forms.Button();
            this.PerspectiveLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ApplyAffin = new System.Windows.Forms.Button();
            this.ReflectionComboBox = new System.Windows.Forms.ComboBox();
            this.ApplyReflection = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown14 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown15 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown16 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown17 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown18 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown19 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown20 = new System.Windows.Forms.NumericUpDown();
            this.ApplyLineRotation = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.numericUpDown21 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown22 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown23 = new System.Windows.Forms.NumericUpDown();
            this.addPointBtn = new System.Windows.Forms.Button();
            this.removePointBtn = new System.Windows.Forms.Button();
            this.densityCountNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.rotationAxisCB = new System.Windows.Forms.ComboBox();
            this.DrawRotationFigure = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityCountNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(210, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(639, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // projectionComboBox
            // 
            this.projectionComboBox.FormattingEnabled = true;
            this.projectionComboBox.Items.AddRange(new object[] {
            "Перспективная",
            "Изометрическая",
            "Ортографическая XY",
            "Ортографическая YZ",
            "Ортографическая XZ"});
            this.projectionComboBox.Location = new System.Drawing.Point(12, 305);
            this.projectionComboBox.Name = "projectionComboBox";
            this.projectionComboBox.Size = new System.Drawing.Size(190, 27);
            this.projectionComboBox.TabIndex = 2;
            // 
            // ApplyProjection
            // 
            this.ApplyProjection.Location = new System.Drawing.Point(12, 337);
            this.ApplyProjection.Name = "ApplyProjection";
            this.ApplyProjection.Size = new System.Drawing.Size(190, 34);
            this.ApplyProjection.TabIndex = 4;
            this.ApplyProjection.Text = "Применить";
            this.ApplyProjection.UseVisualStyleBackColor = true;
            this.ApplyProjection.Click += new System.EventHandler(this.ApplyProjection_Click);
            // 
            // PerspectiveLabel
            // 
            this.PerspectiveLabel.AutoSize = true;
            this.PerspectiveLabel.Location = new System.Drawing.Point(10, 282);
            this.PerspectiveLabel.Name = "PerspectiveLabel";
            this.PerspectiveLabel.Size = new System.Drawing.Size(149, 19);
            this.PerspectiveLabel.TabIndex = 7;
            this.PerspectiveLabel.Text = "Выберите проекцию";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(939, 26);
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
            this.numericUpDown1.TabIndex = 11;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown2.Location = new System.Drawing.Point(1007, 26);
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
            this.numericUpDown2.TabIndex = 12;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 2;
            this.numericUpDown3.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDown3.Location = new System.Drawing.Point(1075, 26);
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
            this.numericUpDown3.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(956, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1024, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1091, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(855, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Смещение";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown4.Location = new System.Drawing.Point(937, 58);
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
            this.numericUpDown4.Size = new System.Drawing.Size(58, 26);
            this.numericUpDown4.TabIndex = 20;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown5.Location = new System.Drawing.Point(1007, 58);
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
            this.numericUpDown5.TabIndex = 19;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown6.Location = new System.Drawing.Point(1073, 58);
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
            this.numericUpDown6.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(866, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "Поворот";
            // 
            // ApplyAffin
            // 
            this.ApplyAffin.Location = new System.Drawing.Point(937, 121);
            this.ApplyAffin.Name = "ApplyAffin";
            this.ApplyAffin.Size = new System.Drawing.Size(190, 34);
            this.ApplyAffin.TabIndex = 26;
            this.ApplyAffin.Text = "Применить";
            this.ApplyAffin.UseVisualStyleBackColor = true;
            this.ApplyAffin.Click += new System.EventHandler(this.ApplyAffin_Click);
            // 
            // ReflectionComboBox
            // 
            this.ReflectionComboBox.FormattingEnabled = true;
            this.ReflectionComboBox.Items.AddRange(new object[] {
            "Отражение по X",
            "Отражение по Y",
            "Отражение по Z"});
            this.ReflectionComboBox.Location = new System.Drawing.Point(941, 191);
            this.ReflectionComboBox.Name = "ReflectionComboBox";
            this.ReflectionComboBox.Size = new System.Drawing.Size(186, 27);
            this.ReflectionComboBox.TabIndex = 27;
            // 
            // ApplyReflection
            // 
            this.ApplyReflection.Location = new System.Drawing.Point(939, 220);
            this.ApplyReflection.Name = "ApplyReflection";
            this.ApplyReflection.Size = new System.Drawing.Size(190, 34);
            this.ApplyReflection.TabIndex = 28;
            this.ApplyReflection.Text = "Применить";
            this.ApplyReflection.UseVisualStyleBackColor = true;
            this.ApplyReflection.Click += new System.EventHandler(this.ApplyReflection_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(937, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 19);
            this.label7.TabIndex = 29;
            this.label7.Text = "Отражение";
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.DecimalPlaces = 1;
            this.numericUpDown10.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown10.Location = new System.Drawing.Point(939, 89);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown10.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Size = new System.Drawing.Size(190, 26);
            this.numericUpDown10.TabIndex = 30;
            this.numericUpDown10.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(863, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 19);
            this.label8.TabIndex = 32;
            this.label8.Text = "Масштаб";
            // 
            // numericUpDown14
            // 
            this.numericUpDown14.DecimalPlaces = 1;
            this.numericUpDown14.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown14.Location = new System.Drawing.Point(941, 288);
            this.numericUpDown14.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown14.Name = "numericUpDown14";
            this.numericUpDown14.Size = new System.Drawing.Size(54, 26);
            this.numericUpDown14.TabIndex = 43;
            // 
            // numericUpDown15
            // 
            this.numericUpDown15.DecimalPlaces = 1;
            this.numericUpDown15.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown15.Location = new System.Drawing.Point(1007, 288);
            this.numericUpDown15.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown15.Name = "numericUpDown15";
            this.numericUpDown15.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown15.TabIndex = 42;
            // 
            // numericUpDown16
            // 
            this.numericUpDown16.DecimalPlaces = 1;
            this.numericUpDown16.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown16.Location = new System.Drawing.Point(1075, 288);
            this.numericUpDown16.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown16.Name = "numericUpDown16";
            this.numericUpDown16.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown16.TabIndex = 41;
            // 
            // numericUpDown17
            // 
            this.numericUpDown17.DecimalPlaces = 1;
            this.numericUpDown17.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown17.Location = new System.Drawing.Point(941, 320);
            this.numericUpDown17.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown17.Name = "numericUpDown17";
            this.numericUpDown17.Size = new System.Drawing.Size(54, 26);
            this.numericUpDown17.TabIndex = 46;
            // 
            // numericUpDown18
            // 
            this.numericUpDown18.DecimalPlaces = 1;
            this.numericUpDown18.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown18.Location = new System.Drawing.Point(1007, 320);
            this.numericUpDown18.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown18.Name = "numericUpDown18";
            this.numericUpDown18.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown18.TabIndex = 45;
            // 
            // numericUpDown19
            // 
            this.numericUpDown19.DecimalPlaces = 1;
            this.numericUpDown19.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown19.Location = new System.Drawing.Point(1075, 320);
            this.numericUpDown19.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown19.Name = "numericUpDown19";
            this.numericUpDown19.Size = new System.Drawing.Size(56, 26);
            this.numericUpDown19.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(939, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 19);
            this.label10.TabIndex = 47;
            this.label10.Text = "Поворот вокруг прямой";
            // 
            // numericUpDown20
            // 
            this.numericUpDown20.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown20.Location = new System.Drawing.Point(941, 350);
            this.numericUpDown20.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDown20.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.numericUpDown20.Name = "numericUpDown20";
            this.numericUpDown20.Size = new System.Drawing.Size(190, 26);
            this.numericUpDown20.TabIndex = 48;
            this.numericUpDown20.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // ApplyLineRotation
            // 
            this.ApplyLineRotation.Location = new System.Drawing.Point(941, 378);
            this.ApplyLineRotation.Name = "ApplyLineRotation";
            this.ApplyLineRotation.Size = new System.Drawing.Size(190, 34);
            this.ApplyLineRotation.TabIndex = 49;
            this.ApplyLineRotation.Text = "Применить";
            this.ApplyLineRotation.UseVisualStyleBackColor = true;
            this.ApplyLineRotation.Click += new System.EventHandler(this.ApplyLineRotation_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(894, 352);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 19);
            this.label11.TabIndex = 47;
            this.label11.Text = "Угол";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(882, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 19);
            this.label12.TabIndex = 47;
            this.label12.Text = "Точка1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(882, 322);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 19);
            this.label13.TabIndex = 47;
            this.label13.Text = "Точка2";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 377);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(92, 35);
            this.SaveButton.TabIndex = 50;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(110, 377);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(92, 35);
            this.LoadButton.TabIndex = 51;
            this.LoadButton.Text = "Загрузить";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(12, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(190, 42);
            this.listBox1.TabIndex = 52;
            // 
            // numericUpDown21
            // 
            this.numericUpDown21.DecimalPlaces = 1;
            this.numericUpDown21.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown21.Location = new System.Drawing.Point(14, 72);
            this.numericUpDown21.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown21.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown21.Name = "numericUpDown21";
            this.numericUpDown21.Size = new System.Drawing.Size(54, 26);
            this.numericUpDown21.TabIndex = 53;
            // 
            // numericUpDown22
            // 
            this.numericUpDown22.DecimalPlaces = 1;
            this.numericUpDown22.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown22.Location = new System.Drawing.Point(81, 72);
            this.numericUpDown22.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown22.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown22.Name = "numericUpDown22";
            this.numericUpDown22.Size = new System.Drawing.Size(54, 26);
            this.numericUpDown22.TabIndex = 53;
            // 
            // numericUpDown23
            // 
            this.numericUpDown23.DecimalPlaces = 1;
            this.numericUpDown23.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown23.Location = new System.Drawing.Point(148, 72);
            this.numericUpDown23.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown23.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown23.Name = "numericUpDown23";
            this.numericUpDown23.Size = new System.Drawing.Size(54, 26);
            this.numericUpDown23.TabIndex = 53;
            // 
            // addPointBtn
            // 
            this.addPointBtn.Location = new System.Drawing.Point(12, 104);
            this.addPointBtn.Name = "addPointBtn";
            this.addPointBtn.Size = new System.Drawing.Size(92, 29);
            this.addPointBtn.TabIndex = 54;
            this.addPointBtn.Text = "Добавить";
            this.addPointBtn.UseVisualStyleBackColor = true;
            this.addPointBtn.Click += new System.EventHandler(this.AddPointBtn_Click);
            // 
            // removePointBtn
            // 
            this.removePointBtn.Location = new System.Drawing.Point(110, 104);
            this.removePointBtn.Name = "removePointBtn";
            this.removePointBtn.Size = new System.Drawing.Size(92, 29);
            this.removePointBtn.TabIndex = 54;
            this.removePointBtn.Text = "Удалить";
            this.removePointBtn.UseVisualStyleBackColor = true;
            this.removePointBtn.Click += new System.EventHandler(this.RemovePointBtn_Click);
            // 
            // densityCountNumUpDown
            // 
            this.densityCountNumUpDown.Location = new System.Drawing.Point(12, 155);
            this.densityCountNumUpDown.Name = "densityCountNumUpDown";
            this.densityCountNumUpDown.Size = new System.Drawing.Size(190, 26);
            this.densityCountNumUpDown.TabIndex = 53;
            this.densityCountNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rotationAxisCB
            // 
            this.rotationAxisCB.FormattingEnabled = true;
            this.rotationAxisCB.Items.AddRange(new object[] {
            "OX",
            "OY",
            "OZ"});
            this.rotationAxisCB.Location = new System.Drawing.Point(12, 206);
            this.rotationAxisCB.Name = "rotationAxisCB";
            this.rotationAxisCB.Size = new System.Drawing.Size(190, 27);
            this.rotationAxisCB.TabIndex = 55;
            // 
            // DrawRotationFigure
            // 
            this.DrawRotationFigure.Location = new System.Drawing.Point(10, 238);
            this.DrawRotationFigure.Name = "DrawRotationFigure";
            this.DrawRotationFigure.Size = new System.Drawing.Size(192, 34);
            this.DrawRotationFigure.TabIndex = 54;
            this.DrawRotationFigure.Text = "Построить";
            this.DrawRotationFigure.UseVisualStyleBackColor = true;
            this.DrawRotationFigure.Click += new System.EventHandler(this.DrawRotationFigure_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Образующая";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 19);
            this.label9.TabIndex = 7;
            this.label9.Text = "Кол-во разбиений";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 186);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 19);
            this.label14.TabIndex = 7;
            this.label14.Text = "Ось вращения";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 421);
            this.Controls.Add(this.rotationAxisCB);
            this.Controls.Add(this.removePointBtn);
            this.Controls.Add(this.DrawRotationFigure);
            this.Controls.Add(this.addPointBtn);
            this.Controls.Add(this.numericUpDown23);
            this.Controls.Add(this.numericUpDown22);
            this.Controls.Add(this.densityCountNumUpDown);
            this.Controls.Add(this.numericUpDown21);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ApplyLineRotation);
            this.Controls.Add(this.numericUpDown20);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericUpDown17);
            this.Controls.Add(this.numericUpDown18);
            this.Controls.Add(this.numericUpDown19);
            this.Controls.Add(this.numericUpDown14);
            this.Controls.Add(this.numericUpDown15);
            this.Controls.Add(this.numericUpDown16);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ApplyReflection);
            this.Controls.Add(this.ReflectionComboBox);
            this.Controls.Add(this.ApplyAffin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.numericUpDown6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PerspectiveLabel);
            this.Controls.Add(this.ApplyProjection);
            this.Controls.Add(this.projectionComboBox);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Построение фигуры вращения";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityCountNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox projectionComboBox;
        private System.Windows.Forms.Button ApplyProjection;
        private System.Windows.Forms.Label PerspectiveLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ApplyAffin;
        private System.Windows.Forms.ComboBox ReflectionComboBox;
        private System.Windows.Forms.Button ApplyReflection;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown14;
        private System.Windows.Forms.NumericUpDown numericUpDown15;
        private System.Windows.Forms.NumericUpDown numericUpDown16;
        private System.Windows.Forms.NumericUpDown numericUpDown17;
        private System.Windows.Forms.NumericUpDown numericUpDown18;
        private System.Windows.Forms.NumericUpDown numericUpDown19;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown20;
        private System.Windows.Forms.Button ApplyLineRotation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown21;
        private System.Windows.Forms.NumericUpDown numericUpDown22;
        private System.Windows.Forms.NumericUpDown numericUpDown23;
        private System.Windows.Forms.Button addPointBtn;
        private System.Windows.Forms.Button removePointBtn;
        private System.Windows.Forms.NumericUpDown densityCountNumUpDown;
        private System.Windows.Forms.ComboBox rotationAxisCB;
        private System.Windows.Forms.Button DrawRotationFigure;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
    }
}

