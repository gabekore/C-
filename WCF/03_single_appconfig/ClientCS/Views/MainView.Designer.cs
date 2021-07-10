namespace ClientCS
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
            this.BtnHelloWorld = new System.Windows.Forms.Button();
            this.BtnCalcPlus = new System.Windows.Forms.Button();
            this.BtnCalcMinus = new System.Windows.Forms.Button();
            this.BtnUseTuple = new System.Windows.Forms.Button();
            this.BtnUseClass = new System.Windows.Forms.Button();
            this.BtnUseListClass = new System.Windows.Forms.Button();
            this.BtnUseArray = new System.Windows.Forms.Button();
            this.TxbLog = new System.Windows.Forms.TextBox();
            this.BtnOverLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnHelloWorld
            // 
            this.BtnHelloWorld.Location = new System.Drawing.Point(12, 12);
            this.BtnHelloWorld.Name = "BtnHelloWorld";
            this.BtnHelloWorld.Size = new System.Drawing.Size(120, 45);
            this.BtnHelloWorld.TabIndex = 0;
            this.BtnHelloWorld.Text = "HelloWorld";
            this.BtnHelloWorld.UseVisualStyleBackColor = true;
            this.BtnHelloWorld.Click += new System.EventHandler(this.BtnHelloWorld_Click);
            // 
            // BtnCalcPlus
            // 
            this.BtnCalcPlus.Location = new System.Drawing.Point(12, 81);
            this.BtnCalcPlus.Name = "BtnCalcPlus";
            this.BtnCalcPlus.Size = new System.Drawing.Size(120, 45);
            this.BtnCalcPlus.TabIndex = 1;
            this.BtnCalcPlus.Text = "CalcPlus";
            this.BtnCalcPlus.UseVisualStyleBackColor = true;
            this.BtnCalcPlus.Click += new System.EventHandler(this.BtnCalcPlus_Click);
            // 
            // BtnCalcMinus
            // 
            this.BtnCalcMinus.Location = new System.Drawing.Point(12, 143);
            this.BtnCalcMinus.Name = "BtnCalcMinus";
            this.BtnCalcMinus.Size = new System.Drawing.Size(120, 45);
            this.BtnCalcMinus.TabIndex = 2;
            this.BtnCalcMinus.Text = "CalcMinus";
            this.BtnCalcMinus.UseVisualStyleBackColor = true;
            this.BtnCalcMinus.Click += new System.EventHandler(this.BtnCalcMinus_Click);
            // 
            // BtnUseTuple
            // 
            this.BtnUseTuple.Location = new System.Drawing.Point(12, 208);
            this.BtnUseTuple.Name = "BtnUseTuple";
            this.BtnUseTuple.Size = new System.Drawing.Size(120, 45);
            this.BtnUseTuple.TabIndex = 3;
            this.BtnUseTuple.Text = "UseTuple";
            this.BtnUseTuple.UseVisualStyleBackColor = true;
            this.BtnUseTuple.Click += new System.EventHandler(this.BtnUseTuple_Click);
            // 
            // BtnUseClass
            // 
            this.BtnUseClass.Location = new System.Drawing.Point(159, 12);
            this.BtnUseClass.Name = "BtnUseClass";
            this.BtnUseClass.Size = new System.Drawing.Size(120, 45);
            this.BtnUseClass.TabIndex = 6;
            this.BtnUseClass.Text = "UseClass";
            this.BtnUseClass.UseVisualStyleBackColor = true;
            this.BtnUseClass.Click += new System.EventHandler(this.BtnUseClass_Click);
            // 
            // BtnUseListClass
            // 
            this.BtnUseListClass.Location = new System.Drawing.Point(159, 81);
            this.BtnUseListClass.Name = "BtnUseListClass";
            this.BtnUseListClass.Size = new System.Drawing.Size(120, 45);
            this.BtnUseListClass.TabIndex = 5;
            this.BtnUseListClass.Text = "UseListClass";
            this.BtnUseListClass.UseVisualStyleBackColor = true;
            this.BtnUseListClass.Click += new System.EventHandler(this.BtnUseListClass_Click);
            // 
            // BtnUseArray
            // 
            this.BtnUseArray.Location = new System.Drawing.Point(159, 143);
            this.BtnUseArray.Name = "BtnUseArray";
            this.BtnUseArray.Size = new System.Drawing.Size(120, 45);
            this.BtnUseArray.TabIndex = 4;
            this.BtnUseArray.Text = "UseArray";
            this.BtnUseArray.UseVisualStyleBackColor = true;
            this.BtnUseArray.Click += new System.EventHandler(this.BtnUseArray_Click);
            // 
            // TxbLog
            // 
            this.TxbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxbLog.Location = new System.Drawing.Point(12, 282);
            this.TxbLog.Multiline = true;
            this.TxbLog.Name = "TxbLog";
            this.TxbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxbLog.Size = new System.Drawing.Size(530, 215);
            this.TxbLog.TabIndex = 7;
            // 
            // BtnOverLoad
            // 
            this.BtnOverLoad.Location = new System.Drawing.Point(159, 208);
            this.BtnOverLoad.Name = "BtnOverLoad";
            this.BtnOverLoad.Size = new System.Drawing.Size(120, 45);
            this.BtnOverLoad.TabIndex = 8;
            this.BtnOverLoad.Text = "OverLoad";
            this.BtnOverLoad.UseVisualStyleBackColor = true;
            this.BtnOverLoad.Click += new System.EventHandler(this.BtnOverLoad_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 509);
            this.Controls.Add(this.BtnOverLoad);
            this.Controls.Add(this.TxbLog);
            this.Controls.Add(this.BtnUseClass);
            this.Controls.Add(this.BtnUseListClass);
            this.Controls.Add(this.BtnUseArray);
            this.Controls.Add(this.BtnUseTuple);
            this.Controls.Add(this.BtnCalcMinus);
            this.Controls.Add(this.BtnCalcPlus);
            this.Controls.Add(this.BtnHelloWorld);
            this.Name = "MainView";
            this.Text = "WCF Client C#";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnHelloWorld;
        private System.Windows.Forms.Button BtnCalcPlus;
        private System.Windows.Forms.Button BtnCalcMinus;
        private System.Windows.Forms.Button BtnUseTuple;
        private System.Windows.Forms.Button BtnUseClass;
        private System.Windows.Forms.Button BtnUseListClass;
        private System.Windows.Forms.Button BtnUseArray;
        private System.Windows.Forms.TextBox TxbLog;
        private System.Windows.Forms.Button BtnOverLoad;
    }
}

