namespace robot_ver5
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_FK = new System.Windows.Forms.Button();
            this.label_FKL = new System.Windows.Forms.Label();
            this.trackBar_8 = new System.Windows.Forms.TrackBar();
            this.trackBar_4 = new System.Windows.Forms.TrackBar();
            this.trackBar_9 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.test = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_9)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox2.Location = new System.Drawing.Point(264, 147);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(506, 351);
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(640, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 44;
            this.button1.Text = "Сброс";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button_FK
            // 
            this.button_FK.Location = new System.Drawing.Point(42, 423);
            this.button_FK.Name = "button_FK";
            this.button_FK.Size = new System.Drawing.Size(111, 23);
            this.button_FK.TabIndex = 45;
            this.button_FK.Text = "Прямая задача";
            this.button_FK.UseVisualStyleBackColor = true;
            this.button_FK.Click += new System.EventHandler(this.button_FK_Click);
            // 
            // label_FKL
            // 
            this.label_FKL.AutoSize = true;
            this.label_FKL.Location = new System.Drawing.Point(40, 468);
            this.label_FKL.Name = "label_FKL";
            this.label_FKL.Size = new System.Drawing.Size(69, 13);
            this.label_FKL.TabIndex = 48;
            this.label_FKL.Text = "Координаты";
            // 
            // trackBar_8
            // 
            this.trackBar_8.Location = new System.Drawing.Point(42, 211);
            this.trackBar_8.Maximum = 40;
            this.trackBar_8.Minimum = -40;
            this.trackBar_8.Name = "trackBar_8";
            this.trackBar_8.Size = new System.Drawing.Size(104, 45);
            this.trackBar_8.TabIndex = 49;
            this.trackBar_8.Scroll += new System.EventHandler(this.trackBar_8_Scroll);
            // 
            // trackBar_4
            // 
            this.trackBar_4.Location = new System.Drawing.Point(42, 262);
            this.trackBar_4.Maximum = 40;
            this.trackBar_4.Minimum = -40;
            this.trackBar_4.Name = "trackBar_4";
            this.trackBar_4.Size = new System.Drawing.Size(104, 45);
            this.trackBar_4.TabIndex = 50;
            this.trackBar_4.Scroll += new System.EventHandler(this.trackBar_8_Scroll);
            // 
            // trackBar_9
            // 
            this.trackBar_9.Location = new System.Drawing.Point(42, 313);
            this.trackBar_9.Maximum = 30;
            this.trackBar_9.Minimum = -30;
            this.trackBar_9.Name = "trackBar_9";
            this.trackBar_9.Size = new System.Drawing.Size(104, 45);
            this.trackBar_9.TabIndex = 51;
            this.trackBar_9.Value = -30;
            this.trackBar_9.Scroll += new System.EventHandler(this.trackBar_8_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Двигатели";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Инструмент";
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(31, 29);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(75, 23);
            this.test.TabIndex = 54;
            this.test.Text = "Test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(149, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "по вертикали";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(152, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "по горизонтали";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(152, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "заглубление";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 555);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.test);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar_9);
            this.Controls.Add(this.trackBar_4);
            this.Controls.Add(this.trackBar_8);
            this.Controls.Add(this.label_FKL);
            this.Controls.Add(this.button_FK);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_FK;
        private System.Windows.Forms.Label label_FKL;
        private System.Windows.Forms.TrackBar trackBar_8;
        private System.Windows.Forms.TrackBar trackBar_4;
        private System.Windows.Forms.TrackBar trackBar_9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

