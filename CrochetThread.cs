
namespace HandicraftApp
{
    public record CrochetThread
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

        private int size;
        public int Size
        {
            get => size;
            set
            {
                size  = value;
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

        private string colour;
        public string Colour
        {
            get => colour;
            set
            {
                colour = value;
            }
        }

        public CrochetThread (string tableName, string id, int size, string material, string colour)
        {
            this.tableName = tableName;
            this.id = id;
            this.size = size;
            this.material = material;
            this.colour = colour;
        }

        public CrochetThread()
        {
            GetData();
            CreateTableEntry();
        }

        private void GetData()
        {
            this.tableName = "crochetThreads";
            //Get id.
            this.id = CollectData.GenerateRandomId("crochetThreads");
            //Get size.
            this.size = CollectData.AskForInt("Virkkuulangan koko: ");
            //Get material.
            this.material = CollectData.AskForString("Virkkuulangan materiaali: ");
            //Get colour. 
            this.colour = CollectData.AskForString("Virkkuulangan väri: ");
        }

        private void CreateTableEntry()
        {
            string tableEntry = $"INSERT INTO {this.tableName} (id, size, material, colour) values ('{this.Id}', {this.Size}, '{this.Material}', '{this.Colour}')";
            Database.AddTableEntry(tableEntry);
        }
    }
}