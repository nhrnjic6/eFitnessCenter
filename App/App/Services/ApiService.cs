using Flurl;
using Flurl.Http;
using Models.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.Services
{
    public class ApiService
    {
        private readonly string _baseUrl = "http://192.168.1.5:45455/api";
        private readonly string _resource;
        private readonly string _token;

        public ApiService(string resource, string token)
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

        public async Task<T> GetById<T>(int id)
        {
            var url = $"{_baseUrl}/{_resource}/{id}";
            
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
            catch (FlurlHttpException e)
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Doslo je do greske pri vasoj akciji", "OK");
                throw;
            }
        }

        public async Task Update<T>(int id, object createRequest)
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
                await Application.Current.MainPage.DisplayAlert("Greska", "Doslo je do greske pri vasoj akciji", "OK");
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
                await Application.Current.MainPage.DisplayAlert("Greska", "Doslo je do greske pri vasoj akciji", "OK");
                throw;
            }
        }
    }
}
