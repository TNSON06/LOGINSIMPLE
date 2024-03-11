using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanAccess TKAccess = new TaiKhoanAccess();
        public string CheckLogin(TaiKhoan taiKhoan)
        {
            if(taiKhoan.sTaiKhoan == "")
            {
                return "requeid_taikhoan";
            }
            if (taiKhoan.sMatKhau == "")
            {
                return "requeid_password";
            }
            string info = TKAccess.CheckLogin(taiKhoan);
            return info;
        }
    }
}
