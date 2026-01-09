using System.ComponentModel.DataAnnotations;
using System.Reflection;
using SDL3;

namespace COIL;

/// <summary>
/// Main class for managing the entire GUI
/// </summary>
public static partial class Coil {
    internal static List<Window> FloatingWindows = [];
    public static Window? PrimaryWindow;
    public static class Colors {
        public static int Outline { get; set; } = 0x1f1515;
        public static int Debug1 { get; set; } = 0xe6482e;
        public static int Debug2 { get; set; } = 0x3978a8;
        public static int Debug3 { get; set; } = 0xb6d53c;
        public static int Debug4 { get; set; } = 0xeea160;
    }
    public static bool DebugDraw = false;
    public static Font RegularFont;
    public static Font SmallFont;
    public static IntPtr Icons;
    public static IntPtr SymbolicIcons;

    public static bool Init(string title, int w, int h) {
        PrimaryWindow = new Window(title, w, h);
        PrimaryWindow.Primary = true;
        Console.WriteLine("Initializing SDL...");
        if (!SDL.Init(SDL.InitFlags.Video)) {
            SDL.LogError(SDL.LogCategory.System, $"Failed to init SDL: {SDL.GetError()}");
            return false;
        }

        SDL.DestroyRenderer(PrimaryWindow.Renderer);
        SDL.DestroyWindow(PrimaryWindow.SdlWindow);
        PrimaryWindow.SdlWindow = SDL.CreateWindow(PrimaryWindow.Title, PrimaryWindow.Width, PrimaryWindow.Height,
            SDL.WindowFlags.Hidden);
        PrimaryWindow.Renderer = SDL.CreateRenderer(PrimaryWindow.SdlWindow, null);
        SDL.SetDefaultTextureScaleMode(PrimaryWindow.Renderer, SDL.ScaleMode.PixelArt);
        PrimaryWindow.Closing += () => _loop = false;
        SDL.SetRenderScale(PrimaryWindow.Renderer, 2, 2);
        SDL.HideCursor();
        PrimaryWindow.RefreshSize();
        string configFolder = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "piui");
        foreach (string[] path in new string[][] {
                     [],
                     ["fonts"],
                     ["icons"]
                 }) {
            string finalPath = path.Aggregate(configFolder, Path.Join);
            if (!Directory.Exists(finalPath)) Directory.CreateDirectory(finalPath);
            Console.WriteLine($"Restored {finalPath}");
        }

        Console.WriteLine("Loading normal font...");
        ExtractResource("Coil.Resources.aseprite_font.png", Path.Join(configFolder, "fonts", "aseprite.png"));
        IntPtr regularSurface = Image.Load(Path.Join(configFolder, "fonts", "aseprite.png"));
        RegularFont = new(regularSurface, 7);
        for (int i = 0; i < 0x4FF; i++) {
            int gx = i % 16 * 11 + 1;
            int gy = i / 16 * 11 + 1;
            int gw = 0;
            for (; gw < 10; gw++) {
                SDL.ReadSurfacePixel(regularSurface, gx + gw, gy, out byte r, out byte g, out byte b, out byte a);
                if ((r == 0 && g == 0 && b == 0 && a == 255)
                    || (r == 255 && g == 0 && b == 0 && a == 0)) break;
            }

            char c = char.ConvertFromUtf32(i + 0x20)[0];
            RegularFont.Glyphs.Add(c, new SDL.FRect {
                X = gx,
                Y = gy,
                W = gw,
                H = 7
            });
        }

        Console.WriteLine("Loading small font...");
        ExtractResource("Coil.Resources.aseprite_mini.png", Path.Join(configFolder, "fonts", "aseprite_mini.png"));
        IntPtr smallSurface = Image.Load(Path.Join(configFolder, "fonts", "aseprite_mini.png"));
        SmallFont = new(smallSurface, 5);
        for (int i = 0; i < 0xFF; i++) {
            int gx = i % 16 * 11 + 1;
            int gy = i / 16 * 11 + 1;
            int gw = 0;
            for (; gw < 6; gw++) {
                SDL.ReadSurfacePixel(regularSurface, gx + gw, gy, out byte r, out byte g, out byte b, out byte a);
                if ((r == 0 && g == 0 && b == 0 && a == 255)
                    || (r == 255 && g == 0 && b == 0 && a == 0)) break;
            }

            char c = char.ConvertFromUtf32(i + 0x20)[0];
            SmallFont.Glyphs.Add(c, new SDL.FRect {
                X = gx,
                Y = gy,
                W = gw - 1, // i do not know why, but it always adds an extra pixel of width on the small font
                H = 5
            });
        }
        Console.WriteLine("Loading cursors...");
        ExtractResource("Coil.Resources.cursor.png", Path.Join(configFolder, "cursor.png"));
        cursorSurface = Image.Load(Path.Join(configFolder, "cursor.png"));

        Console.WriteLine("Loading icons...");
        ExtractResource("Coil.Resources.icons.png", Path.Join(configFolder, "icons.png"));
        Icons = Image.Load(Path.Join(configFolder, "icons.png"));
        
        Console.WriteLine("Loading symbolic icons...");
        ExtractResource("Coil.Resources.icons_symbolic.png", Path.Join(configFolder, "icons_symbolic.png"));
        SymbolicIcons = Image.Load(Path.Join(configFolder, "icons_symbolic.png"));
        return true;
    }
    private static IntPtr cursorSurface = IntPtr.Zero;
    private static Cursor[] cursors = [
        new (new() {
            X = 0, Y = 0,
            W = 9, H = 9
        }, 1, 1),
        new (new() {
            X = 9, Y = 0,
            W = 5, H = 11
        }, 2, 5),
        new (new() {
            X = 14, Y = 0,
            W = 11, H = 5
        }, 5, 2),
        new (new() {
            X = 25, Y = 0,
            W = 11, H = 11
        }, 5, 5),
        new (new() {
            X = 36, Y = 0,
            W = 10, H = 12
        }, 3, 1),
        new (new() {
            X = 46, Y = 0,
            W = 7, H = 11
        }, 3, 9),
        new (new() {
            X = 53, Y = 0,
            W = 9, H = 9
        }, 4, 4),
        new (new() {
            X = 62, Y = 0,
            W = 5, H = 11
        }, 2, 5)
    ];
    public static CursorType Cursor { get; set; }

    public enum CursorType {
        Pointer,
        VertArrows,
        HorizArrows,
        Arrows,
        Hand,
        Question,
        Deny,
        Text
    }

    private static void ExtractResource(string name, string path) {
        Console.WriteLine($"Extracting {name} to {path}...");
        using var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
        if (resource is null) {
            Console.WriteLine($"Could not find resource: {name}");
            return;
        }
        using var file = new FileStream(path, FileMode.Create, FileAccess.Write);
        resource.CopyTo(file);
    }
    
    public static (byte, byte, byte) UnpackColor(int color) {
        return ((byte)(color >> 16 & 0xff), (byte)(color >> 8 & 0xff), (byte)(color & 0xff));
    }
    public static SDL.FRect pixel = new() { H = 1, W = 1 };

    public static void DrawPixel(IntPtr renderer, int x, int y) {
        pixel.X = x;
        pixel.Y = y;
        SDL.RenderRect(renderer, pixel);
    }

    internal static void SetColor(IntPtr renderer, (byte, byte, byte) color) {
        SDL.SetRenderDrawColor(renderer, color.Item1, color.Item2, color.Item3, 255);
    } internal static void SetColor(IntPtr renderer, int hexcolor) {
        (byte, byte, byte) color = UnpackColor(hexcolor);
        SDL.SetRenderDrawColor(renderer, color.Item1, color.Item2, color.Item3, 255);
    }
    private static bool _loop = true;
    public static int MouseX;
    public static int MouseY;
    public static void Start() {
        Console.WriteLine("Starting UI loop...");
        if (PrimaryWindow is null) {
            throw new InvalidOperationException($"Call {nameof(Init)}() before starting GUI");
        }
        SDL.ShowWindow(PrimaryWindow.SdlWindow);
        while (_loop) {
            while (SDL.PollEvent(out SDL.Event @event)) {
                Console.WriteLine($"SDL event: {(SDL.EventType)@event.Type}");
                switch ((SDL.EventType)@event.Type) {
                    case SDL.EventType.WindowCloseRequested:
                    case SDL.EventType.Quit:
                        PrimaryWindow.Close();
                        break;
                    case SDL.EventType.MouseMotion:
                        SDL.GetMouseState(out float mx, out float my);
                        MouseX = (int)mx / 2;
                        MouseY = (int)my / 2;
                        MouseMoved?.Invoke(MouseX, MouseY, null);
                        break;
                    case SDL.EventType.MouseButtonDown:
                        Console.WriteLine($"{MouseX}, {MouseY}, {@event.Button.Button}");
                        MouseDown?.Invoke(MouseX, MouseY, @event.Button.Button);
                        break;
                    case SDL.EventType.MouseButtonUp:
                        Console.WriteLine($"{MouseX}, {MouseY}, {@event.Button.Button}");
                        MouseUp?.Invoke(MouseX, MouseY, @event.Button.Button);
                        break;
                }
            }
            Cursor = CursorType.Pointer;
            PrimaryWindow.Draw(0, 0, false);
            if (DebugDraw) {
                SetColor(PrimaryWindow.Renderer, Colors.Debug3);
                SDL.RenderLine(PrimaryWindow.Renderer, 0, MouseY, PrimaryWindow.Width, MouseY);
                SDL.RenderLine(PrimaryWindow.Renderer, MouseX, 0,   MouseX, PrimaryWindow.Width);
            }
            IntPtr tex = SDL.CreateTextureFromSurface(PrimaryWindow.Renderer, cursorSurface);
            var sRect = cursors[(int)Cursor].TexCoords;
            var dRect = new SDL.FRect {
                X = MouseX - cursors[(int)Cursor].Center.Item1,
                Y = MouseY - cursors[(int)Cursor].Center.Item2,
                W = sRect.W,
                H = sRect.H
            };
            SDL.RenderTexture(PrimaryWindow.Renderer, tex, in sRect, in dRect);
            SDL.DestroyTexture(tex);
            
            SDL.RenderPresent(PrimaryWindow.Renderer);
        }
        Exit?.Invoke();
        SDL.DestroySurface(RegularFont.Surface);
        SDL.DestroySurface(SmallFont.Surface);
        SDL.DestroySurface(cursorSurface);
        SDL.Quit();
    }
}