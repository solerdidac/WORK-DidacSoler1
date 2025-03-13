// Funciones para audios

function seekAudio(audioId, seconds) {
  const audioElement = document.getElementById(audioId);
  audioElement.currentTime = Math.min(Math.max(0, audioElement.currentTime + seconds), audioElement.duration);
}

function changeSpeed(audioId, amount) {
  const audioElement = document.getElementById(audioId);
  audioElement.playbackRate = Math.max(0.1, audioElement.playbackRate + amount);
}

document.addEventListener('play', function(e) {
  const audios = document.getElementsByTagName('audio');
  for (let i = 0; i < audios.length; i++) {
    if (audios[i] !== e.target) {
      audios[i].pause();
    }
  }
}, true);
