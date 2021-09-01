using _1760081.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760081.Controllers
{
    class CtrlTinhTrangNhiem
    {
        internal static List<LichSuTinhTrangNhiem> LayDanhSach(string sCmnd)
        {
            List<LichSuTinhTrangNhiem> result = new List<LichSuTinhTrangNhiem>();
            
            using(QLTTCovid19Entities entity=new QLTTCovid19Entities())
            {
                result = entity.LichSuTinhTrangNhiems.Where(obj => obj.Cmnd == sCmnd).OrderByDescending(obj => obj.ThoiGianCapNhat).ToList();
            }

            return result;
        }

        /// <summary>
        /// Cap nhat tinh trang nhiem benh
        /// </summary>
        /// <param name="oTinhTrangHienTaiCu">Trang thai truoc do</param>
        /// <param name="sTinhTrangMoi">Trang thai moi se duoc cao nhat</param>
        /// <param name="lMaNoiDieuTriCachLiMoi">Ma noi cach ly moi.
        /// Mac dinh la -1 neu khong can cap nhat.</param>
        internal static void CapNhat(LichSuTinhTrangNhiem oTinhTrangHienTaiCu, string sTinhTrangMoi, int? lMaNoiDieuTriCachLiMoi=-1)
        {
            using (QLTTCovid19Entities entity = new QLTTCovid19Entities())
            {
                if (entity.LichSuTinhTrangNhiems
                            .Where(obj => obj.Cmnd == oTinhTrangHienTaiCu.Cmnd
                                        && obj.LaHienTai == true
                                        && obj.TinhTrang == oTinhTrangHienTaiCu.TinhTrang
                                        && obj.NoiCachLy == oTinhTrangHienTaiCu.NoiCachLy).Count() == 0)
                {
                    throw new Exception("Tình trạng đã thay đổi bới 1 quản lý khác.");
                }
                else if (lMaNoiDieuTriCachLiMoi != -1)
                {
                    oTinhTrangHienTaiCu.NoiCachLy = lMaNoiDieuTriCachLiMoi;
                }
                List<LichSuTinhTrangNhiem> lichSuTinhTrangNhiems = entity.LichSuTinhTrangNhiems.Where(obj => obj.Cmnd == oTinhTrangHienTaiCu.Cmnd).ToList();
                foreach (LichSuTinhTrangNhiem item in lichSuTinhTrangNhiems)
                {
                    item.LaHienTai = false;
                }

                oTinhTrangHienTaiCu.ThoiGianCapNhat = DateTime.Now;
                oTinhTrangHienTaiCu.TinhTrang = sTinhTrangMoi;

                entity.LichSuTinhTrangNhiems.Add(oTinhTrangHienTaiCu);

                entity.SaveChanges();
            }
        }
    }
}
