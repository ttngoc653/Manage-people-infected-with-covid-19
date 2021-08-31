using _1760081.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760081.Controllers
{
    class CtrlTaiKhoan
    {
        internal static bool TaoTaiKhoan(string sUsername,string sPassword, int lQuyen)
        {
            bool result = false;
            using (var entity = new QLTTCovid19Entities())
            {
                TaiKhoan tk = new TaiKhoan
                {
                    UserName = sUsername,
                    Password = sPassword,
                    Role = lQuyen,
                    HasLock = false
                };
                entity.TaiKhoans.Add(tk);
                result = (entity.SaveChanges() == 1);
            }
            return result;
        }

        internal static bool DaCoTaiKhoan (string sUsername = "")
        {
            int soTaiKhoan = 0;
            using (var entity = new QLTTCovid19Entities ())
            {
                if (sUsername.Length == 0)
                {
                    soTaiKhoan = entity.TaiKhoans.Count ();
                }
                else
                {
                    soTaiKhoan = entity.TaiKhoans.Where(obj=>obj.UserName==sUsername).Count ();
                }
            }

            return soTaiKhoan != 0;
        }

        internal static List<TaiKhoan> LayToanBo ()
        {
            List<TaiKhoan> result = new List<TaiKhoan> ();

            using (QLTTCovid19Entities entity=new QLTTCovid19Entities())
            {
                result = entity.TaiKhoans.ToList ();
            }

            return result;
        }

        internal static void Khoa(string sUserName, bool hasLock)
        {
            using (QLTTCovid19Entities entity = new QLTTCovid19Entities())
            {
                entity.TaiKhoans.Where(obj => obj.UserName == sUserName).FirstOrDefault().HasLock = hasLock;

                entity.SaveChanges();
            }
        }

        internal static TaiKhoan DangNhap(string sUserName,string sPassword)
        {
            TaiKhoan tk = null;
            using (QLTTCovid19Entities entity=new QLTTCovid19Entities())
            {
                if (sPassword.Length == 0)
                {
                    tk = entity.TaiKhoans.Where(obj => obj.UserName == sUserName).FirstOrDefault();
                }
                else
                {
                    tk = entity.TaiKhoans.Where(obj => obj.UserName == sUserName && obj.Password == sPassword).FirstOrDefault();
                }
            }
            return tk;
        }

        internal static void GhiNhatKy(string sUserName,string sContent)
        {
            using (var entity = new QLTTCovid19Entities())
            {
                entity.LichSuHoatDongs.Add(new LichSuHoatDong
                {
                    UserName=sUserName,
                    ThoiGian=DateTime.UtcNow,
                    HanhDong=sContent
                });

                entity.SaveChanges();
            }
        }

        internal static List<LichSuHoatDong> LayLichSuHoatDong (string sUserName)
        {
            List<LichSuHoatDong> result = new List<LichSuHoatDong> ();
            using (QLTTCovid19Entities entity=new QLTTCovid19Entities())
            {
                result = entity.LichSuHoatDongs.Where (obj => obj.UserName == sUserName).ToList ();
            }
            return result;
        }
    }
}
