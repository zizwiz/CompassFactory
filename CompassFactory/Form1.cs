using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using CenteredMessagebox;

/*
< WinForm implementation of CoordinateSharp to show magnetic declination, 
intensity, directional component, even uncertainly and much more>
Copyright (C) < 2024 >  < ZizWiz>

This program is free software: you can redistribute it and/or modify 
it under the terms of the GNU Affero General Public License as
published by the Free Software Foundation, either version 3 of the
License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

https://coordinatesharp.com/DeveloperGuide#magnetic-fields

*/


namespace CompassFactory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " : v" + Assembly.GetExecutingAssembly().GetName().Version; // put in the version number



            //Get the data file from resources and write to file in same dir as the app.
            if (File.Exists("airport_data.xml")) File.Delete("airport_data.xml");
            File.WriteAllText("airport_data.xml", Properties.Resources.airport_data);

            //populate the combo boxes with the airfield names direct from xml file so we get 
            //names correctly spelt for later look up
            XmlDocument doc = new XmlDocument();
            doc.Load("airport_data.xml");
            XmlNodeList airportList = doc.SelectNodes("uk_airports/airport_info/airport_name");
            foreach (XmlNode Name in airportList)
            {
                cmbobx_airportinfo_to.Items.Add(Name.InnerText);
                cmbobx_airportinfo_from.Items.Add(Name.InnerText);
            }

            //set index to first item
            cmbobx_airportinfo_from.SelectedIndex = cmbobx_airportinfo_to.SelectedIndex = 0;

            //if more than 34 items set to Cambridge item 33
            if (cmbobx_airportinfo_from.Items.Count > 33) cmbobx_airportinfo_from.SelectedIndex = 33;

            // Hide and show items
            lbl_to_airport.Visible = false;
            cmbobx_airportinfo_to.Visible = false;
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
            MsgBox.Show("Build with Jetbrains Rider\rhttps://www.jetbrains.com/rider/", "About", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btn_go_Click(object sender, EventArgs e)
        {
            int year = dateTimePicker1.Value.Year;
            int month = dateTimePicker1.Value.Month;
            int day = dateTimePicker1.Value.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            if (tbcntr_compass_factory.SelectedTab.Name == "tab_solar")
            {
                Solar(cmbobx_airportinfo_from.Text, year, month, day, hour, minute, second);
            }
            else if (tbcntr_compass_factory.SelectedTab.Name == "tab_lunar")
            {
                Lunar(cmbobx_airportinfo_from.Text, year, month, day, hour, minute, second);
            }
            else if (tbcntr_compass_factory.SelectedTab.Name == "tab_charting")
            {
                Charting(cmbobx_airportinfo_from.Text, year, month, day, hour, minute, second);
            }
        }


 

       
        private void tbcntr_compass_factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Flight();
        }

        private void chkbx_flight_CheckedChanged(object sender, EventArgs e)
        {
            Flight();
        }

        private void Flight()
        {
            cmbobx_airportinfo_to.Visible = false;
            lbl_to_airport.Visible = false;

            if ((tbcntr_compass_factory.SelectedTab.Name == "tab_charting")&&(chkbx_flight.Checked))
            {
                lbl_to_airport.Visible = true;
                cmbobx_airportinfo_to.Visible = true;
            }
        }

        private string DecimalToDegrees(double decimal_degrees)
        {
            string direction = "W";
            int sec = (int)Math.Round(decimal_degrees * 3600);
            int deg = sec / 3600;
            sec = Math.Abs(sec % 3600);
            int min = sec / 60;
            sec %= 60;

            if (deg < 0) direction = "E";

            return deg + "° " + min +"' " + sec + "\" " + direction;

        }
    }
}
