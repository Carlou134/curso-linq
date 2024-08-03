LinqQueries queries = new LinqQueries();

//Toda la colección
// PrintValues(queries.TodaColeccion());

//Libros despues del 2000
// PrintValues(queries.LibroDespuesDel2000());

//Libros con mas de 250 paginas y con la palabra in Action
// PrintValues(queries.LibrosConMasDe250PagConPalabraInAction());

// Tiene Status
// Console.WriteLine($"Todos los libros tienen status - {queries.TodosLosLibrosTienenStatus()}");

//Algun libro fue publciado en 2005
// Console.WriteLine($"Algun libro fue publicado en 2005 - {queries.SiPublicadoEn2005()}");

//Libros de python
// PrintValues(queries.LibrosDePython());

//Libros de Java
// PrintValues(queries.LibrosDeJavaOrdernadoPorNombre());

//Libros que tienen mas de 450 pags ordenados por numero de paginas
// PrintValues(queries.LibrosDeMasDe450PagsDescendentes());

//3 primeros libros de Java
// PrintValues(queries.TresPrimerosLibrosJavaOrdenadosPorFecha());

//Tercer y Cuarto Libro con mas de 400 paginas
// PrintValues(queries.TercerYCuartoLibroConMas400Pags());

//Tres primeros valores filtrados con select
// PrintValues(queries.TresPrimerosLibrosDeColeccion());

//Libros con paginas entre 200 y 500
// Console.WriteLine(queries.LibrosEntre200Y500Pags());

//Menor fecha de publicacion
// Console.WriteLine(queries.FechaPublicacionMenor());

//Libro con mayor numero de paginas
// Console.WriteLine(queries.NumeroPagsMayor());

//Libro con menor numero de paginas
// var libroMenorPag = queries.LibroConMenorNumeroDePaginas();
// Console.WriteLine($"{libroMenorPag.Title}, {libroMenorPag.PageCount}"); 


//Libro con fecha publicacion mas reciente
var libroFechaReciente = queries.LibroConFechaPublicacionMasReciente();
Console.WriteLine($"{libroFechaReciente.Title}, {libroFechaReciente.PublishedDate.ToShortDateString()}"); 

void PrintValues(IEnumerable<Book> listLibros)
{
    Console.WriteLine("{0, -60}, {1, 9}, {2, 11}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in listLibros)
    {
        Console.WriteLine("{0, -60}, {1, 9}, {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
