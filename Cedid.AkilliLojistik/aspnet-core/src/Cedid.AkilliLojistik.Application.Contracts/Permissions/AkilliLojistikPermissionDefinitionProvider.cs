using Cedid.AkilliLojistik.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Cedid.AkilliLojistik.Permissions;

public class AkilliLojistikPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AkilliLojistikPermissions.GroupName);
        myGroup.AddPermission(AkilliLojistikPermissions.Parameters.Default, L("Permission:Parameters:Default"));
        myGroup.AddPermission(AkilliLojistikPermissions.Parameters.Create, L("Permission:Parameters:Create"));
        myGroup.AddPermission(AkilliLojistikPermissions.Parameters.Delete, L("Permission:Parameters:Delete"));
        myGroup.AddPermission(AkilliLojistikPermissions.Parameters.Edit, L("Permission:Parameters:Edit"));

        myGroup.AddPermission(AkilliLojistikPermissions.Services.Default, L("Permission:Services:Default"));
        myGroup.AddPermission(AkilliLojistikPermissions.Services.Create, L("Permission:Services:Create"));
        myGroup.AddPermission(AkilliLojistikPermissions.Services.Delete, L("Permission:Services:Delete"));
        myGroup.AddPermission(AkilliLojistikPermissions.Services.Edit, L("Permission:Services:Edit"));

        myGroup.AddPermission(AkilliLojistikPermissions.Vehicles.Default, L("Permission:Vehicles:Default"));
        myGroup.AddPermission(AkilliLojistikPermissions.Vehicles.Create, L("Permission:Vehicles:Create"));
        myGroup.AddPermission(AkilliLojistikPermissions.Vehicles.Delete, L("Permission:Vehicles:Delete"));
        myGroup.AddPermission(AkilliLojistikPermissions.Vehicles.Edit, L("Permission:Vehicles:Edit"));

        myGroup.AddPermission(AkilliLojistikPermissions.ServiceAccessories.Default, L("Permission:ServiceAccessories:Default"));
        myGroup.AddPermission(AkilliLojistikPermissions.ServiceAccessories.Create, L("Permission:ServiceAccessories:Create"));
        myGroup.AddPermission(AkilliLojistikPermissions.ServiceAccessories.Delete, L("Permission:ServiceAccessories:Delete"));
        myGroup.AddPermission(AkilliLojistikPermissions.ServiceAccessories.Edit, L("Permission:ServiceAccessories:Edit"));

        myGroup.AddPermission(AkilliLojistikPermissions.ServiceMaterials.Default, L("Permission:ServiceMaterials:Default"));
        myGroup.AddPermission(AkilliLojistikPermissions.ServiceMaterials.Create, L("Permission:ServiceMaterials:Create"));
        myGroup.AddPermission(AkilliLojistikPermissions.ServiceMaterials.Delete, L("Permission:ServiceMaterials:Delete"));
        myGroup.AddPermission(AkilliLojistikPermissions.ServiceMaterials.Edit, L("Permission:ServiceMaterials:Edit"));

        myGroup.AddPermission(AkilliLojistikPermissions.ServiceOperations.Default, L("Permission:ServiceOperations:Default"));
        myGroup.AddPermission(AkilliLojistikPermissions.ServiceOperations.Create, L("Permission:ServiceOperations:Create"));
        myGroup.AddPermission(AkilliLojistikPermissions.ServiceOperations.Delete, L("Permission:ServiceOperations:Delete"));
        myGroup.AddPermission(AkilliLojistikPermissions.ServiceOperations.Edit, L("Permission:ServiceOperations:Edit"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AkilliLojistikResource>(name);
    }
}
