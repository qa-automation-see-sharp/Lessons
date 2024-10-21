**EN**

What is Client-Server Architecture?

Client-server architecture is a computing model where a server provides resources or services,
and a client accesses them. This model separates the user interface from the data storage and processing logic,
allowing for distributed applications.

**Key Concepts**

* Client: A client is a device or software that requests services or resources from a server.
  Examples include web browsers, mobile apps, and desktop applications.

* Server: A server is a centralized machine or software that provides services, resources,
  or data to clients. It processes requests from clients and sends responses back.

* Communication: Clients and servers communicate over a network using specific protocols,
  such as HTTP, to transfer data.

Advantages:

* Centralized management of resources.
* Scalability to handle numerous clients.
* Improved security through centralized control.

**What is API?**

API stands for Application Programming Interface. It is a set of rules and protocols for building and interacting
with software applications. APIs enable different software systems to communicate with each other by defining
how requests and responses should be structured. They allow developers to access the functionality of another
application,
service, or platform, often over a network.

**Key Concepts of an API**

* **Interface:** An API serves as an interface between different software components. It abstracts the underlying
  complexity
  of operations and provides a standardized way for applications to interact.

* **Communication:** APIs enable communication between various software applications,
  often across different platforms or technologies.

* **Protocol:** An API specifies the protocol for communication, including the request format, response format,
  authentication, and error handling.

* **Resource:** APIs typically provide access to specific resources, such as data or functions,
  that an application or service offers.

**How APIs works?**

**API Request-Response Cycle, most common HTTP/HTTPs protocol.**

* **Client Request:**
    * The client application sends a request to the server API endpoint.
    * The request includes:
        * Address, api.weather.com
        * the HTTP method (GET, POST, PUT, DELETE),
        * headers (e.g., content-type, authorization)
        * and optional data.
* **Server Processing:**
    * The server processes the request based on the specified endpoint and method.
    * It performs the necessary operations, such as retrieving data from a database or executing a function.
* **Server Response:**
    * The server sends a response back to the client.
    * The response includes a status code (e.g., 200 OK, 404 Not Found), headers, and optional data (usually in JSON or
      XML format).

**UA**

**Що таке архітектура клієнт-сервер?**

Архітектура клієнт-сервер - це модель обчислень, де сервер надає ресурси або послуги, а клієнт отримує
до них доступ. Ця модель розділяє інтерфейс користувача від зберігання даних та логіки обробки,
що дозволяє створювати розподілені додатки.

**Основні концепції**

* Клієнт: Клієнт - це пристрій або програмне забезпечення, яке запитує послуги або ресурси у сервера.
  Прикладами є веб-браузери, мобільні додатки та настільні додатки.

* Сервер: Сервер - це централізована машина або програмне забезпечення, яке надає послуги, ресурси
  або дані клієнтам. Він обробляє запити від клієнтів та відправляє відповіді назад.

* Комунікація: Клієнти та сервери взаємодіють через мережу, використовуючи певні протоколи, такі як HTTP,
  для передачі даних.

**Переваги:**

* Централізоване управління ресурсами.
* Масштабованість для обробки великої кількості клієнтів.
* Підвищена безпека завдяки централізованому контролю.

**Типи API**

* **Веб API:**
    * **Також відомі як HTTP API або REST API.**
    * Використовуються для комунікації через веб за допомогою **HTTP** або **HTTPS**.
    * Найпоширеніші формати — **JSON** і **XML**.
* **Бібліотечні API:**
    * Надають набір функціональних можливостей для певної мови програмування або середовища.
    * **Приклади:** .NET Framework API, Java API, Python API.
* **API операційної системи:**
    * Дозволяють взаємодію з підлягаючою операційною системою.
    * **Приклади:** Windows API, POSIX API (для Unix/Linux).
* **API бази даних:**
    * Забезпечують комунікацію з базами даних для виконання CRUD (створення, читання, оновлення, видалення) операцій.
    * **Приклади:** SQL-based API, NoSQL API.
* **API обладнання:**
    * Дозволяють програмним додаткам взаємодіяти з апаратними пристроями.
    * **Приклади:** DirectX для графіки, OpenGL для рендерингу.

**Як працюють API**
Цикл запит-відповідь API:

Запит клієнта:

Клієнтський додаток надсилає запит до серверного API кінцевої точки.
Запит включає метод HTTP (GET, POST, PUT, DELETE), заголовки та необов'язкові дані.
Обробка сервером:

Сервер обробляє запит на основі вказаної кінцевої точки і методу.
Виконує необхідні операції, такі як отримання даних з бази даних або виконання функції.
Відповідь сервера:

Сервер відправляє відповідь назад клієнту.
Відповідь включає код статусу (наприклад, 200 OK, 404 Not Found), заголовки та необов'язкові дані (зазвичай у форматі
JSON або XML).