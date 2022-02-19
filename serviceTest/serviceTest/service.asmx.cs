using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace serviceTest
{
    /// <summary>
    /// Summary description for service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class service : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string[] checkLogin(string empno)
        {
            string[] result = new string[2];
            string check = "  select empno,bithdat,name from [erp].[dbo].[peremp] where  empno= '" + empno + "' ";

            DataTable dt = new DataTable();
            dt = SQLConnect.connectSQL.ExecuteQuery(check);
            if (dt.Rows.Count > 0)
            {
                result[0] = dt.Rows[0][0].ToString().Trim();
                result[1] = dt.Rows[0][2].ToString().Trim();



                return result;

            }
            else
            {
                result[0] = "sai";
                return result;
            }

        }

        [WebMethod]
        public DataSet getEngName()
        {
            DataTable dt = new DataTable();
            string a = "  select engnam, empno   from [erp].[dbo].[peremp] where depno like '%B22%'";

            dt = SQLConnect.connectSQL.ExecuteQuery(a);

            DataSet dataset = new DataSet();
            dataset.Tables.Add(dt);




            return dataset;
        }

        [WebMethod]
        public string deleteNhanVien(string ho, string username)
        {
            string thongbao;
            string a = " Delete [testNhanVien].[dbo].[NhanVien] where Họ = N'" + ho + "' And Tên = N'" + username + "'";

            bool check = SQLConnect.connectSQL.ExecuteNonQuery(a);
            if (check == true)
            {
                thongbao = "Đã xoá nhân viên thành công !";
            }
            else
            {
                thongbao = "Không có dữ liệu của nhân viên này";
            }

            return thongbao;

        }

        [WebMethod]
        public DataSet spinnerTextChange(string spinner)
        {
            string[] temp = new string[3];

            string a = "select plan_id, recipe_id, plan_num from[BB].[dbo].[IF_RtPlan2CWSS]  where Write_Time like'" + DateTime.Now.ToString("yyyy-MM-dd") + "%'";

            string b = "select plan_id, Equip_Code, recipe_id, plan_num from[BB].[dbo].[IF_RtPlan2CWSS]  where Equip_Code='"+spinner+"' order by Plan_Id desc";

            DataTable dt = new DataTable();
            dt = SQLConnect.connectSQL.ExecuteQuery(b);
            DataSet dataSet = new DataSet();


            if (dt.Rows.Count > 0)
            {


                dataSet.Tables.Add(dt);
                return dataSet;

            }
            else
            {
                temp[0] = "không có trong danh sách";
                return dataSet;
            }


        }

        [WebMethod]
        public string InsertNhanvien(string ho, string ten)
        {
            string a = "insert into  [testNhanVien].[dbo].[NhanVien] values (N'" + ho + "',N'" + ten + "')";
            bool check = SQLConnect.connectSQL.ExecuteNonQuery(a);
            string thongbao;
            if (check == true)
            {
                thongbao = "Đa them thanh cong !";
            }
            else
            {
                thongbao = "không thêm thành công";
            }
            return thongbao;
        }

        [WebMethod]
        public string UpdateNhanVien(string hoCu, string tenCu, string hoMoi, string tenMoi)
        {
            string a = "update [testNhanVien].[dbo].[NhanVien] set Họ = N'" + hoMoi + "', Tên = N'" + tenMoi + "' where Họ = N'" + hoCu + "' or Tên = N'" + tenCu + "'";
            bool check = SQLConnect.connectSQL.ExecuteNonQuery(a);
            string thongbao;
            if (check == true)
            {
                thongbao = "Đa update thanh cong !";
            }
            else
            {
                thongbao = "Vui lòng nhập đủ thông tin cho nhân viên";
            }
            return thongbao;
        }

        [WebMethod]
        public DataTable getData()
        {
            string[] arr = null;
            string a = "select * from NhanVien";
            DataTable dataTable = new DataTable();
            dataTable = SQLConnect.connectSQL.ExecuteQuery(a);
            dataTable.TableName = "a";

            return dataTable;
        }

    }
}
