namespace AutoScan
{
    partial class frmMain
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
            this.comboComs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.groupDJ = new System.Windows.Forms.GroupBox();
            this.nudAngle = new System.Windows.Forms.NumericUpDown();
            this.btnAAngle = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtResponse = new System.Windows.Forms.RichTextBox();
            this.btnDistance = new System.Windows.Forms.Button();
            this.picCurve = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupDJ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCurve)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboComs
            // 
            this.comboComs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboComs.FormattingEnabled = true;
            this.comboComs.Location = new System.Drawing.Point(91, 23);
            this.comboComs.Name = "comboComs";
            this.comboComs.Size = new System.Drawing.Size(149, 20);
            this.comboComs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "本机可用串口：";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(246, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷  新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenCom);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.comboComs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择串口";
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Location = new System.Drawing.Point(327, 20);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(92, 23);
            this.btnOpenCom.TabIndex = 3;
            this.btnOpenCom.Text = "打开串口";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click);
            // 
            // groupDJ
            // 
            this.groupDJ.Controls.Add(this.nudAngle);
            this.groupDJ.Controls.Add(this.btnAAngle);
            this.groupDJ.Controls.Add(this.btnAuto);
            this.groupDJ.Controls.Add(this.btnReset);
            this.groupDJ.Enabled = false;
            this.groupDJ.Location = new System.Drawing.Point(12, 78);
            this.groupDJ.Name = "groupDJ";
            this.groupDJ.Size = new System.Drawing.Size(425, 59);
            this.groupDJ.TabIndex = 4;
            this.groupDJ.TabStop = false;
            this.groupDJ.Text = "舵机控制";
            // 
            // nudAngle
            // 
            this.nudAngle.Location = new System.Drawing.Point(340, 23);
            this.nudAngle.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudAngle.Name = "nudAngle";
            this.nudAngle.Size = new System.Drawing.Size(79, 21);
            this.nudAngle.TabIndex = 3;
            // 
            // btnAAngle
            // 
            this.btnAAngle.Location = new System.Drawing.Point(182, 20);
            this.btnAAngle.Name = "btnAAngle";
            this.btnAAngle.Size = new System.Drawing.Size(152, 23);
            this.btnAAngle.TabIndex = 2;
            this.btnAAngle.Text = "转动到指定角度（0-180）";
            this.btnAAngle.UseVisualStyleBackColor = true;
            this.btnAAngle.Click += new System.EventHandler(this.btnAAngle_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(91, 20);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 1;
            this.btnAuto.Text = "自动转动";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(8, 20);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "复  位";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtResponse);
            this.groupBox2.Location = new System.Drawing.Point(12, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 400);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "串口反馈消息";
            // 
            // txtResponse
            // 
            this.txtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponse.Location = new System.Drawing.Point(3, 17);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.Size = new System.Drawing.Size(419, 380);
            this.txtResponse.TabIndex = 0;
            this.txtResponse.Text = "";
            // 
            // btnDistance
            // 
            this.btnDistance.Location = new System.Drawing.Point(446, 33);
            this.btnDistance.Name = "btnDistance";
            this.btnDistance.Size = new System.Drawing.Size(88, 23);
            this.btnDistance.TabIndex = 6;
            this.btnDistance.Text = "测量距离";
            this.btnDistance.UseVisualStyleBackColor = true;
            this.btnDistance.Click += new System.EventHandler(this.btnDistance_Click);
            // 
            // picCurve
            // 
            this.picCurve.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCurve.Location = new System.Drawing.Point(3, 17);
            this.picCurve.Name = "picCurve";
            this.picCurve.Size = new System.Drawing.Size(386, 445);
            this.picCurve.TabIndex = 7;
            this.picCurve.TabStop = false;
            this.picCurve.Paint += new System.Windows.Forms.PaintEventHandler(this.picCurve_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.picCurve);
            this.groupBox3.Location = new System.Drawing.Point(443, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 465);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "曲线";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 555);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnDistance);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupDJ);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "超声波测距";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupDJ.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCurve)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboComs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenCom;
        private System.Windows.Forms.GroupBox groupDJ;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.NumericUpDown nudAngle;
        private System.Windows.Forms.Button btnAAngle;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtResponse;
        private System.Windows.Forms.Button btnDistance;
        private System.Windows.Forms.PictureBox picCurve;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

