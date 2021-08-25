namespace BookStore.Business.DataTransferObjects
{
    public class ComplexAddDTO
    {
        public string NameSurname { get; set; }
        public string Biography { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
        public int NumberOfPage { get; set; }
        public decimal Price { get; set; }
        public string Summary { get; set; }
        public string ImgPath { get; set; }
        public int Stock { get; set; }
        public string GenreName { get; set; }
        public string PublisherName { get; set; }
    }
}
