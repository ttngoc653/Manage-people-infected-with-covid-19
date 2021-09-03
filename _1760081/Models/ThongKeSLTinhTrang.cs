using System.Collections.Generic;

namespace _1760081.Models
{
    internal class ThongKeSLTinhTrang
    {
        public ThongKeSLTinhTrang ()
        {
            STenDiaPhuong = null;
            LTongSoCaNhiemHienTai = 0;
            LSoLuongAmTinh = 0;
            LSoLuongF3 = 0;
            LSoLuongF2 = 0;
            LSoLuongF1 = 0;
            LSoLuongF0 = 0;
            LSoLuongTuVong = 0;
        }
        public string STenDiaPhuong { get; internal set; }
        public int LTongSoCaNhiemHienTai { get; internal set; }
        public int LSoLuongAmTinh { get; internal set; }
        public int LSoLuongF3 { get; internal set; }
        public int LSoLuongF2 { get; internal set; }
        public int LSoLuongF1 { get; internal set; }
        public int LSoLuongF0 { get; internal set; }
        public int LSoLuongTuVong { get; internal set; }
    }

    internal class DataTableTKSLTinhTrang
    {
        public static List<ThongKeSLTinhTrang> GetList { get; set; }
    }
}