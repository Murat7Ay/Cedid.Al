using Cedid.AkilliLojistik.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Cedid.AkilliLojistik.Web.Pages.Parameters
{
    public class CreateModalModel : AkilliLojistikPageModel
    {
        [BindProperty]
        public CreateParameterViewModel Parameter { get; set; }


        private readonly IParameterAppService _parameterAppService;

        public CreateModalModel(IParameterAppService parameterAppService)
        {
            _parameterAppService = parameterAppService;
        }

        public async Task OnGetAsync()
        {
            Parameter = new CreateParameterViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _parameterAppService.CreateAsync(
             ObjectMapper.Map<CreateParameterViewModel, CreateUpdateParameterDto>(Parameter)
             );
            return NoContent();
        }

        public class CreateParameterViewModel
        {
            [Required]
            [StringLength(ParameterConsts.CodeMaxLength)]
            [DisplayName("Code")]
            public string Code { get; set; }
            [Required]
            [StringLength(ParameterConsts.TextMaxLength)]
            [DisplayName("Text")]
            public string Text { get; set; }
            [DisplayName("IsActive")]
            public bool IsActive { get; set; }
            [StringLength(ParameterConsts.SpecMaxLength)]
            [DisplayName("Spec1")]
            public string Spec1 { get; set; }
            [StringLength(ParameterConsts.SpecMaxLength)]
            [DisplayName("Spec2")]
            public string Spec2 { get; set; }
            [StringLength(ParameterConsts.SpecMaxLength)]
            [DisplayName("Spec3")]
            public string Spec3 { get; set; }
            [StringLength(ParameterConsts.SpecMaxLength)]
            [DisplayName("Spec4")]
            public string Spec4 { get; set; }
            [StringLength(ParameterConsts.SpecMaxLength)]
            public string Spec5 { get; set; }
        }

    }
}
