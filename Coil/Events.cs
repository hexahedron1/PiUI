namespace COIL;

public partial class Coil {
    
    public delegate void EmptyDelegate();
    public static event EmptyDelegate? Exit;
    public delegate void MouseEvent(int x, int y, byte? button);
    public static event MouseEvent? MouseDown;
    public static event MouseEvent? MouseUp;
    public static event MouseEvent? MouseMoved;
}