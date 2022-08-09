public class Mutation
{
    public GraphqlResponse InsertBook(BookInput input,[Service] MyDBContext context)
    {
        var book = new Book
        {
            Title = input.Title
        };
        context.Books?.Add(book);
        if (context.SaveChanges() < 1) return GraphqlResponse.Failure;
        return GraphqlResponse.Success;
    }

    public GraphqlResponse UpdateBook(BookInput input,[Service] MyDBContext context)
    {
        var book = context.Books?.Where(item => item.Id == input.Id).FirstOrDefault();
        if (book == null) return GraphqlResponse.Failure;
        book.Title = input.Title;

        if (context.SaveChanges() < 1) return GraphqlResponse.Failure;
        return GraphqlResponse.Success;
    }
}
public record BookInput
{
    public int? Id;
    public string? Title;
}

public class GraphqlResponse
{
    private static GraphqlResponse _success;
    private static GraphqlResponse _failure;
    public static GraphqlResponse Success = _success ?? (_success = new GraphqlResponse(true));
    public static GraphqlResponse Failure = _failure ?? (_failure = new GraphqlResponse(false));
    private GraphqlResponse(bool ok)
    {
        Ok = ok;
    }

    public bool Ok { get; private set; } = false;
}