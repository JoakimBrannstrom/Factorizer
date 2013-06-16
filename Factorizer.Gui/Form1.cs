using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Factorizer.Gui
{
	public partial class Form1 : Form
	{
		readonly BackgroundWorker _worker = new BackgroundWorker();
		readonly Stopwatch _stopwatch = new Stopwatch();
		string _prefix = string.Empty;
		readonly Factoring _factoring = new Factoring();

		static string Filepath { get { return string.Format("{0}\\..\\..\\cached-primes.bin", Environment.CurrentDirectory); } }

		public Form1()
		{
			Closing += (sender, args) => SaveCachedPrimes();

			LoadCachedPrimes();

			InitializeComponent();

			_worker.WorkerReportsProgress = true;
			_worker.WorkerSupportsCancellation = true;
			Thread.CurrentThread.Priority = ThreadPriority.Highest;

			_worker.DoWork += WorkerOnDoWork;
			_worker.ProgressChanged += WorkerOnProgressChanged;
			_worker.RunWorkerCompleted += WorkerOnRunWorkerCompleted;

			var initialValues = new ulong[]
								{
									112589988,
									11258999025,
									11258999052,
									11258999054,
									1125899906801,
									1125899906817,
									1125899906824,
									1125899906830,
									1125899906833,
									1125899906842575
								};

			var index = Environment.TickCount % initialValues.Length;
			Value.Text = initialValues[index].ToString(CultureInfo.InvariantCulture);
		}

		private void WorkerOnDoWork(object sender, DoWorkEventArgs args)
		{
			_stopwatch.Restart();
			_prefix = string.Empty;
			_factoring.CancellationPending = false;

			var value = (ulong)args.Argument;

			var factors = _factoring.GetFactors(value);

			foreach (var factor in factors)
			{
				if (_worker.CancellationPending)
				{
					_worker.ReportProgress(1, "... Canceled by user");
					return;
				}

				_worker.ReportProgress(1, factor);
			}

			_worker.ReportProgress(1, string.Format(" = {0}", value));
		}

		private void WorkerOnProgressChanged(object sender, ProgressChangedEventArgs args)
		{
			if (args.UserState is string)
			{
				Factors.Text = string.Format("{0}{1}", Factors.Text, args.UserState);
			}
			else if (args.UserState is ulong)
			{
				var factor = (ulong)args.UserState;
				Factors.Text = string.Format("{0}{1}{2}", Factors.Text, _prefix, factor);
				_prefix = " * ";
			}
		}

		private void WorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
		{
			_stopwatch.Stop();

			CalculationTime.Text = _stopwatch.Elapsed.ToString();
			NumberOfCachedPrimes.Text = Factoring.CachedPrimes.Count.ToString(CultureInfo.InvariantCulture);
			LargestCachedPrime.Text = Factoring.CachedPrimes.Last().ToString(CultureInfo.InvariantCulture);
		}

		private void Factorize_Click(object sender, EventArgs e)
		{
			if (_worker.IsBusy)
			{
				MessageBox.Show("Worker is busy...");
				return;
			}

			Factors.Text = string.Empty;
			var value = ulong.Parse(Value.Text);

			_worker.RunWorkerAsync(value);
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			_worker.CancelAsync();
			_factoring.CancellationPending = true;
		}

		private void ClearCachedPrimes_Click(object sender, EventArgs e)
		{
			if (File.Exists(Filepath))
				File.Delete(Filepath);

			Factoring.CachedPrimes = new SortedSet<ulong>();
		}

		private void SaveCachedPrimes()
		{
			var tempFile = Filepath + ".temp";
			if (File.Exists(tempFile))
				File.Delete(tempFile);

			using (var file = File.OpenWrite(tempFile))
			{
				Serialize(file, Factoring.CachedPrimes);
			}

			if (File.Exists(Filepath))
			{
				var backupFileName = Filepath + ".old";

				File.Replace(tempFile, Filepath, backupFileName);
			}
			else
				File.Move(tempFile, Filepath);
		}

		private void LoadCachedPrimes()
		{
			if (!File.Exists(Filepath))
				return;

			using (var file = File.OpenRead(Filepath))
			{
				Factoring.CachedPrimes = Deserialize<SortedSet<ulong>>(file);
			}
		}

		private static void Serialize<TData>(Stream output, TData settings)
		{
			var formatter = new BinaryFormatter();
			formatter.Serialize(output, settings);
			output.Flush();
			output.Position = 0;
		}

		private static TData Deserialize<TData>(Stream stream)
		{
			var formatter = new BinaryFormatter();
			stream.Seek(0, SeekOrigin.Begin);
			return (TData)formatter.Deserialize(stream);
		}
	}
}
