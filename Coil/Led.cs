using System.Net.Security;
using SDL3;

namespace COIL;

public enum LedColor {
    Red,
    Green,
    Yellow,
    Blue,
    Cyan,
    Magenta,
    White
}

public class Led(IntPtr renderer, LedColor color) : IComponent {
    public static class Colors {
        public static Dictionary<LedColor, (int, int)> LightColors = new() {
            { LedColor.Red, (0xa93b3b, 0xe6482e) },
            { LedColor.Green, (0x71aa34, 0xb6d53c) },
            { LedColor.Yellow, (0xf47e1b, 0xf4b41b) },
            { LedColor.Blue, (0x394778, 0x3978a8) },
            { LedColor.Cyan, (0x28ccdf, 0x8aebf1) },
            { LedColor.Magenta, (0xcd6093, 0xffaeb6) },
            { LedColor.White, (0xffaeb6, 0xf4eae4) },
        };

        public static int Corner { get; set; } = 0x7d7071;
        public static int Edge { get; set; } = 0xa0938e;
    }

    public Property<bool> Visible { get; set; } = true;
    public IntPtr Renderer { get; set; } = renderer;
    public Property<LedColor> Color { get; set; } = color;
    public Property<bool> Lit { get; set; } = false;
    public (int, int) GetSize() => (5, 5);
    public void Draw(int x, int y) {
        if (!Visible) return;
        SDL.FRect rect = new SDL.FRect {
            X = x, Y = y,
            W = 5, H = 5
        };
        Coil.SetColor(renderer, Colors.Corner);
        SDL.RenderRect(renderer, rect);
        rect.X = x + 1;
        rect.W = 3;
        Coil.SetColor(renderer, Colors.Edge);
        SDL.RenderRect(renderer, rect);
        rect = new SDL.FRect {
            X = x, Y = y+1,
            W = 5, H = 3
        };
        SDL.RenderRect(renderer, rect);
        rect.X = x + 1;
        rect.W = 3;
        Coil.SetColor(renderer, Lit ? Colors.LightColors[Color].Item2 : Colors.LightColors[Color].Item1);
        SDL.RenderFillRect(renderer, rect);
        if (Lit) {
            Coil.SetColor(renderer, Colors.LightColors[Color].Item1);
            Coil.DrawPixel(renderer, x + 1, y + 3);
            Coil.DrawPixel(renderer, x + 3, y + 1);
        }
    }
}