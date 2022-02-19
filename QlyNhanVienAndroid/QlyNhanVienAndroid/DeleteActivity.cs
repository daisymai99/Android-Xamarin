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
    [Activity(Label = "DeleteActivity")]
    public class DeleteActivity : Activity
    {

        EditText edtTen, edtHo;
        Button btnDelete;
        TextView tvThongBao;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.DeleteLayout);

            edtHo = FindViewById<EditText>(Resource.Id.edtHo);
            edtTen = FindViewById<EditText>(Resource.Id.edtTen);
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            tvThongBao = FindViewById<TextView>(Resource.Id.tvThongBao);

            btnDelete.Click += BtnDelete_Click;

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (edtTen.Text == "" || edtHo.Text == "" )
            {
                tvThongBao.Text = "Vui lòng nhập đầy đủ thông tin";
            }
            string kq = Connect.abcdef.service.deleteNhanVien(edtHo.Text.ToString().Trim(), edtTen.Text.ToString().Trim());
            tvThongBao.Text = kq;

        }
    }
}