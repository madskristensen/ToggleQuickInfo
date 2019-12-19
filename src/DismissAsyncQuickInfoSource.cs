using Microsoft.VisualStudio.Language.Intellisense;

using System.Threading;
using System.Threading.Tasks;

namespace ToggleQuickInfo
{
	internal class DismissAsyncQuickInfoSource : IAsyncQuickInfoSource
	{
		public async Task<QuickInfoItem> GetQuickInfoItemAsync(IAsyncQuickInfoSession session, CancellationToken cancellationToken)
		{
			var options = await GeneralOptions.GetLiveInstanceAsync();

			if (!options.ShowTooltips)
			{
				await session.DismissAsync();
			}

			return null;
		}

		public void Dispose()
		{

		}
	}
}