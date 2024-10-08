using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Table;

public class Table : BaseElement
{
    [FindBy(XPath = "//div[@class ='rt-thead -header']" )]
    public Elements<Element> Heads { get; set; }

    [FindBy(XPath = "//div[contains(@class,'rt-tr ')]")]
    public Rows Rows { get; set; }
    
    public Element GetCellFromRows(string text)
    {
        return Rows.GetCellFromRows(text);
    }
    
    public Element GetHead(string text)
    {
        var heads = Heads.GetElements();
        var head = heads.FirstOrDefault(e => e.Text == text);
        return head;
    }
}