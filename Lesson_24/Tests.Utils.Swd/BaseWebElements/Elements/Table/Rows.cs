using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Table;

public class Rows : BaseElement
{
    [FindBy(XPath = "//div[contains(@class,'rt-td')]")]
    public Elements<Element> Elements { get; set; }
    
    public Element GetCellFromRows(string text)
    {
        var cells = Elements.GetElements();
        var cell = cells.FirstOrDefault(e => e.Text == text);
        return cell;
    }
    
}