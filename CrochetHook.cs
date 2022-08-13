using System;

namespace HandicraftApp
{
    public record CrochetHook 
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
            this.tableName = tableName;
            this.id = id;
            this.size = size;
            this.material = material;
        }

        public CrochetHook ()
        {
            GetData();
            CreateTableEntry();
        }

        //Gathers relevant data from the user when object is instantiated.
        private void GetData()
        {
            this.tableName = "crochetHooks";
            //Get id.
            this.id = CollectData.GenerateRandomId("crochetHooks");
            //Get size.
            this.size = CollectData.AskForInt("Virkkuukoukun koko: ");
            //Get material.
            this.material = CollectData.AskForString("Virkkuukoukun materiaali: ");
        }

        //Creates a new table entry based on the data from GetData and passes it to the Database.
        private void CreateTableEntry()
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