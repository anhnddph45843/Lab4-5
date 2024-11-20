namespace Lab4_5
{
    public class Tests
    {
        private SanPhamService _service;
        [SetUp]
        public void setup() 
        {
            _service = new SanPhamService();
        }
        [Test]
        public void addsanphamvoisoluongdung() 
        {
            SanPham sp = new SanPham("ID01","SP01","sanpham01",10000,"Den","1M2",4);
            var reulst = _service.ThemSanPham(sp);
            Assert.IsTrue(reulst);
        }
        [Test]
        public void addsanphamvoisoluongsai() 
        {
            SanPham sp = new SanPham("ID01", "SP01", "sanpham01", 10000, "Den", "1M2", 0);
            var sp1 = _service.ThemSanPham(sp);
            Assert.IsFalse(sp1);
        }
        [Test]
        public void addsanphamvoisoluongam() 
        {
            SanPham sp = new SanPham("ID01", "SP01", "sanpham01", 10000, "Den", "1M2", -4);
            var sp2 = _service.ThemSanPham(sp);
            Assert.IsFalse(sp2);
        }

        [Test]
        public void addsanphamvoisoluongsai1()
        {
            SanPham sp = new SanPham("ID01", "SP01", "sanpham01", 10000, "Den", "1M2", 101);
            var sp3 = _service.ThemSanPham(sp);
            Assert.IsFalse(sp3);
        }

        [Test]
        public void suasanpham() 
        {
            SanPham sp = new SanPham("SP01", "SP001", "S?n ph?m 1", 100, "??", "M", 10);
            _service.ThemSanPham(sp);
            _service.SuaSanPham("sp01", "SP001", "SanPham1", 100, "Do", "M", 10);
            SanPham suasp = _service.getall().Find(e => e.MaSanPham == "SP001");
            Assert.AreEqual("SanPham1", suasp.TenSanPham);
            Assert.AreEqual("sp01", suasp.ID);
            Assert.AreEqual(100, suasp.Gia);
            Assert.AreEqual("Do", suasp.MauSac);
            Assert.AreEqual("M", suasp.KichThuoc);
            Assert.AreEqual(10,suasp.SoLuong);
        }
    }
}