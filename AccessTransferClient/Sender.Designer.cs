using System.Windows.Forms;

namespace AccessTransferClient
{
    partial class Sender
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonDataBaseChoose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.u = new System.Windows.Forms.RadioButton();
            this.radioButtonMaxValue = new System.Windows.Forms.RadioButton();
            this.radioButtonMinValue = new System.Windows.Forms.RadioButton();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelDataBaseConnected = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelServerConnected = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConnectToServer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(372, 107);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(159, 42);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "启动/停止发送";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonDataBaseChoose
            // 
            this.buttonDataBaseChoose.Location = new System.Drawing.Point(83, 32);
            this.buttonDataBaseChoose.Name = "buttonDataBaseChoose";
            this.buttonDataBaseChoose.Size = new System.Drawing.Size(151, 32);
            this.buttonDataBaseChoose.TabIndex = 1;
            this.buttonDataBaseChoose.Text = "数据库文件选择";
            this.buttonDataBaseChoose.UseVisualStyleBackColor = true;
            this.buttonDataBaseChoose.Click += new System.EventHandler(this.buttonDataBaseChoose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.u);
            this.groupBox1.Controls.Add(this.radioButtonMaxValue);
            this.groupBox1.Controls.Add(this.radioButtonMinValue);
            this.groupBox1.Location = new System.Drawing.Point(34, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 159);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据处理模式";
            // 
            // u
            // 
            this.u.AutoSize = true;
            this.u.Location = new System.Drawing.Point(24, 91);
            this.u.Name = "u";
            this.u.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.u.Size = new System.Drawing.Size(73, 19);
            this.u.TabIndex = 2;
            this.u.Text = "平均值";
            this.u.UseVisualStyleBackColor = true;
            // 
            // radioButtonMaxValue
            // 
            this.radioButtonMaxValue.AutoSize = true;
            this.radioButtonMaxValue.Location = new System.Drawing.Point(24, 66);
            this.radioButtonMaxValue.Name = "radioButtonMaxValue";
            this.radioButtonMaxValue.Size = new System.Drawing.Size(73, 19);
            this.radioButtonMaxValue.TabIndex = 1;
            this.radioButtonMaxValue.Text = "最大值";
            this.radioButtonMaxValue.UseVisualStyleBackColor = true;
            // 
            // radioButtonMinValue
            // 
            this.radioButtonMinValue.AutoSize = true;
            this.radioButtonMinValue.Checked = true;
            this.radioButtonMinValue.Location = new System.Drawing.Point(24, 41);
            this.radioButtonMinValue.Name = "radioButtonMinValue";
            this.radioButtonMinValue.Size = new System.Drawing.Size(73, 19);
            this.radioButtonMinValue.TabIndex = 0;
            this.radioButtonMinValue.TabStop = true;
            this.radioButtonMinValue.Text = "最小值";
            this.radioButtonMinValue.UseVisualStyleBackColor = true;
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(431, 46);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(100, 25);
            this.textBoxInterval.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(320, 49);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(105, 15);
            this.label.TabIndex = 4;
            this.label.Text = "数据采集间隔:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(537, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "秒";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelDataBaseConnected);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelServerConnected);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(39, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(501, 160);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "连接状态";
            // 
            // labelDataBaseConnected
            // 
            this.labelDataBaseConnected.AutoSize = true;
            this.labelDataBaseConnected.Location = new System.Drawing.Point(151, 97);
            this.labelDataBaseConnected.Name = "labelDataBaseConnected";
            this.labelDataBaseConnected.Size = new System.Drawing.Size(55, 15);
            this.labelDataBaseConnected.TabIndex = 3;
            this.labelDataBaseConnected.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "是否连接数据库:";
            // 
            // labelServerConnected
            // 
            this.labelServerConnected.AutoSize = true;
            this.labelServerConnected.Location = new System.Drawing.Point(151, 40);
            this.labelServerConnected.Name = "labelServerConnected";
            this.labelServerConnected.Size = new System.Drawing.Size(55, 15);
            this.labelServerConnected.TabIndex = 1;
            this.labelServerConnected.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "是否接服务端:";
            // 
            // buttonConnectToServer
            // 
            this.buttonConnectToServer.Location = new System.Drawing.Point(372, 178);
            this.buttonConnectToServer.Name = "buttonConnectToServer";
            this.buttonConnectToServer.Size = new System.Drawing.Size(159, 37);
            this.buttonConnectToServer.TabIndex = 7;
            this.buttonConnectToServer.Text = "连接服务端";
            this.buttonConnectToServer.UseVisualStyleBackColor = true;
            this.buttonConnectToServer.Click += new System.EventHandler(this.buttonConnectToServer_Click);
            // 
            // Sender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 441);
            this.Controls.Add(this.buttonConnectToServer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.textBoxInterval);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDataBaseChoose);
            this.Controls.Add(this.buttonStart);
            this.Name = "Sender";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Close);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonDataBaseChoose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton u;
        private System.Windows.Forms.RadioButton radioButtonMaxValue;
        private System.Windows.Forms.RadioButton radioButtonMinValue;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private GroupBox groupBox2;
        private Label labelServerConnected;
        private Label label2;
        private Label labelDataBaseConnected;
        private Label label3;
        private Button buttonConnectToServer;
    }
}

