# C# Paddle Webhook Verification

This project is a simple example of verifying Paddle webhooks using C# in an ASP.NET application. The framework is basically an empty "Web API" MVC project in Visual Studio, with a route added to consume a Paddle webhook. The main files and dependancies for this solution are:

  - **Bouncy Castle API**
  -- The [Bouncy Castle API](https://www.bouncycastle.org) is a crypto library we use to do RSA signature verification. It can be downloaded via nuget, or directly from their site and added as a reference in your project.
  - **Controllers/PaddleWebhookController.cs**
  -- This is the controller for the route that accepts the Paddle Webhook, and the main verification code is here, namely _PaddleWebhookVerify_ and _VerifySignature_
  - **Models/PhpSerializer.cs**
  -- A helper class for serializing a data object the way that PHP does, as this is how Paddle signs the data. Should be able to be used 'as is'.
  
# Usage and support
This code is provided as an example MVC Web API project currently successfully validates a Paddle webhook on .NET Framework V4.6.1. 

This code example is not provided by nor supported by Paddle, and Paddle does not provide technical support or maintenance for this code or any derivations of it.
