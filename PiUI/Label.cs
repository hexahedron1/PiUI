using SDL3;

namespace PiUI;

public class Label(IntPtr renderer, string text) : IComponent {
    public Property<bool> Visible { get; set; } = true;
    public IntPtr Renderer { get; set; } = renderer;
    public Property<string> Text { get; set; } = text;
    public Property<LabelFont> Font { get; set; } = LabelFont.Regular;
    public (int, int) Draw(int x, int y) {
        return (x, y);
    }

    public void HandleEvent(SDL.Event @event) { }
}

public enum LabelFont {
    Regular = 0,
    Small = 1
}