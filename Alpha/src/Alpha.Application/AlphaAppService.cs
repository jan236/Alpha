using Alpha.Localization;
using Volo.Abp.Application.Services;

namespace Alpha;

/* Inherit your application services from this class.
 */
public abstract class AlphaAppService : ApplicationService
{
    protected AlphaAppService()
    {
        LocalizationResource = typeof(AlphaResource);
    }
}
