public record MiscItem
{
    private string itemName;
    public string ItemName
    {
        get => itemName;
        set
        {
            itemName = value;
        }
    }

    private string optionalInfo;
    public string OptionalInfo
    {
        get => optionalInfo;
        set
        {
            optionalInfo = value;
        }
    }

    public MiscItem (string itemName, string optionalInfo)
    {
        this.itemName = itemName;
        this.optionalInfo = optionalInfo;
    }
}