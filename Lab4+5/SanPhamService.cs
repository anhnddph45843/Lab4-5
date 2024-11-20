using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5
{
    internal class SanPhamService
    {
        public List<SanPham> sanphamservice = new List<SanPham>();
        public bool ThemSanPham(SanPham sp)
        {
            if (sp.SoLuong <=0 ||sp.SoLuong >=100) return false;
            if (sanphamservice.Any(a => a.MaSanPham == sp.MaSanPham )) return false;
            sanphamservice.Add(sp);
            return true;
        }
        public void SuaSanPham(string iD, string maSanPham, string tenSanPham, float gia, string mauSac, string kichThuoc, int soLuong) 
        {
            SanPham suasanpham = sanphamservice.Find(e => e.ID == iD);
            if (suasanpham != null) 
            {
                suasanpham.ID = iD;
                suasanpham.MaSanPham = maSanPham;
                suasanpham.TenSanPham = tenSanPham;
                suasanpham.Gia = gia;
                suasanpham.MauSac = mauSac;
                suasanpham.KichThuoc = kichThuoc;
                suasanpham.SoLuong = soLuong;
            }

        }
        public void XoaSanPham(string Id) 
        {
            SanPham deleteitem = sanphamservice.Find(e => e.ID == Id);
            if (deleteitem != null)
            {
                Console.WriteLine("San Pham Khong Ton Tai");
            }
            else 
            {
                sanphamservice.Remove(deleteitem);
            }
        }
        public List<SanPham> getall() 
        {
            return sanphamservice;
        }
    }
}
