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
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDataBaseChoose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonMinValue = new System.Windows.Forms.RadioButton();
            this.radioButtonMaxValue = new System.Windows.Forms.RadioButton();
            this.u = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "启动/停止发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonDataBaseChoose
            // 
            this.buttonDataBaseChoose.Location = new System.Drawing.Point(34, 32);
            this.buttonDataBaseChoose.Name = "buttonDataBaseChoose";
            this.buttonDataBaseChoose.Size = new System.Drawing.Size(137, 23);
            this.buttonDataBaseChoose.TabIndex = 1;
            this.buttonDataBaseChoose.Text = "数据库文件选择";
            this.buttonDataBaseChoose.UseVisualStyleBackColor = true;
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
            // radioButtonMinValue
            // 
            this.radioButtonMinValue.AutoSize = true;
            this.radioButtonMinValue.Location = new System.Drawing.Point(63, 39);
            this.radioButtonMinValue.Name = "radioButtonMinValue";
            this.radioButtonMinValue.Size = new System.Drawing.Size(73, 19);
            this.radioButtonMinValue.TabIndex = 0;
            this.radioButtonMinValue.TabStop = true;
            this.radioButtonMinValue.Text = "最小值";
            this.radioButtonMinValue.UseVisualStyleBackColor = true;
            // 
            // radioButtonMaxValue
            // 
            this.radioButtonMaxValue.AutoSize = true;
            this.radioButtonMaxValue.Location = new System.Drawing.Point(63, 79);
            this.radioButtonMaxValue.Name = "radioButtonMaxValue";
            this.radioButtonMaxValue.Size = new System.Drawing.Size(73, 19);
            this.radioButtonMaxValue.TabIndex = 1;
            this.radioButtonMaxValue.TabStop = true;
            this.radioButtonMaxValue.Text = "最大值";
            this.radioButtonMaxValue.UseVisualStyleBackColor = true;
            // 
            // u
            // 
            this.u.AutoSize = true;
            this.u.Location = new System.Drawing.Point(63, 115);
            this.u.Name = "u";
            this.u.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.u.Size = new System.Drawing.Size(73, 19);
            this.u.TabIndex = 2;
            this.u.TabStop = true;
            this.u.Text = "平均值";
            this.u.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(431, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 3;
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
            // Sender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 263);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonDataBaseChoose);
            this.Controls.Add(this.button1);
            this.Name = "Sender";
            this.Text = "Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            this.FormClosing += new FormClosingEventHandler(this.Close);

        }

        #endregion


        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDataBaseChoose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton u;
        private System.Windows.Forms.RadioButton radioButtonMaxValue;
        private System.Windows.Forms.RadioButton radioButtonMinValue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
    }
}

