using EcgTest.Common.Model;
using EcgTest.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcgTest.ViewModels
{
    public class DataViewModel:BindableBase
    {
        public DataViewModel(IRegionManager regionManager)
        {
            PatientInfos = new ObservableCollection<PatientInfo>();
            CreatePatient();
            NavigateCommand = new DelegateCommand<PatientInfo>(Navigate);
            this.regionManager = regionManager;
        }

        private void Navigate(PatientInfo obj)
        {
            
            regionManager.Regions[PrismManager.HomeViewRegionName].RequestNavigate("IndexView");
        }

        private void CreatePatient()
        {
            PatientInfos.Add(new PatientInfo() { PatientId="1008611", ExamCode="11123", Date=DateTime.Now, Name="刘大发" });
            PatientInfos.Add(new PatientInfo() { PatientId = "1008611", ExamCode = "11123", Date = DateTime.Now, Name = "刘大发" });
            PatientInfos.Add(new PatientInfo() { PatientId = "1008611", ExamCode = "11123", Date = DateTime.Now, Name = "刘大发" });
        }

        private ObservableCollection<PatientInfo> patientInfos;
        public DelegateCommand<PatientInfo> NavigateCommand { get; set; }
        public ObservableCollection<PatientInfo> PatientInfos
        {
            get { return patientInfos; }
            set { patientInfos = value; RaisePropertyChanged(); }
        }


        private readonly IRegionManager regionManager;
    }
}
