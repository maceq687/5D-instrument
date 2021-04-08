mergeInto(LibraryManager.library, {

  SetVariables: function () {
    // set global variables and initial values
    this.tempoBPM = 90; // set tempo in BPM
    this.rootMidiNote = 60; // set root note (MIDI number)
    this.sequence = [3, 4, 2, 0, 9, 6, 5, 6, 4, 3, 1, 0, 6 , 6, 4, 2];
    this.hasChange = false;
    this.step = 0;
    this.glide = 0.01;
    this.pitchMidi = 60;
    this.attack = 0.5;
    this.decay = 0.5;
    this.gateWidth = 10;

    // create audio building blocks
    this.context = new (window.AudioContext || window.webkitAudioContext)();
    this.oscillator1 = this.context.createOscillator();
    this.kick = this.context.createOscillator();
    this.gainNode = this.context.createGain();
    this.gainKick = this.context.createGain();

    // connect audio building blocks
    this.oscillator1.connect(this.gainNode);
    this.gainNode.connect(this.context.destination);
    this.kick.connect(this.gainKick);
    this.gainKick.connect(this.context.destination);

    // initiate parameters for audio building blocks
    this.oscillator1.start();
    this.kick.start();
    this.oscillator1.type = 'triangle';
    this.gainNode.gain.setValueAtTime(0.0, this.context.currentTime);
    this.gainKick.gain.setValueAtTime(0.0, this.context.currentTime);
  },
  
  PlayAudio: function () {
    this.context.resume();
    this.tempoMS = 60000 / this.tempoBPM / 4;
    this.trigger = setInterval(_SetPitch, this.tempoMS);
  },

  StopAudio: function () {
    clearInterval(this.trigger);
    // this.gainNode.gain.setValueAtTime(0.0, this.context.currentTime);
  },

  SetPitch: function () {
    if (!this.hasChange) { this.pitchMidi = this.sequence[0] + this.rootMidiNote; }
    this.oscillator1.frequency.exponentialRampToValueAtTime(_ToFrequency(this.pitchMidi), this.context.currentTime + this.glide);
    this.gainNode.gain.exponentialRampToValueAtTime(0.5,
      this.context.currentTime + Math.max(this.gateWidth * this.attack / 1000, 0.01));
    this.gainNode.gain.exponentialRampToValueAtTime(0.0001,
      this.context.currentTime + Math.max(this.gateWidth * this.attack / 1000, 0.01) + Math.max(this.gateWidth * this.decay / 1000, 0.01));
    this.sequence.push(this.pitchMidi - this.rootMidiNote);
    this.sequence.shift();
    this.hasChange = false;
    _StepCount();
  },

  ToFrequency: function (midiNote) {
    return Math.pow(2, (midiNote - 69) / 12) * 440;
  },

  StepCount: function () {
    this.step++;
    if (this.step === 1) { _PlayKick(); }
    if (this.step === 4) { this.step = 0; }
  },

  PlayKick: function() {
    this.gainKick.gain.exponentialRampToValueAtTime(0.3, this.context.currentTime + 0.02);
    this.kick.frequency.linearRampToValueAtTime(110, this.context.currentTime + 0.02);
    this.gainKick.gain.exponentialRampToValueAtTime(0.0001, this.context.currentTime + 0.05);
    this.kick.frequency.linearRampToValueAtTime(55, this.context.currentTime + 0.05);
  },

  SetParamA: function (paramA) {
    this.glide = paramA / 127 * this.tempoMS / 1000;
    if (isNaN(this.glide)) { this.glide = 0.01; }
  },

  SetParamB: function (paramB) {
    this.hasChange = true;
    var value = Math.round(paramB / 12.7);
    switch (value) {
      case 0:
        value = this.rootMidiNote;
        break;
      case 1:
        value = this.rootMidiNote + 2;
        break;
      case 2:
        value = this.rootMidiNote + 4;
        break;
      case 3:
        value = this.rootMidiNote + 7;
        break;
      case 4:
        value = this.rootMidiNote + 9;
        break;
      case 5:
        value = this.rootMidiNote + 12;
        break;
      case 6:
        value = this.rootMidiNote + 14;
        break;
      case 7:
        value = this.rootMidiNote + 16;
        break;
      case 8:
        value = this.rootMidiNote + 19;
        break;
      case 9:
        value = this.rootMidiNote + 21;
        break;
      case 10:
        value = this.rootMidiNote + 24;
        break;
      default:
        value = 5;
        break;
    }
    this.pitchMidi = value;
  },

  SetParamC: function (paramC) {
    this.attack = paramC / 127 * 0.8 + 0.1;
    this.decay = (1 - (paramC / 127)) * 0.8 + 0.1;
  },

  SetParamD: function (paramD) {
    this.gateWidth = (paramD / 127) * 0.8 * this.tempoMS + this.tempoMS * 0.1;
  },

  SetParamE: function (paramE) {},

  SetParamF: function (paramF) {},

  SetParamG: function (paramG) {},

  SetParamH: function (paramH) {},

  SetParamI: function (paramI) {},

  SetParamJ: function (paramJ) {},

  MouseWithin: function (mouseWithin) {
    // console.log('Mouse is inside window: ', mouseWithin);
  },

});