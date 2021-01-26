using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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
			ProcessListBox.Items.Clear();
			processes = Process.GetProcesses();
			for (int i = 0; i < processes.Length; i++)
			{
				ProcessListBox.Items.Add(processes[i].ProcessName);
			}
		}

		private void ProcessList_MouseDown(object sender, MouseEventArgs e)
		{
			ProcessListBox.SelectedIndex = ProcessListBox.IndexFromPoint(e.X, e.Y);
		}

		private void ThreadCount(object sender, EventArgs e)
		{
			Process selectedProcess = processes[ProcessListBox.SelectedIndex];
			int threadCount = selectedProcess.Threads.Count;
			string processName = selectedProcess.ProcessName;
			MessageBox.Show(processName + " işleminin thread sayısı: " + threadCount);
		}

		private void MemoryUsage(object sender, EventArgs e)
		{
			Process selectedProcess = processes[ProcessListBox.SelectedIndex];
			long memoryUsage = selectedProcess.WorkingSet64;
			string processName = selectedProcess.ProcessName;
			MessageBox.Show(processName + " işleminin kullandığı hafıza: " + memoryUsage/1024.0f + "K");
		}

		private void ProcessorUsage(object sender, EventArgs e)
		{
			int loopCount = 5;
			float totalPercentage = 0;
			int processorCount = Environment.ProcessorCount;

			Process selectedProcess = processes[ProcessListBox.SelectedIndex];
			string processName = GetInstanceNameOfProcess(selectedProcess);

			PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", processName);
			cpuCounter.NextValue();
			
			for (int i = 0; i < loopCount; i++)
			{
				Thread.Sleep(200);
				totalPercentage += cpuCounter.NextValue();
			}
			float averagePercentage = totalPercentage / loopCount / processorCount;

			MessageBox.Show(processName + " işleminin kullandığı işlemci: " + averagePercentage + "%");
		}

		private void KillProcess(object sender, EventArgs e)
		{
			Process selectedProcess = processes[ProcessListBox.SelectedIndex];
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

		public static string GetInstanceNameOfProcess(Process process)
		{
			PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");
			string[] instances = cat.GetInstanceNames()
				.Where(inst => inst.StartsWith(process.ProcessName))
				.ToArray();

			foreach (string instance in instances)
			{
				using (PerformanceCounter cnt = new PerformanceCounter("Process",
					"ID Process", instance, true))
				{
					int val = (int)cnt.RawValue;
					if (val == process.Id)
					{
						return instance;
					}
				}
			}
			return null;
		}
	}
}
