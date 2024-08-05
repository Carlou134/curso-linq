using System.IO.Compression;
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

    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(x => x.Status != String.Empty);
    }

    public bool SiPublicadoEn2005()
    {
        return librosCollection.Any(x => x.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosDePython()
    {
        return librosCollection.Where(x => x.Categories.Contains("Python"));
    }

    public IEnumerable<Book> LibrosDeJavaOrdernadoPorNombre()
    {
        return librosCollection.Where(x => x.Categories.Contains("Java")).OrderBy(x => x.Title);
    }

    public IEnumerable<Book> LibrosDeMasDe450PagsDescendentes()
    {
        return librosCollection.Where(x => x.PageCount > 450).OrderByDescending(x => x.PageCount);
    }

    public IEnumerable<Book> TresPrimerosLibrosJavaOrdenadosPorFecha()
    {
        return librosCollection.Where(x => x.Categories.Contains("Java"))
        .OrderBy(x => x.PublishedDate)
        .TakeLast(3);
    }

    public IEnumerable<Book> TercerYCuartoLibroConMas400Pags()
    {
        return librosCollection.Where(x => x.PageCount > 400)
        .Take(4)
        .Skip(2);
    }

    public IEnumerable<Book> TresPrimerosLibrosDeColeccion()
    {
        return librosCollection.Take(3)
        .Select(x => new Book {Title = x.Title, PageCount = x.PageCount});
    }

    public long LibrosEntre200Y500Pags()
    {
        return librosCollection.LongCount(x => x.PageCount >= 200 && x.PageCount <= 500);
    }

    public DateTime FechaPublicacionMenor()
    {
        return librosCollection.Min(x => x.PublishedDate);
    }

    public int NumeroPagsMayor()
    {
        return librosCollection.Max(x => x.PageCount);
    }

    public Book LibroConMenorNumeroDePaginas()
    {
        return librosCollection.Where(x => x.PageCount > 0).MinBy(x => x.PageCount);
    }

    public Book LibroConFechaPublicacionMasReciente()
    {
        return librosCollection.MaxBy(x => x.PublishedDate);
    }

    public int SumarTodasLasPaginasDeLibrosEntre0Y500()
    {
        return librosCollection.Where(x => x.PageCount >= 0 && x.PageCount < 500).Sum(x => x.PageCount);
    }

    public string TitulosDeLibrosDespuesDel2015Concatenados()
    {
        return librosCollection.Where(x => x.PublishedDate.Year > 2015).Aggregate("",(TitulosLibros, next) =>
        {
            if(TitulosLibros != String.Empty) TitulosLibros += " - " + next.Title;
            else TitulosLibros += next.Title;
            return TitulosLibros;
        });
    }

    public double PromedioCaracteresTitulo()
    {
        return librosCollection.Average(x => x.Title.Length);
    } 

    public IEnumerable<IGrouping<int, Book>> LibrosPublicadosDesde2000()
    {
        return librosCollection.Where(x => x.PublishedDate.Year >= 2000).GroupBy(x => x.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionarioDeLibroPorLetra()
    {
        return librosCollection.ToLookup(x => x.Title[0], x => x);
    }

    public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Paginas()
    {
        var librosDespuesDel2005 = librosCollection.Where(x => x.PublishedDate.Year > 2005);

        var librosConMasDe500Paginas = librosCollection.Where(x => x.PageCount > 500);

        return librosDespuesDel2005.Join(librosConMasDe500Paginas, x => x.Title, p => p.Title, (x,p) => x); 
    }
}