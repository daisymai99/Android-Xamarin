using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace QlyNhanVienAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
{
        Button btnDelete, btnInsert, btnEdit;
        

       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

         
            btnDelete = FindViewById<Button>(Resource.Id.btnDelete);
            btnInsert = FindViewById<Button>(Resource.Id.btnInsert);

            btnEdit = FindViewById<Button>(Resource.Id.btnUpdate);



            btnDelete.Click += BtnDelete_Click1;
            btnInsert.Click += BtnInsert_Click;
            btnEdit.Click += BtnEdit_Click;

        }

        private void BtnDelete_Click1(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(DeleteActivity));
            StartActivity(intent);
            //throw new System.NotImplementedException();
        }

        private void BtnEdit_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(UpdateActivity));
            StartActivity(intent);
        }

        private void BtnInsert_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(InsertActivity));
            StartActivity(intent);
            }

       

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}