namespace storiessapi.DTO
{
    public class storiesDTO
    {
        public string title { get; set; }
        public string author { get; set; }
        public double rate { get; set; }
        public IFormFile img { get; set; }

        public int categoryid { get; set; }
    }
}
