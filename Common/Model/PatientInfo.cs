using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcgTest.Common.Model
{
    public class PatientInfo:BindableBase
    {
		private string patientId;

		public string PatientId
		{
			get { return patientId; }
			set { patientId = value; }
		}

		private string examCode;

		public string ExamCode
		{
			get { return examCode; }
			set { examCode = value;}
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value;  }
		}
		private string sex;

		public string Sex
		{
			get { return sex; }
			set { sex = value; }
		}
		private int age;

		public int Age
		{
			get { return age; }
			set { age = value; }
		}


		private DateTime date;

		public DateTime Date
		{
			get { return date; }
			set { date = value;}
		}

	}
}
