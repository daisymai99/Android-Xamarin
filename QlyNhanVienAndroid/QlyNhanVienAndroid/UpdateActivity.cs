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
    [Activity(Label = "UpdateLayout")]
    public class UpdateActivity : Activity


    {

        EditText edtHoCu, edtHoMoi, edtTenCu, edtTenMoi;
        Button btnUpdate;
        TextView tvThongBao;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.UpdateLayout);
            // Create your application here


            edtHoCu = FindViewById<EditText>(Resource.Id.edtHo);
            edtHoMoi = FindViewById<EditText>(Resource.Id.edtHoMoi);
            edtTenCu = FindViewById<EditText>(Resource.Id.edtTen);

            edtTenMoi = FindViewById<EditText>(Resource.Id.edtTenMoi);

            btnUpdate = FindViewById<Button>(Resource.Id.btnUpdate);
            tvThongBao = FindViewById<TextView>(Resource.Id.tvThongBao);

            btnUpdate.Click += BtnUpdate_Click;



        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if(edtHoCu.Text=="" || edtHoMoi.Text=="" || edtTenCu.Text=="" || edtTenMoi.Text=="")
            {
                tvThongBao.Text = "Vui lòng nhập đầy đủ thông tin";
            }
            string kq = Connect.abcdef.service.UpdateNhanVien(edtHoCu.Text.ToString().Trim(), edtTenCu.Text.ToString().Trim(), edtHoMoi.Text.ToString().Trim(), edtTenMoi.Text.ToString().Trim());
            tvThongBao.Text = kq;


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}