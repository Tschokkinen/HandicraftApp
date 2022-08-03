public record CrochetHook 
{
    private int size;
    public int Size
    {
        get => size;
        set
        {
            size = value;
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

    public CrochetHook (int size, string material)
    {
        this.size = size;
        this.material = material;
    }

    public override string ToString()
    {
        return $"Size of the hook is {this.size} and the material is {this.material}.";
    }
}