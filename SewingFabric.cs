public record SewingFabric
{
    private string mainType;
    public string MainType
    {
        get => mainType;
        set
        {
            mainType = value;
        }
    }

    private string subType;
    public string SubType
    {
        get => subType;
        set
        {
            subType = value;
        }
    }

    private double width;
    public double Width
    {
        get => width;
        set
        {
            width = value;
        }
    }

    private double height;
    public double Height
    {
        get => height;
        set
        {
            height = value;
        }
    }
    
    public SewingFabric(string mainType, string subType, double width, double height)
    {
        this.mainType = mainType;
        this.subType = subType;
        this.width = width;
        this.height = height;
    }
}