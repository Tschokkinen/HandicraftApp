using System;

namespace HandicraftApp
{
    public record CrochetHook : Identification
    {
        private double size;
        public double Size
        {
            get => size;
            set
            {
                size = value;
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

        public CrochetHook (string tableName, string id, int size, string material)
        {
            this.TableName = tableName;
            this.Id = id;
            this.size = size;
            this.material = material;
        }

        public CrochetHook ()
        {
            GetData();
            CreateTableEntry();
        }

        //Gathers relevant data from the user when object is instantiated.
        public override void GetData()
        {
            this.TableName = "crochetHooks";
            //Get id.
            this.Id = CollectData.GenerateRandomId("crochetHooks");
            //Get size.
            this.size = CollectData.AskForDouble("Virkkuukoukun koko: ");
            //Get material.
            this.material = CollectData.AskForString("Virkkuukoukun materiaali: ");
        }

        //Creates a new table entry based on the data from GetData and passes it to the Database.
        public override void CreateTableEntry()
        {
            string tableEntry = $"INSERT INTO {this.TableName} (id, size, material) values ('{this.Id}', {this.Size}, '{this.Material}')";
            Database.AddTableEntry(tableEntry);
        }

        public override string ToString()
        {
            return $"Size of the hook is {this.size} and the material is {this.material}.";
        }
    }
}