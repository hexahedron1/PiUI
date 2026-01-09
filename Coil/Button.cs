using System.Data.Common;
using SDL3;

namespace COIL;

enum ButtonState {
    Normal,
    Positive,
    Negative,
    Highlight
}
public class Button : IComponent {
    static class Colors {
        public static int Shadow { get; set; } = 0x1f1515;
        public static int Border { get; set; } = 0xa0938e;
        public static int LowerBorder { get; set; } = 0x7d7071;
        public static int Background { get; set; } = 0x5a5353;
        public static int Content { get; set; } = 0xcfc6b8;
        
        public static int PositiveBorder { get; set; } = 0x71aa34;
        public static int PositiveLowerBorder { get; set; } = 0x397b44;
        public static int PositiveBackground { get; set; } = 0x3c5956;
        public static int PositiveContent { get; set; } = 0xb6d53c;
        
        public static int NegativeBorder { get; set; } = 0xe6482e;
        public static int NegativeLowerBorder { get; set; } = 0xa93b3b;
        public static int NegativeBackground { get; set; } = 0x5e3643;
        public static int NegativeContent { get; set; } = 0xf47e1b;
        
        public static int HighlightBorder { get; set; } = 0x28ccdf;
        public static int HighlightLowerBorder { get; set; } = 0x3978a8;
        public static int HighlightBackground { get; set; } = 0x394778;
        public static int HighlightContent { get; set; } = 0x8aebf1;
    }

    public Property<bool> Visible { get; set; } = true;
    public Property<string?> Text { get; set; }
    public Property<Icon?> Icon { get; set; }
    public IntPtr Renderer { get; set; }
    private bool _pressed;
    private int _x;
    private int _y;
    public event Coil.EmptyDelegate? Pressed; 
    public Button(IntPtr renderer, string? text = null, Icon? icon = null) {
        if (text == null && icon == null) {
            throw new ArgumentNullException(nameof(text) + "," + nameof(icon), "You must define either text or an icon");
        }
        Text = text;
        Icon = icon;
        Renderer = renderer;
        Coil.MouseDown += (x, y, btn) => {
            if (btn != 1) return;
            (int w, int h) = GetSize();
            if (x >= _x && y >= _y && x <= _x + w && y <= _y + h - 4) _pressed = true;
        };
        Coil.MouseUp += (x, y, btn) => {
            if (btn != 1) return;
            if (_pressed) {
                _pressed = false;
                (int w, int h) = GetSize();
                if (x >= _x && y >= _y && x <= _x + w && y <= _y + h - 4) Pressed?.Invoke();
            }
        };
    }

    public enum ButtonStyle {
        Normal,
        Positive,
        Negative,
        Highlight
    }
    /// <summary>
    /// Used for rounding logic. Up, Down, Left, Right
    /// </summary>
    public (bool, bool, bool, bool) Neighbors { get; set; }

    public void Draw(int x, int y) {
        _x = x;
        _y = y;
        var (w, h) = GetSize();
        var rect = new SDL.FRect {
            X = x, Y = y + h - 5,
            W = w, H = 3
        };
        Coil.SetColor(Renderer, Colors.Background);
        SDL.RenderFillRect(Renderer, rect);
        Coil.SetColor(Renderer, Colors.LowerBorder);
        SDL.RenderRect(Renderer, rect);
        rect = new SDL.FRect {
            X = x, Y = y + (_pressed ? 1 : 0),
            W = w, H = h - 4
        };
        Coil.SetColor(Renderer, Colors.Background);
        SDL.RenderFillRect(Renderer, rect);
        Coil.SetColor(Renderer, Colors.Border);
        SDL.RenderRect(Renderer, rect);
        Coil.SetColor(Renderer, Colors.LowerBorder);
        // u d l r
        if (Neighbors is { Item1: false, Item3: false })
            Coil.DrawPixel(Renderer, x + 1, y + 1 + (_pressed ? 1 : 0)); // ul
        if (Neighbors is { Item1: false, Item4: false })
            Coil.DrawPixel(Renderer, (int)(x + rect.W) - 2, y + 1 + (_pressed ? 1 : 0)); // ur
        if (Neighbors is { Item2: false, Item3: false })
            Coil.DrawPixel(Renderer, x + 1, (int)(y + rect.H) - 2 + (_pressed ? 1 : 0)); // dl
        if (Neighbors is { Item2: false, Item4: false })
            Coil.DrawPixel(Renderer, (int)(x + rect.W) - 2, (int)(y + rect.H) - 2 + (_pressed ? 1 : 0)); // dr
        rect = new SDL.FRect {
            X = x, Y = y + h - 2,
            W = w, H = _pressed ? 1 : 2
        };
        Coil.SetColor(Renderer, Colors.Shadow);
        SDL.RenderFillRect(Renderer, rect);
        if (Icon.Value is not null) {
            Icon.Value.Value.Draw(Renderer, x + 2, y + 2 + (_pressed ? 1 : 0));
        }
        if (Text.Value is not null)
            Coil.RegularFont.DrawText(Renderer, Text!, x + (Icon.Value is not null ? (int)Icon.Value.Value.Location.W+1 : 0) + 2, y + 3 + (_pressed ? 1 : 0), Colors.Content);
        if (Coil.MouseX >= _x && Coil.MouseY >= _y && Coil.MouseX <= _x + w && Coil.MouseY <= _y + h - 4) Coil.Cursor = Coil.CursorType.Hand;
    }
    public (int, int) GetSize() {
        int h = 16;
        int w = 4;
        if (Text.Value is not null)
            w += Coil.RegularFont.MeasureText(Text!) +1;
        if (Icon.Value is not null)
            w += (int)Icon.Value.Value.Location.W;
        return (w, h);
    }
}