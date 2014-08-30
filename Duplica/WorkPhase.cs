using System;
using System.ComponentModel;

namespace Duplica
{
	internal abstract class WorkPhase : BackgroundWorker
	{
		public abstract string Name { get; }
		public abstract string StatusText { get; }
		public abstract long TotalProgress { get; }
		public abstract long CurrentProgress { get; }
		protected DateTime StartTime;
		protected ScanContext Context;

		protected WorkPhase(ScanContext context)
		{
			Context = context;
			WorkerSupportsCancellation = true;
		}

		public void Start()
		{
			StartTime = DateTime.Now;
			RunWorkerAsync();
		}

		public double ElapsedSeconds
		{
			get { return (DateTime.Now - StartTime).TotalSeconds; }
		}
	}
}