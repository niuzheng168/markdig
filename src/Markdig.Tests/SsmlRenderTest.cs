using Markdig;
namespace Markdig.Tests.Ssml;
public class SsmlRenderTest
{
    private static MarkdownPipeline _pipeline = new MarkdownPipelineBuilder()
            .UseSsmlExtensions()
            .Build();

    [Test]
    [TestCase("1. Item one\n2. Item two\n3. Item three\n", "1. Item one\n2. Item two\n3. Item three\n")]
    [TestCase("3. Item three\n4. Item four\n5. Item five\n", "3. Item three\n4. Item four\n5. Item five\n")]
    public void TestOrderedListExplicitOrdinal(string markdown, string expectedSsml)
    {
        var ssml = Markdown.ToSsml(markdown, _pipeline);
        Assert.AreEqual(expectedSsml, ssml);
    }

    [Test]
    public void TestMathBlockRendering()
    {
        var markdown = "$$E = mc^2$$";
        var expectedSsml = "<mstts:prompt domain=\"Math\" />E = mc^2\n";
        var ssml = Markdown.ToSsml(markdown, _pipeline);
        Assert.AreEqual(expectedSsml, ssml);
    }

    [Test]
    public void TestFootnoteRendering()
    {
        var markdown = "This is link.[^1]\n[^1]: This is the footnote.";
        var expectedSsml = "This is link.\nThis is the footnote.\n";
        var ssml = Markdown.ToSsml(markdown, _pipeline);
        Assert.AreEqual(expectedSsml, ssml);
    }

    [Test]
    public void TestOnlyFootnoteRendering()
    {
        var markdown = "[^1]: This is the footnote.";
        var expectedSsml = "This is the footnote.\n";
        var ssml = Markdown.ToSsml(markdown, _pipeline);
        Assert.AreEqual(expectedSsml, ssml);
    }
}