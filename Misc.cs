public record Misc
{
    private string name;
    public string Name
    {
        get => name;
        set
        {
            name = value;
        }
    }

    private string optional;
    public string Optional
    {
        get => optional;
        set
        {
            optional = value;
        }
    }

    public Misc (string name, string optional)
    {
        this.name = name;
        this.optional = optional;
    }
}