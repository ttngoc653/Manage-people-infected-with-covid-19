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

        internal static bool Them (string sTen, short lSucChua)
        {
            if (Lay(sTen)!=null)
            {
                throw new Exception ("Da ton tai " + sTen + " trong dach sach.");
            }

            bool result = false;
            using (QLTTCovid19Entities entity=new QLTTCovid19Entities ())
            {
                NoiDieuTriCachLy noiDieuTriCachLy = new NoiDieuTriCachLy
                {
                    Ten = sTen,
                    SucChua = lSucChua,
                    SoLuongHienTaiTiepNhan = 0
                };

                entity.NoiDieuTriCachLies.Add (noiDieuTriCachLy);

                result = entity.SaveChanges () > 0;
            }
            return result;
        }

        internal static NoiDieuTriCachLy Lay (string sTen)
        {
            NoiDieuTriCachLy result = null;
            using (QLTTCovid19Entities entity = new QLTTCovid19Entities ())
            {
                result = entity.NoiDieuTriCachLies.Where (obj => obj.Ten == sTen).FirstOrDefault ();
            }
            return result;
        }

        internal static List<NoiDieuTriCachLy> LayTatCa ()
        {
            List<NoiDieuTriCachLy> result=new List<NoiDieuTriCachLy>();

            using (QLTTCovid19Entities entity = new QLTTCovid19Entities ())
            {
                result = entity.NoiDieuTriCachLies.ToList();
            }

            return result;
        }

        internal static bool CapNhatSucChua(int lId,int lSucChua)
        {
            bool result = false;
            using (QLTTCovid19Entities entity=new QLTTCovid19Entities ())
            {
                entity.NoiDieuTriCachLies.Where (obj => obj.id == lId).FirstOrDefault ().SucChua = lSucChua;

                result = entity.SaveChanges () > 0;
            }
            return result;
        }

        internal static NoiDieuTriCachLy Lay (int key)
        {
            NoiDieuTriCachLy result = null;
            using (QLTTCovid19Entities entity = new QLTTCovid19Entities())
            {
                result = entity.NoiDieuTriCachLies.Where(obj => obj.id == key).FirstOrDefault();
            }
            return result;
        }
    }
}
