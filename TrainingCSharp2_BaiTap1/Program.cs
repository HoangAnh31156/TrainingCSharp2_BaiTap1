using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCSharp2_BaiTap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            MENU();
        }
        static void MENU()
        {
            SERVICE service = new SERVICE();
            List<Bike> _lstBikes = new List<Bike>
            {
                new Bike(123, "GN 2.0 27", "Thống nhất"),
                new Bike(14, "MTP 2.1", "Thống nhất"),
                new Bike(625, "The flash", "MoveHiHo"),
                new Bike(226, "SLX - TB", "HaHaMove"),

            };

            string path = @"E:\CODE\VisualStudio\TrainingCSharp2_BaiTap1\TrainingCSharp2_BaiTap1\FileBike.txt";
            File.WriteAllText(path, "");

            int chon;
            do
            {
                Console.WriteLine("------------MENU-------------");
                Console.WriteLine("1. Nhập DS (Mã ID tự tăng khi nhập vào)");
                Console.WriteLine("2. Xuất DS");
                Console.WriteLine("3. Ghi file");
                Console.WriteLine("4. Đọc file");
                Console.WriteLine("5. Xóa đối tượng theo mã ID ");
                Console.WriteLine("0. Thoát CT");
                Console.WriteLine("-----------------------------");
                Console.Write("Mời bạn chọn chức năng:  ");
                chon = Convert.ToInt32(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        service.NhapDS(_lstBikes);
                        break;
                    case 2:
                        service.XuatDS(_lstBikes);
                        break;
                    case 3:
                        service.GhiFile(path, _lstBikes);
                        break;
                    case 4:
                        List<Bike> bike = service.DocFile(path);
                        foreach (var item in _lstBikes)
                        {
                            item.InThongTin();
                        }
                        break;
                    case 5:
                        service.Xoa(_lstBikes);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Moi chon lai");
                        break;
                }

            } while (chon != 0);
        }

    }
}
