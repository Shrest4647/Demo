public class BookMutation
{
    public GraphqlResponse InsertBook(Book input, MyDBContext context)
    {
        var book = new Book
        {
            Title = input.Title
        };
        context.Books?.Add(book);
        if (context.SaveChanges() < 1) return GraphqlResponse.Failure;
        return GraphqlResponse.Success;
    }

    public GraphqlResponse UpdateBook(Book input, MyDBContext context)
    {
        var book = context.Books?.Where(item => item.Id == input.Id).FirstOrDefault();
        if (book == null) return GraphqlResponse.Failure;
        book.Title = input.Title;

        if (context.SaveChanges() < 1) return GraphqlResponse.Failure;
        return GraphqlResponse.Success;
    }

    public GraphqlResponse RemoveBook(int BookId, MyDBContext context)
    {
        var book = context.Books?.Where(item => item.Id == BookId).FirstOrDefault();
        if (book == null) return GraphqlResponse.Failure;
        context.Books.Remove(book);

        if (context.SaveChanges() < 1) return GraphqlResponse.Failure;
        return GraphqlResponse.Success;
    }
}
