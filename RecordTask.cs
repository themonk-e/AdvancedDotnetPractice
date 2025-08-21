public static class RecordTask
{
    //positional
     record book(string name, int price);

   //property
    record books
    {
        public string Name { get; init; }
        public decimal Price { get; init; }
    }

    public static void printRecordTaskOutputs()
    {

        //Introduced in C# 9 (.NET 5+).
        // Designed to make working with immutable, value-based objects much easier.
        // Classes → compared by reference (default).
        // Records → compared by value (by default).


        book initialPublication = new book("Alchemist", 200); //positional
        book copy = new book("Alchemist", 200);
        book newBook = new book("5AMCLUB", 200);


        //equality check
        Console.WriteLine(initialPublication.Equals(copy));
        Console.WriteLine(initialPublication.Equals(newBook));


        //non destructive mutability
        // Records support non-destructive mutation with the with keyword.
        // This means you can create a new record copying all properties except the ones you change.
        book secondEdition = initialPublication with { price = 300 };
        Console.WriteLine(secondEdition);


    }
}