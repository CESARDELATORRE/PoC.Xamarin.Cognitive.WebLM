using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Microsoft.ProjectOxford.Text.WebLM;

namespace PoC.Xamarin.Cognitive.WebLM
{
    public class App : Application
    {
        /// <summary>
        /// Initialzes a new instance of <see cref="LMServiceClient"/> class.
        /// </summary>
        //private static readonly LMServiceClient s_client = new LMServiceClient("34e53d6c483b423db9cb7ad7eb5e1f53");
        LMServiceClient m_client;

        public App()
        {
            //WebLM stuff
            m_client = new LMServiceClient("34e53d6c483b423db9cb7ad7eb5e1f53");
            /// Which model to use. Only title/anchor/query/body are currently supported.
            var model = "body";
            /// The Markov N-gram order to use. If higher than the model's max order, the model's max order is used instead.
            var order = 5;
            /// The maximum number of results to be returned by next word generation and word breaking. The limit is 1000.
            var maxNumCandidates = 5;

            /// Get available models.
            var modelsResponse = m_client.ListAvailableModelsAsync().GetAwaiter().GetResult();

            //foreach (var modelsResult in modelsResponse.Models)
            //{
            //    //Console.WriteLine("Models:  Name={0}  MaxOrder={1}", modelsResult.Name, modelsResult.MaxOrder);
            //}

            string modelNumberThreeName = "Nothing yet";

            modelNumberThreeName = modelsResponse.Models[3].Name;

            // **** UI stuff ****
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Let's test Microsoft Cognitive Services WebLM! - Model 1: " + modelNumberThreeName
                        }
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
