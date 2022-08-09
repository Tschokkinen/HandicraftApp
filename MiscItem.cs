public record MiscItem
{
    private string id;
    public string Id
    {
        get => id;
        set
        {
            id = value;
        }
    }

    private string tableName;
    public string TableName
    {
        get => tableName;
        set
        {
            tableName = value;
        }
    }

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

    public MiscItem()
    {
        GetData();
        CreateTableEntry();
    }

    //Gathers relevant data from the user when object is instantiated.
    private void GetData()
    {
        this.tableName = "misc";
        //Get id.
        this.id = CollectData.GenerateRandomId("misc");
        //Get item name.
        this.itemName = CollectData.AskForString("Esineen nimi: ");
        //Get optional info.
        this.optionalInfo = CollectData.AskForString("Lisätietoja (paina enter jättääksesi kenttä tyhjäksi): ");
    }

    //Creates a new table entry based on the data from GetData and passes it to the Database.
    private void CreateTableEntry()
    {
        string tableEntry = $"INSERT INTO {this.TableName} (id, name, optionalInfo) values ('{this.Id}', '{this.ItemName}', '{this.OptionalInfo}')";
        Database.AddTableEntry(tableEntry);
    }
}