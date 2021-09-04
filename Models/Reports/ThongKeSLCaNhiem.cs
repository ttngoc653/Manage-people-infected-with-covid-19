using System.Collections.Generic;

namespace _1760081.Models
{
    internal class ThongKeSLCaNhiem
    {
        public ThongKeSLCaNhiem()
        {
            SDiaPhuong = null;
            LCaChuaKhoi = 0;
            LCaNhiem = 0;
            LCaTuVong = 0;
            LTongCaChuaKhoi = 0;
            LTongCaTuVong = 0;
            LTongSoNhiem = 0;
        }
        public string SDiaPhuong { get; internal set; }
        public int LCaNhiem { get; internal set; }
        public int LTongSoNhiem { get; internal set; }
        public int LCaTuVong { get; internal set; }
        public int LTongCaTuVong { get; internal set; }
        public int LCaChuaKhoi { get; internal set; }
        public int LTongCaChuaKhoi { get; internal set; }
    }

    internal class DataTableTKSLCaNhiem
    {
        public static List<ThongKeSLCaNhiem> GetList { get; set; }
    }
}