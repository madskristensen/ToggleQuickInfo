using EnvDTE;
using Microsoft;
using Microsoft.VisualStudio.Shell;

using System;
using System.ComponentModel.Design;

using Task = System.Threading.Tasks.Task;

namespace ToggleQuickInfo
{
	[ProvideSearchableCommand(nameof(ToggleCommand), PackageGuids.guidToggleQuickInfoPackageCmdSetString, PackageIds.MyMenu)]
	internal sealed class ToggleCommand
	{
		public static async Task InitializeAsync(AsyncPackage package)
		{
			await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

			var commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
			var dte = await package.GetServiceAsync(typeof(DTE)) as DTE;
			Assumes.Present(commandService);

			var menuCommandID = new CommandID(PackageGuids.guidToggleQuickInfoPackageCmdSet, PackageIds.ToggleCommandId);
			var menuItem = new MenuCommand((s, e) => Execute(dte), menuCommandID);
			commandService.AddCommand(menuItem);
		}

		private static void Execute(DTE dte)
		{
			ThreadHelper.ThrowIfNotOnUIThread();
			
			GeneralOptions.Instance.ShowTooltips = !GeneralOptions.Instance.ShowTooltips;
			GeneralOptions.Instance.Save();

			dte.StatusBar.Text = GeneralOptions.Instance.ShowTooltips ? "Tooltips enabled" : "Tooltips disabled";
		}
	}
}
