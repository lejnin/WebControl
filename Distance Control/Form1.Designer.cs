namespace WebControlApplication
{
    partial class GeneralForm
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

            server.Stop();

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralForm));
            this.labelIp = new System.Windows.Forms.Label();
            this.displayCode = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.inputIp = new System.Windows.Forms.TextBox();
            this.inputPort = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.buttonCloseConnect = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIp
            // 
            this.labelIp.AutoSize = true;
            this.labelIp.Location = new System.Drawing.Point(12, 9);
            this.labelIp.Name = "labelIp";
            this.labelIp.Size = new System.Drawing.Size(20, 13);
            this.labelIp.TabIndex = 1;
            this.labelIp.Text = "IP:";
            // 
            // displayCode
            // 
            this.displayCode.AutoSize = true;
            this.displayCode.Location = new System.Drawing.Point(16, 91);
            this.displayCode.Name = "displayCode";
            this.displayCode.Size = new System.Drawing.Size(0, 13);
            this.displayCode.TabIndex = 4;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(104, 51);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(74, 23);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "Open";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // inputIp
            // 
            this.inputIp.Location = new System.Drawing.Point(12, 25);
            this.inputIp.Name = "inputIp";
            this.inputIp.Size = new System.Drawing.Size(143, 20);
            this.inputIp.TabIndex = 6;
            // 
            // inputPort
            // 
            this.inputPort.Location = new System.Drawing.Point(185, 25);
            this.inputPort.Name = "inputPort";
            this.inputPort.Size = new System.Drawing.Size(87, 20);
            this.inputPort.TabIndex = 7;
            this.inputPort.Text = "8080";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(182, 9);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(29, 13);
            this.labelPort.TabIndex = 8;
            this.labelPort.Text = "Port:";
            // 
            // buttonCloseConnect
            // 
            this.buttonCloseConnect.Enabled = false;
            this.buttonCloseConnect.Location = new System.Drawing.Point(185, 51);
            this.buttonCloseConnect.Name = "buttonCloseConnect";
            this.buttonCloseConnect.Size = new System.Drawing.Size(87, 23);
            this.buttonCloseConnect.TabIndex = 9;
            this.buttonCloseConnect.Text = "Close";
            this.buttonCloseConnect.UseVisualStyleBackColor = true;
            this.buttonCloseConnect.Click += new System.EventHandler(this.ButtonCloseConnect_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.Location = new System.Drawing.Point(12, 91);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(260, 108);
            this.textBoxLog.TabIndex = 11;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipTitle = "WEB Control";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "WEB Control";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 51);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(86, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonCloseConnect);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.inputPort);
            this.Controls.Add(this.inputIp);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.displayCode);
            this.Controls.Add(this.labelIp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.Name = "GeneralForm";
            this.Text = "WEB Controller";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();
            this.ShowInTaskbar = false;

        }
        #endregion
        private System.Windows.Forms.Label labelIp;
        private System.Windows.Forms.Label displayCode;
        private System.Windows.Forms.Button buttonConnect;
        public System.Windows.Forms.TextBox inputIp;
        public System.Windows.Forms.TextBox inputPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Button buttonCloseConnect;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button buttonSave;
    }
}

