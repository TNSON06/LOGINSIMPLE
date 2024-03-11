using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class SqlConnectionData
    {
        public static SqlConnection Connect()
        {
            string strcon = @"Data Source=TNSON\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon);//khoi tao connect
            return conn;
        }
    }
    //Tạo chuỗi kết nối CSDL
   
    public class DatabaseAccess
    {
        public static string CheckLoginDTO(TaiKhoan taikhoan)
        {
            string user = null;
            //Ham connect toi CSDL
            SqlConnection con = SqlConnectionData.Connect();
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_logic",con); 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", taikhoan.sTaiKhoan);
            cmd.Parameters.AddWithValue("@pass", taikhoan.sMatKhau);
            cmd.Connection = con;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user = reader.GetString(0);
                    
                }
                reader.Close();
                con.Close();
            }
            else
            {
                return "Tai khoan hoặc mật khẩu không chính xác";
            }
            return user;
        }
    }
}
