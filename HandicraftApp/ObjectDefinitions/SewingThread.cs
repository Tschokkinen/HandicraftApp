namespace HandicraftApp
{
    public record SewingThread : Identification
    {
        private string colour;
        public string Colour
        {
            get => colour;
            set
            {
                colour = value;
            }
        }

        private string optionalField;
        public string OptionalField
        {
            get => optionalField;
            set
            {
                optionalField = value;
            } 
        }

        public SewingThread (string tableName, string id, string colour, string optionalField)
        {
            this.TableName = tableName;
            this.Id = id;
            this.colour = colour;
            this.optionalField = optionalField;
        }

        public SewingThread()
        {
            GetData();
            CreateTableEntry();
        }

        public override void GetData()
        {
            this.TableName = "sewingThreads";
            //Get id.
            this.Id = CollectData.GenerateRandomId("sewingThreads");
            //Get size.
            this.colour = CollectData.AskForString("Ompelulangan väri: ");
            //Get material.
            this.optionalField = CollectData.AskForString("Lisätietoja (paina enter jättääksesi kenttä tyhjäksi): ");
        }

        public override void CreateTableEntry()
        {
            string tableEntry = $"INSERT INTO {this.TableName} (id, colour, optionalInfo) values ('{this.Id}', '{this.Colour}', '{this.OptionalField}')";
            Database.AddTableEntry(tableEntry);
        }
    }
}