using SDL3;
namespace PiUI;
/// <summary>
/// A container that lays out its components sequentially
/// </summary>
public class StackBox(IntPtr parentRenderer) : IContainer {
    public List<IComponent> Components { get; set; } = [];
    public Property<int> Width { get; set; } = 0;
    public Property<int> Height { get; set; } = 0;
    public IntPtr Renderer { get; set; } = parentRenderer;
    public void HandleEvent(SDL.Event @event) {}
    public Property<int> Padding { get; set; } = 2;
    public Property<int> Spacing { get; set; } = 1;
    public void Draw(int x, int y) {
        if (!Visible) return;
        if (PiUi.DebugDraw) {
            PiUi.SetColor(Renderer, PiUi.Colors.Debug1);
            SDL.FRect rect = new() {
                X = x, Y = y,
                W = Width, H = Height
            };
            SDL.RenderRect(Renderer, rect);
        }

        int yPos = y + Padding;
        foreach (IComponent component in Components) {
            if (PiUi.DebugDraw) {
                PiUi.SetColor(Renderer, PiUi.Colors.Debug2);
                var (w, h) = component.GetSize();
                SDL.FRect rect = new() {
                    X = x + Padding, Y = yPos,
                    W = w, H = h
                };
                SDL.RenderRect(Renderer, rect);
            }
            component.Draw(x + Padding, yPos);
            yPos += component.GetSize().Item2 + Spacing;
        }
    }

    public Property<bool> Visible { get; set; } = true;
    public (int, int) GetSize() {
        return (Width, Height);
    }
}