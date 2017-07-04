/**
 * Created by Marty on 7/3/2017.
 */
"use strict"
function getAudioContext(){
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
