﻿using System.Windows.Forms;

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
            this.radioButtonLatest = new System.Windows.Forms.RadioButton();
            this.radioButtonAverage = new System.Windows.Forms.RadioButton();
            this.radioButtonMaxValue = new System.Windows.Forms.RadioButton();
            this.radioButtonMinValue = new System.Windows.Forms.RadioButton();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelDataBaseName = new System.Windows.Forms.Label();
            this.labelDataBaseConnected = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelServerConnected = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConnectToServer = new System.Windows.Forms.Button();
            this.groupBoxMessage = new System.Windows.Forms.GroupBox();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRCInterval = new System.Windows.Forms.TextBox();
            this.radioButtonAutoRCN = new System.Windows.Forms.RadioButton();
            this.radioButtonAutoRC = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxMessage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(372, 106);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(159, 41);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "启动/停止发送";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonDataBaseChoose
            // 
            this.buttonDataBaseChoose.Location = new System.Drawing.Point(83, 31);
            this.buttonDataBaseChoose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDataBaseChoose.Name = "buttonDataBaseChoose";
            this.buttonDataBaseChoose.Size = new System.Drawing.Size(151, 31);
            this.buttonDataBaseChoose.TabIndex = 1;
            this.buttonDataBaseChoose.Text = "数据库文件选择";
            this.buttonDataBaseChoose.UseVisualStyleBackColor = true;
            this.buttonDataBaseChoose.Click += new System.EventHandler(this.buttonDataBaseChoose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonLatest);
            this.groupBox1.Controls.Add(this.radioButtonAverage);
            this.groupBox1.Controls.Add(this.radioButtonMaxValue);
            this.groupBox1.Controls.Add(this.radioButtonMinValue);
            this.groupBox1.Location = new System.Drawing.Point(33, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(141, 159);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据处理模式";
            // 
            // radioButtonLatest
            // 
            this.radioButtonLatest.AutoSize = true;
            this.radioButtonLatest.Location = new System.Drawing.Point(24, 115);
            this.radioButtonLatest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonLatest.Name = "radioButtonLatest";
            this.radioButtonLatest.Size = new System.Drawing.Size(73, 19);
            this.radioButtonLatest.TabIndex = 3;
            this.radioButtonLatest.TabStop = true;
            this.radioButtonLatest.Text = "最新值";
            this.radioButtonLatest.UseVisualStyleBackColor = true;
            // 
            // radioButtonAverage
            // 
            this.radioButtonAverage.AutoSize = true;
            this.radioButtonAverage.Location = new System.Drawing.Point(24, 91);
            this.radioButtonAverage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonAverage.Name = "radioButtonAverage";
            this.radioButtonAverage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButtonAverage.Size = new System.Drawing.Size(73, 19);
            this.radioButtonAverage.TabIndex = 2;
            this.radioButtonAverage.Text = "平均值";
            this.radioButtonAverage.UseVisualStyleBackColor = true;
            // 
            // radioButtonMaxValue
            // 
            this.radioButtonMaxValue.AutoSize = true;
            this.radioButtonMaxValue.Location = new System.Drawing.Point(24, 66);
            this.radioButtonMaxValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.radioButtonMinValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.textBoxInterval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.groupBox2.Controls.Add(this.labelDataBaseName);
            this.groupBox2.Controls.Add(this.labelDataBaseConnected);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.labelServerConnected);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(39, 255);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(501, 160);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "连接状态";
            // 
            // labelDataBaseName
            // 
            this.labelDataBaseName.AutoSize = true;
            this.labelDataBaseName.Location = new System.Drawing.Point(25, 106);
            this.labelDataBaseName.Name = "labelDataBaseName";
            this.labelDataBaseName.Size = new System.Drawing.Size(0, 15);
            this.labelDataBaseName.TabIndex = 4;
            // 
            // labelDataBaseConnected
            // 
            this.labelDataBaseConnected.AutoSize = true;
            this.labelDataBaseConnected.Location = new System.Drawing.Point(151, 71);
            this.labelDataBaseConnected.Name = "labelDataBaseConnected";
            this.labelDataBaseConnected.Size = new System.Drawing.Size(55, 15);
            this.labelDataBaseConnected.TabIndex = 3;
            this.labelDataBaseConnected.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 71);
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
            this.label2.Location = new System.Drawing.Point(25, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "是否接服务端:";
            // 
            // buttonConnectToServer
            // 
            this.buttonConnectToServer.Location = new System.Drawing.Point(372, 179);
            this.buttonConnectToServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonConnectToServer.Name = "buttonConnectToServer";
            this.buttonConnectToServer.Size = new System.Drawing.Size(159, 36);
            this.buttonConnectToServer.TabIndex = 7;
            this.buttonConnectToServer.Text = "连接服务端";
            this.buttonConnectToServer.UseVisualStyleBackColor = true;
            this.buttonConnectToServer.Click += new System.EventHandler(this.buttonConnectToServer_Click);
            // 
            // groupBoxMessage
            // 
            this.groupBoxMessage.Controls.Add(this.richTextBoxMessage);
            this.groupBoxMessage.Location = new System.Drawing.Point(39, 436);
            this.groupBoxMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxMessage.Name = "groupBoxMessage";
            this.groupBoxMessage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxMessage.Size = new System.Drawing.Size(500, 105);
            this.groupBoxMessage.TabIndex = 8;
            this.groupBoxMessage.TabStop = false;
            this.groupBoxMessage.Text = "消息栏";
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.Location = new System.Drawing.Point(8, 28);
            this.richTextBoxMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.ReadOnly = true;
            this.richTextBoxMessage.Size = new System.Drawing.Size(483, 62);
            this.richTextBoxMessage.TabIndex = 0;
            this.richTextBoxMessage.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxRCInterval);
            this.groupBox3.Controls.Add(this.radioButtonAutoRCN);
            this.groupBox3.Controls.Add(this.radioButtonAutoRC);
            this.groupBox3.Location = new System.Drawing.Point(197, 79);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(152, 159);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "自动重连";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "重连间隔(秒)";
            // 
            // textBoxRCInterval
            // 
            this.textBoxRCInterval.Location = new System.Drawing.Point(8, 100);
            this.textBoxRCInterval.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRCInterval.Name = "textBoxRCInterval";
            this.textBoxRCInterval.Size = new System.Drawing.Size(105, 25);
            this.textBoxRCInterval.TabIndex = 2;
            this.textBoxRCInterval.Text = "300";
            // 
            // radioButtonAutoRCN
            // 
            this.radioButtonAutoRCN.AutoSize = true;
            this.radioButtonAutoRCN.Location = new System.Drawing.Point(83, 41);
            this.radioButtonAutoRCN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonAutoRCN.Name = "radioButtonAutoRCN";
            this.radioButtonAutoRCN.Size = new System.Drawing.Size(43, 19);
            this.radioButtonAutoRCN.TabIndex = 1;
            this.radioButtonAutoRCN.Text = "否";
            this.radioButtonAutoRCN.UseVisualStyleBackColor = true;
            // 
            // radioButtonAutoRC
            // 
            this.radioButtonAutoRC.AutoSize = true;
            this.radioButtonAutoRC.Checked = true;
            this.radioButtonAutoRC.Location = new System.Drawing.Point(8, 41);
            this.radioButtonAutoRC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonAutoRC.Name = "radioButtonAutoRC";
            this.radioButtonAutoRC.Size = new System.Drawing.Size(43, 19);
            this.radioButtonAutoRC.TabIndex = 0;
            this.radioButtonAutoRC.TabStop = true;
            this.radioButtonAutoRC.Text = "是";
            this.radioButtonAutoRC.UseVisualStyleBackColor = true;
            // 
            // Sender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 562);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxMessage);
            this.Controls.Add(this.buttonConnectToServer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.textBoxInterval);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDataBaseChoose);
            this.Controls.Add(this.buttonStart);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Sender";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Close);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxMessage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonDataBaseChoose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonAverage;
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
        private RadioButton radioButtonLatest;
        private GroupBox groupBoxMessage;
        private RichTextBox richTextBoxMessage;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label labelDataBaseName;
        private GroupBox groupBox3;
        private Label label4;
        private TextBox textBoxRCInterval;
        private RadioButton radioButtonAutoRCN;
        private RadioButton radioButtonAutoRC;
    }
}

