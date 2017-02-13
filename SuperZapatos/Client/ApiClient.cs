using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SuperZapatos.Client
{
    public class ApiClient
    {

        string APIUri = "http://localhost:57240/";

        public T ExecuteGet<T>(params string[] _params)
        {
            using (var _client = new HttpClient() { BaseAddress = new Uri(APIUri) })
            {
                String _query = "";
                foreach (string _param in _params)
                {
                    _query = String.Concat(_query, @"/", _param);
                }
                var _respuesta = _client.GetAsync(_query).Result;
                _respuesta.EnsureSuccessStatusCode();
                return _respuesta.Content.ReadAsAsync<T>().Result;
            }
        }

        public T ExecutePost<T>(string _metodo, T _entity)
        {
            using (var _client = new HttpClient() { BaseAddress = new Uri(APIUri) })
            {
                var _respuesta = _client.PostAsJsonAsync<T>(_metodo, _entity).Result;
                _respuesta.EnsureSuccessStatusCode();
                return _respuesta.Content.ReadAsAsync<T>().Result;
            }
        }

        public T ExecutePut<T>(string _metodo, T _entity)
        {
            using (var _client = new HttpClient() { BaseAddress = new Uri(APIUri) })
            {
                var _respuesta = _client.PutAsJsonAsync<T>(_metodo, _entity).Result;
                _respuesta.EnsureSuccessStatusCode();
                return _respuesta.Content.ReadAsAsync<T>().Result;
            }
        }

        public HttpResponseMessage ExecuteDelete(string _metodo, int id)
        {
            using (var _client = new HttpClient() { BaseAddress = new Uri(APIUri) })
            {
                String _query = "";
                _query = String.Concat(_metodo, @"/", id.ToString());
                var _respuesta = _client.DeleteAsync(_query).Result;
                _respuesta.EnsureSuccessStatusCode();
                return _respuesta;
            }
        }

    }
}