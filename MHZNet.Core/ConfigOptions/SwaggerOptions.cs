using MHZNet.Common.Attributes;

namespace MHZNet.Core.ConfigOptions;

[OptionsSettings]
public class SwaggerOptions
{
    public bool Enabled { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public string Title { get; set; }
}
