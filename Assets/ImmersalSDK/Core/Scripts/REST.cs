/*===============================================================================
Copyright (C) 2020 Immersal Ltd. All Rights Reserved.

This file is part of the Immersal SDK.

The Immersal SDK cannot be copied, distributed, or made available to
third-parties for commercial purposes without written permission of Immersal Ltd.

Contact sdk@immersal.com for licensing requests.
===============================================================================*/

using System;

namespace Immersal.REST
{
    public static class Endpoint
    {
        public const string URL_FORMAT          = "{0}/fcgi?{1}";
        public const string CAPTURE_IMAGE       = "1";
        public const string CONSTRUCT_MAP       = "2";
        public const string LOAD_MAP            = "3";
        public const string DOWNLOAD_SPARSE     = "5";
        public const string LOGIN               = "6";
        public const string LIST_JOBS           = "8";
        public const string CLEAR_JOB           = "9";
        public const string STATUS              = "10";
        public const string DOWNLOAD_DENSE      = "14";
        public const string DELETE_MAP          = "16";
        public const string SERVER_LOCALIZE     = "17";
        public const string RESTORE_MAP_IMAGES  = "19";
        public const string LIST_GEOJOBS        = "20";
        public const string SERVER_GEOLOCALIZE  = "21";
        public const string SERVER_ECEF         = "23";
    }

    [Serializable]
    public class SDKRequestBase
    {
        public string token;
    }

    [Serializable]
    public class SDKLoginRequest
    {
        public string login;
        public string password;
    }

    [Serializable]
    public class SDKLoginResult
    {
        public string error;
        public string token;
        public int banks;
    }

    [Serializable]
    public class SDKClearRequest : SDKRequestBase
    {
        public int bank;
        public bool anchor;
    }

    [Serializable]
    public class SDKClearResult
    {
        public string error;
    }

    [Serializable]
    public class SDKConstructRequest : SDKRequestBase
    {
        public int bank;
        public string name;
    }

    [Serializable]
    public class SDKConstructResult
    {
        public int id;
        public string error;
        public int size;
    }

    [Serializable]
    public class SDKJob
    {
        public int id;
        public int size;
        public int bank;
        public string work;
        public string status;
        public string server;
        public string name;
        public double latitude;
        public double longitude;
        public double altitude;
        public string created;
        public string modified;
    }

    [Serializable]
    public class SDKStatusRequest : SDKRequestBase
    {
        public int bank;
    }

    [Serializable]
    public class SDKStatusResult
    {
        public string error;
        public int imageCount;
        public int bankMax;
        public int imageMax;
        public bool eulaAccepted;
    }

    [Serializable]
    public class SDKJobsRequest : SDKRequestBase
    {
        public int bank;
    }

    [Serializable]
    public class SDKGeoJobsRequest : SDKJobsRequest
    {
        public double latitude;
        public double longitude;
        public double radius;
    }

    [Serializable]
    public class SDKJobsResult
    {
        public string error;
        public int count;
        public SDKJob[] jobs;
    }

    [Serializable]
    public class SDKImageRequest : SDKRequestBase
    {
        public int bank;
        public int run;
        public int index;
        public bool anchor;
        public double px;
        public double py;
        public double pz;
        public double r00;
        public double r01;
        public double r02;
        public double r10;
        public double r11;
        public double r12;
        public double r20;
        public double r21;
        public double r22;
        public double fx;
        public double fy;
        public double ox;
        public double oy;
        public double latitude;
        public double longitude;
        public double altitude;
        public string b64;
    }

    [Serializable]
    public class SDKImageResult
    {
        public string error;
        public string path;
    }
     
    [Serializable]
    public class SDKMapId
    {
        public int id;
    }

    [Serializable]
    public class SDKGeoLocalizeRequest : SDKLocalizeRequest
    {
        public double latitude;
        public double longitude;
        public double radius;
    }

    [Serializable]
    public class SDKLocalizeRequest : SDKRequestBase
    {
        public double fx;
        public double fy;
        public double ox;
        public double oy;
        public string b64;
        public SDKMapId[] mapIds;
    }

    [Serializable]
    public class SDKLocalizeResult
    {
        public string error;
        public bool success;
        public int map;
        public float px;
        public float py;
        public float pz;
        public float r00;
        public float r01;
        public float r02;
        public float r10;
        public float r11;
        public float r12;
        public float r20;
        public float r21;
        public float r22;
    }

    [Serializable]
    public class SDKEcefRequest
    {
        public string token;
        public int id;
    }

    [Serializable]
    public class SDKEcefResult
    {
        public string error;
        public double[] ecef;
    }

    [Serializable]
    public class SDKMapRequest : SDKRequestBase
    {
        public int id;
    }

    [Serializable]
    public class SDKMapResult
    {
        public string error;
        public string md5_al;
        public string b64;
    }

    [Serializable]
    public class SDKDeleteMapRequest : SDKRequestBase
    {
        public int id;
    }

    [Serializable]
    public class SDKDeleteMapResult
    {
        public string error;
    }

    [Serializable]
    public class SDKRestoreMapImagesRequest : SDKRequestBase
    {
        public int id;
    }

    [Serializable]
    public class SDKRestoreMapImagesResult
    {
        public string error;
    }
}