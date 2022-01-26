namespace FileManager.View
{
    public interface IOrientable
    {
        Orientation Orientation { get; }
    }

    public enum Orientation : ushort
    {
        Horizontal, Vertical
    }
}
