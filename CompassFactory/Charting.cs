using System;
using System.Drawing;
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
    public partial class Form1
    {

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



            Coordinate fc = new Coordinate(from_lat, from_lng, new DateTime(year, month, day, hour, minute, second),
                new EagerLoad(false));


            fc.FormatOptions.Format = CoordinateFormatType.Degree_Minutes_Seconds;
            fc.FormatOptions.Display_Leading_Zeros = true;
            fc.FormatOptions.Round = 3;

            Magnetic m = new Magnetic(fc, DataModel.WMM2020);

            rchtxtbx_charting_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxtbx_charting_output.AppendText("\rDecimal Degrees for " + cmbobx_airportinfo_from.Text + "\r");
            rchtxtbx_charting_output.AppendText("Declination: \t" + Math.Round(m.MagneticFieldElements.Declination, 2) +
                                                "\r");
            rchtxtbx_charting_output.AppendText("Variation: \t\t" + Math.Round(m.SecularVariations.Declination, 2) +
                                                "\r");
            rchtxtbx_charting_output.AppendText("Uncertainty: \t" + Math.Round(m.Uncertainty.Declination, 2) + "\r");

            rchtxtbx_charting_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxtbx_charting_output.AppendText("\rDegrees, minutes and seconds for " + cmbobx_airportinfo_from.Text +
                                                "\r");
            rchtxtbx_charting_output.AppendText("Declination: \t" +
                                                DecimalToDegrees(m.MagneticFieldElements.Declination) + "\r");
            rchtxtbx_charting_output.AppendText("Variation: \t\t" + DecimalToDegrees(m.SecularVariations.Declination) +
                                                "\r");
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
    }
}