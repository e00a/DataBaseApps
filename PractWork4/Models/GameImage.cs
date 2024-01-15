namespace PractWork4.Models
{
    public partial class GameImage
    {
        private string imageFileName;
        public string ImageFileName
        {
            get { return imageFileName; }
            set
            {
                imageFileName = value;
                ImagePath = new Uri($@"Y:\images\{imageFileName}", UriKind.Absolute);
            }
        }

        public Uri ImagePath { get; private set; }
    }
}
