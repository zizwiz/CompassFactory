using System;
using System.Collections.Generic;
using System.Drawing;
using CoordinateSharp;
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
    }
}
