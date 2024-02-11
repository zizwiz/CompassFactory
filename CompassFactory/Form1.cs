using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using CenteredMessagebox;
using CoordinateSharp;
using CoordinateSharp.Magnetic;
using Metar_Taf_Viewer.common_data;

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
                MsgBox.Show("Lunar", "hello", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbcntr_compass_factory.SelectedTab.Name == "tab_charting")
            {
                Charting(cmbobx_airportinfo_from.Text, year, month, day, hour, minute, second);
            }
        }


        private void Charting(string AirfieldName, int year, int month, int day, int hour, int minute, int second)
        {

            rchtxtbx_charting_output.Text = "";

            string[] from_data = airport_data.GetAirportInfo(AirfieldName);
            double from_lat = double.Parse(from_data[4]);
            double from_lng = double.Parse(from_data[6]);

            //Coordinate fc = new Coordinate(from_lat, from_lng, new DateTime(year, month, day, hour, minute, second), new EagerLoad(false));
            //Magnetic m = new Magnetic(fc, DataModel.WMM2020);

            //rchtxtbx_charting_output.AppendText("Declination: \t" + Math.Round(m.MagneticFieldElements.Declination, 2) + "\r");
            //rchtxtbx_charting_output.AppendText("Variation: \t\t" + Math.Round(m.SecularVariations.Declination, 2) + "\r");
            //rchtxtbx_charting_output.AppendText("Uncertainty: \t" + Math.Round(m.Uncertainty.Declination, 2) + "\r");

            

            Coordinate fc = new Coordinate(from_lat, from_lng, new DateTime(year, month, day, hour, minute, second), new EagerLoad(false));
            

            fc.FormatOptions.Format = CoordinateFormatType.Degree_Minutes_Seconds;
            fc.FormatOptions.Display_Leading_Zeros = true;
            fc.FormatOptions.Round = 3;

            Magnetic m = new Magnetic(fc, DataModel.WMM2020);

            rchtxtbx_charting_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxtbx_charting_output.AppendText("\rDecimal Degrees for " + cmbobx_airportinfo_from.Text + "\r");
            rchtxtbx_charting_output.AppendText("Declination: \t" + Math.Round(m.MagneticFieldElements.Declination, 2) + "\r");
            rchtxtbx_charting_output.AppendText("Variation: \t\t" + Math.Round(m.SecularVariations.Declination, 2) + "\r");
            rchtxtbx_charting_output.AppendText("Uncertainty: \t" + Math.Round(m.Uncertainty.Declination, 2) + "\r");

            rchtxtbx_charting_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxtbx_charting_output.AppendText("\rDegrees, minutes and seconds for " + cmbobx_airportinfo_from.Text + "\r");
            rchtxtbx_charting_output.AppendText("Declination: \t" + DecimalToDegrees(m.MagneticFieldElements.Declination) + "\r");
            rchtxtbx_charting_output.AppendText("Variation: \t\t" + DecimalToDegrees(m.SecularVariations.Declination) + "\r");
            rchtxtbx_charting_output.AppendText("Uncertainty: \t" + DecimalToDegrees(m.Uncertainty.Declination) + "\r");

            
            //Only show if we have chosen to fly between two airfields
            if (chkbx_flight.Checked)
            {
                string[] to_data = airport_data.GetAirportInfo(cmbobx_airportinfo_to.Text);
                double to_lat = double.Parse(to_data[4]);
                double to_lng = double.Parse(to_data[6]);

                Coordinate tc = new Coordinate(to_lat, to_lng, new DateTime(year, month, day, hour, minute, second));
                Distance d = new Distance(fc, tc, Shape.Ellipsoid);

                rchtxtbx_charting_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
                rchtxtbx_charting_output.AppendText("\rFlying from " + cmbobx_airportinfo_from.Text + " to " +
                                                    cmbobx_airportinfo_to.Text + "\r");

                rchtxtbx_charting_output.AppendText("Distance = " + Math.Round(d.NauticalMiles, 2) + "nm\r");
                rchtxtbx_charting_output.AppendText("Bearing = " + Math.Round(d.Bearing, 2) + "°\r");
            }
        }

        private void Solar(string AirfieldName, int year, int month, int day, int hour, int minute, int second)
        {

            rchtxtbx_solar_output.Text = "";

            string[] data = airport_data.GetAirportInfo(AirfieldName);
            double lat = double.Parse(data[4]);
            double lng = double.Parse(data[6]);

            Coordinate c = new Coordinate(lat, lng, new DateTime(year, month, day, hour, minute, second));
            
            rchtxtbx_solar_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxtbx_solar_output.AppendText("\rSolar Information for " + cmbobx_airportinfo_from.Text + "\r");

            rchtxtbx_solar_output.AppendText("\rCoordinates = \t\t" + c + "\r");
            //formatting coordinates
            c.FormatOptions.Format = CoordinateFormatType.Decimal_Degree;
            c.FormatOptions.Display_Leading_Zeros = true;
            c.FormatOptions.Round = 3;
            rchtxtbx_solar_output.AppendText("Latitude (decimal) = \t\t" + c.Latitude + "\r");
            rchtxtbx_solar_output.AppendText("Longitude (decimal) = \t" + c.Longitude + "\r");

            //You can get sunrise for any day by just adding or subtracting days
            rchtxtbx_solar_output.AppendText("\rYesterdays Sunrise = \t" +
                                             Celestial.Get_Next_SunRise(lat, lng, DateTime.Now.AddDays(-2)) + "\r");
            rchtxtbx_solar_output.AppendText("Today's  Sunrise = \t\t" + c.CelestialInfo.SunRise + "\r");
            rchtxtbx_solar_output.AppendText("Tomorrows Sunrise = \t" +
                                             Celestial.Get_Next_SunRise(lat, lng, DateTime.Now.AddDays(0)) + "\r");

            //You can get sunrise for any day by just adding or subtracting days
            rchtxtbx_solar_output.AppendText("\rYesterdays Sunset = \t" +
                                             Celestial.Get_Next_SunSet(lat, lng, DateTime.Now.AddDays(-1)) + "\r");
            rchtxtbx_solar_output.AppendText("Today's Sunset = \t\t" + c.CelestialInfo.SunSet + "\r");
            rchtxtbx_solar_output.AppendText("Tomorrows Sunset = \t" +
                                             Celestial.Get_Next_SunSet(lat, lng, DateTime.Now.AddDays(1)) + "\r");


            rchtxtbx_solar_output.AppendText("\rSolar Noon = \t" + c.CelestialInfo.SolarNoon + "\r");
            rchtxtbx_solar_output.AppendText("Sun Altitude = \t" + c.CelestialInfo.SunAltitude + "\r");
            rchtxtbx_solar_output.AppendText("Solar Azimuth = \t" + c.CelestialInfo.SunAzimuth + "\r");



            rchtxtbx_solar_output.AppendText("\rIs it Daylight at the moment? = " + c.CelestialInfo.IsSunUp + "\r");
            rchtxtbx_solar_output.AppendText("Sun Condition = " + c.CelestialInfo.SunCondition + "\r");

            rchtxtbx_solar_output.AppendText(
                "\rLast Solar Eclipse = " + c.CelestialInfo.SolarEclipse.LastEclipse + "\r");
            rchtxtbx_solar_output.AppendText("Next Solar Eclipse = " + c.CelestialInfo.SolarEclipse.NextEclipse + "\r");
            rchtxtbx_solar_output.AppendText("\rZodiac Sign = " + c.CelestialInfo.AstrologicalSigns.ZodiacSign + "\r");
            rchtxtbx_solar_output.AppendText("\rSummer Solstice = " + c.CelestialInfo.Solstices.Summer + "\r");
            rchtxtbx_solar_output.AppendText("Winter Solstice = " + c.CelestialInfo.Solstices.Winter + "\r");
            rchtxtbx_solar_output.AppendText("\rAutumn Equinox = " + c.CelestialInfo.Equinoxes.Fall + "\r");
            rchtxtbx_solar_output.AppendText("Spring Equinox = " + c.CelestialInfo.Equinoxes.Spring + "\r");


            //Write out all the Solar Eclipses for present century
            //Adjust year in DateTime below to get other centuries.
            rchtxtbx_solar_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxtbx_solar_output.AppendText("\rEclipse Table for present Century\r");
            List<SolarEclipseDetails> events =
                Celestial.Get_Solar_Eclipse_Table(lat, lng, new DateTime(year, month, day, hour, minute, second));

            for (int i = 0; i < events.Count; i++)
            {
                rchtxtbx_solar_output.AppendText("\r" + events[i]);
            }



            // rchtxtbx_output.AppendText("Universal Transverse Mercator values = " + c.UTM + "\r");
            // // 10T 550200mE 5272748mN
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

            if ((tbcntr_compass_factory.SelectedTab.Name == "tab_charting")&&(chkbx_flight.Checked))
            {
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
