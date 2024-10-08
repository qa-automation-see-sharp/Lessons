using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements;

public class CheckBox : BaseElement
{
    public bool Checked => Selected;
}