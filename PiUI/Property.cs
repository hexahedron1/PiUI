namespace PiUI;

public class Property<T>(T v) {
    private T _value = v;
    public T Value {
        get => _value;
        set {
            _value = value;
            Changed?.Invoke(value);
        }
    }
    public delegate void ChangedHandler(T newValue);
    public event ChangedHandler? Changed;
    public static implicit operator T(Property<T> v) => v.Value;
    public static implicit operator Property<T>(T v) => new(v);
}