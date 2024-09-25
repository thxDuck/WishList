namespace WishList.Models;

public class Wish
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Tags { get; set; }
    public DateTime? DateTime { get; set; }
}

// dotnet aspnet-codegenerator controller -name WishController -m Wish -dc WishList.Data.WishListContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider sqlite