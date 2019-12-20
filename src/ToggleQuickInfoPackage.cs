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
	//[ProvideOptionPage(typeof(DialogPageProvider.General), "Environment", "Tooltips", 0, 0, true, new[] { "Toggle Tooltips" }, SupportsProfiles = true, ProvidesLocalizedCategoryName = false)]
	[Guid(PackageGuids.guidToggleQuickInfoPackageString)]
	[ProvideMenuResource("Menus.ctmenu", 1)]
	public sealed class ToggleQuickInfoPackage : AsyncPackage
	{
		protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
		{
		    await ToggleCommand.InitializeAsync(this);
		}
	}
}
