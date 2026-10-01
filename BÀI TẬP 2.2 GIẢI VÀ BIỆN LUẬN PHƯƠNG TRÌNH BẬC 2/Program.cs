using System;
using System.Text;

namespace GiaiPhuongTrinhBac2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hỗ trợ hiển thị tiếng Việt có dấu trên Console
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                // Nhập 3 hệ số a, b, c (double)
                Console.Write("Nhập hệ số a: ");
                double a = Convert.ToDouble(Console.ReadLine());

                Console.Write("Nhập hệ số b: ");
                double b = Convert.ToDouble(Console.ReadLine());

                Console.Write("Nhập hệ số c: ");
                double c = Convert.ToDouble(Console.ReadLine());

                // Xử lý trường hợp a = 0 (Phương trình trở thành bậc nhất bx+c=0)
                if (a == 0)
                {
                    if (b == 0)
                    {
                        if (c == 0)
                        {
                            Console.WriteLine("Phương trình có vô số nghiệm.");
                        }
                        else
                        {
                            Console.WriteLine("Vô nghiệm.");
                        }
                    }
                    else
                    {
                        double x = -c / b;
                        Console.WriteLine($"x={x:F2}");
                    }
                }
                // Khi a # 0, tính Δ=b2−4ac: tìm nghiệm
                else
                {
                    double delta = (b * b) - (4 * a * c);

                    if (delta < 0)
                    {
                        Console.WriteLine("Vô nghiệm.");
                    }
                    else if (delta == 0)
                    {
                        double x = -b / (2 * a);
                        Console.WriteLine($"Nghiệm kép x={x:F2}.");
                    }
                    else
                    {
                        double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                        double x2 = (-b - Math.Sqrt(delta)) / (2 * a);

                        // Sắp xếp x1, x2 theo Testcase (x1 lớn hơn x2 trong ví dụ a=1,b=-3,c=2)
                        if (x2 > x1)
                        {
                            double temp = x1;
                            x1 = x2;
                            x2 = temp;
                        }

                        Console.WriteLine($"x1={x1:F2},x2={x2:F2}.");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Lỗi: Vui lòng nhập số hợp lệ.");
            }
        }
    }
}