using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TrainingCSharp2_BaiTap1
{
    internal class SERVICE
    {
        public void NhapDS(List<Bike> _lstBikes)
        {
            int id = 1;
            string tiepTuc;
            do
            {              
                Bike bike = new Bike();
                while (_lstBikes.Any(x => x.ID1 == id))
                {
                    id++;
                }
                bike.ID1 = id;
                Console.Write("Nhập tên:  ");
                bike.Ten1 = Console.ReadLine();
                Console.Write("Nhập hãng sản xuất:  ");
                bike.HSX1 = Console.ReadLine();
                _lstBikes.Add(bike);
                Console.WriteLine("Ban co muon tiep tuc ko ? (c/k)");
                tiepTuc = Console.ReadLine();
            } while (tiepTuc.Equals("co"));
        }
        
        public void XuatDS(List<Bike> _lstBikes)
        {
            if(_lstBikes.Count == 0)
            {
                Console.WriteLine("Chưa có thông tin !");
                return;
            }
            foreach (var item in _lstBikes)
            {
                item.InThongTin();
            }
        }
        public void GhiFile(string path, List<Bike> _lstBikes)
        {
            if(File.Exists(path))
            {
                foreach (var item in _lstBikes)
                {
                    string line = item.ObjToStr();
                    File.AppendAllText(path, line);
                }
                Console.WriteLine("Ghi file thanh cong !");
            }
            else
            {
                Console.WriteLine("File Khong ton tai !");
            }
        }
        public List<Bike>  DocFile(string path)
        {
            List<Bike> _lstBikes = new List<Bike>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if(line.Trim().Length == 0)
                {
                    continue;
                }
                else
                {
                    string[] attributes = line.Split('-');
                    Bike bike = new Bike();
                    bike.ID1 = Convert.ToInt32(attributes[0]);
                    bike.Ten1 = attributes[1];
                    bike.HSX1 = attributes[2];
                    _lstBikes.Add(bike);
                }
            }
            return _lstBikes;
        }
        public void Xoa(List<Bike> lstBikes)
        {
            Console.Write("Nhập ID cần xóa :  ");
            int id = Convert.ToInt32(Console.ReadLine());
            var XoaQuery =
                (from b in lstBikes
                 where b.ID1 == id
                 select b).FirstOrDefault();
            if(XoaQuery == null)        
            {
                Console.WriteLine("Không tìm thấy ID cần tìm !");
                return;
            }
            else
            {
                lstBikes.Remove(XoaQuery);
            }
        }
        
    }
}
