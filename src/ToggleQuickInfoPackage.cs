using System;
using System.Runtime.InteropServices;
using System.Threading;
using EnvDTE;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace ToggleQuickInfo
{
	[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
	[InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
	[ProvideOptionPage(typeof(DialogPageProvider.General), "Environment", "Tooltips", 0, 0, true, new[] { "Toggle Tooltips" }, ProvidesLocalizedCategoryName = false)]
	[Guid("e144a113-29b4-4495-a051-23b9300e41b3")]
	public sealed class ToggleQuickInfoPackage : AsyncPackage
	{
		protected override Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
		{
			GeneralOptions.Saved += OnSaved;

			return base.InitializeAsync(cancellationToken, progress);
		}

		private void OnSaved(object sender, EventArgs e)
		{
			JoinableTaskFactory.Run(async () =>
			{
				await JoinableTaskFactory.SwitchToMainThreadAsync();

				var dte = await GetServiceAsync(typeof(DTE)) as DTE;
				Assumes.Present(dte);

				var options = (GeneralOptions)sender;

				dte.StatusBar.Text = options.ShowTooltips ? "Tooltips enabled" : "Tooltips disabled";
			});
		}
	}
}
