using _1760081.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760081.Controllers
{
    class CtrlKhuVuc
    {
        internal static Ward LayPhuongXa(String sPhuongXa,String sQuanHuyen, String sTinhThanhPho)
        {
            Ward result = null;
            using(var entity=new QLTTCovid19Entities())
            {
                result = entity.Wards.Where(obj => (obj.Type + " " + obj.Name) == sPhuongXa
                                                && (obj.District.Type + " " + obj.District.Name) == sQuanHuyen
                                                && (obj.District.Province.Type + " " + obj.District.Province.Name) == sTinhThanhPho)
                                    .FirstOrDefault();
                if (result == null)
                {
                    throw new Exception("Dia phuong khong ton tai.");
                }
            }

            return result;
        }

        internal static List<String> LayDanhSachTenTinhThanhPho()
        {
            List<string> result=new List<string>();

            using (var entity = new Models.QLTTCovid19Entities())
            {
                result = entity.Provinces.Select(obj => obj.Type + " " + obj.Name).ToList();
            }

            return result;
        }

        internal static List<string> LayDanhSachTenQuanHuyen(string sTinhThanhPho)
        {
            List<string> result = new List<string>();
            using (QLTTCovid19Entities entity=new QLTTCovid19Entities())
            {
                result = entity.Districts.Where((obj) => (obj.Province.Type + " " + obj.Province.Name) == sTinhThanhPho)
                                         .OrderBy(obj => obj.Name)
                                         .Select(obj => obj.Type + " " + obj.Name).ToList();
            }
            return result;
        }

        internal static List<string> LayDanhSachTenPhuongXa(string sTinhThanhPho,string sQuanHuyen)
        {
            List<string> result = new List<string>();
            using (QLTTCovid19Entities entity = new QLTTCovid19Entities())
            {
                result = entity.Wards
                                .Where((obj) => (obj.District.Type + " " + obj.District.Name) == sQuanHuyen && (obj.District.Province.Type + " " + obj.District.Province.Name) == sTinhThanhPho)
                                .OrderBy(obj => obj.Name)
                                .Select(obj => obj.Type + " " + obj.Name)
                                .ToList();
            }
            return result;
        }

        internal static Ward LayPhuongXa(int? lId)
        {
            Ward result = null;
            using (QLTTCovid19Entities entity = new QLTTCovid19Entities())
            {
                result = entity.Wards.Where(obj => obj.Id == lId).FirstOrDefault();
            }

            return result;
        }

        internal static District LayQuanHuyen(int? lId)
        {
            District result = null;
            using (QLTTCovid19Entities entity = new QLTTCovid19Entities())
            {
                result = entity.Districts.Where(obj => obj.Id == lId).FirstOrDefault();
            }

            return result;
        }

        internal static Province LayTinhThanh(int? lId)
        {
            Province result = null;
            using (QLTTCovid19Entities entity = new QLTTCovid19Entities())
            {
                result = entity.Provinces.Where(obj => obj.Id == lId).FirstOrDefault();
            }

            return result;
        }
    }
}
