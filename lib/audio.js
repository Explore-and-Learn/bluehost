/**
 * Created by Marty on 7/3/2017.
 */
"use strict"
function audioContextCheck(){
  if (typeof AudioContext !== "Undefined"){
    return new AudioContext();
  }
  else if( typeof webkitAudioContext !== "undefined"){
    return new webkitAudioContext();
  }
  else if(typeof mozAudioContext !== "undefined"){
    return new mozAudioContext();
  }
  return new Error("AudioContext not supported.")
}

var audioContext = audioContextCheck();

var osc = audioContext.createOscillator();
osc.connect(audioContext.destination);
osc.start(audioContext.currentTime);
