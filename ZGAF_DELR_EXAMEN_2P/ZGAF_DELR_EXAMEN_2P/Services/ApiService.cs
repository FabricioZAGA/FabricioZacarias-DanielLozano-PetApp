using ZGAF_DELR_EXAMEN_2P.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ZGAF_DELR_EXAMEN_2P.Services
{
    public class ApiService
    {
        private string ApiUrl = "https://maps.googleapis.com/maps/api/geocode/json?key=AIzaSyAIy5kA5LG5PYgU5TgpcZXaepb8xe_WPRU&address=";

        public async Task<ApiResponse> GetDataAsync<T>(string direction)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiUrl + direction)
                };
                var response = await client.GetAsync("");
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                var data = JsonConvert.DeserializeObject<T>(result);
                return new ApiResponse
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = data
                };
            }
            catch (System.Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null
                };
            }
        }

    }
}
