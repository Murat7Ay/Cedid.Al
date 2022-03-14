using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Cedid.AkilliLojistik.Pages;

public class Index_Tests : AkilliLojistikWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
