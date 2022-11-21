using EcgTest.Common;
using EcgTest.Common.Model;
using EcgTest.Views;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;

namespace EcgTest.ViewModels
{
    public class IndexViewModel : BindableBase
    {
        static int num;//第几秒的数据
        public IndexViewModel(IRegionManager regionManager)
        {
            num = -2;
            this.regionManager = regionManager;
            Stork = new DoubleCollection();
            EcgData = new EcgData();
            PathGeometries = new ObservableCollection<EcgData>();
            JsonConvert = new MyJsonConvert();
            MeasuredParameters = new ObservableCollection<MeasuredParameter>();
            CreateMeasured();
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    num = num + 3;
                    string paraStr = $"time={num}&caseId={"636e5b79a7c210e6b082822716021068"}";
                    string apiResult = WebApiRequest.WebApiGetAsync("http://192.168.1.109:5000/getLine?", paraStr);//JSON
                    RealTimeData(num, apiResult);
                    await Task.Delay(1000);   
                }
            });


        }
        List<string> zollData = new List<string>();
        private void RealTimeData(int n, string data1)
        {

            //回到主线程操作
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                string[] datas = JsonConvert.ConvertFromJson(data1).Split(",");
                zollData.AddRange(datas);
                if (n > 7)
                {
                    string zollLead1 = JsonConvert.ConvertFromPoint(zollData.ToArray());
                    EcgData.LeadDataI = PathGeometry.CreateFromGeometry(Geometry.Parse(zollLead1));

                   // PathGeometries.Add(new EcgData { LeadDataI = PathGeometry.CreateFromGeometry(Geometry.Parse(zollLead1)) });
                    EcgData.LeadI = "I";

                    var geo = EcgData.LeadDataI;
                    geo.GetPointAtFractionLength(0.1, out var p, out _);//第一个参数是路径的精度
                    From = (p - geo.Figures[0].StartPoint).Length * 10 / 1;//被除数是path路径的StrokeThickness值 绑定动画中的From
                    Stork = DoubleCollection.Parse(From.ToString());//绑定StrokeDashArray


                }

            }));

            //var animation = new DoubleAnimation()
            //{
            //    From = From,
            //    To = 0,
            //    Duration = TimeSpan.FromSeconds(10),

            //};
            //EcgData.LeadDataI.BeginAnimation(Path.StrokeDashOffsetProperty, animation);


        }
        private ObservableCollection<EcgData> pathGeometries;

        public ObservableCollection<EcgData> PathGeometries
        {
            get { return pathGeometries; }
            set { pathGeometries = value; RaisePropertyChanged(); }
        }


        private MyJsonConvert jsonConvert;

        public MyJsonConvert JsonConvert
        {
            get { return jsonConvert; }
            set { jsonConvert = value; }
        }


        private double from;
        public double From
        {
            get { return from; }
            set
            {
                from = value;
                RaisePropertyChanged();
            }
        }
        private DoubleCollection stork;

        public DoubleCollection Stork
        {
            get { return stork; }
            set
            {
                stork = value;
                RaisePropertyChanged();
            }
        }


        private void CreateMeasured()
        {
            MeasuredParameters.Add(new MeasuredParameter
            {
                PatientId = "110",
                Age = 20,
                ExamCode = "8848",
                Date = DateTime.Now,
                Name = "刘大发",
                QRS = "72",
                PQRST = "000",
                Sex = "男",
                P = "001",
                PR = "002",
                QTQTC = "10/20",
                RRPP = "106/001",
                RV5 = "55",
                SV1RV5 = "120+55"
            });
        }
        private EcgData ecgData;

        public EcgData EcgData
        {
            get { return ecgData; }
            set { ecgData = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<MeasuredParameter> measuredParameters;

        public ObservableCollection<MeasuredParameter> MeasuredParameters
        {
            get { return measuredParameters; }
            set { measuredParameters = value; RaisePropertyChanged(); }
        }

        public IndexView MyView { get; set; }
        private readonly IRegionManager regionManager;
    }
}