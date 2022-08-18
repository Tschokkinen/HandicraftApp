namespace HandicraftApp
{
    public record MiscItem : Identification
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

        public MiscItem (string tableName, string id, string itemName, string optionalInfo)
        {
            this.TableName = tableName;
            this.Id = id;
            this.itemName = itemName;
            this.optionalInfo = optionalInfo;
        }

        public MiscItem()
        {
            GetData();
            CreateTableEntry();
        }

        //Gathers relevant data from the user when object is instantiated.
        public override void GetData()
        {
            this.TableName = "misc";
            //Get id.
            this.Id = CollectData.GenerateRandomId("misc");
            //Get item name.
            this.itemName = CollectData.AskForString("Esineen nimi: ");
            //Get optional info.
            this.optionalInfo = CollectData.AskForString("Lisätietoja (paina enter jättääksesi kenttä tyhjäksi): ");
        }

        //Creates a new table entry based on the data from GetData and passes it to the Database.
        public override void CreateTableEntry()
        {
            string tableEntry = $"INSERT INTO {this.TableName} (id, name, optionalInfo) values ('{this.Id}', '{this.ItemName}', '{this.OptionalInfo}')";
            Database.AddTableEntry(tableEntry);
        }
    }
}