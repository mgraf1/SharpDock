using RestSharp;
using SharpDock.Rest.Requests;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SharpDock.Rest
{
    public static class Extensions
    {
        public static bool IsSuccessStatusCode(this HttpStatusCode responseCode)
        {
            int numericResponse = (int)responseCode;
            return numericResponse >= 200
                && numericResponse <= 399;
        }
    }
}
