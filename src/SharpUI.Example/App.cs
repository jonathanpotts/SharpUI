using System.Drawing;

namespace SharpUI.Example
{
    public static class App
    {
        public static View View = new View()
        {
            new Text()
            {
                new Span("Hello world")
                    .ForegroundColor(Color.Magenta),
                new Span(" "),
                new Span("from .NET!")
                    .ForegroundColor(Color.Navy)
            }
                .FontFamily(new FileFontFamily("fonts/Bangers/Bangers-Regular.ttf"))
        };
    }
}
