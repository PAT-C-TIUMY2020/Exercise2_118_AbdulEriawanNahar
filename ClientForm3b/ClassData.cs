﻿using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Net;
using static ClientForm3b.Form1;
using System.Runtime.Serialization;
using RestSharp;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ClientForm3b
{
    public class ClassData
    {
       
            string baseUrl = "http://localhost:1908/";

            public Mahasiswa search(string nim)
            {
                var json = new WebClient().DownloadString("http://localhost:1908/Mahasiswa/" + nim);
                var data = JsonConvert.DeserializeObject<Mahasiswa>(json);
                return data;
            }


            public List<Mahasiswa> getAllData()
            {
                var json = new WebClient().DownloadString("http://localhost:1908/Mahasiswa");
                var data = JsonConvert.DeserializeObject<List<Mahasiswa>>(json);
                return data;
            }

            public bool updateDatabase(Mahasiswa mhs)
            {
                bool updated = false;
                try
                {
                    var client = new RestClient(baseUrl);
                    var request = new RestRequest("UpdateMahasiswa", Method.PUT);
                    request.AddJsonBody(mhs);
                    client.Execute(request);
                }
                catch (Exception ex)
                {

                }
                return updated;
            }

            public bool deleteMahasiswa(string nim)
            {
                bool deleted = false;
                try
                {
                    var client = new RestClient(baseUrl);
                    var request = new RestRequest("DeleteMahasiswa" + nim, Method.DELETE);
                    client.Execute(request);
                }
                catch (Exception ex)
                {

                }
                return deleted;
            }
        
    }

}