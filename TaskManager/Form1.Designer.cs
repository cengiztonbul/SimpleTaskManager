
namespace TaskManager
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.processList = new System.Windows.Forms.ListBox();
			this.processContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.test0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.işlemciKullanımıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.göreviSonlandırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.processUsageLabel = new System.Windows.Forms.Label();
			this.processContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// processList
			// 
			this.processList.ContextMenuStrip = this.processContextMenu;
			this.processList.FormattingEnabled = true;
			this.processList.Location = new System.Drawing.Point(12, 12);
			this.processList.Name = "processList";
			this.processList.Size = new System.Drawing.Size(366, 420);
			this.processList.TabIndex = 0;
			this.processList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.processList_MouseDown);
			// 
			// processContextMenu
			// 
			this.processContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test0ToolStripMenuItem,
            this.test1ToolStripMenuItem,
            this.işlemciKullanımıToolStripMenuItem,
            this.göreviSonlandırToolStripMenuItem});
			this.processContextMenu.Name = "contextMenuStrip1";
			this.processContextMenu.Size = new System.Drawing.Size(165, 92);
			// 
			// test0ToolStripMenuItem
			// 
			this.test0ToolStripMenuItem.Name = "test0ToolStripMenuItem";
			this.test0ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.test0ToolStripMenuItem.Text = "Thread Sayısı";
			this.test0ToolStripMenuItem.Click += new System.EventHandler(this.ThreadCount);
			// 
			// test1ToolStripMenuItem
			// 
			this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
			this.test1ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.test1ToolStripMenuItem.Text = "Bellek Kullanımı";
			this.test1ToolStripMenuItem.Click += new System.EventHandler(this.MemoryUsage);
			// 
			// işlemciKullanımıToolStripMenuItem
			// 
			this.işlemciKullanımıToolStripMenuItem.Name = "işlemciKullanımıToolStripMenuItem";
			this.işlemciKullanımıToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.işlemciKullanımıToolStripMenuItem.Text = "İşlemci Kullanımı";
			this.işlemciKullanımıToolStripMenuItem.Click += new System.EventHandler(this.ProcessorUsage);
			// 
			// göreviSonlandırToolStripMenuItem
			// 
			this.göreviSonlandırToolStripMenuItem.Name = "göreviSonlandırToolStripMenuItem";
			this.göreviSonlandırToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.göreviSonlandırToolStripMenuItem.Text = "Görevi Sonlandır";
			this.göreviSonlandırToolStripMenuItem.Click += new System.EventHandler(this.KillProcess);
			// 
			// processUsageLabel
			// 
			this.processUsageLabel.AutoSize = true;
			this.processUsageLabel.Location = new System.Drawing.Point(384, 12);
			this.processUsageLabel.Name = "processUsageLabel";
			this.processUsageLabel.Size = new System.Drawing.Size(35, 13);
			this.processUsageLabel.TabIndex = 1;
			this.processUsageLabel.Text = "label1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 451);
			this.Controls.Add(this.processUsageLabel);
			this.Controls.Add(this.processList);
			this.Name = "Form1";
			this.Text = "Form1";
			this.processContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox processList;
		private System.Windows.Forms.ContextMenuStrip processContextMenu;
		private System.Windows.Forms.ToolStripMenuItem test0ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem işlemciKullanımıToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem göreviSonlandırToolStripMenuItem;
		private System.Windows.Forms.Label processUsageLabel;
	}
}

