# Tech Test Exam

This project is a technical test application involving two components:
- `Discount.Client` — the client-side console application
- `Discount.TcpServer` — the TCP server handling discount code logic

## Overall Architecture

This solution follows modern software engineering practices to ensure scalability, testability, and maintainability:

- **Clean Architecture** — Separates concerns by organizing code into layers (Domain, Application, Infrastructure, Presentation).
- **Repository Pattern** — Abstracts data access logic to promote loose coupling and easy testing.
- **Factory Pattern** — Creates instances of related objects without specifying exact classes.
- **Dependency Injection** — Promotes code decoupling and improves testability.
- **TCP Socket-Based Communication** — No HTTP or Web API; uses raw TCP sockets for communication between server and client.
- **Console Application** — Both server and client are console-based applications.

## How to Run the Code

To run this project correctly, you need to set both `Discount.Client` and `Discount.TcpServer` as **Multiple Startup Projects** in Visual Studio.

### Steps in Visual Studio 2022

1. Open the solution in Visual Studio.
2. Right-click the **solution** in Solution Explorer and choose **Properties**.
3. Go to **Common Properties** → **Startup Project**.
4. Select **Multiple startup projects**.
5. For both `Discount.TcpServer` and `Discount.Client`, set the **Action** to `Start`.
6. Click **OK**.
7. Press **F5** to run both applications simultaneously.
