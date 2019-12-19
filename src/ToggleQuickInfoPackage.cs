using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace ToggleQuickInfo
{
	[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
	[InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
	[ProvideOptionPage(typeof(DialogPageProvider.General), "Environment", "Code Cleanup on Save", 0, 0, true, new[] { "Code Cleanup on Save" }, ProvidesLocalizedCategoryName = false)]
	[Guid("e144a113-29b4-4495-a051-23b9300e41b3")]
	public sealed class ToggleQuickInfoPackage : AsyncPackage
	{
		protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
		{
			// When initialized asynchronously, the current thread may be a background thread at this point.
			// Do any initialization that requires the UI thread after switching to the UI thread.
			await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
		}
	}
}
