using System.Threading.Tasks;
using Cedid.AkilliLojistik.Localization;
using Cedid.AkilliLojistik.MultiTenancy;
using Cedid.AkilliLojistik.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Cedid.AkilliLojistik.Web.Menus;

public class AkilliLojistikMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<AkilliLojistikResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                AkilliLojistikMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );



        if (await context.IsGrantedAsync(AkilliLojistikPermissions.Parameters.Default))
        {
            var parameterMenu = new ApplicationMenuItem(
            "Parameter",
            l["Menu:Parameter"],
            icon: "fa fa-square-o",
            url: "/Parameters"
            );
            context.Menu.Items.Add(parameterMenu);
        }

        if (await context.IsGrantedAsync(AkilliLojistikPermissions.Vehicles.Default))
        {
            var parameterMenu = new ApplicationMenuItem(
            "Vehicle",
            l["Menu:Vehicle"],
            icon: "fa fa-car",
            url: "/Vehicles"
            );
            context.Menu.Items.Add(parameterMenu);
        }

        if (await context.IsGrantedAsync(AkilliLojistikPermissions.Services.Default))
        {
            var parameterMenu = new ApplicationMenuItem(
            "Service",
            l["Menu:Service"],
            icon: "fa fa-wrench",
            url: "/Services"
            );
            context.Menu.Items.Add(parameterMenu);
        }

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
