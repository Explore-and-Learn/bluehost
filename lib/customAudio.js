
var audioContext = getAudioContext();

var audioBuffer;

var getSound = new XMLHttpRequest();

getSound.open("get", "sounds/snore.mp3", true);
getSound.responseType = "arraybuffer";

getSound.onload = function(){
    audioContext.decodeAudioData(getSound.response, function(buffer){
        audioBuffer = buffer;
    });
};

getSound.send();

window.addEventListener("mousedown", playback);


function playback(){
    var playSound = audioContext.createBufferSource();
    playSound.buffer = audioBuffer;
    playSound.connect(audioContext.destination);
    playSound.start(audioContext.currentTime);
}
