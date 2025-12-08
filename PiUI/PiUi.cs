using System.Reflection;
using SDL3;

namespace PiUI;

/// <summary>
/// Main class for managing the entire GUI
/// </summary>
public static class PiUi {
    internal static List<Window> FloatingWindows = [];
    public static Window? PrimaryWindow;
    public static class Colors {
        public static int Outline { get; set; } = 0x1f1515;
        public static int Debug1 { get; set; } = 0xe6482e;
    }
    public delegate void EmptyDelegate();
    public static event EmptyDelegate? Exit;
    public static bool DebugDraw = false;
    public static IntPtr RegularFont { get; private set; }
    public static IntPtr SmallFont { get; private set; }
    public static bool Init(string title, int w, int h) {
        PrimaryWindow = new Window(title, w, h);
        PrimaryWindow.Primary = true;
        Console.WriteLine("Initializing SDL...");
        if (!SDL.Init(SDL.InitFlags.Video)) {
            SDL.LogError(SDL.LogCategory.System, $"FATAL: {SDL.GetError()}");
            return false;
        }
        SDL.DestroyRenderer(PrimaryWindow.Renderer);
        SDL.DestroyWindow(PrimaryWindow.SdlWindow);
        PrimaryWindow.SdlWindow = SDL.CreateWindow(PrimaryWindow.Title, PrimaryWindow.Width, PrimaryWindow.Height, SDL.WindowFlags.Hidden);
        PrimaryWindow.Renderer = SDL.CreateRenderer(PrimaryWindow.SdlWindow, null);
        PrimaryWindow.Closing += () => _loop = false;
        SDL.SetRenderScale(PrimaryWindow.Renderer, 2, 2);
        PrimaryWindow.RefreshSize();
        string configFolder = Path.Join(nameof(Environment.SpecialFolder.ApplicationData), "piui");
        if (!Directory.Exists(configFolder)) Directory.CreateDirectory(configFolder);
        if (!File.Exists(Path.Join(configFolder, "aseprite.ttf"))) ExtractResource("aseprite.ttf", Path.Join(configFolder, "aseprite.ttf"));
        if (!File.Exists(Path.Join(configFolder, "aseprite-mini.ttf"))) ExtractResource("aseprite-mini.ttf", Path.Join(configFolder, "aseprite-mini.ttf"));
        RegularFont = TTF.OpenFont(Path.Join(configFolder, "aseprite.ttf"), 7f);
        SmallFont = TTF.OpenFont(Path.Join(configFolder, "aseprite-mini.ttf"), 7f);
        return true;
    }

    private static void ExtractResource(string name, string path) {
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
    public static SDL.FRect pixel = new SDL.FRect() { H = 1, W = 1 };

    public static void DrawPixel(IntPtr renderer, int x, int y) {
        pixel.X = x;
        pixel.Y = y;
        SDL.RenderRect(renderer, pixel);
    }

    public static int DrawText(string text, int x, int y, IntPtr font) {
        
    }

    internal static void SetColor(IntPtr renderer, (byte, byte, byte) color) {
        SDL.SetRenderDrawColor(renderer, color.Item1, color.Item2, color.Item3, 255);
    } internal static void SetColor(IntPtr renderer, int hexcolor) {
        (byte, byte, byte) color = UnpackColor(hexcolor);
        SDL.SetRenderDrawColor(renderer, color.Item1, color.Item2, color.Item3, 255);
    }
    private static bool _loop = true;
    public static void Start() {
        if (PrimaryWindow is null) {
            throw new InvalidOperationException($"Call {nameof(Init)}() before starting GUI");
        }
        SDL.ShowWindow(PrimaryWindow.SdlWindow);
        while (_loop) {
            #region Render
            PrimaryWindow!.Draw(0, 0);
            #endregion
            while (SDL.PollEvent(out SDL.Event @event)) {
                Console.WriteLine($"SDL event: {(SDL.EventType)@event.Type}");
                switch ((SDL.EventType)@event.Type) {
                    case SDL.EventType.WindowCloseRequested:
                    case SDL.EventType.Quit:
                        PrimaryWindow.Close();
                        break;
                }

                PrimaryWindow.HandleEvent(@event);
            }
        }
        Exit?.Invoke();
        SDL.Quit();
    }
}