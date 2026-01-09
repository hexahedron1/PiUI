using System.Diagnostics.Contracts;
using SDL3;

namespace PiUI;

/// <summary>
/// A component that can be drawn inside a window
/// </summary>
public interface IComponent {
    public Property<bool> Visible { get; set; }
    public void Draw(int x, int y);
    public IntPtr Renderer { get; internal set; }
    [Pure] public (int, int) GetSize();
}
public enum Alignment {
    Start, Center, End
}

public enum Direction {
    Horizontal, Vertical
}

public interface IContainer : IComponent {
    public List<IComponent> Components { get; set; }
    public Property<int> Width { get; set; }
    public Property<int> Height { get; set; }
}