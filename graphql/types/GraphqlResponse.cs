
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