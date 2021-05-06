
namespace HomeWork10
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbStartUrl = new System.Windows.Forms.TextBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.rtbCrawlInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(56, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始网址：";
            // 
            // tbStartUrl
            // 
            this.tbStartUrl.Location = new System.Drawing.Point(155, 64);
            this.tbStartUrl.Name = "tbStartUrl";
            this.tbStartUrl.Size = new System.Drawing.Size(389, 25);
            this.tbStartUrl.TabIndex = 1;
            // 
            // btnAction
            // 
            this.btnAction.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAction.Location = new System.Drawing.Point(595, 59);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(128, 31);
            this.btnAction.TabIndex = 2;
            this.btnAction.Text = "启动爬虫";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // rtbCrawlInfo
            // 
            this.rtbCrawlInfo.Location = new System.Drawing.Point(60, 113);
            this.rtbCrawlInfo.Name = "rtbCrawlInfo";
            this.rtbCrawlInfo.Size = new System.Drawing.Size(683, 339);
            this.rtbCrawlInfo.TabIndex = 3;
            this.rtbCrawlInfo.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 515);
            this.Controls.Add(this.rtbCrawlInfo);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.tbStartUrl);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStartUrl;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.RichTextBox rtbCrawlInfo;
    }
}

