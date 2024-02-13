using System;
using System.Collections.Generic;
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

        private void Lunar(string AirfieldName, int year, int month, int day, int hour, int minute, int second)
        {

            rchtxtbx_solar_output.Text = "";

            string[] data = airport_data.GetAirportInfo(AirfieldName);
            double lat = double.Parse(data[4]);
            double lng = double.Parse(data[6]);

            Coordinate c = new Coordinate(lat, lng, new DateTime(year, month, day, hour, minute, second));

            rchtxtbx_lunar_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxtbx_lunar_output.AppendText("Lunar Information for " + cmbobx_airportinfo_from.Text + "\r");

            rchtxtbx_lunar_output.AppendText("\rCoordinates = \t\t" + c + "\r");
            //formatting coordinates
            c.FormatOptions.Format = CoordinateFormatType.Decimal_Degree;
            c.FormatOptions.Display_Leading_Zeros = true;
            c.FormatOptions.Round = 3;
            rchtxtbx_lunar_output.AppendText("Latitude (decimal) = \t\t" + c.Latitude + "\r");
            rchtxtbx_lunar_output.AppendText("Longitude (decimal) = \t" + c.Longitude + "\r");

            //You can get moonrise for any day by just adding or subtracting days
            rchtxtbx_lunar_output.AppendText("\rYesterdays Moonrise = \t" +
                                             Celestial.Get_Next_MoonRise(lat, lng, DateTime.Now.AddDays(-2)) + "\r");
            rchtxtbx_lunar_output.AppendText("Today's  Moonrise = \t" + c.CelestialInfo.MoonRise + "\r");
            rchtxtbx_lunar_output.AppendText("Tomorrows Moonrise = \t" +
                                             Celestial.Get_Next_MoonRise(lat, lng, DateTime.Now.AddDays(0)) + "\r");

            //You can get moonrise for any day by just adding or subtracting days
            rchtxtbx_lunar_output.AppendText("\rYesterdays Moonset = \t" +
                                             Celestial.Get_Next_MoonSet(lat, lng, DateTime.Now.AddDays(-1)) + "\r");
            rchtxtbx_lunar_output.AppendText("Today's Moonset = \t\t" + c.CelestialInfo.MoonSet + "\r");
            rchtxtbx_lunar_output.AppendText("Tomorrows Moonset = \t" +
                                             Celestial.Get_Next_MoonSet(lat, lng, DateTime.Now.AddDays(1)) + "\r");
            
            rchtxtbx_lunar_output.AppendText("\rIs Moon visible = \t\t" + c.CelestialInfo.IsMoonUp + "\r");
            rchtxtbx_lunar_output.AppendText("Lunar Phase name = \t" + c.CelestialInfo.MoonIllum.PhaseName + "\r");
            rchtxtbx_lunar_output.AppendText("Lunar Phase = \t\t" + GetLunarPhaseName(Math.Round(c.CelestialInfo.MoonIllum.Phase, 2)) + "\r");
            rchtxtbx_lunar_output.AppendText("Lunar Condition = \t\t" + c.CelestialInfo.MoonCondition + "\r");

            

            rchtxtbx_lunar_output.AppendText("\rLast lunar Eclipse = \t\t" + c.CelestialInfo.LunarEclipse.LastEclipse + "\r");
            rchtxtbx_lunar_output.AppendText("Next lunar Eclipse = \t" + c.CelestialInfo.LunarEclipse.NextEclipse + "\r");

            rchtxtbx_lunar_output.AppendText("\rZodiac Sign = \t\t" + c.CelestialInfo.AstrologicalSigns.ZodiacSign + "\r");
            rchtxtbx_lunar_output.AppendText("EMoon Sign = \t\t" + c.CelestialInfo.AstrologicalSigns.EMoonSign + "\r");
            rchtxtbx_lunar_output.AppendText("EMoon Name = \t\t" + c.CelestialInfo.AstrologicalSigns.EMoonName + "\r");


            rchtxtbx_lunar_output.AppendText("\rLunar Altitude = \t\t" + Math.Round(c.CelestialInfo.MoonAltitude, 2) + "°\r");
            rchtxtbx_lunar_output.AppendText("Lunar Azimuth = \t\t" + Math.Round(c.CelestialInfo.MoonAzimuth, 2) + "\r");
            rchtxtbx_lunar_output.AppendText("Lunar Distance = \t\t" + Math.Round(c.CelestialInfo.MoonDistance.Kilometers, 2) + "km\r");
            

            /////////////////////////////////////////////////////////////
            /// Closest and furthest from the earth
            /// ////////////////////////////////////////////////////////////
            rchtxtbx_lunar_output.SelectionFont = new Font("Ariel", 8, FontStyle.Bold);
            rchtxtbx_lunar_output.AppendText("\rThe point at which the Moon is nearest Earth each month is called its Perigee, " +
                                             "while the point at which the Moon is farthest from Earth each month is called " +
                                             "its Apogee" + "\r");

            rchtxtbx_lunar_output.AppendText("\rPrevious Perigee Date = \t\t" + c.CelestialInfo.Perigee.LastPerigee.Date + "\r");
            rchtxtbx_lunar_output.AppendText("Previous Perigee Distance = \t\t" + Math.Round(c.CelestialInfo.Perigee.LastPerigee.Distance.Kilometers, 2) + "km\r");
            rchtxtbx_lunar_output.AppendText("Previous Perigee Bearing = \t\t" + Math.Round(c.CelestialInfo.Perigee.LastPerigee.Distance.Bearing, 2) + "°\r");
            rchtxtbx_lunar_output.AppendText("Previous Perigee Horizontal Parallax = \t" + Math.Round(c.CelestialInfo.Perigee.LastPerigee.HorizontalParallax, 2) + "\r");

            rchtxtbx_lunar_output.AppendText("\rNext Perigee Date = \t\t" + c.CelestialInfo.Perigee.NextPerigee.Date + "\r");
            rchtxtbx_lunar_output.AppendText("Next Perigee Distance = \t\t" + Math.Round(c.CelestialInfo.Perigee.NextPerigee.Distance.Kilometers, 2) + "km\r");
            rchtxtbx_lunar_output.AppendText("Next Perigee Bearing = \t\t" + Math.Round(c.CelestialInfo.Perigee.NextPerigee.Distance.Bearing, 2) + "°\r");
            rchtxtbx_lunar_output.AppendText("Next Perigee Horizontal Parallax = \t" + Math.Round(c.CelestialInfo.Perigee.NextPerigee.HorizontalParallax, 2) + "\r");


            rchtxtbx_lunar_output.AppendText("\rPrevious Apogee Date = \t\t" + c.CelestialInfo.Apogee.LastApogee.Date + "\r");
            rchtxtbx_lunar_output.AppendText("Previous Apogee Distance = \t\t" + Math.Round(c.CelestialInfo.Apogee.LastApogee.Distance.Kilometers, 2) + "km\r");
            rchtxtbx_lunar_output.AppendText("Previous Apogee Bearing = \t\t" + Math.Round(c.CelestialInfo.Apogee.LastApogee.Distance.Bearing, 2) + "°\r");
            rchtxtbx_lunar_output.AppendText("Previous Apogee Horizontal Parallax = \t" + Math.Round(c.CelestialInfo.Apogee.LastApogee.HorizontalParallax, 2) + "\r");

            rchtxtbx_lunar_output.AppendText("\rNext Apogee Date = \t\t" + c.CelestialInfo.Apogee.NextApogee.Date + "\r");
            rchtxtbx_lunar_output.AppendText("Next Apogee Distance = \t\t" + Math.Round(c.CelestialInfo.Apogee.NextApogee.Distance.Kilometers, 2) + "km\r");
            rchtxtbx_lunar_output.AppendText("Next Apogee Bearing = \t\t" + Math.Round(c.CelestialInfo.Apogee.NextApogee.Distance.Bearing, 2) + "°\r");
            rchtxtbx_lunar_output.AppendText("Next Apogee Horizontal Parallax = \t" + Math.Round(c.CelestialInfo.Apogee.NextApogee.HorizontalParallax, 2) + "\r");




            //Write out all the Lunar Eclipses for present century
            //Adjust year in DateTime below to get other centuries.
            rchtxtbx_lunar_output.SelectionFont = new Font("Ariel", 8, FontStyle.Underline);
            rchtxtbx_lunar_output.AppendText("\rEclipse Table for present Century\r");
            List<LunarEclipseDetails> events =
                Celestial.Get_Lunar_Eclipse_Table(lat, lng, new DateTime(year, month, day, hour, minute, second));

            for (int i = 0; i < events.Count; i++)
            {
                rchtxtbx_lunar_output.AppendText("\r" + events[i]);
            }






        }


        private string GetLunarPhaseName(double myPhaseValue)
        {
            switch (myPhaseValue)
            {
                case 0:
                    return "New Moon";
                case double expression when (myPhaseValue > 0 && myPhaseValue < 0.25):
                    return "New Moon moving towards First Quarter";
                case 0.25:
                    return "First Quarter";
                case double expression when (myPhaseValue > 0.25 && myPhaseValue < 0.5):
                    return "First Quarter moving towards Full Moon";
                case 0.5:
                    return "Full Moon";
                case double expression when (myPhaseValue > 0.5 && myPhaseValue < 0.75):
                    return "Full Moon moving towards Third Quarter";
                case 0.75:
                    return "Third Quarter";
                default:
                    return "Third Quarter moving towards New Moon";
            }


           





            
        }
    }
}