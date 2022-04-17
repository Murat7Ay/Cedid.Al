using Cedid.AkilliLojistik.Parameters;
using Cedid.AkilliLojistik.ServiceAccessories;
using Cedid.AkilliLojistik.ServiceMaterials;
using Cedid.AkilliLojistik.ServiceOperations;
using Cedid.AkilliLojistik.Services;
using Cedid.AkilliLojistik.Vehicles;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Cedid.AkilliLojistik.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class AkilliLojistikDbContext :
    AbpDbContext<AkilliLojistikDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<Parameter> Parameters { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceOperation> ServiceOperations { get; set; }
    public DbSet<ServiceMaterial> ServiceMaterials { get; set; }
    public DbSet<ServiceAccessory> ServiceAccessories { get; set; }

    public AkilliLojistikDbContext(DbContextOptions<AkilliLojistikDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();


        builder.Entity<Parameter>(b =>
        {
            b.ToTable(AkilliLojistikConsts.DbTablePrefix + "Parameters", AkilliLojistikConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Code).IsRequired().HasMaxLength(ParameterConsts.CodeMaxLength);
            b.Property(x => x.Text).IsRequired().HasMaxLength(ParameterConsts.CodeMaxLength);
            b.Property(x => x.Spec1).HasMaxLength(ParameterConsts.SpecMaxLength);
            b.Property(x => x.Spec2).HasMaxLength(ParameterConsts.SpecMaxLength);
            b.Property(x => x.Spec3).HasMaxLength(ParameterConsts.SpecMaxLength);
            b.Property(x => x.Spec4).HasMaxLength(ParameterConsts.SpecMaxLength);
            b.Property(x => x.Spec5).HasMaxLength(ParameterConsts.SpecMaxLength);
            b.HasIndex(x => x.Code);
        });

        builder.Entity<Vehicle>(b =>
        {
            b.ToTable(AkilliLojistikConsts.DbTablePrefix + "Vehicles", AkilliLojistikConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.PlateNo).IsRequired().HasMaxLength(VehicleConsts.PlateNoMaxLength);
            b.HasIndex(x => x.PlateNo).IsUnique();
            b.Property(x => x.LicenseNumber).IsRequired().HasMaxLength(VehicleConsts.LicenseNumberMaxLength);
            b.Property(x => x.ChassisNumber).HasMaxLength(VehicleConsts.ChassisNumberMaxLength);
            b.Property(x => x.EngineNumber).HasMaxLength(VehicleConsts.EngineNumberMaxLength);
            b.Property(x => x.GearBoxNumber).HasMaxLength(VehicleConsts.GearBoxNumberMaxLength);
            b.Property(x => x.TrafficReleaseDate).IsRequired();
            b.Property(x => x.Radio).HasMaxLength(VehicleConsts.RadioMaxLength);
            b.Property(x => x.Flooring).HasMaxLength(VehicleConsts.FlooringMaxLength);
            b.Property(x => x.ImageUrl).HasMaxLength(VehicleConsts.ImageUrlMaxLength);
            b.Property(x => x.Description).HasMaxLength(VehicleConsts.DescriptionMaxLength);
        });

        builder.Entity<Service>(b =>
        {
            b.ToTable(AkilliLojistikConsts.DbTablePrefix + "Services", AkilliLojistikConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.VehicleId).IsRequired();
            b.Property(x => x.ServiceStatuTypeId).IsRequired();
            b.HasIndex(x=>x.VehicleId);
            b.Property(x => x.Contact).HasMaxLength(ServiceConsts.ContactMaxLength);
            b.Property(x => x.ServiceResult).HasMaxLength(ServiceConsts.ServiceResultMaxLength);
            b.Property(x => x.Detection).HasMaxLength(ServiceConsts.DetectionMaxLength);
            b.Property(x => x.ExpenseDescription).HasMaxLength(ServiceConsts.ExpenseDescriptionMaxLength);
            b.Property(x => x.Description).HasMaxLength(ServiceConsts.DescriptionMaxLength);
            b.Property(x => x.InvoiceNumber).HasMaxLength(ServiceConsts.InvoiceNumberMaxLength);
            b.Property(x => x.Signer).HasMaxLength(ServiceConsts.SignerMaxLength);
            b.Property(x => x.SignerContact).HasMaxLength(ServiceConsts.SignerContactMaxLength);
            b.Property(x => x.ReportedFault).HasMaxLength(ServiceConsts.ReportedFaultMaxLength);
        });

        builder.Entity<ServiceOperation>(b =>
        {
            b.ToTable(AkilliLojistikConsts.DbTablePrefix + "ServiceOperations", AkilliLojistikConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Description).HasMaxLength(ServiceOperationConsts.DescriptionMaxLength);
            b.Property(x => x.ServiceId).IsRequired();
            b.HasIndex(x => x.ServiceId);
        });

        builder.Entity<ServiceMaterial>(b =>
        {
            b.ToTable(AkilliLojistikConsts.DbTablePrefix + "ServiceMaterials", AkilliLojistikConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Description).HasMaxLength(ServiceMaterialConsts.DescriptionMaxLength);
            b.Property(x => x.ServiceId).IsRequired();
            b.HasIndex(x => x.ServiceId);
            b.Property(x => x.Type).IsRequired();
            b.Property(x => x.Price).HasPrecision(18, 2);
            b.Property(x => x.Amount).HasPrecision(18, 2);
            b.Property(x => x.KDVAmount).HasPrecision(18, 2);
            b.Property(x => x.DiscountAmount).HasPrecision(18, 2);
            b.Property(x => x.DiscountTwoAmount).HasPrecision(18, 2);
            b.Property(x => x.NetAmount).HasPrecision(18, 2);
            b.HasIndex(x => new { x.ServiceId, x.Type });
        });

        builder.Entity<ServiceAccessory>(b =>
        {
            b.ToTable(AkilliLojistikConsts.DbTablePrefix + "ServiceAccessories", AkilliLojistikConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.SerialNumber).HasMaxLength(ServiceAccessoryConsts.SerialNumberMaxLength);
            b.Property(x => x.ServiceId).IsRequired();
            b.HasIndex(x => x.ServiceId);
        });
    }
}
