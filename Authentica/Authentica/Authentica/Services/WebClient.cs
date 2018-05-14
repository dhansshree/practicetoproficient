using Authentica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Authentica.Services
{
    public static class WebService
    {
        // All of this can be merged
        // There is no need to instantiate http client every time
        
        public static async Task<Result<T>> GetData<T>(string path)
        {
            Result<T> result = new Result<T>();
            try
            {
                using (var client = new HttpClient()) // Should be called only once
                {
                    client.BaseAddress = new Uri("http://interviewapi20170221095727.azurewebsites.net");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", "authentica", "@uth3nt1c@"))));


                    List<T> enrollments = null;
                    HttpResponseMessage response = await client.GetAsync(path);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        enrollments = await response.Content.ReadAsAsync<List<T>>();
                        result.Status = response.StatusCode;
                        result.resultList = enrollments;
                    }
                    return result;
                }
            }
            catch(Exception ex)
            {
                result.Status = System.Net.HttpStatusCode.InternalServerError;
                result.error = ex.InnerException.ToString();
            }
            return result;
            
        }

     


    }

   
}