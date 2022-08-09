using System;

public record SewingFabric
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

    public SewingFabric()
    {
        GetData();
        CreateTableEntry();
    }

    //Gathers relevant data from the user when object is instantiated.
    private void GetData()
    {
        this.tableName = "sewingFabrics";
        //Get id.
        this.id = CollectData.GenerateRandomId("sewingFabrics");
        //Get fabric main type.
        this.mainType = CollectData.AskForFabricMainType("Valitse kankaan luokka: ");
        //Get fabric subtype.
        this.subType = CollectData.AskForString("Materiaalin alaluokka: ");
        //Get fabric size.
        Console.WriteLine("Kangas palan koko: ");
        this.width = CollectData.AskForDouble("Leveys (cm): ");
        this.height = CollectData.AskForDouble("Korkeus (cm): ");
    }

    //Creates a new table entry based on the data from GetData and passes it to the Database.
    private void CreateTableEntry()
    {
        string tableEntry = $"INSERT INTO {this.tableName} (id, mainType, subType, width, height) values ('{this.Id}', '{this.MainType}', '{this.SubType}', {this.Width}, {this.Height})";
        Database.AddTableEntry(tableEntry);
    }
}