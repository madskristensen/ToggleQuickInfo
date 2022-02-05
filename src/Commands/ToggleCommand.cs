using Microsoft;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.ComponentModel.Design;
using Community.VisualStudio.Toolkit;

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
			Assumes.Present(commandService);

			var menuCommandID = new CommandID(PackageGuids.guidToggleQuickInfoPackageCmdSet, PackageIds.ToggleCommandId);
			var menuItem = new MenuCommand((s, e) => Execute(), menuCommandID);
			commandService.AddCommand(menuItem);
		}

		private static void Execute()
		{
			ThreadHelper.ThrowIfNotOnUIThread();
			
			GeneralOptions.Instance.ShowTooltips = !GeneralOptions.Instance.ShowTooltips;
			GeneralOptions.Instance.Save();

			string text = GeneralOptions.Instance.ShowTooltips ? "Tooltips enabled" : "Tooltips disabled";

            VS.StatusBar.ShowMessageAsync(text).FireAndForget();
		}
	}
}
