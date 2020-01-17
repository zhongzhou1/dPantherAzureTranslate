<!--
*** Thanks for checking out this README Template. If you have a suggestion that would
*** make this better, please fork the repo and create a pull request or simply open
*** an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
***
***
***
*** To avoid retyping too much info. Do a search and replace for the following:
*** github_username, repo, twitter_handle, email
-->





<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  

  <h3 align="center">FIU Library</h3>

  <p align="center">
    FIU Digital Collecion Center
    <br />
    <a href="https://github.com/zhongzhou1/dPantherAzureTranslate"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    ·
    <a href="https://github.com/zhongzhou1/dPantherAzureTranslate/issues">Report Bug</a>
    ·
    <a href="https://github.com/zhongzhou1/dPantherAzureTranslate/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Contributing](#contributing)
* [License](#license)
* [Contact](#contact)
* [Acknowledgements](#acknowledgements)



<!-- ABOUT THE PROJECT -->
## About The Project


The Florida International University (FIU) Libraries led the testing and exploration of translation and transcription functionality into the open source digital repository systems, dPanther and dLOC. Upon embarking on this project in 2018, the intended outcome was increased access to digital collections materials written or spoken in English for non-English speaking patrons and vice-versa for content written or spoken in other languages, as well as providing additional measures of access for individuals with visual or hearing impairments.


### Built With

* [Microsoft Visual Studio 2019](https://visualstudio.microsoft.com//vs/)
* [PyCharm](https://www.jetbrains.com/pycharm/download/#section=windows)




<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.
1. Creat an Azure Speech Resource to get your subscription key and region.
2. Creat an Azure Translator Text API to get subscription key.
3. Open Visual Studio 2019, install Speech SDK, Newtonsoft.Json and RestSharp to run speechfinaltest of this project.
4. Open PyCharm, install youtube_dl and pafy to run DownloadMusicTracks of this project.

### Prerequisites

1. Creat an Azure Speech Resource to get your subscription key and region.
2. Download Visual Studio 2019.
3. Colne this project and choose Debug to get new with x64 active solution platform to run .
4. Dowmload PyCharm. 
### Installation

#### Visual Studio 2019
1. In the Solituon Explorer of Visual Studio 2019, right-click the project, and select Manage Nuget Packages.
2. In the upper-right corner, find the Package Source drop-down box, and make sure that nuget.org is selected.
3. In the upper-left corner, select Browse.
4. In the search box, type Microsoft.CognitiveServices.Speech and select Enter.
5. From the search results, select the Microsoft.CognitiveServices.Speech package, and then select Install to install the latest stable version.
6. Accept all agreements and licenses to start the installation.
7. In the search box, type Newtonsoft.Json to install the latest stable version.
8. In the search box, type RestSharp to install the latest stable version.
9. From the menu bar, select Build > Configuration Manager. 
10. In the Active solution platform frop-down box, select New. 
11. In the Type or select the new platform frop-down box:  *If you are runing 64-bit Windows, select x64.  *If you are running 32-bit Windows, select x86

#### PyCharm  
1. At the upper-left corner of PyCharm, click "file" and choose “settings”.
2. Choose project and click "Project Interpreter".
3. In the upper-right corner of PyCharm, select "+".
4. Search youtube_dl and pafy and click "Install Package" button to install.



<!-- USAGE EXAMPLES -->
## Usage
### speechfinaltest
You can find all codes at **Program.cs** class, run it in the Visual Studio 2019

1. Open Visual Studio 2019 and clone this project. Find **Program.cs** file then replace the 2 string YourSubscriptionKey with your subscription key and 2 string YourServiceRegion with the region associated of Speech Resource.
![Keyregion](https://github.com/zhongzhou1/dPantherAzureTranslate/blob/master/Pictures/Keyregion.png)
![keyregion1](https://github.com/zhongzhou1/dPantherAzureTranslate/blob/master/Pictures/Keyregion1.png)

2. Replace the string YourSubscriptionKey with your subscription key of Translator Text API in the **Program.cs**. 
![key](https://github.com/zhongzhou1/dPantherAzureTranslate/blob/master/Pictures/key.png)

3. Replace all path of input and output, you can find codes in the **Program.cs**.
<br>Change audio file input path at line 57 **using (var audioInput = AudioConfig.FromWavFileInput(@"Path.wav"))**).<br>
<br>Change text file output path at line 124 **string path1= @"path" + strfilename;**.<br>
<br>Change converted audio file ouput path at line 158 **var fileName = @"path" + "name" + ".wav";**.<br>


4. Start the project, the audio file will sent to the Speech service, then you can see in the console.
![recognized](https://github.com/zhongzhou1/dPantherAzureTranslate/blob/master/Pictures/recognized.png)

5. At next step, you can see the translate results with your target language in the console.
![speechtotext](https://github.com/zhongzhou1/dPantherAzureTranslate/blob/master/Pictures/speechtotext.png)

6. At the end, you can see the text is converted to speech, and saved in the audio file specified.
![texttospeech](https://github.com/zhongzhou1/dPantherAzureTranslate/blob/master/Pictures/texttospeech.png)

In this project, we used **RecognizeOnceAsync()** method to start speech recognition, this method returns only a single utterance, please use **StartContinuousRecognitionAsync()** method for long-running multi-utterance recognition.

### textFinalTest
You can find all codes in the **translatorAPIs.html**

1. Replace the string key at line32 **"Ocp-Apim-Subscription-Key": "key"** with Azure Translator Text API key.
2. Open .html file, then you can input text and select target language then click translate button to translate.

In this case we use "English","Chinese","Spanish" as default translate languages, you can also find more language support for Translator Text API: https://docs.microsoft.com/en-us/azure/cognitive-services/Translator/language-support

### DownloadMusicTracks
You can find codes in the **MusicTracks.py**, run it in the PyCharm.
1. Double click Pycharm, and click "File" at upper-left corner of Pyharm.
2. Click "open" button to open **MusicTracks.py**.

In this case, we used youtube_dl tool to download, you can find supported sites: https://ytdl-org.github.io/youtube-dl/supportedsites.html







<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


  
<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

Zhongzhou Li  - zli049@fiu.edu
Project Link: [https://github.com/zhongzhou1](https://github.com/zhongzhou1)

Boyuan Guan  - bguan@fiu.edu
Project Link: [https://github.com/Keven1894](https://github.com/Keven1894)
<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

This project has been made possible through the generous support of the Society of American Archivists (SAA) Foundation 2018-2019 Strategic Growth Grant award.





<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/zhongzhou1/dPantherAzureTranslate
[contributors-url]: https://github.com/zhongzhou1/dPantherAzureTranslate/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/zhongzhou1/dPantherAzureTranslate?label=Fork&style=flat-square
[forks-url]: https://github.com/zhongzhou1/dPantherAzureTranslate/network/members
[stars-shield]: https://img.shields.io/github/stars/zhongzhou1/dPantherAzureTranslate
[stars-url]: https://github.com/zhongzhou1/dPantherAzureTranslate/stargazers
[issues-shield]: https://img.shields.io/github/issues/zhongzhou1/dPantherAzureTranslate
[issues-url]: https://github.com/zhongzhou1/dPantherAzureTranslate/issues
[license-shield]: https://img.shields.io/github/license/zhongzhou1/dPantherAzureTranslate
[license-url]: https://github.com/othneildrew/Best-README-Template/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/zhongzhou-li-159625162 
[product-screenshot]: images/screenshot.png
