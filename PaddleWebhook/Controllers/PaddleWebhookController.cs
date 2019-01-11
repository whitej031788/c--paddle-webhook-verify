// Crypto library for RSA key signature verification
// https://www.nuget.org/packages/BouncyCastle
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using PaddleWebhook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace PaddleWebhook.Controllers
{
    public class PaddleWebhookController : Controller
    {
        [HttpPost]
        public JsonResult Index(PaddleWebhookModel content)
        {
            /* The PaddleWebhookVerify function below is the primary helper for the process
             * The 'content' should be the JSON POST object from the Paddle Webhook
             * 
             * The PaddleWebhookModel can be seen defined with all potential Paddle
             * properties for any webhook in Models/PaddleWebhook.cs
             * 
             * Instead of using the PaddleWebhook Model, you could also simply parse the Request.Form.AllKeys
             * which will look at the POST body independantly of a defined model. You can then construct 
             * your dictionary below based on that. We chose to use the model for structure's sake
             * 
             * *NOTE* If Paddle adds any properties to their webhooks, they must be added to the Model, otheriwse
             * verification will break
             * 
             * This can be tested via the Paddle webhook tester at
             * https://vendors.paddle.com/webhook-alert-test
             * and making one of your RouteConfig's point to this controller
            */
            return Json(new { webhook_verified = PaddleWebhookVerify(content) });
        }
        
        private bool PaddleWebhookVerify(PaddleWebhookModel content)
        {
            SortedDictionary<string, dynamic> padStuff = new SortedDictionary<string, dynamic>();
            PhpSerializer serializer = new PhpSerializer();
            byte[] signature = Convert.FromBase64String(content.p_signature);
            // 'pad_pub_key.pem' should be a file containing only your Paddle Public Key
            // from Vendor Settings / Public Key, including the starting and ending lines
            // -----BEGIN PUBLIC KEY-----
            // MIICIjANBgkqhk...................
            // -----END PUBLIC KEY-----
            string publicKey = System.IO.File.ReadAllText(Server.MapPath("~/pad_pub_key.pem"));
            // Now fill up SortedDictionary with any properties excluding p_signature
            foreach (PropertyInfo prop in content.GetType().GetProperties())
            {
                var myVal = content.GetType().GetProperty(prop.Name).GetValue(content);
                if (myVal != null && prop.Name != "p_signature")
                {
                    padStuff.Add(prop.Name, myVal);
                }
            }

            string payload = serializer.Serialize(padStuff);

            return verifySignature(signature, payload, publicKey);
        }

        private bool verifySignature(byte[] signatureBytes, string message, string pubKey)
        {
            StringReader newStringReader = new StringReader(pubKey);
            AsymmetricKeyParameter publicKey = (AsymmetricKeyParameter)new PemReader(newStringReader).ReadObject();
            ISigner sig = SignerUtilities.GetSigner("SHA1withRSA");
            sig.Init(false, publicKey);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            sig.BlockUpdate(messageBytes, 0, messageBytes.Length);
            return sig.VerifySignature(signatureBytes);
        }
    }
}