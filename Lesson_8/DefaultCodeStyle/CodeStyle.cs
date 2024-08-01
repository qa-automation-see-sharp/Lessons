namespace DefaultCodeStyle;

/* Code style in C# refers to a set of guidelines and conventions that developers follow to write clean, readable, and
 * maintainable code. These guidelines help ensure consistency across codebases, making it easier for teams
 * to collaborate and for new developers to understand existing code. Code style covers various aspects,
 * including naming conventions, formatting, indentation, and the use of comments.
 */
/* Стиль коду в C# - це набір рекомендацій та конвенцій, яких дотримуються розробники для написання чистого,
 * читабельного та підтримуваного коду. Ці рекомендації допомагають забезпечити узгодженість коду, що полегшує
 * співпрацю в команді та розуміння існуючого коду новими розробниками. Стиль коду охоплює різні аспекти,
 * включаючи правила іменування, форматування, відступи та використання коментарів.
 */
/* Useful links for code style:
 * https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names
 * https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
 */
/* Types of naming conventions that are commonly used in C#:
 * PascalCase, used for class names, method names, property names, and namespace names.
 * camelCase, used for local variables and method parameters.
 * _camelCase, used for private fields in classes.
 * snake_case, used for naming fields in classes and properties.
 * Pascal_Snake_Case, used for naming constants or long method names for testing purposes.
 */

// Structure of Class example
// Приклад структури класу 

// Class name should be named using PascalCase.
public class CodeStyle
{
    // Private fields should be named using _camelCase. 
    private int _myInt1;

    // Constants should be named using PascalCase.
    private const int MyConstInt = 32;

    // Public properties and fields should be named using PascalCase.
    public int MyPublicInt;
    public int MyInt { get; set; }

    // Static and Constant fields should be named using PascalCase.
    public const string MyString = "Hello, World!";

    // Constructors should be named using PascalCase.
    // Parameters should be named using camelCase.
    public CodeStyle(int myInt)
    {
        _myInt1 = myInt;
    }

    // Methods should be named using PascalCase.
    public void MyMethod()
    {
        // Local variables should be named using camelCase.
        var myTemporaryVariable = 0;
        _myInt1 = myTemporaryVariable;
    }

    // Private methods should be named using PascalCase.
    private void MyPrivateMethod()
    {
    }
}