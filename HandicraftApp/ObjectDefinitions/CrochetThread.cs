
namespace HandicraftApp
{
    public record CrochetThread : Identification
    {
        private double size;
        public double Size
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
            this.TableName = tableName;
            this.Id = id;
            this.size = size;
            this.material = material;
            this.colour = colour;
        }

        public CrochetThread()
        {
            GetData();
            CreateTableEntry();
        }

        public override void GetData()
        {
            this.TableName = "crochetThreads";
            //Get id.
            this.Id = CollectData.GenerateRandomId("crochetThreads");
            //Get size.
            this.size = CollectData.AskForDouble("Virkkuulangan koko: ");
            //Get material.
            this.material = CollectData.AskForString("Virkkuulangan materiaali: ");
            //Get colour. 
            this.colour = CollectData.AskForString("Virkkuulangan väri: ");
        }

        public override void CreateTableEntry()
        {
            string tableEntry = $"INSERT INTO {this.TableName} (id, size, material, colour) values ('{this.Id}', {this.Size}, '{this.Material}', '{this.Colour}')";
            Database.AddTableEntry(tableEntry);
        }
    }
}