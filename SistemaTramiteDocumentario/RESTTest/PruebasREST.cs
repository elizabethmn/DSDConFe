﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using STDDatos;
using System.Text;
using System.Collections.Generic;

namespace RESTTest
{
    [TestClass]
    public class PruebasREST
    {
        [TestMethod]
        public void ObtenerEvaluacion()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Evaluacion.svc/Evaluacion/1");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string expedienteJson = reader.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            List<Evaluacion> evaluacionObt = js2.Deserialize<List<Evaluacion>>(expedienteJson);
            Assert.AreEqual("1", evaluacionObt[0].codigoExpediente.ToString());
            Assert.AreEqual("Permisos de construccion urbana", evaluacionObt[0].Tramite);
        }

        [TestMethod]
        public void ObtenerEvaluacionError()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Evaluacion.svc/Evaluacion/3");
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string expedienteJson = reader.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                List<Evaluacion> evaluacionObt = js2.Deserialize<List<Evaluacion>>(expedienteJson);
                Assert.AreEqual("2", evaluacionObt[0].codigoExpediente.ToString());
                Assert.AreEqual("Permisos de construccion urbana", evaluacionObt[0].Tramite);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("No hay informacion del expediente", mensaje);
            }

            // if (evaluacionObt.Count >0) {
            //Assert.AreEqual("Permisos de construccion urbana", evaluacionObt[0].Tramite);
            //}            
        }

        [TestMethod]
        public void ObtenerEvaluacionError2()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Evaluacion.svc/Evaluacion/asd");
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string expedienteJson = reader.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                List<Evaluacion> evaluacionObt = js2.Deserialize<List<Evaluacion>>(expedienteJson);
                Assert.AreEqual("2", evaluacionObt[0].codigoExpediente.ToString());
                Assert.AreEqual("Permisos de construccion urbana", evaluacionObt[0].Tramite);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Debe enviar un codigo valido", mensaje);
            }

            // if (evaluacionObt.Count >0) {
            //Assert.AreEqual("Permisos de construccion urbana", evaluacionObt[0].Tramite);
            //}            
        }


        [TestMethod]
        public void GrabarUsuario()
        {
            try
            {
                string postdata = "{" +
                "\"Dni\":\"45678912\"," +
                "\"Nombre\":\"Paul asdasd\"," +
                "\"Tipo\":1" +
                "}";
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Usuario.svc/Usuario");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string usuarioJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                bool usuarioCreado = js.Deserialize<bool>(usuarioJson);

                //Assert.AreEqual("2", evaluacionObt[0].codigoExpediente.ToString());
                //Assert.AreEqual("Permisos de construccion urbana", evaluacionObt[0].Tramite);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Usuario no fue creado", mensaje);
            }

            // if (evaluacionObt.Count >0) {
            //Assert.AreEqual("Permisos de construccion urbana", evaluacionObt[0].Tramite);
            //}            
        }

    }
}
