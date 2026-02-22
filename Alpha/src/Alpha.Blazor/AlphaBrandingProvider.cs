using Microsoft.Extensions.Localization;
using Alpha.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Alpha.Blazor;

[Dependency(ReplaceServices = true)]
public class AlphaBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AlphaResource> _localizer;

    public AlphaBrandingProvider(IStringLocalizer<AlphaResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
