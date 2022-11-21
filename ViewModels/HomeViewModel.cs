using EcgTest.Common.Model;
using EcgTest.Extensions;
using Prism.Commands;
using Prism.Ioc;
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
    public class HomeViewModel: BindableBase
    {
        private readonly IRegionManager regionManager;
        public HomeViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
          
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            this.regionManager = regionManager;
            Create();
        }

        private void Create()
        {
            //注释这是用来测试git的
            MenuBars.Add(new MenuBar() { Icon = "Cryengine", Title = "患者数据1", NameSpace = "DataView" });
            MenuBars.Add(new MenuBar() { Icon= "Cryengine", Title="心电图1",NameSpace="IndexView"});
            MenuBars.Add(new MenuBar() { Icon = "Cryengine", Title = "未知1", NameSpace = "" });
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))

                return;
            regionManager.Regions[PrismManager.HomeViewRegionName].RequestNavigate(obj.NameSpace);

        }
        private ObservableCollection<MenuBar> menuBars;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; set; }
    }
}
