using Markdig.Renderers;

public class SsmlRender : HtmlRenderer
{
    public bool ExplicitOrdinalInOrderedList {get; set;} = true;
    public bool AutoAddMathDomainTag {get; set;} = true;
    public SsmlRender(System.IO.TextWriter writer) : base(writer)
    {
    }
}