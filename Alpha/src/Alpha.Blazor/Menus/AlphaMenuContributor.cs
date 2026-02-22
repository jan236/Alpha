using System.Threading.Tasks;
using Alpha.Localization;
using Alpha.Permissions;
using Alpha.MultiTenancy;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.Identity.Blazor;

namespace Alpha.Blazor.Menus;

public class AlphaMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<AlphaResource>();
        
        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AlphaMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 1
            )
        );

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 6;

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        context.Menu.AddItem(
         new ApplicationMenuItem(
             "BooksStore",
             l["Menu:Alpha"],
             icon: "fa fa-book"
         ).AddItem(
             new ApplicationMenuItem(
                 "BooksStore.Books",
                 l["Menu:Books"],
                 url: "/books"
             ).RequirePermissions(AlphaPermissions.Books.Default) 
         )
        );

        return Task.CompletedTask;
    }
}
