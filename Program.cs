LinqQueries queries = new LinqQueries();

//Toda la colección
// PrintValues(queries.TodaColeccion());

//Libros despues del 2000
// PrintValues(queries.LibroDespuesDel2000());

//Libros con mas de 250 paginas y con la palabra in Action
PrintValues(queries.LibrosConMasDe250PagConPalabraInAction());

void PrintValues(IEnumerable<Book> listLibros)
{
    Console.WriteLine("{0, -60}, {1, 9}, {2, 11}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in listLibros)
    {
        Console.WriteLine("{0, -60}, {1, 9}, {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
