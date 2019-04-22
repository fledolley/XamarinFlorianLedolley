
using System;
using System.Collections.Generic;
using System.Text;
using fourplaceproject.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using MonkeyCache.SQLite;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace fourplaceproject
{
    public static class Service 
    {
        static HttpClient httpClient;
        
        public static async Task<bool> TryRefresh()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = new Uri(string.Format(App.URI_API + App.REFRESH, string.Empty));
                string token = Barrel.Current.Get<LoginResult>("Login").RefreshToken;
                RefreshRequest refreshRequest = new RefreshRequest(token);
                string data = JsonConvert.SerializeObject(refreshRequest);
                var content = new StringContent(data, Encoding.UTF8, "application.json");
                var response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var resultat =await response.Content.ReadAsStringAsync();
                    Response<LoginResult> loginResult = JsonConvert.DeserializeObject<Response<LoginResult>>(resultat);
                    int temps = loginResult.Data.ExpiresIn;
                    Barrel.Current.Add(key: "Login", data: loginResult.Data, expireIn: TimeSpan.FromSeconds(temps));
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception e)
            {
                return false;
            }
        }
        public static async Task<bool> TryLogin(string mail, string  mdp)
        {
            if (!Barrel.Current.IsExpired(key:"Login"))
            {
                Console.WriteLine("TRYREFRESH");
                if(await TryRefresh())
                {
                    return true;

                }

            }
            httpClient = new HttpClient();
            var uri = new Uri(string.Format(App.URI_API + App.LOGIN, string.Empty));
            LoginRequest loginRequest = new LoginRequest(mail,mdp);
            string data = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            try
            {
                var response = await httpClient.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var resultat = await response.Content.ReadAsStringAsync();
                    Response<LoginResult> loginResult = JsonConvert.DeserializeObject<Response<LoginResult>>(resultat);
                    Barrel.Current.Add(key: "Login", data: loginResult.Data, expireIn: TimeSpan.FromDays(1));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public static async Task<bool> Register(string email, string firstname, string lastname, string password)
        {
            httpClient = new HttpClient();
            RegisterRequest registerRequest = new RegisterRequest(email, firstname, lastname, password);
            string req = JsonConvert.SerializeObject(registerRequest);
            var uri = new Uri(string.Format(App.URI_API + App.REGISTER, string.Empty));
            var content = new StringContent(req, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    Response<LoginResult> res = JsonConvert.DeserializeObject<Response<LoginResult>>(contentResponse);
                    int temps = res.Data.ExpiresIn;
                    Barrel.Current.Add(key: "Login", data: res.Data, expireIn: TimeSpan.FromDays(temps));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        


        public static async Task<bool> GetMe()
        {
            try
            {
                httpClient = new HttpClient();
                var uri = new Uri(string.Format(App.URI_API + App.ME, string.Empty));
                var authHeader = new AuthenticationHeaderValue("Bearer", Barrel.Current.Get<LoginResult>("Login").AccessToken);
                
                httpClient.DefaultRequestHeaders.Authorization = authHeader;
                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Response<UserItem> res = JsonConvert.DeserializeObject<Response<UserItem>>(content);
                    Barrel.Current.Add(key: "Me",data: res.Data, expireIn: TimeSpan.FromHours(12));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public static async Task PatchMe()
        {
            

        }

        public static async Task<bool> ChangePassword(string old, string psw)
        {
            try
            {
                httpClient = new HttpClient();
                var uri = new Uri(string.Format(App.URI_API + App.PASSWORD, string.Empty));
                var authHeader = new AuthenticationHeaderValue("Bearer", Barrel.Current.Get<LoginResult>("Login").AccessToken);
                UpdatePasswordRequest updatePasswordRequest = new UpdatePasswordRequest(old,psw);
                httpClient.DefaultRequestHeaders.Authorization = authHeader;
                string req = JsonConvert.SerializeObject(updatePasswordRequest);
                var content = new StringContent(req, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch(Exception e)
            {
                return false;
            }
            

        }
        public static async Task LoadImage()
        {

        }
        public static async Task GetImage(int? id)
        {

        }
        public static async Task<ListeLieux> GetPlaces()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet && !Barrel.Current.IsExpired(key: "ListeLieux"))
            {
                return Barrel.Current.Get<ListeLieux>(key: "ListeLieux");
            }
            try
            {
                httpClient = new HttpClient();
                var uri = new Uri(string.Format(App.URI_API + App.PLACES, string.Empty));
                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Response<List<PlaceItemSummary>> res = JsonConvert.DeserializeObject<Response<List<PlaceItemSummary>>>(content);
                    Barrel.Current.Add(key: "ListeLieux", data: new ListeLieux(res.Data), expireIn: TimeSpan.FromDays(1));
                    return new ListeLieux(res.Data);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        public static async Task PostPlace()
        {
           

        }
        public static async Task<PlaceItem> GetPlaceId(int id)
        {
            try
            {
                httpClient = new HttpClient();
                var uri = new Uri(string.Format(App.URI_API + App.PLACES+"/"+id, string.Empty));
                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Response<PlaceItem> res = JsonConvert.DeserializeObject<Response<PlaceItem>>(content);
                    return res.Data;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;

        }
        public static async Task PostComment(string comment,int placeId)
        {
            try
            {
                httpClient = new HttpClient();
                var uri = new Uri(string.Format(App.URI_API+App.PLACES+"/"+placeId+App.COMMENTS, string.Empty));
                var authHeader = new AuthenticationHeaderValue("Bearer", Barrel.Current.Get<LoginResult>("Login").AccessToken);
                httpClient.DefaultRequestHeaders.Authorization = authHeader;
                CreateCommentRequest createCommentRequest = new CreateCommentRequest(comment);
                string req = JsonConvert.SerializeObject(createCommentRequest);
                var content = new StringContent(req, Encoding.UTF8, "application/json");
                var response =await httpClient.PostAsync(uri, content);
                Console.WriteLine("Avant Comment");
                if (response.IsSuccessStatusCode)
                {
                    
                    var resultat = await response.Content.ReadAsStringAsync();

                }

            }
            catch(Exception e)
            {
                Console.WriteLine("ECHEC");

            }
            
        }

        public static async  Task<MediaFile> ChoosePicture()
        {
            await CrossMedia.Current.Initialize();
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
                return photo;
            }
            return null;
        }

        public static async Task TakePicture()
        {

        }
        

    }
}
