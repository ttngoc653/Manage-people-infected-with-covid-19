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
                    Role = lQuyen + 1,
                    HasLock = false
                };
                entity.TaiKhoans.Add(tk);
                result = (entity.SaveChanges() == 1);
            }
            return result;
        }

        internal static bool DaCoTaiKhoan()
        {
            using (var entity = new QLTTCovid19Entities())
            {
                return (entity.TaiKhoans.Count() == 0);
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
    }
}
