using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;
using Models.Extenstions;
using Models.Requests;

namespace eFitnessCenterDesktop.Services
{
    public class ApiService
    {
        private readonly string _baseUrl = "https://localhost:44330/api";
        private readonly string _resource;
        private readonly string _token;

        public ApiService (string resource, string token)
        {
            _resource = resource;
            _token = token;
        }

        public async Task<T> GetAll<T>(IQueryParams queryParams)
        {
            var url = $"{_baseUrl}/{_resource}";
            url += queryParams?.ToQueryParams();
            return await url
                .WithHeader("Authorization", _token)
                .GetJsonAsync<T>();
        }

        public async Task<T> Create<T>(object createRequest)
        {
            var url = $"{_baseUrl}/{_resource}";

            try
            {
                return await url
                    .WithHeader("Authorization", _token)
                    .PostJsonAsync(createRequest)
                    .ReceiveJson<T>();
            }
            catch (Exception)
            {
                MessageBox.Show("Doslo je do greske prilikom vaseg zathjeva.");
                throw;
            }
        }

        public async Task Update<T>(int id ,object createRequest)
        {
            var url = $"{_baseUrl}/{_resource}";

            try
            {
                 await url
                    .AppendPathSegment(id)
                    .WithHeader("Authorization", _token)
                    .PutJsonAsync(createRequest);
            }
            catch (Exception)
            {
                MessageBox.Show("Doslo je do greske prilikom vaseg zathjeva.");
                throw;
            }
        }

        public async Task Delete(int id)
        {
            var url = $"{_baseUrl}/{_resource}";

            try
            {
                await url
                   .AppendPathSegment(id)
                   .WithHeader("Authorization", _token)
                   .DeleteAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Doslo je do greske prilikom vaseg zathjeva.");
                throw;
            }
        }
    }
}
