using WindowDock.Core.Enums;

namespace WindowDock.Option.Local.Models;
public class StyleModel
{
    public StyleEnum type { get; set; }
    public string Name { get; set; }

    public StyleModel(StyleEnum type, string name)
    {
        this.type = type;
        Name = name;
    }
}
