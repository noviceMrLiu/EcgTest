using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Newtonsoft.Json.Linq;

namespace EcgTest.Common
{
    public class MyJsonConvert
    {
        public string ConvertFromJson(string original)
        {
            original = original.Replace("\r\n", "").Trim().Replace("\t", "");
            JObject obj = JObject.Parse(original);
            var Leads = obj.SelectTokens("$....WaveRec").ToList();
            return Leads[0].SelectToken("UnpackedSamples").ToString().Replace("[","").Replace("]","").Replace(" ","");//II导联
            Leads[1].SelectToken("UnpackedSamples").ToString();//I导联
            Leads[2].SelectToken("UnpackedSamples").ToString();//III导联

        }

        public string ConvertFromPoint(string[] dataPoint)
        {
            double[] nums;
            nums = Array.ConvertAll<string, double>(dataPoint, s => int.Parse(s));
            List<Point> points = new List<Point>() { };
            double x = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = nums[i] * -1;
                points.Add(new Point { X = x, Y = nums[i] });
                x += 0.225;
            }
            List<LineSegment> segments = new List<LineSegment>();
            foreach (var item in points)
            {
                segments.Add(new LineSegment(item, true));
            }
            PathFigure figure = new PathFigure(points.First(), segments, false);
            PathGeometry myPathGeometry = new PathGeometry();
            myPathGeometry.Figures.Add(figure);
            return myPathGeometry.ToString();
        }

        private string[] leadIjson;

        public string[] LeadIJson
        {
            get { return leadIjson; }
            set { leadIjson = value; }
        }
        private string[] leadIIJson;

        public string[] LeadIIJson
        {
            get { return leadIIJson; }
            set { leadIIJson = value; }
        }

        private string[] leadIIIJson;

        public string[] LeadIIIJson
        {
            get { return leadIIIJson; }
            set { leadIIIJson = value; }
        }

    }
}
