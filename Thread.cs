public record Thread
{
    private int size;
    public int Size
    {
        get => size;
        set
        {
            size  = value;
        }
    }

    private string material;
    public string Material
    {
        get => material;
        set
        {
            material = value;
        }
    }

    private string colour;
    public string Colour
    {
        get => colour;
        set
        {
            colour = value;
        }
    }

    public Thread (int size, string material, string colour)
    {
        this.size = size;
        this.material = material;
        this.colour = colour;
    }
}