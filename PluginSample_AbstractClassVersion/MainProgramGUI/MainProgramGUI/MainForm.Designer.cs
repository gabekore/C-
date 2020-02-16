namespace MainProgramGUI
{
    partial class MainForm
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
            this.listLog = new System.Windows.Forms.ListBox();
            this.btnThreadStart = new System.Windows.Forms.Button();
            this.btnThreadStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listLog
            // 
            this.listLog.FormattingEnabled = true;
            this.listLog.HorizontalScrollbar = true;
            this.listLog.ItemHeight = 12;
            this.listLog.Location = new System.Drawing.Point(12, 55);
            this.listLog.Name = "listLog";
            this.listLog.ScrollAlwaysVisible = true;
            this.listLog.Size = new System.Drawing.Size(630, 388);
            this.listLog.TabIndex = 4;
            // 
            // btnThreadStart
            // 
            this.btnThreadStart.Location = new System.Drawing.Point(12, 12);
            this.btnThreadStart.Name = "btnThreadStart";
            this.btnThreadStart.Size = new System.Drawing.Size(153, 37);
            this.btnThreadStart.TabIndex = 0;
            this.btnThreadStart.Text = "Thread Start";
            this.btnThreadStart.UseVisualStyleBackColor = true;
            this.btnThreadStart.Click += new System.EventHandler(this.btnThreadStart_Click);
            // 
            // btnThreadStop
            // 
            this.btnThreadStop.Location = new System.Drawing.Point(171, 12);
            this.btnThreadStop.Name = "btnThreadStop";
            this.btnThreadStop.Size = new System.Drawing.Size(153, 37);
            this.btnThreadStop.TabIndex = 1;
            this.btnThreadStop.Text = "Thread Stop";
            this.btnThreadStop.UseVisualStyleBackColor = true;
            this.btnThreadStop.Click += new System.EventHandler(this.btnThreadStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 452);
            this.Controls.Add(this.btnThreadStop);
            this.Controls.Add(this.btnThreadStart);
            this.Controls.Add(this.listLog);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plugin Sample";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.Button btnThreadStart;
        private System.Windows.Forms.Button btnThreadStop;
    }
}

