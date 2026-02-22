using Alpha.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Alpha.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AlphaController : AbpControllerBase
{
    protected AlphaController()
    {
        LocalizationResource = typeof(AlphaResource);
    }
}
