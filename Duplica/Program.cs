using System;
using System.Windows.Forms;
using Duplica.Forms;

namespace Duplica
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ScanSettingsForm(args));
		}
		
	}
}
