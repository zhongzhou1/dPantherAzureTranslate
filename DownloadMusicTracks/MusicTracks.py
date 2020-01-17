import youtube_dl
import pafy

# Download the Pluralsight 'we are one' video
# url of video
url = "https://www.youtube.com/watch?v=TgRwoBgPM0o"
# create video object
video = pafy.new(url)
audiostreams = video.audiostreams
for a in audiostreams:
    a.download()
