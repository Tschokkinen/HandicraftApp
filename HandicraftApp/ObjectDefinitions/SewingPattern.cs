namespace HandicraftApp
{
    public record SewingPattern : Identification
    {
        private string patternModel;
        public string PatternModel
        {
            get => patternModel;
            set
            {
                patternModel = value;
            }
        }

        private string patternSizes;
        public string PatternSizes
        {
            get => patternSizes;
            set
            {
                patternSizes = value;
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

        public SewingPattern(string tableName, string id, string patternModel, string patternSizes, string optionalInfo)
        {
            this.TableName = tableName;
            this.Id = id;
            this.patternModel = patternModel;
            this.patternSizes = patternSizes;
            this.optionalInfo = optionalInfo;
        }

        public SewingPattern ()
        {
            GetData();
            CreateTableEntry();
        }

        //Gathers relevant data from the user when object is instantiated.
        public override void GetData()
        {
            this.TableName = "sewingPatterns";
            //Get id.
            this.Id = CollectData.GenerateRandomId("sewingPatterns");
            //Get get pattern model.
            this.patternModel = CollectData.AskForString("Kaavan malli: ");
            //Get pattern sizes.
            this.patternSizes = CollectData.AskForString("Kaavan koot: ");
            //Get optional info.
            this.optionalInfo = CollectData.AskForString("Lisätietoja (paina enter jättääksesi kenttä tyhjäksi): ");
        }

        //Creates a new table entry based on the data from GetData and passes it to the Database.
        public override void CreateTableEntry()
        {
            string tableEntry = $"INSERT INTO {this.TableName} (id, patternModel, patternSizes, optionalInfo) values ('{this.Id}', '{this.PatternModel}', '{this.PatternSizes}', '{this.OptionalInfo}')";
            Database.AddTableEntry(tableEntry);
        }
    }
}