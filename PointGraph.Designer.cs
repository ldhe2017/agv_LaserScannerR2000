/*
 * Created by SharpDevelop.
 * User: ZJUCAOBIN
 * Date: 2019/3/20
 * Time: 13:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace P_F_Interface
{
	partial class PointGraph
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.DataGridView lidardatadgv;
		private System.Windows.Forms.DataGridViewTextBoxColumn Distance;
		private System.Windows.Forms.DataGridViewTextBoxColumn Angle;
		private System.Windows.Forms.DataGridViewTextBoxColumn X;
		private System.Windows.Forms.DataGridViewTextBoxColumn Y;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 导入外部数据ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 连接PFLidarToolStripMenuItem;
		private System.Windows.Forms.PictureBox cloudgraph;
		private System.Windows.Forms.DataGridViewTextBoxColumn Index;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem 命令ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 绘图ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem;
		private System.Windows.Forms.TextBox orginpoint;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem 重绘坐标系ToolStripMenuItem;
		private System.Windows.Forms.TextBox angletem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox palartem;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripMenuItem 绘制障碍物ToolStripMenuItem;
		
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
			this.lidardatadgv = new System.Windows.Forms.DataGridView();
			this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Angle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.angletem = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.palartem = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.orginpoint = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cloudgraph = new System.Windows.Forms.PictureBox();
			this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.导入外部数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.连接PFLidarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.命令ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.绘图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.重绘坐标系ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.绘制障碍物ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lidardatadgv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cloudgraph)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 28);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lidardatadgv);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.angletem);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.palartem);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.orginpoint);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.cloudgraph);
			this.splitContainer1.Size = new System.Drawing.Size(1875, 931);
			this.splitContainer1.SplitterDistance = 625;
			this.splitContainer1.TabIndex = 8;
			// 
			// lidardatadgv
			// 
			this.lidardatadgv.BackgroundColor = System.Drawing.Color.White;
			this.lidardatadgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.lidardatadgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.lidardatadgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.Index,
			this.Distance,
			this.Angle,
			this.X,
			this.Y});
			this.lidardatadgv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lidardatadgv.Location = new System.Drawing.Point(0, 0);
			this.lidardatadgv.Name = "lidardatadgv";
			this.lidardatadgv.RowHeadersVisible = false;
			this.lidardatadgv.RowTemplate.Height = 27;
			this.lidardatadgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.lidardatadgv.Size = new System.Drawing.Size(640, 900);
			this.lidardatadgv.TabIndex = 9;
			this.lidardatadgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LidardatadgvCellContentClick);
			// 
			// Index
			// 
			this.Index.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Index.DataPropertyName = "Index";
			this.Index.FillWeight = 20F;
			this.Index.HeaderText = "序号";
			this.Index.MaxInputLength = 327678;
			this.Index.Name = "Index";
			this.Index.Width = 90;
			// 
			// Distance
			// 
			this.Distance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Distance.DataPropertyName = "Distance";
			this.Distance.FillWeight = 20F;
			this.Distance.HeaderText = "距离/mm";
			this.Distance.Name = "Distance";
			this.Distance.Width = 97;
			// 
			// Angle
			// 
			this.Angle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Angle.DataPropertyName = "Angle";
			this.Angle.FillWeight = 18.90954F;
			this.Angle.HeaderText = "角度/deg";
			this.Angle.Name = "Angle";
			this.Angle.Width = 97;
			// 
			// X
			// 
			this.X.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.X.DataPropertyName = "X";
			this.X.FillWeight = 20F;
			this.X.HeaderText = "X(mm)";
			this.X.Name = "X";
			this.X.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.X.Width = 97;
			// 
			// Y
			// 
			this.Y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Y.DataPropertyName = "Y";
			this.Y.FillWeight = 20F;
			this.Y.HeaderText = "Y(mm)";
			this.Y.Name = "Y";
			this.Y.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Y.Width = 97;
			// 
			// angletem
			// 
			this.angletem.Location = new System.Drawing.Point(1151, 37);
			this.angletem.Name = "angletem";
			this.angletem.Size = new System.Drawing.Size(92, 25);
			this.angletem.TabIndex = 17;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(1084, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 16;
			this.label3.Text = "Angle:";
			// 
			// palartem
			// 
			this.palartem.Location = new System.Drawing.Point(1151, 6);
			this.palartem.Name = "palartem";
			this.palartem.Size = new System.Drawing.Size(92, 25);
			this.palartem.TabIndex = 15;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(1084, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 14;
			this.label2.Text = "Polar:";
			// 
			// orginpoint
			// 
			this.orginpoint.Location = new System.Drawing.Point(969, 1);
			this.orginpoint.Name = "orginpoint";
			this.orginpoint.Size = new System.Drawing.Size(92, 25);
			this.orginpoint.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(902, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 12;
			this.label1.Text = "AGV坐标";
			this.label1.Click += new System.EventHandler(this.Label1Click);
			// 
			// cloudgraph
			// 
			this.cloudgraph.BackColor = System.Drawing.Color.White;
			this.cloudgraph.Location = new System.Drawing.Point(0, 0);
			this.cloudgraph.Name = "cloudgraph";
			this.cloudgraph.Size = new System.Drawing.Size(900, 900);
			this.cloudgraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.cloudgraph.TabIndex = 11;
			this.cloudgraph.TabStop = false;
			// 
			// 设置ToolStripMenuItem
			// 
			this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.导入外部数据ToolStripMenuItem,
			this.连接PFLidarToolStripMenuItem});
			this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
			this.设置ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
			this.设置ToolStripMenuItem.Text = "设置";
			// 
			// 导入外部数据ToolStripMenuItem
			// 
			this.导入外部数据ToolStripMenuItem.Name = "导入外部数据ToolStripMenuItem";
			this.导入外部数据ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
			this.导入外部数据ToolStripMenuItem.Text = "导入外部数据";
			// 
			// 连接PFLidarToolStripMenuItem
			// 
			this.连接PFLidarToolStripMenuItem.Name = "连接PFLidarToolStripMenuItem";
			this.连接PFLidarToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
			this.连接PFLidarToolStripMenuItem.Text = "连接P+F Lidar";
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.设置ToolStripMenuItem,
			this.命令ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1875, 28);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1ItemClicked);
			this.menuStrip1.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuStrip1Paint);
			// 
			// 命令ToolStripMenuItem
			// 
			this.命令ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.绘图ToolStripMenuItem,
			this.清除ToolStripMenuItem,
			this.重绘坐标系ToolStripMenuItem,
			this.绘制障碍物ToolStripMenuItem});
			this.命令ToolStripMenuItem.Name = "命令ToolStripMenuItem";
			this.命令ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
			this.命令ToolStripMenuItem.Text = "命令";
			// 
			// 绘图ToolStripMenuItem
			// 
			this.绘图ToolStripMenuItem.Name = "绘图ToolStripMenuItem";
			this.绘图ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
			this.绘图ToolStripMenuItem.Text = "绘图";
			this.绘图ToolStripMenuItem.Click += new System.EventHandler(this.绘图ToolStripMenuItemClick);
			// 
			// 清除ToolStripMenuItem
			// 
			this.清除ToolStripMenuItem.Name = "清除ToolStripMenuItem";
			this.清除ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
			this.清除ToolStripMenuItem.Text = "清除";
			this.清除ToolStripMenuItem.Click += new System.EventHandler(this.清除ToolStripMenuItemClick);
			// 
			// 重绘坐标系ToolStripMenuItem
			// 
			this.重绘坐标系ToolStripMenuItem.Name = "重绘坐标系ToolStripMenuItem";
			this.重绘坐标系ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
			this.重绘坐标系ToolStripMenuItem.Text = "重绘坐标系";
			this.重绘坐标系ToolStripMenuItem.Click += new System.EventHandler(this.重绘坐标系ToolStripMenuItemClick);
			// 
			// 绘制障碍物ToolStripMenuItem
			// 
			this.绘制障碍物ToolStripMenuItem.Name = "绘制障碍物ToolStripMenuItem";
			this.绘制障碍物ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
			this.绘制障碍物ToolStripMenuItem.Text = "绘制障碍物";
			this.绘制障碍物ToolStripMenuItem.Click += new System.EventHandler(this.绘制障碍物ToolStripMenuItemClick);
			// 
			// PointGraph
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1875, 959);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "PointGraph";
			this.Text = "Cloud of  Points";
			this.Load += new System.EventHandler(this.PointGraphLoad);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.PointGraphPaint);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lidardatadgv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cloudgraph)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
