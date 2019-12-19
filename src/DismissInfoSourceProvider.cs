using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;

using System.ComponentModel.Composition;

namespace ToggleQuickInfo
{
	[Export(typeof(IAsyncQuickInfoSourceProvider))]
	[Name(nameof(DismissInfoSourceProvider))]
	[ContentType("code")]
	[Order]
	class DismissInfoSourceProvider : IAsyncQuickInfoSourceProvider
	{
		public IAsyncQuickInfoSource TryCreateQuickInfoSource(ITextBuffer textBuffer)
		{
			return textBuffer.Properties.GetOrCreateSingletonProperty(() => new DismissAsyncQuickInfoSource());
		}
	}
}
