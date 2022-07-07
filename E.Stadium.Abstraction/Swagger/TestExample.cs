using Swashbuckle.AspNetCore.Filters;

namespace E.Stadium.Abstraction.Swagger;

public class TestExample : IExamplesProvider<object>
{
    public object GetExamples()
    {
        return "";
    }
}
