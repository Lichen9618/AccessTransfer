using System.Windows.Forms;

namespace AccessTransferServer
{
    partial class Receiver
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.richTextBoxConnectionPool = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 307);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "启动/停止接受";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(19, 17);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(371, 260);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            // 
            // richTextBoxConnectionPool
            // 
            this.richTextBoxConnectionPool.Location = new System.Drawing.Point(407, 17);
            this.richTextBoxConnectionPool.Name = "richTextBoxConnectionPool";
            this.richTextBoxConnectionPool.Size = new System.Drawing.Size(230, 260);
            this.richTextBoxConnectionPool.TabIndex = 2;
            this.richTextBoxConnectionPool.Text = "";
            // 
            // Receiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 380);
            this.Controls.Add(this.richTextBoxConnectionPool);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Receiver";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.RichTextBox richTextBox;
        private RichTextBox richTextBoxConnectionPool;
    }
}

