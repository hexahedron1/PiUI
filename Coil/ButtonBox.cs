using SDL3;

namespace PiUI;

public class ButtonBox(IntPtr parentRenderer, Direction order = Direction.Horizontal) : IComponent {
    public List<Button> Buttons { get; } = [];
    public IntPtr Renderer { get; set; } = parentRenderer;
    public Property<bool> Visible { get; set; } = true;
    public Property<Direction> Order { get; set; } = order;
    
    public void Draw(int x, int y) {
        var (Width, Height) = GetSize();
        if (PiUi.DebugDraw) {
            PiUi.SetColor(Renderer, PiUi.Colors.Debug1);
            SDL.FRect rect = new() {
                X = x, Y = y,
                W = Width, H = Height
            };
            SDL.RenderRect(Renderer, rect);
        }
        if (Order == Direction.Vertical) {
            int i = 0;
            foreach (var btn in Buttons) {
                btn.Neighbors = (i > 0, i < Buttons.Count-1, false, false); // u d l r
                btn.Draw(x, y);
                var (_, dy) = btn.GetSize();
                y += dy-3;
                i++;
            }
        } else {
            int i = 0;
            foreach (var btn in Buttons) {
                btn.Neighbors = (false, false, i > 0, i < Buttons.Count-1); // u d l r
                btn.Draw(x, y);
                var (dx, _) = btn.GetSize();
                x += dx-1;
                i++;
            }
        }
    }

    public (int, int) GetSize() {
        int w = 0;
        int h = 0;
        if (Order == Direction.Vertical) {
            foreach (var btn in Buttons) {
                var (bw, bh) = btn.GetSize();
                w = Math.Max(w, bw);
                h += bh;
            }
        } else  {
            foreach (var btn in Buttons) {
                var (bw, bh) = btn.GetSize();
                w += bw;
            }
            h = 16;
        } 
        return (w, h);
    }

}