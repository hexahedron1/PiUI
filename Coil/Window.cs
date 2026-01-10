using SDL3;

namespace COIL;
/// <summary>
/// A window that can contains UI components
/// </summary>
public class Window : IComponent, IDisposable {
    public static class Colors {
        public static int Background { get; set; } = 0x302c2e;
        public static int Header { get; set; } = 0xa0938e;
        public static int InternalBorder { get; set; } = 0x5a5353;
        public static int Border { get; set; } = 0x7d7071;
    }
    internal bool Primary { get; set; }
    public Property<string> Title { get; set; } = string.Empty;
    public Property<int> Width { get; set; } = 0;
    public Property<int> Height { get; set; } = 0;
    public Property<int> MinWidth { get; set; } = 4;
    public Property<int> MinHeight { get; set; } = 4;
    public Property<bool> Resizeable { get; set; } = false;
    public IntPtr Renderer { get; set; }
    internal IntPtr SdlWindow;
    private Property<IContainer>? _primaryContainer;
    public Property<int> Padding { get; set; } = 2;

    public Property<IContainer>? PrimaryContainer {
        get =>  _primaryContainer;
        set {
            _primaryContainer = value;
            if (_primaryContainer == null) return;
            _primaryContainer.Value.Width = Width - Padding*2;
            _primaryContainer.Value.Height = Height - Padding*2;
        }
    }
    public Window(string title, int w, int h, bool external = false) {
        if (!external) {
            SdlWindow = SDL.CreateWindow("test", w, h, SDL.WindowFlags.Hidden);
            Renderer = SDL.CreateRenderer(SdlWindow, null);
            SDL.SetDefaultTextureScaleMode(Renderer, SDL.ScaleMode.PixelArt);
            Width = w;
            Height = h;
        }
        Width.Changed += (_) => {
            if (SdlWindow != IntPtr.Zero)
                RefreshSize();
        };
        Height.Changed += (_) => {
            if (SdlWindow != IntPtr.Zero)
                RefreshSize();
        };
        Title.Changed += (newTitle) => {
            if (SdlWindow != IntPtr.Zero)
                SDL.SetWindowTitle(SdlWindow, newTitle);
        };
        RefreshSize();
        Title = title;
    }

    public void RefreshSize() {
        if (Width < MinWidth)
            Width = MinWidth;
        if (Height < MinHeight)
            Height = MinHeight;
        Console.WriteLine($"New size: {Width*2}x{Height*2}");
        SDL.SetWindowSize(SdlWindow, Width*2, Height*2);
    }

    public void Draw(int x, int y) => Draw(x, y, true);
    public void Draw(int x, int y, bool refresh) {
        if (!Visible) return;
        if (Renderer == IntPtr.Zero) return;
        Coil.SetColor(Renderer, Colors.Background);
        SDL.RenderClear(Renderer);
        Coil.SetColor(Renderer, Colors.InternalBorder);
        SDL.FRect inBorder = new SDL.FRect {
            X = 0, Y = 0,
            W = Width, H = Height
        };
        SDL.RenderRect(Renderer, inBorder);
        Coil.DrawPixel(Renderer, 1, Height - 2);
        Coil.DrawPixel(Renderer, Width-2, Height - 2);
        if (PrimaryContainer != null) PrimaryContainer.Value.Draw(x + Padding, y + Padding);
        if (refresh)
            SDL.RenderPresent(Renderer);
    }

    public (int, int) GetSize() {
        return (Width, Height);
    }

    public Coil.EmptyDelegate? Closing;
    public void Close() {
        Closing?.Invoke();
        Dispose();
    }
    private bool _disposed;

    public void Dispose() {
        if(!_disposed) {
            if (SdlWindow != IntPtr.Zero) {
                SDL.DestroyWindow(SdlWindow);
                SdlWindow = IntPtr.Zero;
            }
            if (Renderer != IntPtr.Zero) {
                SDL.DestroyRenderer(Renderer);
                Renderer = IntPtr.Zero;
            }

            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }
    public Property<bool> Visible { get; set; } = true;
}