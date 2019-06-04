using Models.Requests.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using System.Windows.Forms;

namespace eFitnessCenterDesktop.Services
{
    public class TokenService
    {
        private readonly string baseUrl = "https://localhost:44330/api";

        public async Task<TokenResponse> GetToken (GetTokenPost getTokenPost) 
        {
            try
            {
                var url = $"{baseUrl}/token";
                return await url
                    .PostJsonAsync(getTokenPost)
                    .ReceiveJson<TokenResponse>();
            }catch(FlurlHttpException e)
            {
                return null;
            }   
        }
    }
}
