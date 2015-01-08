﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NCast.Devices.Chromecast.Entities.Response;
using NCast.Discovery;

namespace NCast.Devices
{
    public class ChromecastDevice : IDevice
    {
        public ChromecastDevice(ChromecastDeviceDiscoveryReportItem report)
        {
            Parse(report);
        }

        public bool Parse(DeviceDiscoveryReportItem report)
        {
            if (report is ChromecastDeviceDiscoveryReportItem == false)
                return false;
            var chromeCastReport = report as ChromecastDeviceDiscoveryReportItem;
            this.EndPoint = chromeCastReport.EndPoint;
            this.Interface = chromeCastReport.Interface;
            this.Name = chromeCastReport.Name;
            this.BaseUrl = chromeCastReport.BaseUri.ToString();
            this.Type = chromeCastReport.DeviceType;
            this.Manufacturer = chromeCastReport.Manufacturer;
            this.Model = chromeCastReport.Model;
            return true;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        ///     Parses the v1 response from a chromecast device
        /// </summary>
        ///
        /// <param name="response">
        ///     The response.
        /// </param>
        ///-------------------------------------------------------------------------------------------------


        public IPEndPoint EndPoint { get; set; }
        public IPAddress Interface { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string BaseUrl { get; set; }
        public DeviceType Type { get; set; }

    }
}
