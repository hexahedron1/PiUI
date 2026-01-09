using SDL3;
namespace PiUI;
/// <summary>
/// A container that lays out its components sequentially
/// </summary>
public class StackBox(IntPtr parentRenderer, Direction dir = Direction.Vertical, Alignment align = Alignment.Start) : IContainer {
    public List<IComponent> Components { get; set; } = [];
    public Property<int> Width { get; set; } = 0;
    public Property<int> Height { get; set; } = 0;
    public IntPtr Renderer { get; set; } = parentRenderer;
    public void HandleEvent(SDL.Event @event) {}
    public Property<Direction> Direction { get; set; } = dir;
    public Property<Alignment> Alignment { get; set; } = align;
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

        if (Direction == PiUI.Direction.Vertical) {
            int yPos = y + Padding;
            Height = Padding;
            foreach (IComponent component in Components) {
                var (w, h) = component.GetSize();
                if (PiUi.DebugDraw) {
                    PiUi.SetColor(Renderer, PiUi.Colors.Debug2);
                    SDL.FRect rect = new() {
                        X = x + Padding, Y = yPos,
                        W = w, H = h
                    };
                    SDL.RenderRect(Renderer, rect);
                }

                int xOff = Alignment.Value switch {
                    PiUI.Alignment.Start => 0,
                    PiUI.Alignment.Center => Width / 2 - w / 2,
                    PiUI.Alignment.End => Width - w,
                    _ => 0
                };
                component.Draw(x + Padding + xOff, yPos);
                yPos += h + Spacing;
                Height += h + Spacing;
                Width = Math.Max(Width, w + Padding*2);
            }
            Height += Spacing;
        }
        else {
            int xPos = x + Padding;
            Width = Padding;
            foreach (IComponent component in Components) {
                var (w, h) = component.GetSize();
                if (PiUi.DebugDraw) {
                    PiUi.SetColor(Renderer, PiUi.Colors.Debug2);
                    SDL.FRect rect = new() {
                        X = xPos, Y = y + Padding,
                        W = w, H = h
                    };
                    SDL.RenderRect(Renderer, rect);
                }
                int yOff = Alignment.Value switch {
                    PiUI.Alignment.Start => 0,
                    PiUI.Alignment.Center => Height / 2 - h / 2,
                    PiUI.Alignment.End => Height - h,
                    _ => 0
                };
                component.Draw(xPos ,y + Padding + yOff);
                xPos += w + Spacing;
                Width += w + Spacing;
                Height = Math.Max(Height, h + Padding*2);
            }

            Width += Padding;
        }
    }

    public Property<bool> Visible { get; set; } = true;
    public (int, int) GetSize() {
        return (Width, Height);
    }
}