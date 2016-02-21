# Bohemian360
360* Viewer. Project was used in the #pulshackadays Hackathon
![Demo](https://raw.githubusercontent.com/EliasKotlyar/Bohemian360/master/doc/demo1.jpg)

### Prerequisite:
Convert some Videos to OGV-Format and the Audio to the OGG-Format
 
use the following commands to perform a conversion from to the desired Format:
 
	ffmpeg2theora --soft-target -V 2000 --two-pass --first-pass pass.pass --optimize --noaudio -x 640 -y 360 <filename>
	ffmpeg2theora --soft-target -V 2000 --two-pass --second-pass pass.pass --optimize --noaudio -x 640 -y 360 <filename>
	
Download and install Unity,and Android Studio(for Android support)

### Usage:


Put the converted Video Files into:
/Assets/StreamingAssets/video0.ogv
/Assets/StreamingAssets/video1.ogv
...
/Assets/StreamingAssets/video7.ogv

Put the converted Audio Files into:
/Assets/Resources/audio0.gov
/Assets/Resources/audio1.gov
...
/Assets/Resources/audio7.gov
	
Compile the Scene "Assets/movies.unity" and enjoy

### Runs on:
Android CardBoard,Windows,MacOs(all tested and verified)

### Dependencys: 
This Project uses the Mobile Movie Texture 2.1.2 in the Demo Edition. Use following Link to get to the Demo/Full Version:
  http://forum.unity3d.com/threads/mobile-movie-texture.115885/
  Hint: The demo Version will place a watermark into the ViewField
  
  
###Developers:
    Korbinian
    Jan
    Dennis
    Philipp
    Elias