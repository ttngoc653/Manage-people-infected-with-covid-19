using _1760081.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760081.Controllers
{
    class CtrlNguoiLienQuan
    {
        /// <summary>
        /// Tim kiem nguoi lien quan dua vao tu khoa co trongho ten hoac cmnd
        /// </summary>
        /// <param name="sKey">Tu khoa tim kiem</param>
        /// <returns>Danh sach nguoi lien quan chua tat ca thong tin</returns>
        internal static List<string> TimKiem(string sKey)
        {
            List<String> result = new List<string>();
            using (var entity = new Models.QLTTCovid19Entities ())
            {
                result = entity.NguoiLienQuans.Where (obj => obj.Cmnd.IndexOf (sKey) >= 0 || obj.HoTen.IndexOf (sKey) >= 0).OrderBy (obj => obj.HoTen).Select (item => item.Cmnd + " - " + item.HoTen + " - " + item.NamSinh + " - " + item.SoNhaDuong + ", Phường/Xã " + item.Ward.Name + ", Quận/Huyện/Thị xã" + item.Ward.District.Name + ", Tỉnh/Thành phố " + item.Ward.District.Province.Name).ToList ();
            }

            return result;
        }

        internal static bool Them(Models.NguoiLienQuan nguoiLienQuan)
        {
            bool result = false;
            using (var entity = new Models.QLTTCovid19Entities())
            {
                Models.NguoiLienQuan timKiem = entity.NguoiLienQuans.Where(obj => obj.Cmnd == nguoiLienQuan.Cmnd).FirstOrDefault();

                if (timKiem != null)
                {
                    throw new Exception("Nguoi lien quan da co trong he thong. Vui long kiem tra lai.");
                }

                entity.NguoiLienQuans.Add(nguoiLienQuan);

                if (entity.SaveChanges() >= 1)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            if (nguoiLienQuan.LichSuTinhTrangNhiems.Count>0)
            {
                CtrlNoiDieuTri.CapNhatSoLuongHienTai((int)nguoiLienQuan.LichSuTinhTrangNhiems.ElementAt(0).NoiCachLy);
            }

            return result;
        }

        internal static NguoiLienQuan TimKiemTheoCmnd(string sCmnd)
        {
            NguoiLienQuan result = null;
            using (QLTTCovid19Entities entity = new QLTTCovid19Entities())
            {
                result = entity.NguoiLienQuans.Where(obj => obj.Cmnd == sCmnd).FirstOrDefault();
            }

            return result;
        }

        internal static LichSuTinhTrangNhiem TinhTrangHienTai (string sCmnd)
        {
            LichSuTinhTrangNhiem result = null;
            using (QLTTCovid19Entities entity = new QLTTCovid19Entities ())
            {
                result = entity.LichSuTinhTrangNhiems.Where (obj => obj.LaHienTai == true && obj.Cmnd == sCmnd).FirstOrDefault ();
            }

            return result;
        }

        internal static List<NguoiLienQuan> LayToanBo ()
        {
            List<NguoiLienQuan> result = null;
            using (QLTTCovid19Entities entity = new QLTTCovid19Entities ())
            {
                result = entity.NguoiLienQuans.ToList();
            }

            return result;
        }
    }
}
