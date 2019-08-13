/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/4/16
 * Time: 14:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace P_F_Interface
{
	partial class ParameterSet_Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox maxdistance;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox filtererror;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox lenerror;
		private System.Windows.Forms.TextBox xyerror;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox maxpointnum;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox packagetype;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox watchdogtimeout;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox timetorance;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox filterwidth;
		private System.Windows.Forms.ComboBox filtertype;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.filterwidth = new System.Windows.Forms.ComboBox();
			this.filtertype = new System.Windows.Forms.ComboBox();
			this.timetorance = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.filtererror = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.maxdistance = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lenerror = new System.Windows.Forms.TextBox();
			this.xyerror = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.maxpointnum = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.packagetype = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.watchdogtimeout = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ip = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.button2);
			this.splitContainer1.Panel2.Controls.Add(this.button1);
			this.splitContainer1.Size = new System.Drawing.Size(891, 546);
			this.splitContainer1.SplitterDistance = 754;
			this.splitContainer1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.filterwidth);
			this.groupBox2.Controls.Add(this.filtertype);
			this.groupBox2.Controls.Add(this.timetorance);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.filtererror);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.maxdistance);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.lenerror);
			this.groupBox2.Controls.Add(this.xyerror);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Location = new System.Drawing.Point(6, 232);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(741, 300);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "数据处理设置";
			// 
			// filterwidth
			// 
			this.filterwidth.AutoCompleteCustomSource.AddRange(new string[] {
			"remission",
			"none"});
			this.filterwidth.FormattingEnabled = true;
			this.filterwidth.Items.AddRange(new object[] {
			"2",
			"4",
			"8",
			"16"});
			this.filterwidth.Location = new System.Drawing.Point(159, 78);
			this.filterwidth.Name = "filterwidth";
			this.filterwidth.Size = new System.Drawing.Size(195, 23);
			this.filterwidth.TabIndex = 25;
			this.filterwidth.Text = "16";
			// 
			// filtertype
			// 
			this.filtertype.FormattingEnabled = true;
			this.filtertype.Items.AddRange(new object[] {
			"remission",
			"none"});
			this.filtertype.Location = new System.Drawing.Point(159, 34);
			this.filtertype.Name = "filtertype";
			this.filtertype.Size = new System.Drawing.Size(195, 23);
			this.filtertype.TabIndex = 24;
			this.filtertype.Text = "remission";
			this.filtertype.SelectedIndexChanged += new System.EventHandler(this.FiltertypeSelectedIndexChanged);
			// 
			// timetorance
			// 
			this.timetorance.Location = new System.Drawing.Point(159, 126);
			this.timetorance.Name = "timetorance";
			this.timetorance.Size = new System.Drawing.Size(195, 25);
			this.timetorance.TabIndex = 23;
			this.timetorance.Text = "3";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(9, 81);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(118, 23);
			this.label7.TabIndex = 22;
			this.label7.Text = "滤波宽度:";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(4, 129);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(169, 23);
			this.label10.TabIndex = 21;
			this.label10.Text = "反光柱识别时间容差:";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(9, 32);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(118, 23);
			this.label11.TabIndex = 18;
			this.label11.Text = "滤波类型:";
			// 
			// filtererror
			// 
			this.filtererror.Location = new System.Drawing.Point(543, 126);
			this.filtererror.Name = "filtererror";
			this.filtererror.Size = new System.Drawing.Size(195, 25);
			this.filtererror.TabIndex = 17;
			this.filtererror.Text = "10";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(393, 81);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(118, 23);
			this.label9.TabIndex = 16;
			this.label9.Text = "识别偏差阀值2:";
			// 
			// maxdistance
			// 
			this.maxdistance.Location = new System.Drawing.Point(543, 173);
			this.maxdistance.Name = "maxdistance";
			this.maxdistance.Size = new System.Drawing.Size(195, 25);
			this.maxdistance.TabIndex = 15;
			this.maxdistance.Text = "100000";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(393, 173);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(174, 23);
			this.label5.TabIndex = 14;
			this.label5.Text = "探测最大距离（mm）:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(393, 129);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 12;
			this.label6.Text = "结果滤波阀值1 :";
			// 
			// lenerror
			// 
			this.lenerror.Location = new System.Drawing.Point(543, 84);
			this.lenerror.Name = "lenerror";
			this.lenerror.Size = new System.Drawing.Size(195, 25);
			this.lenerror.TabIndex = 11;
			this.lenerror.Text = "60";
			// 
			// xyerror
			// 
			this.xyerror.Location = new System.Drawing.Point(543, 32);
			this.xyerror.Name = "xyerror";
			this.xyerror.Size = new System.Drawing.Size(195, 25);
			this.xyerror.TabIndex = 9;
			this.xyerror.Text = "60";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(393, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(118, 23);
			this.label8.TabIndex = 8;
			this.label8.Text = "识别偏差阀值1:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.maxpointnum);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.packagetype);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.watchdogtimeout);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.ip);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(6, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(741, 223);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "基本参数设置";
			// 
			// maxpointnum
			// 
			this.maxpointnum.FormattingEnabled = true;
			this.maxpointnum.Items.AddRange(new object[] {
			"980",
			"15260"});
			this.maxpointnum.Location = new System.Drawing.Point(527, 78);
			this.maxpointnum.Name = "maxpointnum";
			this.maxpointnum.Size = new System.Drawing.Size(195, 23);
			this.maxpointnum.TabIndex = 16;
			this.maxpointnum.Text = "980";
			this.maxpointnum.SelectedIndexChanged += new System.EventHandler(this.MaxpointnumSelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(393, 81);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(118, 23);
			this.label4.TabIndex = 14;
			this.label4.Text = "最大输出点数:";
			// 
			// packagetype
			// 
			this.packagetype.FormattingEnabled = true;
			this.packagetype.Items.AddRange(new object[] {
			"A",
			"B",
			"C"});
			this.packagetype.Location = new System.Drawing.Point(527, 29);
			this.packagetype.Name = "packagetype";
			this.packagetype.Size = new System.Drawing.Size(195, 23);
			this.packagetype.TabIndex = 13;
			this.packagetype.Text = "A";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(393, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(118, 23);
			this.label3.TabIndex = 12;
			this.label3.Text = "输出数据类型:";
			// 
			// watchdogtimeout
			// 
			this.watchdogtimeout.Location = new System.Drawing.Point(159, 76);
			this.watchdogtimeout.Name = "watchdogtimeout";
			this.watchdogtimeout.Size = new System.Drawing.Size(195, 25);
			this.watchdogtimeout.TabIndex = 11;
			this.watchdogtimeout.Text = "4000";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "访问超时（毫秒）:";
			// 
			// ip
			// 
			this.ip.Location = new System.Drawing.Point(159, 24);
			this.ip.Name = "ip";
			this.ip.Size = new System.Drawing.Size(195, 25);
			this.ip.TabIndex = 9;
			this.ip.Text = "192.168.0.3";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Lidar_IP:";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Red;
			this.button2.Location = new System.Drawing.Point(3, 339);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(116, 42);
			this.button2.TabIndex = 19;
			this.button2.Text = "设置";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Red;
			this.button1.Location = new System.Drawing.Point(3, 168);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(116, 42);
			this.button1.TabIndex = 18;
			this.button1.Text = "编辑";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// ParameterSet_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(891, 546);
			this.Controls.Add(this.splitContainer1);
			this.Name = "ParameterSet_Form";
			this.Text = "参数设置";
			this.Load += new System.EventHandler(this.ParameterSet_FormLoad);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
