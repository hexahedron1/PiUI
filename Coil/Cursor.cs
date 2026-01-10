using SDL3;

namespace COIL;

public class Cursor(SDL.FRect coords, int cx, int cy) {
    public SDL.FRect TexCoords { get; } = coords;
    public (int, int) Center { get; } = (cx, cy);
}