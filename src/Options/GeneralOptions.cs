using System.ComponentModel;

namespace ToggleQuickInfo
{
    internal class GeneralOptions : BaseOptionModel<GeneralOptions>
    {
        [Category("General")]
        [DisplayName("Show Tooltips")]
        [Description("Specifies whether to show editor tooltips (QuickInfo) when mouse hovers over an identifier.")]
        [DefaultValue(false)]
        public bool ShowTooltips { get; set; }
    }
}
