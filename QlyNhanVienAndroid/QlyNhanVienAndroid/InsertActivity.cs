using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QlyNhanVienAndroid
{
    [Activity(Label = "Insert Data", Theme = "@style/AppTheme", MainLauncher = false)]
    class InsertActivity : AppCompatActivity
    {

        Spinner spinner;
        EditText edtHo, edtTen;
        Button btnThem;
        TextView tvThongBao;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.InsertLayout);


            edtHo = FindViewById<EditText>(Resource.Id.edtHo);
            edtTen = FindViewById<EditText>(Resource.Id.edtTen);
            btnThem = FindViewById<Button>(Resource.Id.btnInsert);
            tvThongBao = FindViewById<TextView>(Resource.Id.tvThongBao);
            spinner = FindViewById<Spinner>(Resource.Id.spinner);

           
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.car_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);


            spinner.Adapter = adapter;


            btnThem.Click += BtnThem_Click;

        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            edtTen.Text = string.Format("", spinner.GetItemAtPosition(e.Position));
            string b = spinner.SelectedItem.ToString();
            Toast.MakeText(this, "test" + b, ToastLength.Short);




        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (edtTen.Text == "" || edtHo.Text == "")
            {
                tvThongBao.Text = "Vui lòng nhập đầy đủ thông tin";
            }
            string kq = Connect.abcdef.service.InsertNhanvien(edtHo.Text.ToString().Trim(), spinner.SelectedItem.ToString());
            tvThongBao.Text = kq;
        
        }
    }
}