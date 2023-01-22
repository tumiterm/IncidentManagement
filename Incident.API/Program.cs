

using Incident.API;
using RestSharp;

var client = new RestClient("http://forekapi.dreamline-ict.co.za/authenticate/?Username=forekapi@forekinstitute.co.za&Password=api.P@ssw0rd");

var request = new RestRequest();

var body = new User { Username = "forekapi@forekinstitute.co.za", Password = "api.P@ssw0rd" };

request.AddJsonBody(body);

var response = client.Post(request);

Console.WriteLine(response.ToString());
