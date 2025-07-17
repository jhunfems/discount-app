# Tech Test Exam

This project is a technical test application involving two components:
- `Discount.Client` — the client-side console application
- `Discount.TcpServer` — the TCP server handling discount code logic

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
