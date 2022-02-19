using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QlyNhanVienAndroid
{
    [Activity(Label = "LoginActivity",MainLauncher = true)]
    public class LoginActivity : Activity
    {
        EditText edtHo, edtTen;
        Button btnLogin;
        TextView tvThongBao;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

            edtTen = FindViewById<EditText>(Resource.Id.edtTen);
            edtHo = FindViewById<EditText>(Resource.Id.edtHo);
            tvThongBao = FindViewById<TextView>(Resource.Id.tvThongBao);

            btnLogin = FindViewById<Button>(Resource.Id.buttonLogin);

            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (edtTen.Text == "" || edtHo.Text == "")
            {
                tvThongBao.Text = "Vui lòng nhập đầy đủ thông tin";
            }
            string[] kq = Connect.abcdef.service.checkLogin(edtHo.Text.ToString().Trim(), edtTen.Text.ToString().Trim());
            if (kq[0] == "sai")
            {
                tvThongBao.Text = "Vui lòng nhập lại";
            }
            else
            {
                Intent intent = new Intent(this, typeof(DeleteActivity));
                StartActivity(intent);
            }
        }
    }
}