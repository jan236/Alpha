using Alpha.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Alpha.Blazor;

public abstract class AlphaComponentBase : AbpComponentBase
{
    protected AlphaComponentBase()
    {
        LocalizationResource = typeof(AlphaResource);
    }
}
