using System;
using System.IO;
using System.Windows.Forms;

namespace MetricImperialConverter
{
    public partial class FormMetricImperial : Form
    {
        public FormMetricImperial()
        {
            InitializeComponent();
        }

        int totalMiles;
        int totalYards;
        int totalFeet;
        int totalInches;

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            string line = "";
            int cm;

            string path = Application.StartupPath + @"\metric.txt";
            StreamReader streamReader = new StreamReader(path);

            bool finished = false;

            while (!finished)
            {
                line = streamReader.ReadLine();

                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    cm = Convert.ToInt32(line);
                    ConvertMetric(cm);
                    TxtResult.Text += totalMiles + " mile(s), " + totalYards + " yard(s), " + totalFeet + " foo(ee)t, " + totalInches + " inch(es)" + Environment.NewLine;
                }
            }
        }

        private void ConvertMetric(int cm)
        {
            //Convert all to cm.
            double inch = 2.54;
            double foot = 12 * 2.54;
            double yard = 3 * 12 * 2.54;
            double mile = 1760 * 3 * 12 * 2.54;

            double remaining;

            totalMiles = (int)((double)cm / mile);
            remaining = cm - totalMiles * mile;

            totalYards = (int)((double)remaining / yard);
            remaining -= totalYards * yard;

            totalFeet = (int)((double)remaining / foot);
            remaining -= totalFeet * foot;

            totalInches = (int)((double)remaining / inch);
            remaining -= totalInches * inch;
        }
    }
}
