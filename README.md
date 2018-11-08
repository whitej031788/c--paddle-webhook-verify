# C# Paddle Webhook Verification

This project is a simple example of verifying Paddle webhooks using C# in an ASP.NET application. The framework is basically an empty "Web API" MVC project in Visual Studio, with a route added to consume a Paddle webhook. The main files and dependancies for this solution are:

  - **Bouncy Castle API**
  -- The [Bouncy Castle API](https://www.bouncycastle.org) is a crypto library we use to do RSA signature verification. It can be downloaded via nuget, or directly from their site and added as a reference in your project.
  - **Controllers/PaddleWebhookController.cs**
  -- This is the controller for the route that accepts the Paddle Webhook, and the main verification code is here, namely _PaddleWebhookVerify_ and _VerifySignature_
  - **Models/PaddleWebhook.cs**
  -- This is a Model for a Paddle Webhook, containing all possible properties for any Paddle webhook. You can work with the dynamic POST content too if preferred.
  - **Models/PhpSerializer.cs**
  -- A helper class for serializing a data object the way that PHP does, as this is how Paddle signs the data. Should be able to be used 'as is'.

# Disclaimer
This is meant more to be an example, and it not directly supported by the Paddle team. This "empty" MVC Web API project currently successfully validates a Paddle webhook on .NET Framework V4.6.1.