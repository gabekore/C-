namespace Server
{
    partial class MainView
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStartService = new System.Windows.Forms.Button();
            this.BtnStopService = new System.Windows.Forms.Button();
            this.TxbLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnStartService
            // 
            this.BtnStartService.Location = new System.Drawing.Point(12, 12);
            this.BtnStartService.Name = "BtnStartService";
            this.BtnStartService.Size = new System.Drawing.Size(130, 55);
            this.BtnStartService.TabIndex = 0;
            this.BtnStartService.Text = "サービス開始";
            this.BtnStartService.UseVisualStyleBackColor = true;
            this.BtnStartService.Click += new System.EventHandler(this.BtnStartService_Click);
            // 
            // BtnStopService
            // 
            this.BtnStopService.Location = new System.Drawing.Point(157, 12);
            this.BtnStopService.Name = "BtnStopService";
            this.BtnStopService.Size = new System.Drawing.Size(130, 55);
            this.BtnStopService.TabIndex = 1;
            this.BtnStopService.Text = "サービス停止";
            this.BtnStopService.UseVisualStyleBackColor = true;
            this.BtnStopService.Click += new System.EventHandler(this.BtnStopService_Click);
            // 
            // TxbLog
            // 
            this.TxbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxbLog.Location = new System.Drawing.Point(12, 83);
            this.TxbLog.Multiline = true;
            this.TxbLog.Name = "TxbLog";
            this.TxbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxbLog.Size = new System.Drawing.Size(492, 254);
            this.TxbLog.TabIndex = 2;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 349);
            this.Controls.Add(this.TxbLog);
            this.Controls.Add(this.BtnStopService);
            this.Controls.Add(this.BtnStartService);
            this.Name = "MainView";
            this.Text = "WCF Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStartService;
        private System.Windows.Forms.Button BtnStopService;
        private System.Windows.Forms.TextBox TxbLog;
    }
}

