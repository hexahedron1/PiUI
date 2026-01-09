using SDL3;

namespace COIL;

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
    public static readonly Icon SymbolicAdd = new(Coil.SymbolicIcons, new SDL.FRect { X = 0, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicConfirm = new(Coil.SymbolicIcons, new SDL.FRect { X = 8, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicDelete = new (Coil.SymbolicIcons, new SDL.FRect { X = 16, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicRemove = new (Coil.SymbolicIcons, new SDL.FRect { X = 24, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicClean = new (Coil.SymbolicIcons, new SDL.FRect { X = 32, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicPicker = new (Coil.SymbolicIcons, new SDL.FRect { X = 40, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicCopy = new (Coil.SymbolicIcons, new SDL.FRect { X = 48, Y = 0, W = 8, H = 8 });
    public static readonly Icon SymbolicCut = new (Coil.SymbolicIcons, new SDL.FRect { X = 56, Y = 0, W = 8, H = 8 });
    
    public static readonly Icon SymbolicPaste = new(Coil.SymbolicIcons, new SDL.FRect { X = 0, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicLock = new(Coil.SymbolicIcons, new SDL.FRect { X = 8, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicError = new(Coil.SymbolicIcons, new SDL.FRect { X = 16, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicInfo = new(Coil.SymbolicIcons, new SDL.FRect { X = 24, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicQuestion = new(Coil.SymbolicIcons, new SDL.FRect { X = 32, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicWarning = new(Coil.SymbolicIcons, new SDL.FRect { X = 40, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicPlay = new(Coil.SymbolicIcons, new SDL.FRect { X = 48, Y = 8, W = 8, H = 8 });
    public static readonly Icon SymbolicFind = new(Coil.SymbolicIcons, new SDL.FRect { X = 56, Y = 8, W = 8, H = 8 });
    
    public static readonly Icon SymbolicFindReplace = new(Coil.SymbolicIcons, new SDL.FRect { X = 0, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicSave = new(Coil.SymbolicIcons, new SDL.FRect { X = 8, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicBottom = new(Coil.SymbolicIcons, new SDL.FRect { X = 16, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicTop = new(Coil.SymbolicIcons, new SDL.FRect { X = 24, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicLeftmost = new(Coil.SymbolicIcons, new SDL.FRect { X = 32, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicRightmost = new(Coil.SymbolicIcons, new SDL.FRect { X = 40, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicUp = new(Coil.SymbolicIcons, new SDL.FRect { X = 48, Y = 16, W = 8, H = 8 });
    public static readonly Icon SymbolicDown = new(Coil.SymbolicIcons, new SDL.FRect { X = 56, Y = 16, W = 8, H = 8 });
    
    public static readonly Icon SymbolicLeft = new(Coil.SymbolicIcons, new SDL.FRect { X = 0, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicRight = new(Coil.SymbolicIcons, new SDL.FRect { X = 8, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicHelp = new(Coil.SymbolicIcons, new SDL.FRect { X = 16, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicHome = new(Coil.SymbolicIcons, new SDL.FRect { X = 24, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicMissing = new(Coil.SymbolicIcons, new SDL.FRect { X = 32, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicNew = new(Coil.SymbolicIcons, new SDL.FRect { X = 40, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicOpen = new(Coil.SymbolicIcons, new SDL.FRect { X = 48, Y = 24, W = 8, H = 8 });
    public static readonly Icon SymbolicTrash = new(Coil.SymbolicIcons, new SDL.FRect { X = 56, Y = 24, W = 8, H = 8 });
    
    public static readonly Icon SymbolicProperties = new(Coil.SymbolicIcons, new SDL.FRect { X = 0, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicSettings = new(Coil.SymbolicIcons, new SDL.FRect { X = 8, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicQuit = new (Coil.SymbolicIcons, new SDL.FRect { X = 16, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicUndo = new (Coil.SymbolicIcons, new SDL.FRect { X = 24, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicRedo = new (Coil.SymbolicIcons, new SDL.FRect { X = 32, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicRefresh = new (Coil.SymbolicIcons, new SDL.FRect { X = 40, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicEdit = new (Coil.SymbolicIcons, new SDL.FRect { X = 48, Y = 32, W = 8, H = 8 });
    public static readonly Icon SymbolicSaveAs = new (Coil.SymbolicIcons, new SDL.FRect { X = 56, Y = 32, W = 8, H = 8 });
    
    public static readonly Icon SymbolicPause = new(Coil.SymbolicIcons, new SDL.FRect { X = 0, Y = 40, W = 8, H = 8 });
    public static readonly Icon SymbolicStop = new(Coil.SymbolicIcons, new SDL.FRect { X = 8, Y = 40, W = 8, H = 8 });
    public static readonly Icon SymbolicZoomIn = new (Coil.SymbolicIcons, new SDL.FRect { X = 16, Y = 40, W = 8, H = 8 });
    public static readonly Icon SymbolicZoomOut = new (Coil.SymbolicIcons, new SDL.FRect { X = 24, Y = 40, W = 8, H = 8 });
    public static readonly Icon SymbolicZoomReset = new (Coil.SymbolicIcons, new SDL.FRect { X = 32, Y = 40, W = 8, H = 8 });
    
    public static readonly Icon Add = new(Coil.Icons, new SDL.FRect { X = 0, Y = 0, W = 8, H = 8 });
    public static readonly Icon Confirm = new(Coil.Icons, new SDL.FRect { X = 8, Y = 0, W = 8, H = 8 });
    public static readonly Icon Delete = new (Coil.Icons, new SDL.FRect { X = 16, Y = 0, W = 8, H = 8 });
    public static readonly Icon Remove = new (Coil.Icons, new SDL.FRect { X = 24, Y = 0, W = 8, H = 8 });
    public static readonly Icon Clean = new (Coil.Icons, new SDL.FRect { X = 32, Y = 0, W = 8, H = 8 });
    public static readonly Icon Picker = new (Coil.Icons, new SDL.FRect { X = 40, Y = 0, W = 8, H = 8 });
    public static readonly Icon Copy = new (Coil.Icons, new SDL.FRect { X = 48, Y = 0, W = 8, H = 8 });
    public static readonly Icon Cut = new (Coil.Icons, new SDL.FRect { X = 56, Y = 0, W = 8, H = 8 });
    
    public static readonly Icon Paste = new(Coil.Icons, new SDL.FRect { X = 0, Y = 8, W = 8, H = 8 });
    public static readonly Icon Lock = new(Coil.Icons, new SDL.FRect { X = 8, Y = 8, W = 8, H = 8 });
    public static readonly Icon Error = new(Coil.Icons, new SDL.FRect { X = 16, Y = 8, W = 8, H = 8 });
    public static readonly Icon Info = new(Coil.Icons, new SDL.FRect { X = 24, Y = 8, W = 8, H = 8 });
    public static readonly Icon Question = new(Coil.Icons, new SDL.FRect { X = 32, Y = 8, W = 8, H = 8 });
    public static readonly Icon Warning = new(Coil.Icons, new SDL.FRect { X = 40, Y = 8, W = 8, H = 8 });
    public static readonly Icon Play = new(Coil.Icons, new SDL.FRect { X = 48, Y = 8, W = 8, H = 8 });
    public static readonly Icon Find = new(Coil.Icons, new SDL.FRect { X = 56, Y = 8, W = 8, H = 8 });
    
    public static readonly Icon FindReplace = new(Coil.Icons, new SDL.FRect { X = 0, Y = 16, W = 8, H = 8 });
    public static readonly Icon Save = new(Coil.Icons, new SDL.FRect { X = 8, Y = 16, W = 8, H = 8 });
    public static readonly Icon Bottom = new(Coil.Icons, new SDL.FRect { X = 16, Y = 16, W = 8, H = 8 });
    public static readonly Icon Top = new(Coil.Icons, new SDL.FRect { X = 24, Y = 16, W = 8, H = 8 });
    public static readonly Icon Leftmost = new(Coil.Icons, new SDL.FRect { X = 32, Y = 16, W = 8, H = 8 });
    public static readonly Icon Rightmost = new(Coil.Icons, new SDL.FRect { X = 40, Y = 16, W = 8, H = 8 });
    public static readonly Icon Up = new(Coil.Icons, new SDL.FRect { X = 48, Y = 16, W = 8, H = 8 });
    public static readonly Icon Down = new(Coil.Icons, new SDL.FRect { X = 56, Y = 16, W = 8, H = 8 });
    
    public static readonly Icon Left = new(Coil.Icons, new SDL.FRect { X = 0, Y = 24, W = 8, H = 8 });
    public static readonly Icon Right = new(Coil.Icons, new SDL.FRect { X = 8, Y = 24, W = 8, H = 8 });
    public static readonly Icon Help = new(Coil.Icons, new SDL.FRect { X = 16, Y = 24, W = 8, H = 8 });
    public static readonly Icon Home = new(Coil.Icons, new SDL.FRect { X = 24, Y = 24, W = 8, H = 8 });
    public static readonly Icon Missing = new(Coil.Icons, new SDL.FRect { X = 32, Y = 24, W = 8, H = 8 });
    public static readonly Icon New = new(Coil.Icons, new SDL.FRect { X = 40, Y = 24, W = 8, H = 8 });
    public static readonly Icon Open = new(Coil.Icons, new SDL.FRect { X = 48, Y = 24, W = 8, H = 8 });
    public static readonly Icon Trash = new(Coil.Icons, new SDL.FRect { X = 56, Y = 24, W = 8, H = 8 });
    
    public static readonly Icon Properties = new(Coil.Icons, new SDL.FRect { X = 0, Y = 32, W = 8, H = 8 });
    public static readonly Icon Settings = new(Coil.Icons, new SDL.FRect { X = 8, Y = 32, W = 8, H = 8 });
    public static readonly Icon Quit = new (Coil.Icons, new SDL.FRect { X = 16, Y = 32, W = 8, H = 8 });
    public static readonly Icon Undo = new (Coil.Icons, new SDL.FRect { X = 24, Y = 32, W = 8, H = 8 });
    public static readonly Icon Redo = new (Coil.Icons, new SDL.FRect { X = 32, Y = 32, W = 8, H = 8 });
    public static readonly Icon Refresh = new (Coil.Icons, new SDL.FRect { X = 40, Y = 32, W = 8, H = 8 });
    public static readonly Icon Edit = new (Coil.Icons, new SDL.FRect { X = 48, Y = 32, W = 8, H = 8 });
    public static readonly Icon SaveAs = new (Coil.Icons, new SDL.FRect { X = 56, Y = 32, W = 8, H = 8 });
    
    public static readonly Icon Pause = new(Coil.Icons, new SDL.FRect { X = 0, Y = 40, W = 8, H = 8 });
    public static readonly Icon Stop = new(Coil.Icons, new SDL.FRect { X = 8, Y = 40, W = 8, H = 8 });
    public static readonly Icon ZoomIn = new (Coil.Icons, new SDL.FRect { X = 16, Y = 40, W = 8, H = 8 });
    public static readonly Icon ZoomOut = new (Coil.Icons, new SDL.FRect { X = 24, Y = 40, W = 8, H = 8 });
    public static readonly Icon ZoomReset = new (Coil.Icons, new SDL.FRect { X = 32, Y = 40, W = 8, H = 8 });
    #endregion              
}