using _1760081.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760081.Controllers
{
    class CtrlNoiDieuTri
    {
        internal static NoiDieuTriCachLy CoTheTiepNhanThemBenhNhan(string sTenNoiDieuTri)
        {
            NoiDieuTriCachLy result = null;
            using(QLTTCovid19Entities entity =new QLTTCovid19Entities())
            {
                NoiDieuTriCachLy noi = entity.NoiDieuTriCachLies.Where(obj => obj.Ten == sTenNoiDieuTri).FirstOrDefault();

                if (noi==null)
                {
                    throw new Exception("Noi tiep nhan cach ly dieu tri khong ton tai.");
                }

                int soLuongHienTai = entity.LichSuTinhTrangNhiems.Where(obj => obj.LaHienTai == true && obj.NoiCachLy == noi.id).Count();

                noi.SoLuongHienTaiTiepNhan = soLuongHienTai;

                entity.SaveChanges();

                if (soLuongHienTai<noi.SucChua)
                {
                    result = noi;
                }
            }
            return result;
        }

        internal static void CapNhatSoLuongHienTai(int lId)
        {
            using (QLTTCovid19Entities entity=new QLTTCovid19Entities())
            {
                int soLuongBenhNhanHienTai = entity.LichSuTinhTrangNhiems.Where(obj => obj.LaHienTai == true && obj.NoiCachLy == lId).Count();

                entity.NoiDieuTriCachLies.Where(obj => obj.id == lId).First().SoLuongHienTaiTiepNhan = soLuongBenhNhanHienTai;
                entity.SaveChanges();
            }
        }
    }
}
