using Cedid.AkilliLojistik.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Cedid.AkilliLojistik.Permissions;

public class AkilliLojistikPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AkilliLojistikPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AkilliLojistikPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AkilliLojistikResource>(name);
    }
}
