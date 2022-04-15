namespace Cedid.AkilliLojistik.Permissions;

public static class AkilliLojistikPermissions
{
    public const string GroupName = "AkilliLojistik";

    public static class Parameters
    {
        public const string Default = GroupName + ".Parameters";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Vehicles
    {
        public const string Default = GroupName + ".Vehicles";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Services
    {
        public const string Default = GroupName + ".Services";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class ServiceMaterials
    {
        public const string Default = GroupName + ".ServiceMaterials";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class ServiceAccessories
    {
        public const string Default = GroupName + ".ServiceAccessories";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class ServiceOperations
    {
        public const string Default = GroupName + ".ServiceOperations";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
