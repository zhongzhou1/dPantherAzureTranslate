using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

/// <summary>
/// This project was created by using Microsofte Speechservice and Translator API to get output audio file with target language
/// By Zhongzhou, Keven, 12/27/2019
/// </summary>

namespace Dpanther_Translate
{
    class Program
    {
        private static string strfilename;

        public static async Task Main()
        {
            while (true)
            {

                //start recognizing the audio from the audio in the folder
                string txtAudio = await RecognizeSpeechAsync();

                //tranlate the recognized text into spanish
                string translatedTextPath = await Translate(txtAudio, "es");

                //convert translated language into audio and save into an assigned path
                string audioPath = await SynthesisToAudioFileAsync(translatedTextPath);

                //write the file path to the console
                Console.WriteLine(audioPath);

                return;
            }
        }

        /// <summary>
        /// Task to recognize speech from an audio file with Microsoft Speech service
        /// By Zhongzhou, Keven, 12/27/2019
        /// </summary>
        /// <returns></returns>

        public static async Task<string> RecognizeSpeechAsync()
        {

            string strReturn = "";
            //Insert subscription key and subscription region 
            var config = SpeechConfig.FromSubscription("YourSubscriptionKey", "YourServiceRegion");

            //Input an audio file with farmat WAV

            using (var audioInput = AudioConfig.FromWavFileInput(@"Path.wav"))
            {

                //Waiting Speech service to recognize speech from input audio  
                using (var recognizer = new SpeechRecognizer(config, audioInput))
                {
                    Console.WriteLine("Recognizing first result...");

                    //To let the Speech service know a single phrase for recognition.
                    var result = await recognizer.RecognizeOnceAsync();

                    //Make sure your audio file was recognized when regonize result is returned
                    if (result.Reason == ResultReason.RecognizedSpeech)
                    {
                        Console.WriteLine($"We recognized: {result.Text}");
                        strReturn = result.Text;
                    }
                    else if (result.Reason == ResultReason.NoMatch)
                    {
                        Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = CancellationDetails.FromResult(result);
                        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                            Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                            Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }
                    }
                }
            }

            return strReturn;
        }

        /// <summary>
        /// Task to Translate two texts to any support languate in Cognitive Service
        /// By Zhongzhou, Keven, 12/27/2019
        /// </summary>
        /// <param name="text"><string> text to be translated</param>
        /// <param name="language"><string> target language</param>
        /// <returns>the path of generated file</returns>
        public static async Task<string> Translate(string text, string language)
        {
            var encodedText = WebUtility.UrlEncode(text);
 
            {
                //add the text string from the convertion of the aduio
                string txtAudio = encodedText; 

                //Post request API with target language
                var client = new RestClient("https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&to=es");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Ocp-Apim-Subscription-Key", "key");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "[{'Text':'" + txtAudio + "'}]", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                var result = JsonConvert.DeserializeObject(response.Content);
                
                //save returned json to .txt file with default name
                strfilename = "Name"  + ".txt";
                string path1= @"path" + strfilename;
                Object obj = new Object();
                obj = result;
                string sr = ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)result).First).Last).Last).Last).First).First).Value.ToString();
                sr = WebUtility.UrlDecode(sr);
                System.IO.File.WriteAllText(path1, sr);

                //******** This line demonstrate the way to get the the actual translate text;
                //return ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)result).First).Last).Last).Last).First).First).Value.ToString();
                return path1;
            }


            
        }

        /// <summary>
        /// Task to Synthesize speech into an audio file with Microsoft Speech service
        /// By Zhongzhou, Keven, 12/27/2019
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public static async Task<string> SynthesisToAudioFileAsync(string strPath)
        {
            string strReturn = "";

            //Insert subscription key and subscription region 
            var config = SpeechConfig.FromSubscription("YourSubscriptionKey", "YourServiceRegion");

            //Set Sets property values that will be passed to service using the specified channel.
            config.SetProperty("SpeechSynthesisLanguage", "es-MX");
            config.SetProperty("SpeechSynthesisVoiceName", "es-MX-HildaRUS");
            config.SpeechSynthesisLanguage = "es-MX";
            config.SpeechSynthesisVoiceName = "es-MX-HildaRUS";
            var fileName = @"path" + "name" + ".wav";

            //Using Speech SDK to convert text to synthesized speech in an audio file
            using (var fileOutput = AudioConfig.FromWavFileOutput(fileName))
            {
               
                using (var synthesizer = new SpeechSynthesizer(config, fileOutput))
                {

                    //Sends your text to the Speech service which converts it to audio. 
                    StreamReader sr1 = new StreamReader(strPath);
                    var text1 = sr1.ReadToEnd();
                    var result1 = await synthesizer.SpeakTextAsync(text1);

                    //To make sure text was successfully synthesized when the synthesis result is returned.
                    if (result1.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        Console.WriteLine($"Speech synthesized to [{fileName}] for text [{text1}]");
                        strReturn = fileName;
                    }
                    else if (result1.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result1);
                        Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                            Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                            Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }


                    }




                }
            }

            return strReturn;
        }
    }
}







