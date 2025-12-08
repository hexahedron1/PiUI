using SDL3;
namespace PiUI;
/// <summary>
/// A container that lays out its components sequentially
/// </summary>
public class StackBox : IContainer {
    public IComponent[] Components { get; set; } = [];
    public Property<int> Width { get; set; } = 0;
    public Property<int> Height { get; set; } = 0;
    public IntPtr Renderer { get; set; }
    public void HandleEvent(SDL.Event @event) {}
    public Property<int> Padding { get; set; } = 2;
    public (int, int) Draw(int x, int y) {
        if (PiUi.DebugDraw) {
            PiUi.SetColor(Renderer, PiUi.Colors.Debug1);
            SDL.FRect rect = new() {
                X = x, Y = y,
                W = Width, H = Height
            };
            SDL.RenderRect(Renderer, rect);
        }
        return (Width, Height);
    }
    public Property<bool> Visible { get; set; }

    public StackBox(IntPtr parentRenderer) {
        Renderer = parentRenderer;
    }
}