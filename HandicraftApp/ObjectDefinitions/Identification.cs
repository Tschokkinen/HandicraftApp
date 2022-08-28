namespace HandicraftApp
{
    public abstract record Identification
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

        public virtual void GetData()
        {

        }

        public virtual void CreateTableEntry()
        {

        }
    }
}