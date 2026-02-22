using Alpha.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Alpha.Permissions;

public class AlphaPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AlphaPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(AlphaPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(AlphaPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(AlphaPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(AlphaPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AlphaPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AlphaResource>(name);
    }
}
