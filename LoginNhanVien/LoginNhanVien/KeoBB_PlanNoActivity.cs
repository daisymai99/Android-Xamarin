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
    [Activity(Label = "KeoBB_PlanNoActivity")]
    public class KeoBB_PlanNoActivity : Activity
    {

        Spinner spinner;
        TextView tvRecipeId, tvPlanNumber, tvThongbao;

        DataTable dataTable;
        public static WebReference.service service = new WebReference.service();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.KeoBB_PlanNoLayout);

            spinner = FindViewById<Spinner>(Resource.Id.spinner1);

            tvRecipeId = FindViewById<TextView>(Resource.Id.tvRecipeId);

            tvPlanNumber = FindViewById<TextView>(Resource.Id.tvPlanNumber);

            tvThongbao = FindViewById<TextView>(Resource.Id.tvThongBao);

           
            List<string> list = new List<string>();

            DataSet dataSet = service.spinnerTextChange(Intent.GetStringExtra("code"));

            dataTable = dataSet.Tables[0];


            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(row[0].ToString().Trim());
                tvRecipeId.Text = row[2].ToString().Trim();
                tvPlanNumber.Text = row[3].ToString().Trim();


            }



            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, list);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            spinner.ItemSelected += Spinner_ItemSelected;


            spinner.Adapter = adapter;
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            foreach (DataRow row in dataTable.Rows)
            { 
                if(spinner.SelectedItem.ToString() == row[0].ToString().Trim() )
                {
                    if(Intent.GetStringExtra("code") == spinner.SelectedItem.ToString())
                    {
                        tvRecipeId.Text = row[2].ToString().Trim();
                   
                        
                        tvPlanNumber.Text = row[3  ].ToString().Trim();

                    }
                    else
                    {
                        tvThongbao.Text = "Không có trong danh sách !";
                    }

                   
                }
                
           


            }

        }


    }
}