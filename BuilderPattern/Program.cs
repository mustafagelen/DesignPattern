
var eb = new DesignPattern.BuilderPattern.EndpointBuilder("http://localhost:3000/");

eb.Append("api")
  .Append("v1")
  .Append("user")
  .AppendParam("id", "5")
  .AppendParam("status", "admin");

var url = eb.Build();

Console.WriteLine("Final URL :" + url);

