using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcgTest.Common.Model
{
    public class MeasuredParameter:PatientInfo
    {
		private string qrs;

		public string QRS
		{
			get { return qrs; }
			set { qrs = value; }
		}
		private string qtAndqtc;

		public string QTQTC
		{
			get { return qtAndqtc; }
			set { qtAndqtc = value; }
		}
		private string pr;

		public string PR
		{
			get { return pr; }
			set { pr = value; }
		}
		private string p;

		public string P
		{
			get { return p; }
			set { p = value; }
		}
		private string rrpp;

		public string RRPP
		{
			get { return rrpp; }
			set { rrpp = value; }
		}
		private string pAndqrsAndt;

		public string PQRST
		{
			get { return pAndqrsAndt; }
			set { pAndqrsAndt = value; }
		}
		private string rv5;

		public string RV5
		{
			get { return rv5; }
			set { rv5 = value; }
		}
		private string sv1rv5;

		public string SV1RV5
		{
			get { return sv1rv5; }
			set { sv1rv5 = value; }
		}


	}
}
