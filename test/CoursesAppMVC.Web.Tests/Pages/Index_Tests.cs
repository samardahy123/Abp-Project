using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CoursesAppMVC.Pages;

public class Index_Tests : CoursesAppMVCWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
