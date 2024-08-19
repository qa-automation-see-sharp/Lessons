//HTTP - Hyper Text Transfer Protocol



using System.Text;
using Newtonsoft.Json;

// To work with HTTP, we need Client
var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("http://localhost:5111");

//To Set up the HTTP client, we need to configure it with the base address of the API we want to interact with.

// HTTP Request consist of: URI, Request Line, Headers, Body
// 1. Request Line
/* The request line is the first line of the HTTP request and includes three key elements:
 *
 * HTTP Method: Specifies the action to be performed on the resource
 * (e.g., GET, POST, PUT, DELETE, HEAD, OPTIONS, etc.).
 *
 * Request URI: Identifies the resource on the server. This could be a path to a file,
 * a script, or another endpoint (e.g., /index.html, /api/books, etc.).
 *
 * HTTP Version: Indicates the HTTP protocol version used by the client (e.g., HTTP/1.1, HTTP/2).
 *
 * Example:
 * GET /index.html HTTP/1.1
 */

// URI - Uniform Resource Identifier, URL - Uniform Resource Locator
/* Identification: A URI can be used to identify anything, such as a document,
 * image, downloadable file, service, or resource, either on the web or elsewhere.
 *
 * Structure: A URI can be a locator (providing a way to access the resource),
 * a name (providing a name for the resource), or both.
 *
 * Components: A URI typically consists of the following components:
 *
 * Scheme: Indicates the protocol (e.g., http, https, ftp, mailto).
 * Authority: Includes the domain name (e.g., example.com).
 * Path: Specifies the specific resource or location (e.g., /path/to/resource).
 * Query: Contains additional parameters (e.g., ?id=123).
 * Fragment: Points to a specific section of the resource (e.g., #section2).
 */

/* A URL is a specific type of URI that provides the means to locate and access a resource on the internet.
 * It includes information on how to reach the resource, typically through a protocol
 * such as HTTP, HTTPS, FTP, etc.
 * Key Points about URL:
 * Locator: A URL specifies the location of a resource and the mechanism to retrieve it.
 *
 * Specific Type of URI: All URLs are URIs, but not all URIs are URLs. A URL is a subset
 * of URI that explicitly tells you where the resource is located and how to access it.
 *
 * Structure: A URL has a specific format that includes:
 * Scheme: Specifies the protocol (e.g., http, https, ftp).
 * Host: The domain name or IP address (e.g., www.example.com).
 * Path: The file path on the server (e.g., /path/to/resource).
 * Query: Optional parameters for the request (e.g., ?id=123).
 * Fragment: An optional section identifier within the resource (e.g., #section2).
 */
var uri = new Uri(httpClient.BaseAddress, "api/users");

// 2. Headers
/* HTTP headers are key-value pairs that provide additional information about the request.
 * Headers can include metadata such as the type of content being sent, authentication credentials,
 * the client's user agent, and more.
 *
 * Common HTTP Headers:
 * Host: Specifies the domain name of the server (e.g., Host: www.example.com).
 * User-Agent: Identifies the client software (e.g., User-Agent: Mozilla/5.0).
 * Accept: Specifies the types of media that the client can process (e.g., Accept: text/html).
 * Content-Type: Indicates the media type of the request body (e.g., Content-Type: application/json).
 * Authorization: Contains credentials for authenticating the client with the server
 * (e.g., Authorization: Basic YWxhZGRpbjpvcGVuc2VzYW1l).
 * Accept-Language: Indicates the preferred languages for the response (e.g., Accept-Language: en-US).
 */

// 3. Body (Optional)
/* The body of the HTTP request contains the data that the client wants to send to the server.
 * The body is typically included in requests that modify the state of the server, such as POST and PUT
 * requests. The content of the body is determined by the Content-Type header.
 *
 * Examples of Request Bodies:
 *
 * {
       "title": "Example Book",
       "author": "John Doe"
   }
 *
 * URL-Encoded Form Data:
 * title=Example+Book&author=John+Doe
 */

// var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri);
//     httpClient.Send(requestMessage);
//     await httpClient.SendAsync(requestMessage);

// GET
Uri uriGetBooks = new Uri(httpClient.BaseAddress, "api/books/by-author/Oleh Kutafin");
HttpResponseMessage responseGet = await httpClient.GetAsync(uriGetBooks);
string responseStringFromGet = await responseGet.Content.ReadAsStringAsync();
List<Book>? books = JsonConvert.DeserializeObject<List<Book>>(responseStringFromGet);


// PUT
User userToCreate = new User
{
    FullName = "Oleh Kutafin",
    NickName = "Oleh",
    Password = "12345"
};

string userJsonString = JsonConvert.SerializeObject(userToCreate);

var payloadPut = new StringContent(userJsonString, Encoding.UTF8, "application/json");

Uri uriPostUser = new Uri(httpClient.BaseAddress, "api/user/register");

HttpResponseMessage responsePut = await httpClient.PostAsync(uriPostUser, payloadPut);

string responseStringFromPut = await responsePut.Content.ReadAsStringAsync();


// // POST
// var payloadPost = new StringContent("Hello, from POST");
// HttpResponseMessage responsePost = await httpClient.PostAsync(uri, new StringContent("Hello, from POST"));
// string responseStringFromPost = await responsePost.Content.ReadAsStringAsync();
//
//

// DELETE
Uri uriDeleteBook = new Uri(httpClient.BaseAddress,
    "api/books/delete?title=My%20Best%20Book&author=Oleh%20Kutafin&token=f8dc01c2-0ceb-4706-9bc5-2fdaed00eac5");
HttpResponseMessage responseDelete = await httpClient.DeleteAsync(uriDeleteBook);
string responseStringFromDelete = await responseDelete.Content.ReadAsStringAsync();

// HTTP status codes
/* HTTP status codes are standardized codes that indicate the result of an HTTP request.
 * 100-199: Informational responses
 * 200-299: Success responses
 * 300-399: Redirection responses
 * 400-499: Client error responses
 * 500-599: Server error responses
 */


Console.WriteLine(responseStringFromDelete);

public class Book
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int YearOfRelease { get; set; }
}

public sealed class User
{
    public string? FullName { get; set; }
    public string? Password { get; set; }
    public string? NickName { get; set; }
}