using System.Security.Cryptography.X509Certificates;

public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();

    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> TodaColeccion()
    {
        return this.librosCollection;
    }

    public IEnumerable<Book> LibroDespuesDel2000()
    {
        //extension method
        // return librosCollection.Where(x => x.PublishedDate.Year > 2000);

        //query expression
        return from l in librosCollection
               where l.PublishedDate.Year > 2000
               select l;
    }

    public IEnumerable<Book> LibrosConMasDe250PagConPalabraInAction()
    {
        //extension method
        // return librosCollection.Where(x => x.PageCount > 250 && x.Title.Contains("in Action"));

        //query expresion
        return from l in librosCollection
               where l.PageCount > 250 && l.Title.Contains("in Action")
               select l;
    }
}