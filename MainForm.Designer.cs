namespace FillStorage
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFill = new System.Windows.Forms.Button();
            this.show_info = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbDevices = new System.Windows.Forms.ComboBox();
            this.txbDeviceInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rb_internal = new System.Windows.Forms.RadioButton();
            this.rb_sdcard = new System.Windows.Forms.RadioButton();
            this.txb_avail_size = new System.Windows.Forms.TextBox();
            this.btn_bugreport = new System.Windows.Forms.Button();
            this.mPushProgressBar = new System.Windows.Forms.ProgressBar();
            this.mPushProgressText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(531, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(96, 34);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "获取设备";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_refresh);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "可用内存：";
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(110, 225);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(96, 49);
            this.btnFill.TabIndex = 2;
            this.btnFill.Text = "内存填充";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_fill);
            // 
            // show_info
            // 
            this.show_info.AutoSize = true;
            this.show_info.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.show_info.ForeColor = System.Drawing.Color.Red;
            this.show_info.Location = new System.Drawing.Point(206, 187);
            this.show_info.Name = "show_info";
            this.show_info.Size = new System.Drawing.Size(0, 20);
            this.show_info.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "设备序号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "设备信息：";
            // 
            // cbbDevices
            // 
            this.cbbDevices.FormattingEnabled = true;
            this.cbbDevices.Location = new System.Drawing.Point(110, 25);
            this.cbbDevices.Name = "cbbDevices";
            this.cbbDevices.Size = new System.Drawing.Size(394, 23);
            this.cbbDevices.TabIndex = 6;
            this.cbbDevices.SelectedIndexChanged += new System.EventHandler(this.CbbDevices_SelectedIndexChanged);
            // 
            // txbDeviceInfo
            // 
            this.txbDeviceInfo.Location = new System.Drawing.Point(110, 61);
            this.txbDeviceInfo.Name = "txbDeviceInfo";
            this.txbDeviceInfo.ReadOnly = true;
            this.txbDeviceInfo.Size = new System.Drawing.Size(393, 25);
            this.txbDeviceInfo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "填充分区：";
            // 
            // rb_internal
            // 
            this.rb_internal.AutoSize = true;
            this.rb_internal.Checked = true;
            this.rb_internal.Location = new System.Drawing.Point(110, 101);
            this.rb_internal.Name = "rb_internal";
            this.rb_internal.Size = new System.Drawing.Size(88, 19);
            this.rb_internal.TabIndex = 9;
            this.rb_internal.TabStop = true;
            this.rb_internal.Text = "内部存储";
            this.rb_internal.UseVisualStyleBackColor = true;
            this.rb_internal.CheckedChanged += new System.EventHandler(this.Rb_Internal_CheckedChanged);
            // 
            // rb_sdcard
            // 
            this.rb_sdcard.AutoSize = true;
            this.rb_sdcard.Location = new System.Drawing.Point(262, 101);
            this.rb_sdcard.Name = "rb_sdcard";
            this.rb_sdcard.Size = new System.Drawing.Size(51, 19);
            this.rb_sdcard.TabIndex = 10;
            this.rb_sdcard.TabStop = true;
            this.rb_sdcard.Text = "T卡";
            this.rb_sdcard.UseVisualStyleBackColor = true;
            this.rb_sdcard.CheckedChanged += new System.EventHandler(this.Rb_Sdcard_CheckedChanged);
            // 
            // txb_avail_size
            // 
            this.txb_avail_size.Location = new System.Drawing.Point(110, 129);
            this.txb_avail_size.Name = "txb_avail_size";
            this.txb_avail_size.ReadOnly = true;
            this.txb_avail_size.Size = new System.Drawing.Size(393, 25);
            this.txb_avail_size.TabIndex = 11;
            // 
            // btn_bugreport
            // 
            this.btn_bugreport.Enabled = false;
            this.btn_bugreport.Location = new System.Drawing.Point(386, 225);
            this.btn_bugreport.Name = "btn_bugreport";
            this.btn_bugreport.Size = new System.Drawing.Size(117, 49);
            this.btn_bugreport.TabIndex = 12;
            this.btn_bugreport.Text = "抓取Bugreport";
            this.btn_bugreport.UseVisualStyleBackColor = true;
            this.btn_bugreport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_Bugreport);
            // 
            // mPushProgressBar
            // 
            this.mPushProgressBar.Location = new System.Drawing.Point(110, 161);
            this.mPushProgressBar.Name = "mPushProgressBar";
            this.mPushProgressBar.Size = new System.Drawing.Size(393, 23);
            this.mPushProgressBar.Step = 1;
            this.mPushProgressBar.TabIndex = 13;
            // 
            // mPushProgressText
            // 
            this.mPushProgressText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.mPushProgressText.BackColor = System.Drawing.Color.Transparent;
            this.mPushProgressText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mPushProgressText.Location = new System.Drawing.Point(506, 161);
            this.mPushProgressText.Margin = new System.Windows.Forms.Padding(0);
            this.mPushProgressText.Name = "mPushProgressText";
            this.mPushProgressText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mPushProgressText.Size = new System.Drawing.Size(56, 23);
            this.mPushProgressText.TabIndex = 14;
            this.mPushProgressText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(655, 286);
            this.Controls.Add(this.mPushProgressText);
            this.Controls.Add(this.mPushProgressBar);
            this.Controls.Add(this.btn_bugreport);
            this.Controls.Add(this.txb_avail_size);
            this.Controls.Add(this.rb_sdcard);
            this.Controls.Add(this.rb_internal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbDeviceInfo);
            this.Controls.Add(this.cbbDevices);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.show_info);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "内存填充工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Label show_info;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbDevices;
        private System.Windows.Forms.TextBox txbDeviceInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rb_internal;
        private System.Windows.Forms.RadioButton rb_sdcard;
        private System.Windows.Forms.TextBox txb_avail_size;
        private System.Windows.Forms.Button btn_bugreport;
        private System.Windows.Forms.ProgressBar mPushProgressBar;
        private System.Windows.Forms.Label mPushProgressText;
    }
}

