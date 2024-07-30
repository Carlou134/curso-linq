LinqQueries queries = new LinqQueries();
PrintValues(queries.TodaColeccion());

void PrintValues(IEnumerable<Book> listLibros)
{
    Console.WriteLine("{0, -60}, {1, 9}, {2, 11}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in listLibros)
    {
        Console.WriteLine("{0, -60}, {1, 9}, {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
