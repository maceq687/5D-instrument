mergeInto(LibraryManager.library, {

  SetVar: function () {
    this.context = new (window.AudioContext || window.webkitAudioContext)();
    this.oscillator1 = this.context.createOscillator();
    this.gainNode = this.context.createGain();
  },

  Init: function () {
    this.oscillator1.connect(this.gainNode);
    this.gainNode.connect(this.context.destination);

    this.oscillator1.start();
    this.gainNode.gain.setValueAtTime(0.0, this.context.currentTime);
  },
  
  Play: function () {
    this.gainNode.gain.setValueAtTime(0.25, this.context.currentTime);
  }

});