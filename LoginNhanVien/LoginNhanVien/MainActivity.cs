using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Collections.Generic;
using System.Data;

namespace LoginNhanVien
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        EditText edtNumber, edtPass;
        Button btnLogin;
        TextView tvThongBao;

        Spinner spinner;
        DataTable dataTabel;
        public static WebReference.service service = new WebReference.service();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            edtNumber = FindViewById<EditText>(Resource.Id.edtNumber);
            edtPass = FindViewById<EditText>(Resource.Id.edtPassword);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            tvThongBao = FindViewById<TextView>(Resource.Id.textView2);
            spinner = FindViewById<Spinner>(Resource.Id.spinner1);

            edtNumber.TextChanged += EdtNumber_TextChanged;

            var adapter = ArrayAdapter.CreateFromResource(this,Resource.Array.code, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            spinner.Adapter = adapter;

            btnLogin.Click += BtnLogin_Click;
        }

        private void EdtNumber_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if(edtNumber.Text.Length == 6)
            {
                  string[] kq =service.checkLogin(edtNumber.Text.ToString().Trim());
                  if(kq[0] != "sai")
                {
                    tvThongBao.Text = kq[1];
                } 
            }
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            string[] kq = service.checkLogin(edtNumber.Text.ToString().Trim());

            if (kq[0] == "sai")
            {
                tvThongBao.Text = "Vui lòng đăng nhập lại!";
            }
            else
            {
                
                Intent intent = new Intent(this, typeof(KeoBB_PlanNoActivity));
                intent.PutExtra("code", spinner.SelectedItem.ToString());
                StartActivity(intent);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}