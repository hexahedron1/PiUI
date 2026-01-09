using SDL3;

namespace PiUI;

public struct Icon(IntPtr surface, SDL.FRect location) {
    public IntPtr Surface { get; set; } = surface;
    public SDL.FRect Location { get; set; } = location;

    public void Draw(IntPtr renderer, int x, int y) {
        IntPtr tex = SDL.CreateTextureFromSurface(renderer, Surface);
        var drect = new SDL.FRect {
            X = x, Y = y,
            W = Location.W, H = Location.H
        };
        SDL.FRect rect = Location;
        SDL.RenderTexture(renderer, tex, in rect, in drect);
        SDL.DestroyTexture(tex);
    }
    #region Constants
    public static readonly Icon SymbolicAdd = new(PiUi.SymbolicIcons, new SDL.FRect { X = 0, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicConfirm = new(PiUi.SymbolicIcons, new SDL.FRect { X = 8, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicDelete = new (PiUi.SymbolicIcons, new SDL.FRect { X = 16, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicRemove = new (PiUi.SymbolicIcons, new SDL.FRect { X = 24, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicClean = new (PiUi.SymbolicIcons, new SDL.FRect { X = 32, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicPicker = new (PiUi.SymbolicIcons, new SDL.FRect { X = 40, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicCopy = new (PiUi.SymbolicIcons, new SDL.FRect { X = 48, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicCut = new (PiUi.SymbolicIcons, new SDL.FRect { X = 56, Y = 0, W = 8, H = 8 });
    
    public static readonly Icon SymbolicPaste = new(PiUi.SymbolicIcons, new SDL.FRect { X = 0, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicLock = new(PiUi.SymbolicIcons, new SDL.FRect { X = 8, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicError = new(PiUi.SymbolicIcons, new SDL.FRect { X = 16, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicInfo = new(PiUi.SymbolicIcons, new SDL.FRect { X = 24, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicQuestion = new(PiUi.SymbolicIcons, new SDL.FRect { X = 32, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicWarning = new(PiUi.SymbolicIcons, new SDL.FRect { X = 40, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicPlay = new(PiUi.SymbolicIcons, new SDL.FRect { X = 48, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicFind = new(PiUi.SymbolicIcons, new SDL.FRect { X = 56, Y = 8, W = 8, H = 8 });
    
    public static readonly Icon SymbolicFindReplace = new(PiUi.SymbolicIcons, new SDL.FRect { X = 0, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicSave = new(PiUi.SymbolicIcons, new SDL.FRect { X = 8, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicBottom = new(PiUi.SymbolicIcons, new SDL.FRect { X = 16, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicTop = new(PiUi.SymbolicIcons, new SDL.FRect { X = 24, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicLeftmost = new(PiUi.SymbolicIcons, new SDL.FRect { X = 32, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicRightmost = new(PiUi.SymbolicIcons, new SDL.FRect { X = 40, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicUp = new(PiUi.SymbolicIcons, new SDL.FRect { X = 48, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicDown = new(PiUi.SymbolicIcons, new SDL.FRect { X = 56, Y = 16, W = 8, H = 8 });
    
    public static readonly Icon SymbolicLeft = new(PiUi.SymbolicIcons, new SDL.FRect { X = 0, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicRight = new(PiUi.SymbolicIcons, new SDL.FRect { X = 8, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicHelp = new(PiUi.SymbolicIcons, new SDL.FRect { X = 16, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicHome = new(PiUi.SymbolicIcons, new SDL.FRect { X = 24, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicMissing = new(PiUi.SymbolicIcons, new SDL.FRect { X = 32, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicNew = new(PiUi.SymbolicIcons, new SDL.FRect { X = 40, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicOpen = new(PiUi.SymbolicIcons, new SDL.FRect { X = 48, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicTrash = new(PiUi.SymbolicIcons, new SDL.FRect { X = 56, Y = 24, W = 8, H = 8 });
    
    public static readonly Icon SymbolicProperties = new(PiUi.SymbolicIcons, new SDL.FRect { X = 0, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicSettings = new(PiUi.SymbolicIcons, new SDL.FRect { X = 8, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicQuit = new (PiUi.SymbolicIcons, new SDL.FRect { X = 16, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicUndo = new (PiUi.SymbolicIcons, new SDL.FRect { X = 24, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicRedo = new (PiUi.SymbolicIcons, new SDL.FRect { X = 32, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicRefresh = new (PiUi.SymbolicIcons, new SDL.FRect { X = 40, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicEdit = new (PiUi.SymbolicIcons, new SDL.FRect { X = 48, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicSaveAs = new (PiUi.SymbolicIcons, new SDL.FRect { X = 56, Y = 32, W = 8, H = 8 });
    
    public static readonly Icon SymbolicPause = new(PiUi.SymbolicIcons, new SDL.FRect { X = 0, Y = 40, W = 8, H = 8 });
    public static readonly Icon SymbolicStop = new(PiUi.SymbolicIcons, new SDL.FRect { X = 8, Y = 40, W = 8, H = 8 });
    public static readonly Icon SymbolicZoomIn = new (PiUi.SymbolicIcons, new SDL.FRect { X = 16, Y = 40, W = 8, H = 8 });
    public static readonly Icon SymbolicZoomOut = new (PiUi.SymbolicIcons, new SDL.FRect { X = 24, Y = 40, W = 8, H = 8 });
    public static readonly Icon SymbolicZoomReset = new (PiUi.SymbolicIcons, new SDL.FRect { X = 32, Y = 40, W = 8, H = 8 });
    
    public static readonly Icon Add = new(PiUi.Icons, new SDL.FRect { X = 0, Y = 0, W = 8, H = 8 });
    public static readonly Icon Confirm = new(PiUi.Icons, new SDL.FRect { X = 8, Y = 0, W = 8, H = 8 });
    public static readonly Icon Delete = new (PiUi.Icons, new SDL.FRect { X = 16, Y = 0, W = 8, H = 8 });
    public static readonly Icon Remove = new (PiUi.Icons, new SDL.FRect { X = 24, Y = 0, W = 8, H = 8 });
    public static readonly Icon Clean = new (PiUi.Icons, new SDL.FRect { X = 32, Y = 0, W = 8, H = 8 });
    public static readonly Icon Picker = new (PiUi.Icons, new SDL.FRect { X = 40, Y = 0, W = 8, H = 8 });
    public static readonly Icon Copy = new (PiUi.Icons, new SDL.FRect { X = 48, Y = 0, W = 8, H = 8 });
    public static readonly Icon Cut = new (PiUi.Icons, new SDL.FRect { X = 56, Y = 0, W = 8, H = 8 });
    
    public static readonly Icon Paste = new(PiUi.Icons, new SDL.FRect { X = 0, Y = 8, W = 8, H = 8 });
    public static readonly Icon Lock = new(PiUi.Icons, new SDL.FRect { X = 8, Y = 8, W = 8, H = 8 });
    public static readonly Icon Error = new(PiUi.Icons, new SDL.FRect { X = 16, Y = 8, W = 8, H = 8 });
    public static readonly Icon Info = new(PiUi.Icons, new SDL.FRect { X = 24, Y = 8, W = 8, H = 8 });
    public static readonly Icon Question = new(PiUi.Icons, new SDL.FRect { X = 32, Y = 8, W = 8, H = 8 });
    public static readonly Icon Warning = new(PiUi.Icons, new SDL.FRect { X = 40, Y = 8, W = 8, H = 8 });
    public static readonly Icon Play = new(PiUi.Icons, new SDL.FRect { X = 48, Y = 8, W = 8, H = 8 });
    public static readonly Icon Find = new(PiUi.Icons, new SDL.FRect { X = 56, Y = 8, W = 8, H = 8 });
    
    public static readonly Icon FindReplace = new(PiUi.Icons, new SDL.FRect { X = 0, Y = 16, W = 8, H = 8 });
    public static readonly Icon Save = new(PiUi.Icons, new SDL.FRect { X = 8, Y = 16, W = 8, H = 8 });
    public static readonly Icon Bottom = new(PiUi.Icons, new SDL.FRect { X = 16, Y = 16, W = 8, H = 8 });
    public static readonly Icon Top = new(PiUi.Icons, new SDL.FRect { X = 24, Y = 16, W = 8, H = 8 });
    public static readonly Icon Leftmost = new(PiUi.Icons, new SDL.FRect { X = 32, Y = 16, W = 8, H = 8 });
    public static readonly Icon Rightmost = new(PiUi.Icons, new SDL.FRect { X = 40, Y = 16, W = 8, H = 8 });
    public static readonly Icon Up = new(PiUi.Icons, new SDL.FRect { X = 48, Y = 16, W = 8, H = 8 });
    public static readonly Icon Down = new(PiUi.Icons, new SDL.FRect { X = 56, Y = 16, W = 8, H = 8 });
    
    public static readonly Icon Left = new(PiUi.Icons, new SDL.FRect { X = 0, Y = 24, W = 8, H = 8 });
    public static readonly Icon Right = new(PiUi.Icons, new SDL.FRect { X = 8, Y = 24, W = 8, H = 8 });
    public static readonly Icon Help = new(PiUi.Icons, new SDL.FRect { X = 16, Y = 24, W = 8, H = 8 });
    public static readonly Icon Home = new(PiUi.Icons, new SDL.FRect { X = 24, Y = 24, W = 8, H = 8 });
    public static readonly Icon Missing = new(PiUi.Icons, new SDL.FRect { X = 32, Y = 24, W = 8, H = 8 });
    public static readonly Icon New = new(PiUi.Icons, new SDL.FRect { X = 40, Y = 24, W = 8, H = 8 });
    public static readonly Icon Open = new(PiUi.Icons, new SDL.FRect { X = 48, Y = 24, W = 8, H = 8 });
    public static readonly Icon Trash = new(PiUi.Icons, new SDL.FRect { X = 56, Y = 24, W = 8, H = 8 });
    
    public static readonly Icon Properties = new(PiUi.Icons, new SDL.FRect { X = 0, Y = 32, W = 8, H = 8 });
    public static readonly Icon Settings = new(PiUi.Icons, new SDL.FRect { X = 8, Y = 32, W = 8, H = 8 });
    public static readonly Icon Quit = new (PiUi.Icons, new SDL.FRect { X = 16, Y = 32, W = 8, H = 8 });
    public static readonly Icon Undo = new (PiUi.Icons, new SDL.FRect { X = 24, Y = 32, W = 8, H = 8 });
    public static readonly Icon Redo = new (PiUi.Icons, new SDL.FRect { X = 32, Y = 32, W = 8, H = 8 });
    public static readonly Icon Refresh = new (PiUi.Icons, new SDL.FRect { X = 40, Y = 32, W = 8, H = 8 });
    public static readonly Icon Edit = new (PiUi.Icons, new SDL.FRect { X = 48, Y = 32, W = 8, H = 8 });
    public static readonly Icon SaveAs = new (PiUi.Icons, new SDL.FRect { X = 56, Y = 32, W = 8, H = 8 });
    
    public static readonly Icon Pause = new(PiUi.Icons, new SDL.FRect { X = 0, Y = 40, W = 8, H = 8 });
    public static readonly Icon Stop = new(PiUi.Icons, new SDL.FRect { X = 8, Y = 40, W = 8, H = 8 });
    public static readonly Icon ZoomIn = new (PiUi.Icons, new SDL.FRect { X = 16, Y = 40, W = 8, H = 8 });
    public static readonly Icon ZoomOut = new (PiUi.Icons, new SDL.FRect { X = 24, Y = 40, W = 8, H = 8 });
    public static readonly Icon ZoomReset = new (PiUi.Icons, new SDL.FRect { X = 32, Y = 40, W = 8, H = 8 });
    #endregion              
}