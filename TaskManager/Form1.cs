using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
	public partial class Form1 : Form
	{
		Process[] processes;

		public Form1()
		{
			InitializeComponent();
			RefreshList();
		}

		private void RefreshList()
		{
			Thread.Sleep(100);
			processList.Items.Clear();
			processes = Process.GetProcesses();
			for (int i = 0; i < processes.Length; i++)
			{
				processList.Items.Add(processes[i].ProcessName);
			}
		}

		private void processList_MouseDown(object sender, MouseEventArgs e)
		{
			processList.SelectedIndex = processList.IndexFromPoint(e.X, e.Y);
		}

		private void ThreadCount(object sender, EventArgs e)
		{
			Process selectedProcess = processes[processList.SelectedIndex];
			int threadCount = selectedProcess.Threads.Count;
			string processName = selectedProcess.ProcessName;
			MessageBox.Show(processName + " işleminin thread sayısı: " + threadCount);
		}

		private void MemoryUsage(object sender, EventArgs e)
		{
			Process selectedProcess = processes[processList.SelectedIndex];
			long memoryUsage = selectedProcess.PrivateMemorySize64;
			string processName = selectedProcess.ProcessName;
			MessageBox.Show(processName + " işleminin kullandığı hafıza: " + memoryUsage/1024.0f + "K");
		}

		private void ProcessorUsage(object sender, EventArgs e)
		{
			Process selectedProcess = processes[processList.SelectedIndex];
			string processName = selectedProcess.ProcessName;
			
			PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", processName);
			for (int i = 0; i < 3; i++)
			{
				cpuCounter.NextValue();
				Thread.Sleep(1000);
			}
			// TODO: divide to logical processor count
			MessageBox.Show(processName + " işleminin kullandığı işlemci: " + cpuCounter.NextValue() + ""); 
		}

		private void KillProcess(object sender, EventArgs e)
		{
			Process selectedProcess = processes[processList.SelectedIndex];
			string killedProcess = selectedProcess.ProcessName;

			try
			{
				selectedProcess.Kill();
				MessageBox.Show(killedProcess + " işlemi sonlandırıldı.");
			}
			catch (Exception exc)
			{
				MessageBox.Show("işlem sonlandırılırken hata meydana geldi.\n" + exc.Message);
			}

			RefreshList();
		}
	}
}
