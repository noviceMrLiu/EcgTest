using Prism.Mvvm;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EcgTest.Common.Model
{
    public class EcgData:BindableBase
    {
		private PathGeometry leadDataI;

		public PathGeometry LeadDataI
        {
			get { return leadDataI; }
			set { leadDataI = value; RaisePropertyChanged(); }
		}		
        private PathGeometry leadDataII;

        public PathGeometry LeadDataII
        {
            get { return leadDataII; }
            set { leadDataII = value; RaisePropertyChanged(); }
        }
        private PathGeometry leadDataIII;

        public PathGeometry LeadDataIII
        {
            get { return leadDataIII; }
            set { leadDataIII = value; RaisePropertyChanged(); }
        }
        private string leadI;

        public string LeadI
        {
            get { return leadI; }
            set { leadI = value; }
        }
        private string leadII;

        public string LeadII
        {
            get { return leadII; }
            set { leadII = value; }
        }
        private string leadIII;

        public string LeadIII
        {
            get { return leadIII; }
            set { leadIII = value; }
        }

    }
}
