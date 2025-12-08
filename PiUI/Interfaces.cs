using SDL3;

namespace PiUI;

/// <summary>
/// A component that can be drawn inside a window
/// </summary>
public interface IComponent {
    public Property<bool> Visible { get; set; }
    public (int, int) Draw(int x, int y);
    public IntPtr Renderer { get; internal set; }
}

/// <summary>
/// A component that contains other components
/// </summary>
enum Alignment {
    Left, Center, Right
}

public interface IContainer : IComponent {
    public IComponent[] Components { get; set; }
    public Property<int> Width { get; set; }
    public Property<int> Height { get; set; }
}