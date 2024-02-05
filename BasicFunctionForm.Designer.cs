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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicFunctionForm));
            this.grpToday = new System.Windows.Forms.GroupBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.chbNextDay = new System.Windows.Forms.CheckBox();
            this.lblTodayNextSound = new System.Windows.Forms.Label();
            this.lblTodayTemplate = new System.Windows.Forms.Label();
            this.Sound = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSoundsToday = new System.Windows.Forms.ComboBox();
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
            this.checkBoxMuted = new System.Windows.Forms.CheckBox();
            this.checkBoxRepeat = new System.Windows.Forms.CheckBox();
            this.btnStopRepeat = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cboSounds = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNowPlaying = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTemplateManager = new System.Windows.Forms.Button();
            this.grpToday.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpToday
            // 
            this.grpToday.Controls.Add(this.txtTime);
            this.grpToday.Controls.Add(this.chbNextDay);
            this.grpToday.Controls.Add(this.lblTodayNextSound);
            this.grpToday.Controls.Add(this.lblTodayTemplate);
            this.grpToday.Controls.Add(this.Sound);
            this.grpToday.Controls.Add(this.label7);
            this.grpToday.Controls.Add(this.cboSoundsToday);
            this.grpToday.Controls.Add(this.btnTodayRemove);
            this.grpToday.Controls.Add(this.btnTodayAdd);
            this.grpToday.Controls.Add(this.label3);
            this.grpToday.Controls.Add(this.label2);
            this.grpToday.Controls.Add(this.lblTodayDay);
            this.grpToday.Controls.Add(this.lbxToday);
            this.grpToday.Location = new System.Drawing.Point(17, 111);
            this.grpToday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpToday.Name = "grpToday";
            this.grpToday.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpToday.Size = new System.Drawing.Size(361, 625);
            this.grpToday.TabIndex = 0;
            this.grpToday.TabStop = false;
            this.grpToday.Text = "Today\'s Schedule";
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtTime.Location = new System.Drawing.Point(90, 487);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(86, 31);
            this.txtTime.TabIndex = 13;
            // 
            // chbNextDay
            // 
            this.chbNextDay.AutoSize = true;
            this.chbNextDay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chbNextDay.Location = new System.Drawing.Point(182, 489);
            this.chbNextDay.Name = "chbNextDay";
            this.chbNextDay.Size = new System.Drawing.Size(110, 29);
            this.chbNextDay.TabIndex = 12;
            this.chbNextDay.Text = "Next Day";
            this.chbNextDay.UseVisualStyleBackColor = false;
            // 
            // lblTodayNextSound
            // 
            this.lblTodayNextSound.AutoSize = true;
            this.lblTodayNextSound.Location = new System.Drawing.Point(90, 88);
            this.lblTodayNextSound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTodayNextSound.Name = "lblTodayNextSound";
            this.lblTodayNextSound.Size = new System.Drawing.Size(119, 25);
            this.lblTodayNextSound.TabIndex = 11;
            this.lblTodayNextSound.Text = "Reveille, 0700";
            // 
            // lblTodayTemplate
            // 
            this.lblTodayTemplate.AutoSize = true;
            this.lblTodayTemplate.Location = new System.Drawing.Point(90, 63);
            this.lblTodayTemplate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTodayTemplate.Name = "lblTodayTemplate";
            this.lblTodayTemplate.Size = new System.Drawing.Size(139, 25);
            this.lblTodayTemplate.TabIndex = 10;
            this.lblTodayTemplate.Text = "M/T/W/Th Class";
            // 
            // Sound
            // 
            this.Sound.AutoSize = true;
            this.Sound.Location = new System.Drawing.Point(9, 533);
            this.Sound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Sound.Name = "Sound";
            this.Sound.Size = new System.Drawing.Size(68, 25);
            this.Sound.TabIndex = 9;
            this.Sound.Text = "Sound:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 490);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Time:";
            // 
            // cboSoundsToday
            // 
            this.cboSoundsToday.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cboSoundsToday.FormattingEnabled = true;
            this.cboSoundsToday.Location = new System.Drawing.Point(90, 530);
            this.cboSoundsToday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSoundsToday.Name = "cboSoundsToday";
            this.cboSoundsToday.Size = new System.Drawing.Size(225, 33);
            this.cboSoundsToday.TabIndex = 7;
            // 
            // btnTodayRemove
            // 
            this.btnTodayRemove.Location = new System.Drawing.Point(9, 432);
            this.btnTodayRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTodayRemove.Name = "btnTodayRemove";
            this.btnTodayRemove.Size = new System.Drawing.Size(167, 38);
            this.btnTodayRemove.TabIndex = 5;
            this.btnTodayRemove.Text = "Remove";
            this.btnTodayRemove.UseVisualStyleBackColor = true;
            this.btnTodayRemove.Click += new System.EventHandler(this.btnTodayRemove_Click);
            // 
            // btnTodayAdd
            // 
            this.btnTodayAdd.Location = new System.Drawing.Point(9, 577);
            this.btnTodayAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTodayAdd.Name = "btnTodayAdd";
            this.btnTodayAdd.Size = new System.Drawing.Size(167, 38);
            this.btnTodayAdd.TabIndex = 4;
            this.btnTodayAdd.Text = "Add";
            this.btnTodayAdd.UseVisualStyleBackColor = true;
            this.btnTodayAdd.Click += new System.EventHandler(this.btnTodayAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Next:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Template: ";
            // 
            // lblTodayDay
            // 
            this.lblTodayDay.AutoSize = true;
            this.lblTodayDay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblTodayDay.Location = new System.Drawing.Point(9, 32);
            this.lblTodayDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTodayDay.Name = "lblTodayDay";
            this.lblTodayDay.Size = new System.Drawing.Size(161, 25);
            this.lblTodayDay.TabIndex = 1;
            this.lblTodayDay.Text = "January 27th, 2023";
            // 
            // lbxToday
            // 
            this.lbxToday.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbxToday.FormattingEnabled = true;
            this.lbxToday.HorizontalScrollbar = true;
            this.lbxToday.ItemHeight = 25;
            this.lbxToday.Location = new System.Drawing.Point(9, 137);
            this.lbxToday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbxToday.Name = "lbxToday";
            this.lbxToday.Size = new System.Drawing.Size(338, 279);
            this.lbxToday.TabIndex = 0;
            // 
            // dtpTemplateDayChanger
            // 
            this.dtpTemplateDayChanger.CalendarMonthBackground = System.Drawing.SystemColors.ControlDark;
            this.dtpTemplateDayChanger.CalendarTitleBackColor = System.Drawing.SystemColors.ControlDark;
            this.dtpTemplateDayChanger.Location = new System.Drawing.Point(9, 33);
            this.dtpTemplateDayChanger.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTemplateDayChanger.Name = "dtpTemplateDayChanger";
            this.dtpTemplateDayChanger.Size = new System.Drawing.Size(321, 31);
            this.dtpTemplateDayChanger.TabIndex = 1;
            this.dtpTemplateDayChanger.ValueChanged += new System.EventHandler(this.dtpTemplateDayChanger_ValueChanged);
            // 
            // cboChangeDayTemplates
            // 
            this.cboChangeDayTemplates.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cboChangeDayTemplates.FormattingEnabled = true;
            this.cboChangeDayTemplates.Location = new System.Drawing.Point(101, 82);
            this.cboChangeDayTemplates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboChangeDayTemplates.Name = "cboChangeDayTemplates";
            this.cboChangeDayTemplates.Size = new System.Drawing.Size(229, 33);
            this.cboChangeDayTemplates.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnCreateTemplateDayException);
            this.groupBox2.Controls.Add(this.dtpTemplateDayChanger);
            this.groupBox2.Controls.Add(this.cboChangeDayTemplates);
            this.groupBox2.Location = new System.Drawing.Point(396, 350);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(337, 177);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Change Day Schedule";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Template:";
            // 
            // btnCreateTemplateDayException
            // 
            this.btnCreateTemplateDayException.Location = new System.Drawing.Point(9, 125);
            this.btnCreateTemplateDayException.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateTemplateDayException.Name = "btnCreateTemplateDayException";
            this.btnCreateTemplateDayException.Size = new System.Drawing.Size(146, 38);
            this.btnCreateTemplateDayException.TabIndex = 3;
            this.btnCreateTemplateDayException.Text = "Confirm Change";
            this.btnCreateTemplateDayException.UseVisualStyleBackColor = true;
            this.btnCreateTemplateDayException.Click += new System.EventHandler(this.create_template_day_exception_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxMuted);
            this.groupBox3.Controls.Add(this.checkBoxRepeat);
            this.groupBox3.Controls.Add(this.btnStopRepeat);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.cboSounds);
            this.groupBox3.Location = new System.Drawing.Point(396, 166);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(328, 174);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Play Now";
            // 
            // checkBoxMuted
            // 
            this.checkBoxMuted.AutoSize = true;
            this.checkBoxMuted.Location = new System.Drawing.Point(107, 124);
            this.checkBoxMuted.Name = "checkBoxMuted";
            this.checkBoxMuted.Size = new System.Drawing.Size(79, 29);
            this.checkBoxMuted.TabIndex = 7;
            this.checkBoxMuted.Text = "Mute";
            this.checkBoxMuted.UseVisualStyleBackColor = true;
            this.checkBoxMuted.Visible = false;
            this.checkBoxMuted.CheckedChanged += new System.EventHandler(this.checkBoxMuted_CheckedChanged);
            // 
            // checkBoxRepeat
            // 
            this.checkBoxRepeat.AutoSize = true;
            this.checkBoxRepeat.Location = new System.Drawing.Point(9, 124);
            this.checkBoxRepeat.Name = "checkBoxRepeat";
            this.checkBoxRepeat.Size = new System.Drawing.Size(92, 29);
            this.checkBoxRepeat.TabIndex = 6;
            this.checkBoxRepeat.Text = "Repeat";
            this.checkBoxRepeat.UseVisualStyleBackColor = true;
            this.checkBoxRepeat.CheckedChanged += new System.EventHandler(this.checkBoxRepeat_CheckedChanged);
            // 
            // btnStopRepeat
            // 
            this.btnStopRepeat.Location = new System.Drawing.Point(163, 78);
            this.btnStopRepeat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStopRepeat.Name = "btnStopRepeat";
            this.btnStopRepeat.Size = new System.Drawing.Size(140, 38);
            this.btnStopRepeat.TabIndex = 5;
            this.btnStopRepeat.Text = "Stop";
            this.btnStopRepeat.UseVisualStyleBackColor = true;
            this.btnStopRepeat.Click += new System.EventHandler(this.stopRepeatButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "File:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 78);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Play Sound";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.play_now_btn_click);
            // 
            // cboSounds
            // 
            this.cboSounds.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cboSounds.FormattingEnabled = true;
            this.cboSounds.Location = new System.Drawing.Point(57, 30);
            this.cboSounds.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboSounds.Name = "cboSounds";
            this.cboSounds.Size = new System.Drawing.Size(243, 33);
            this.cboSounds.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNowPlaying);
            this.groupBox1.Location = new System.Drawing.Point(396, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 47);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // lblNowPlaying
            // 
            this.lblNowPlaying.AutoSize = true;
            this.lblNowPlaying.Location = new System.Drawing.Point(7, 16);
            this.lblNowPlaying.Name = "lblNowPlaying";
            this.lblNowPlaying.Size = new System.Drawing.Size(163, 25);
            this.lblNowPlaying.TabIndex = 8;
            this.lblNowPlaying.Text = "Now Playing: None";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 22.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(17, 33);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(686, 61);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "CWOC Basic Daily Sound Module";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(737, 33);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadFilesToolStripMenuItem});
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(76, 29);
            this.audioToolStripMenuItem.Text = "Audio";
            // 
            // reloadFilesToolStripMenuItem
            // 
            this.reloadFilesToolStripMenuItem.Name = "reloadFilesToolStripMenuItem";
            this.reloadFilesToolStripMenuItem.Size = new System.Drawing.Size(207, 34);
            this.reloadFilesToolStripMenuItem.Text = "Reload Files";
            this.reloadFilesToolStripMenuItem.Click += new System.EventHandler(this.reloadFilesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(164, 34);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // btnTemplateManager
            // 
            this.btnTemplateManager.Location = new System.Drawing.Point(405, 535);
            this.btnTemplateManager.Name = "btnTemplateManager";
            this.btnTemplateManager.Size = new System.Drawing.Size(191, 38);
            this.btnTemplateManager.TabIndex = 10;
            this.btnTemplateManager.Text = "Template Manager";
            this.btnTemplateManager.UseVisualStyleBackColor = true;
            this.btnTemplateManager.Click += new System.EventHandler(this.btnTemplateManager_Click);
            // 
            // BasicFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(737, 750);
            this.Controls.Add(this.btnTemplateManager);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpToday);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BasicFunctionForm";
            this.Text = "CWOC BDSM";
            this.grpToday.ResumeLayout(false);
            this.grpToday.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private Button btnTodayRemove;
        private Button btnTodayAdd;
        private GroupBox groupBox3;
        private Label label5;
        private Button button2;
        private ComboBox comboBox2;
        private Label lblName;
        private Label lblTodayNextSound;
        private Label lblTodayTemplate;
        private ComboBox cboSounds;
        private ComboBox cboSoundsToday;
        private CheckBox chbNextDay;
        private CheckBox checkBoxMuted;
        public CheckBox checkBoxRepeat;
        public Button btnStopRepeat;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem audioToolStripMenuItem;
        private ToolStripMenuItem reloadFilesToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private TextBox txtTime;
        private Label lblNowPlaying;
        private GroupBox groupBox1;
        private Button btnTemplateManager;
    }
}