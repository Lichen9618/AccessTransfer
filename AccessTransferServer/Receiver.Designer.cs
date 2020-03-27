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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDataBaseConfig = new System.Windows.Forms.Button();
            this.labelDataBaseConnection = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 205);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "启动/停止接受";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(13, 11);
            this.richTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(249, 175);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            // 
            // richTextBoxConnectionPool
            // 
            this.richTextBoxConnectionPool.Location = new System.Drawing.Point(271, 11);
            this.richTextBoxConnectionPool.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxConnectionPool.Name = "richTextBoxConnectionPool";
            this.richTextBoxConnectionPool.Size = new System.Drawing.Size(155, 175);
            this.richTextBoxConnectionPool.TabIndex = 2;
            this.richTextBoxConnectionPool.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDataBaseConfig);
            this.groupBox1.Controls.Add(this.labelDataBaseConnection);
            this.groupBox1.Location = new System.Drawing.Point(13, 249);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(412, 106);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库连接状态";
            // 
            // buttonDataBaseConfig
            // 
            this.buttonDataBaseConfig.Location = new System.Drawing.Point(23, 63);
            this.buttonDataBaseConfig.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDataBaseConfig.Name = "buttonDataBaseConfig";
            this.buttonDataBaseConfig.Size = new System.Drawing.Size(100, 23);
            this.buttonDataBaseConfig.TabIndex = 1;
            this.buttonDataBaseConfig.Text = "配置数据库";
            this.buttonDataBaseConfig.UseVisualStyleBackColor = true;
            this.buttonDataBaseConfig.Click += new System.EventHandler(this.buttonDataBaseConfig_Click);
            // 
            // labelDataBaseConnection
            // 
            this.labelDataBaseConnection.AutoSize = true;
            this.labelDataBaseConnection.Location = new System.Drawing.Point(30, 34);
            this.labelDataBaseConnection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDataBaseConnection.Name = "labelDataBaseConnection";
            this.labelDataBaseConnection.Size = new System.Drawing.Size(77, 12);
            this.labelDataBaseConnection.TabIndex = 0;
            this.labelDataBaseConnection.Text = "数据库未连接";
            // 
            // Receiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 369);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBoxConnectionPool);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Receiver";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.RichTextBox richTextBox;
        private RichTextBox richTextBoxConnectionPool;
        private GroupBox groupBox1;
        private Button buttonDataBaseConfig;
        private Label labelDataBaseConnection;
    }
}

