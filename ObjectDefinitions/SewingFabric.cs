using System;

namespace HandicraftApp
{
    public record SewingFabric : Identification
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
    
        public SewingFabric(string tableName, string id, string mainType, string subType, double width, double height)
        {
            this.TableName = tableName;
            this.Id = id;
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
        public override void GetData()
        {
            this.TableName = "sewingFabrics";
            //Get id.
            this.Id = CollectData.GenerateRandomId("sewingFabrics");
            //Get fabric main type.
            this.mainType = CollectData.AskForFabricMainType("Valitse kankaan luokka: ");
            //Get fabric subtype.
            this.subType = CollectData.AskForFabricSubType("Materiaalin alaluokka: ");
            //Get fabric size.
            Console.WriteLine("Kangas palan koko: ");
            this.width = CollectData.AskForDouble("Leveys (cm): ");
            this.height = CollectData.AskForDouble("Korkeus (cm): ");
        }

        //Creates a new table entry based on the data from GetData and passes it to the Database.
        public override void CreateTableEntry()
        {
            string tableEntry = $"INSERT INTO {this.TableName} (id, mainType, subType, width, height) values ('{this.Id}', '{this.MainType}', '{this.SubType}', {this.Width}, {this.Height})";
            Database.AddTableEntry(tableEntry);
        }
    }
}   