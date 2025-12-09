using SDL3;

namespace PiUI;

public class Label(IntPtr renderer, string text, Font font) : IComponent {
    public static class Colors {
        public static int Text { get; set; } = 0xcfc6b8;
        public static int Shadow { get; set; } = 0x1f1515;
    }

    public Property<bool> Visible { get; set; } = true;
    public IntPtr Renderer { get; set; } = renderer;
    public Property<string> Text { get; set; } = text;

    public Property<Font> Font { get; set; } = font;

    public void Draw(int x, int y) {
        if (!Visible) return;
        Font.Value.DrawText(Renderer,  Text, x, y+1, Colors.Shadow);
        Font.Value.DrawText(Renderer,  Text, x, y, Colors.Text);
        if (PiUi.DebugDraw) {
            PiUi.SetColor(Renderer, PiUi.Colors.Debug2);
            var (w, h) = GetSize();
            SDL.FRect rect = new() {
                X = x, Y = y,
                W = w, H = h
            };
            SDL.RenderRect(Renderer, rect);
        }
    }
    public (int, int) GetSize() => (Font.Value.MeasureText(Text), Font.Value.Height);
}

public enum LabelFont {
    Regular = 0,
    Small = 1
}