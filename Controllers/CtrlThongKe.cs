using _1760081.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760081.Controllers
{
    class CtrlThongKe
    {
        internal static List<ThongKeSLTinhTrang> GenThongKeSoLuongTinhTrang(string sNhomDiaPhuong, DateTime dtTu, DateTime dtDen)
        {
            List<ThongKeSLTinhTrang> result = new List<ThongKeSLTinhTrang>();

            using (QLTTCovid19Entities entity = new QLTTCovid19Entities())
            {
                List<string> listDiaPhuong = new List<string>();

                // Can lay theo tinh thanh
                if (sNhomDiaPhuong == null)
                {
                    entity.Provinces.ToList().ForEach(obj =>
                    {
                        listDiaPhuong.Add(obj.Type + " " + obj.Name);
                    });
                }
                else
                {
                    entity.Districts.Where(o => o.Province.Type + " " + o.Province.Name == sNhomDiaPhuong).ToList().ForEach(obj =>
                    {
                        listDiaPhuong.Add(obj.Type + " " + obj.Name);
                    });
                }

                foreach (string iDiaPhuong in listDiaPhuong)
                {
                    ThongKeSLTinhTrang thongKe = new ThongKeSLTinhTrang()
                    {
                        STenDiaPhuong = iDiaPhuong
                    };


                    List<NguoiLienQuan> nguoiLienQuans;
                    if (sNhomDiaPhuong == null)
                    {
                        nguoiLienQuans = entity.NguoiLienQuans.Where(obj => obj.Ward.District.Province.Type + " " + obj.Ward.District.Province.Name == iDiaPhuong).ToList();
                    }
                    else
                    {
                        nguoiLienQuans = entity.NguoiLienQuans.Where(obj => obj.Ward.District.Type + " " + obj.Ward.District.Name == iDiaPhuong).ToList();
                    }

                    foreach (NguoiLienQuan iNguoiLienQuan in nguoiLienQuans)
                    {
                        List<LichSuTinhTrangNhiem> tinhtrangs;

                        #region Them ca nhiem vao tong so ca nhiem
                        tinhtrangs = entity.LichSuTinhTrangNhiems.Where(obj => obj.Cmnd == iNguoiLienQuan.Cmnd && obj.TinhTrang == "F0").ToList();

                        if (tinhtrangs.Count > 0)
                        {
                            thongKe.LTongSoCaNhiemHienTai++;
                        }
                        #endregion

                        tinhtrangs = entity.LichSuTinhTrangNhiems
                                            .Where(obj => obj.Cmnd == iNguoiLienQuan.Cmnd
                                                        && dtTu <= obj.ThoiGianCapNhat
                                                        && obj.ThoiGianCapNhat <= dtDen).ToList();

                        if (tinhtrangs.Count > 0)
                        {
                            #region Kiem tra va them da tung am tinh
                            if (tinhtrangs.Where(obj => obj.TinhTrang == "Âm tính").ToList().Count > 0)
                            {
                                thongKe.LSoLuongAmTinh++;
                            }
                            #endregion

                            #region Kiem tra va them da tung F3
                            if (tinhtrangs.Where(obj => obj.TinhTrang == "F3").ToList().Count > 0)
                            {
                                thongKe.LSoLuongF3++;
                            }
                            #endregion

                            #region Kiem tra va them da tung F2
                            if (tinhtrangs.Where(obj => obj.TinhTrang == "F2").ToList().Count > 0)
                            {
                                thongKe.LSoLuongF2++;
                            }
                            #endregion

                            #region Kiem tra va them da tung F1
                            if (tinhtrangs.Where(obj => obj.TinhTrang == "F1").ToList().Count > 0)
                            {
                                thongKe.LSoLuongF1++;
                            }
                            #endregion

                            #region Kiem tra va them da tung F0
                            if (tinhtrangs.Where(obj => obj.TinhTrang == "F0").ToList().Count > 0)
                            {
                                thongKe.LSoLuongF0++;
                            }
                            #endregion

                            #region Kiem tra va them da tu vong
                            if (tinhtrangs.Where(obj => obj.TinhTrang == "Tử vong").ToList().Count > 0)
                            {
                                thongKe.LSoLuongTuVong++;
                            }
                            #endregion
                        }
                    }

                    result.Add(thongKe);
                }
            }

            return result;
        }

        [Obsolete]
        internal static List<ThongKeSLCaNhiem> GenThongKeSoLuongCaNhiem(string sNhomDiaPhuong, DateTime dtNgay)
        {
            List<ThongKeSLCaNhiem> result = new List<ThongKeSLCaNhiem>();

            string sTemporary;

            using (QLTTCovid19Entities entity = new QLTTCovid19Entities())
            {
                List<string> listDiaPhuong = new List<string>();

                // Can lay theo tinh thanh
                if (sNhomDiaPhuong == null)
                {
                    entity.Provinces.ToList().ForEach(obj =>
                    {
                        listDiaPhuong.Add(obj.Type + " " + obj.Name);
                    });
                }
                else
                {
                    entity.Districts.Where(o => o.Province.Type + " " + o.Province.Name == sNhomDiaPhuong).ToList().ForEach(obj =>
                    {
                        listDiaPhuong.Add(obj.Type + " " + obj.Name);
                    });
                }

                foreach (string iDiaPhuong in listDiaPhuong)
                {
                    ThongKeSLCaNhiem thongKe = new ThongKeSLCaNhiem()
                    {
                        SDiaPhuong = iDiaPhuong
                    };


                    List<NguoiLienQuan> nguoiLienQuans;
                    if (sNhomDiaPhuong == null)
                    {
                        nguoiLienQuans = entity.NguoiLienQuans.Where(obj => obj.Ward.District.Province.Type + " " + obj.Ward.District.Province.Name == iDiaPhuong).ToList();
                    }
                    else
                    {
                        nguoiLienQuans = entity.NguoiLienQuans.Where(obj => obj.Ward.District.Type + " " + obj.Ward.District.Name == iDiaPhuong).ToList();
                    }

                    foreach (NguoiLienQuan iNguoiLienQuan in nguoiLienQuans)
                    {
                        List<LichSuTinhTrangNhiem> tinhtrangs;

                        #region Them ca nhiem vao tong so ca nhiem
                        tinhtrangs = entity.LichSuTinhTrangNhiems.Where(obj => obj.Cmnd == iNguoiLienQuan.Cmnd && obj.TinhTrang == "F0").ToList();

                        if (tinhtrangs.Count > 0)
                        {
                            thongKe.LTongSoNhiem++;

                            sTemporary = tinhtrangs[0].Cmnd;

                            tinhtrangs = entity.LichSuTinhTrangNhiems.Where(obj => obj.Cmnd == sTemporary).ToList();

                            #region Kiem tra lan gan nhat da am tinh/tu vong va them vao
                            switch (tinhtrangs.Last().TinhTrang)
                            {
                                case "Âm tính":
                                    thongKe.LTongCaChuaKhoi++;
                                    break;
                                case "Tử vong":
                                    thongKe.LTongCaTuVong++;
                                    break;
                                default:
                                    break;
                            }
                            #endregion
                        }
                        #endregion

                        tinhtrangs = entity.LichSuTinhTrangNhiems
                                            .Where(obj => obj.Cmnd == iNguoiLienQuan.Cmnd
                                                        && EntityFunctions.TruncateTime(obj.ThoiGianCapNhat) == EntityFunctions.TruncateTime(dtNgay)).ToList();
                        if (tinhtrangs.Count>0)
                        {
                            switch (tinhtrangs.Last().TinhTrang)
                            {
                                case "F0":
                                    thongKe.LCaNhiem++;
                                    break;
                                case "Âm tính":
                                    thongKe.LCaChuaKhoi++;
                                    break;
                                case "Tử vong":
                                    thongKe.LCaTuVong++;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    result.Add(thongKe);
                }
            }

            return result.OrderByDescending(o=>o.LCaNhiem).OrderByDescending(o=>o.LTongSoNhiem).ToList();
        }
    }
}