namespace PiUI;

public class IconLabel(IntPtr renderer, Icon icon) : IComponent {
    
    public Property<bool> Visible { get; set; } = true;
    public IntPtr Renderer { get; set; } = renderer;
    public Property<Icon> Icon { get; set; } = icon;
    public (int, int) GetSize() => ((int)Icon.Value.Location.W, (int)Icon.Value.Location.H);

    public void Draw(int x, int y) {
        Icon.Value.Draw(Renderer, x, y);
    }
}