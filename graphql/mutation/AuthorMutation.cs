public class AuthorMutation
{
    public GraphqlResponse InsertAuthor(Author input, MyDBContext context)
    {
        var author = new Author
        {
            Name = input.Name
        };
        context.Authors?.Add(author);
        if (context.SaveChanges() < 1) return GraphqlResponse.Failure;
        return GraphqlResponse.Success;
    }

    public GraphqlResponse UpdateAuthor(Author input, MyDBContext context)
    {
        var author = context.Authors?.Where(item => item.Id == input.Id).FirstOrDefault();
        if (author == null) return GraphqlResponse.Failure;
        author.Name = input.Name;

        if (context.SaveChanges() < 1) return GraphqlResponse.Failure;
        return GraphqlResponse.Success;
    }

    public GraphqlResponse RemoveAuthor(int AuthorId, MyDBContext context)
    {
        var author = context.Authors?.Where(item => item.Id == AuthorId).FirstOrDefault();
        if (author == null) return GraphqlResponse.Failure;
        context.Authors.Remove(author);

        if (context.SaveChanges() < 1) return GraphqlResponse.Failure;
        return GraphqlResponse.Success;
    }
}
