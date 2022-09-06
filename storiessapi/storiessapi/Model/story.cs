namespace storiessapi.Model
{
    public class story
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public double rate { get; set; }
        public byte[] img { get; set; }

        public int categoryid { get; set; }
        virtual public Category Category { get; set; }

    }
}
