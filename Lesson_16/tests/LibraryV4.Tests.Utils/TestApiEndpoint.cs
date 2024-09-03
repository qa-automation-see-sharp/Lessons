namespace LibraryV4.Tests.Utils;

public static class TestApiEndpoint
{
    private const string ApiBase = "api";

    public static class Users
    {
        private const string Base = $"{ApiBase}/user";
        public const string Register = $"{Base}/register";

        public static string Login(string nickName, string password) =>
            $"{Base}/login?nickname={nickName}&password={password}";
    }

    public static class Books
    {
        private const string Base = $"{ApiBase}/books";

        public static string Create(string token) => $"{Base}/create?token={token}";
        public static string GetBooksByTitle(string title) => $"{Base}/by-title/{title}";
        public static string GetBooksByAuthor(string author) => $"{Base}/by-author/{author}";

        public static string Delete(string title, string author, string token) =>
            $"{Base}/delete?title={title}&author={author}&token={token}";
    }
}