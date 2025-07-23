
namespace WebComponentTest.Entities
{
    public class SearchResultItem
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public SearchResultItem(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return $"{nameof(SearchResultItem)}:{{\n" +
                    $"{nameof(Title)} = {Title},\n" +
                    $"{nameof(Description)} = {Description}\n" +
                   "}}";
        }

        // Generate Equals and GetHashCode...
        // GitHubWebComponentTest --> searchResultsPage.SearchResultsItemsText() 
        public override bool Equals(object? obj)
        {
            return obj is SearchResultItem item &&
                   Title == item.Title &&
                   Description == item.Description;
        }

        public override int GetHashCode() => HashCode.Combine(Title, Description);      // Use expression body for method...

        /*
        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Description);
        }
        */
    }
}
