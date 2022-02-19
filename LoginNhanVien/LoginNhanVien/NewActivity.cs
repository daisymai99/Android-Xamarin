using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LoginNhanVien
{
    [Activity(Label = "NewActivity")]
    public class NewActivity : Activity
    {
        Spinner spinner;
        public static WebReference.service service = new WebReference.service();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LayoutNew);
            // Create your application here

            spinner = FindViewById<Spinner>(Resource.Id.spinner1);

            DataSet dataSet = service.getEngName();

            DataTable dataTable = dataSet.Tables[0];

            List<string> list = new List<string>();

            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(row[0].ToString().Trim()+" - "+row[1].ToString().Trim());
              

            }

            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem,list);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);


            spinner.Adapter = adapter;

          












        }
    }
}