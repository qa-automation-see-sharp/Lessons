namespace LibraryV4.Endpoints;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Users
    {
        private const string Base = $"{ApiBase}/user";
        public const string Register = $"{Base}/register";
        public const string Login = $"{Base}/login";
    }

    public static class Books
    {
        private const string Base = $"{ApiBase}/books";

        public const string Create = $"{Base}/create";
        public const string GetBooksByTitle = $"{Base}/by-title/{{title}}";
        public const string GetBooksByAuthor = $"{Base}/by-author/{{author}}";
        public const string Delete = $"{Base}/delete";
    }
}