namespace CWOC_Audio_Scheduler
{
    partial class BasicFunctionForm
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
            this.grpToday = new System.Windows.Forms.GroupBox();
            this.lblTodayNext = new System.Windows.Forms.Label();
            this.lblTodayTemplate = new System.Windows.Forms.Label();
            this.Sound = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSoundsToday = new System.Windows.Forms.ComboBox();
            this.dtpTodayTime = new System.Windows.Forms.DateTimePicker();
            this.btnTodayRemove = new System.Windows.Forms.Button();
            this.btnTodayAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTodayDay = new System.Windows.Forms.Label();
            this.lbxToday = new System.Windows.Forms.ListBox();
            this.dtpTemplateDayChanger = new System.Windows.Forms.DateTimePicker();
            this.cboChangeDayTemplates = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreateTemplateDayException = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cboSounds = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpToday.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpToday
            // 
            this.grpToday.Controls.Add(this.lblTodayNext);
            this.grpToday.Controls.Add(this.lblTodayTemplate);
            this.grpToday.Controls.Add(this.Sound);
            this.grpToday.Controls.Add(this.label7);
            this.grpToday.Controls.Add(this.cboSoundsToday);
            this.grpToday.Controls.Add(this.dtpTodayTime);
            this.grpToday.Controls.Add(this.btnTodayRemove);
            this.grpToday.Controls.Add(this.btnTodayAdd);
            this.grpToday.Controls.Add(this.label3);
            this.grpToday.Controls.Add(this.label2);
            this.grpToday.Controls.Add(this.lblTodayDay);
            this.grpToday.Controls.Add(this.lbxToday);
            this.grpToday.Location = new System.Drawing.Point(12, 47);
            this.grpToday.Name = "grpToday";
            this.grpToday.Size = new System.Drawing.Size(253, 391);
            this.grpToday.TabIndex = 0;
            this.grpToday.TabStop = false;
            this.grpToday.Text = "Today\'s Schedule";
            // 
            // lblTodayNext
            // 
            this.lblTodayNext.AutoSize = true;
            this.lblTodayNext.Location = new System.Drawing.Point(73, 53);
            this.lblTodayNext.Name = "lblTodayNext";
            this.lblTodayNext.Size = new System.Drawing.Size(77, 15);
            this.lblTodayNext.TabIndex = 11;
            this.lblTodayNext.Text = "Reveille, 0700";
            // 
            // lblTodayTemplate
            // 
            this.lblTodayTemplate.AutoSize = true;
            this.lblTodayTemplate.Location = new System.Drawing.Point(73, 38);
            this.lblTodayTemplate.Name = "lblTodayTemplate";
            this.lblTodayTemplate.Size = new System.Drawing.Size(93, 15);
            this.lblTodayTemplate.TabIndex = 10;
            this.lblTodayTemplate.Text = "M/T/W/Th Class";
            // 
            // Sound
            // 
            this.Sound.AutoSize = true;
            this.Sound.Location = new System.Drawing.Point(6, 320);
            this.Sound.Name = "Sound";
            this.Sound.Size = new System.Drawing.Size(44, 15);
            this.Sound.TabIndex = 9;
            this.Sound.Text = "Sound:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Time:";
            // 
            // cboSoundsToday
            // 
            this.cboSoundsToday.FormattingEnabled = true;
            this.cboSoundsToday.Location = new System.Drawing.Point(85, 317);
            this.cboSoundsToday.Name = "cboSoundsToday";
            this.cboSoundsToday.Size = new System.Drawing.Size(159, 23);
            this.cboSoundsToday.TabIndex = 7;
            // 
            // dtpTodayTime
            // 
            this.dtpTodayTime.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpTodayTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTodayTime.Location = new System.Drawing.Point(85, 288);
            this.dtpTodayTime.Name = "dtpTodayTime";
            this.dtpTodayTime.RightToLeftLayout = true;
            this.dtpTodayTime.Size = new System.Drawing.Size(81, 23);
            this.dtpTodayTime.TabIndex = 6;
            // 
            // btnTodayRemove
            // 
            this.btnTodayRemove.Location = new System.Drawing.Point(6, 259);
            this.btnTodayRemove.Name = "btnTodayRemove";
            this.btnTodayRemove.Size = new System.Drawing.Size(117, 23);
            this.btnTodayRemove.TabIndex = 5;
            this.btnTodayRemove.Text = "Remove";
            this.btnTodayRemove.UseVisualStyleBackColor = true;
            this.btnTodayRemove.Click += new System.EventHandler(this.btnTodayRemove_Click);
            // 
            // btnTodayAdd
            // 
            this.btnTodayAdd.Location = new System.Drawing.Point(6, 346);
            this.btnTodayAdd.Name = "btnTodayAdd";
            this.btnTodayAdd.Size = new System.Drawing.Size(117, 23);
            this.btnTodayAdd.TabIndex = 4;
            this.btnTodayAdd.Text = "Add";
            this.btnTodayAdd.UseVisualStyleBackColor = true;
            this.btnTodayAdd.Click += new System.EventHandler(this.btnTodayAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Next:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Template: ";
            // 
            // lblTodayDay
            // 
            this.lblTodayDay.AutoSize = true;
            this.lblTodayDay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblTodayDay.Location = new System.Drawing.Point(6, 19);
            this.lblTodayDay.Name = "lblTodayDay";
            this.lblTodayDay.Size = new System.Drawing.Size(103, 15);
            this.lblTodayDay.TabIndex = 1;
            this.lblTodayDay.Text = "January 27th, 2023";
            // 
            // lbxToday
            // 
            this.lbxToday.FormattingEnabled = true;
            this.lbxToday.HorizontalScrollbar = true;
            this.lbxToday.ItemHeight = 15;
            this.lbxToday.Location = new System.Drawing.Point(6, 82);
            this.lbxToday.Name = "lbxToday";
            this.lbxToday.Size = new System.Drawing.Size(238, 169);
            this.lbxToday.TabIndex = 0;
            // 
            // dtpTemplateDayChanger
            // 
            this.dtpTemplateDayChanger.Location = new System.Drawing.Point(6, 20);
            this.dtpTemplateDayChanger.Name = "dtpTemplateDayChanger";
            this.dtpTemplateDayChanger.Size = new System.Drawing.Size(205, 23);
            this.dtpTemplateDayChanger.TabIndex = 1;
            this.dtpTemplateDayChanger.ValueChanged += new System.EventHandler(this.dtpTemplateDayChanger_ValueChanged);
            // 
            // cboChangeDayTemplates
            // 
            this.cboChangeDayTemplates.FormattingEnabled = true;
            this.cboChangeDayTemplates.Location = new System.Drawing.Point(70, 49);
            this.cboChangeDayTemplates.Name = "cboChangeDayTemplates";
            this.cboChangeDayTemplates.Size = new System.Drawing.Size(141, 23);
            this.cboChangeDayTemplates.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnCreateTemplateDayException);
            this.groupBox2.Controls.Add(this.dtpTemplateDayChanger);
            this.groupBox2.Controls.Add(this.cboChangeDayTemplates);
            this.groupBox2.Location = new System.Drawing.Point(271, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 119);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change Day Schedule";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Template:";
            // 
            // btnCreateTemplateDayException
            // 
            this.btnCreateTemplateDayException.Location = new System.Drawing.Point(6, 78);
            this.btnCreateTemplateDayException.Name = "btnCreateTemplateDayException";
            this.btnCreateTemplateDayException.Size = new System.Drawing.Size(110, 23);
            this.btnCreateTemplateDayException.TabIndex = 3;
            this.btnCreateTemplateDayException.Text = "Confirm Change";
            this.btnCreateTemplateDayException.UseVisualStyleBackColor = true;
            this.btnCreateTemplateDayException.Click += new System.EventHandler(this.create_template_day_exception_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.cboSounds);
            this.groupBox3.Location = new System.Drawing.Point(271, 172);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 85);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Play Now";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "File:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Play Sound";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.play_now_btn_click);
            // 
            // cboSounds
            // 
            this.cboSounds.FormattingEnabled = true;
            this.cboSounds.Location = new System.Drawing.Point(40, 19);
            this.cboSounds.Name = "cboSounds";
            this.cboSounds.Size = new System.Drawing.Size(171, 23);
            this.cboSounds.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(12, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(447, 41);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "CWOC Basic Scheduling Module";
            // 
            // BasicFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 450);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpToday);
            this.Name = "BasicFunctionForm";
            this.Text = "CWOC BASM";
            this.grpToday.ResumeLayout(false);
            this.grpToday.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox grpToday;
        private Label label3;
        private Label label2;
        private Label lblTodayDay;
        private ListBox lbxToday;
        private DateTimePicker dtpTemplateDayChanger;
        private ComboBox cboChangeDayTemplates;
        private GroupBox groupBox2;
        private Label label4;
        private Button btnCreateTemplateDayException;
        private Label Sound;
        private Label label7;
        private ComboBox comboBox3;
        private DateTimePicker dtpTodayTime;
        private Button btnTodayRemove;
        private Button btnTodayAdd;
        private GroupBox groupBox3;
        private Label label5;
        private Button button2;
        private ComboBox comboBox2;
        private Label lblName;
        private Label lblTodayNext;
        private Label lblTodayTemplate;
        private ComboBox cboSounds;
        private ComboBox cboSoundsToday;
    }
}