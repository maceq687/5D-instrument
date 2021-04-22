mergeInto(LibraryManager.library, {

  SetVariables: function () {
    // set global variables and initial values
    this.playing = 0;
    this.tempoBPM = 90; // set tempo in BPM
    this.rootMidiNote = 60; // set root note (MIDI number)
    this.sequence = [3, 4, 2, 0, 9, 6, 5, 6, 4, 3, 1, 0];
    this.hasChange = false;
    this.step = 0;
    this.glide = 0.01;
    this.velocity = 0.5;
    this.pitchMidi = 60;
    this.attack = 0.1;
    this.decay = 0.9;
    this.gateWidth = 15;
    this.osc2tune = 0.5;

    // create audio building blocks
    this.context = new (window.AudioContext || window.webkitAudioContext)();
    this.oscillator1tri = this.context.createOscillator();
    this.oscillator1saw = this.context.createOscillator();
    this.oscillator2 = this.context.createOscillator();
    this.lfo = this.context.createOscillator();
    this.filter = this.context.createBiquadFilter();
    this.kick = this.context.createOscillator();
    this.delay = this.context.createDelay(1);
    this.distortion = this.context.createWaveShaper();
    this.gainOsc1tri = this.context.createGain();
    this.gainOsc1saw = this.context.createGain();
    this.gainOsc2 = this.context.createGain();
    this.gainNode = this.context.createGain();
    this.gainLfo = this.context.createGain();
    this.gainDel = this.context.createGain();
    this.gainKick = this.context.createGain();

    // connect audio building blocks
    this.oscillator1tri.connect(this.gainOsc1tri);
    this.oscillator1saw.connect(this.gainOsc1saw);
    this.oscillator2.connect(this.gainOsc2);
    this.lfo.connect(this.gainLfo);
    this.gainLfo.connect(this.filter.frequency);
    this.gainOsc1tri.connect(this.distortion);
    this.gainOsc1saw.connect(this.distortion);
    this.distortion.connect(this.filter);
    this.gainOsc2.connect(this.filter);
    this.filter.connect(this.gainNode);
    this.gainNode.connect(this.delay);
    this.gainNode.connect(this.context.destination);
    this.delay.connect(this.gainDel);
    this.gainDel.connect(this.delay); // feedback loop
    this.gainDel.connect(this.context.destination);
    this.kick.connect(this.gainKick);
    this.gainKick.connect(this.context.destination);

    // initiate parameters for audio building blocks
    this.oscillator1tri.start();
    this.oscillator1saw.start();
    this.oscillator2.start();
    this.lfo.start();
    this.kick.start();
    this.oscillator1tri.type = 'triangle';
    this.oscillator1saw.type = 'sawtooth';
    this.distortion.oversample = '4x';
    this.distortion.curve = _DistortionCurve(0);
    this.lfo.frequency.setValueAtTime(12, this.context.currentTime);
    this.filter.type = 'lowpass';
    this.filter.frequency.setValueAtTime(5000, this.context.currentTime);
    this.gainOsc1tri.gain.setValueAtTime(0.1, this.context.currentTime);
    this.gainOsc1saw.gain.setValueAtTime(0.0, this.context.currentTime);
    this.gainOsc2.gain.setValueAtTime(0.7, this.context.currentTime);
    this.gainNode.gain.setValueAtTime(0.0, this.context.currentTime);
    this.gainLfo.gain.setValueAtTime(1, this.context.currentTime);
    this.gainDel.gain.setValueAtTime(0.5, this.context.currentTime);
    this.gainKick.gain.setValueAtTime(0.0, this.context.currentTime);
  },
  
  PlayAudio: function () {
    playing = ++playing;

    if (playing === 1) {
      this.context.resume();
      this.tempoMS = 60000 / this.tempoBPM / 4;
      this.trigger = setInterval(_SetPitch, this.tempoMS);
    }
  },

  StopAudio: function () {
    clearInterval(this.trigger);
    // this.gainNode.gain.setValueAtTime(0.0, this.context.currentTime);
    this.playing = 0;
  },

  SetPitch: function () {
    if (!this.hasChange) { this.pitchMidi = this.sequence[0] + this.rootMidiNote; }
    this.oscillator1tri.frequency.exponentialRampToValueAtTime(_ToFrequency(this.pitchMidi), this.context.currentTime + this.glide);
    this.oscillator1saw.frequency.exponentialRampToValueAtTime(_ToFrequency(this.pitchMidi), this.context.currentTime + this.glide);
    this.oscillator2.frequency.exponentialRampToValueAtTime(_ToFrequency(this.pitchMidi + this.osc2tune), this.context.currentTime + this.glide);
    this.gainNode.gain.exponentialRampToValueAtTime(this.velocity,
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

  DistortionCurve: function (amount) {
    var k = typeof amount === 'number' ? amount : 50;
    var samples = 256;
    var curve = new Float32Array(samples);
    var i = 0;
    var x;
    for ( ; i < samples; ++i ) {
      x = i * 2 / samples - 1;
      curve[i] = (Math.PI + k) * x / (Math.PI + k * Math.abs(x) );
    }
    return curve;
  },

  ValueLimit: function (val, min, max) {
    return val < min ? min : (val > max ? max : val);
  },

  SetParamA: function (paramA) {
    paramA = _ValueLimit(paramA, 0, 127);
    // this.glide = paramA / 127 * this.tempoMS / 1000;
    // if (isNaN(this.glide)) { this.glide = 0.01; }
    this.velocity = paramA / 127 * 0.4 + 0.3;
  },

  SetParamB: function (paramB) {
    paramB = _ValueLimit(paramB, 0, 127);
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
    paramC = _ValueLimit(paramC, 0, 127);
    this.attack = paramC / 127 * 0.8 + 0.1;
    this.decay = (1 - (paramC / 127)) * 0.8 + 0.1;
  },

  SetParamD: function (paramD) {
    paramD = _ValueLimit(paramD, 0, 127);
    this.gateWidth = (paramD / 127) * 0.8 * this.tempoMS + this.tempoMS * 0.1;
  },

  SetParamE: function (paramE) {
    paramE = _ValueLimit(paramE, 0, 127);
    var value = paramE / 127;
    this.gainOsc1tri.gain.linearRampToValueAtTime(1 - value, this.context.currentTime + 0.3);
    this.gainOsc1saw.gain.linearRampToValueAtTime(value, this.context.currentTime + 0.3);
  },

  SetParamF: function (paramF) {
    paramF = _ValueLimit(paramF, 0, 127);
    var value = Math.round(paramF / 25.6);
    switch (value) {
      case 0:
        value = -24;
        break;
      case 1:
        value = -12;
        break;
      case 2:
        value = -5;
        break;
      case 3:
        value = 0.5;
        break;
      case 4:
        value = 7;
        break;
      case 5:
        value = 12;
        break;
      case 6:
        value = 24;
        break;
      default:
        value = 3;
        break;
    }
    this.osc2tune = value;
  },

  SetParamG: function (paramG) {
    paramG = _ValueLimit(paramG, 0, 127);
    var value = paramG / 127;
    value = value * value;
    value = value * -1 + 1;
    var mult = value * 1950 + 500;
    var sum = (value * -1 + 1) * 2450 + 2550;
    var q = value * 4;
    this.filter.frequency.setValueAtTime(sum, this.context.currentTime);
    this.gainLfo.gain.setValueAtTime(mult, this.context.currentTime);
    this.filter.Q.setValueAtTime(q, this.context.currentTime);
  },

  SetParamH: function (paramH) {
    paramH = _ValueLimit(paramH, 0, 127);
    var value = Math.round(paramH / 127 * 4);
    if ( value === 0) {
      value = 0.5;
    } else {
      value = value;
    }
    var lfoFreq = 1 / (this.tempoMS) * 1000 * value;
    this.lfo.frequency.setValueAtTime(lfoFreq, this.context.currentTime);
  },

  SetParamI: function (paramI) {
    paramI = _ValueLimit(paramI, 0, 127);
    var value = Math.round(paramI / 32);
    switch (value) {
      case 0:
        value = 0.1;
        break;
      case 1:
        value = 0.2;
        break;
      case 2:
        value = 0.33;
        break;
      case 3:
        value = 0.5;
        break;
      case 4:
        value = 0.66;
        break;
      default:
        value = 3;
        break;
    }
    value = value * this.tempoMS / 1000;
    this.delay.delayTime.setValueAtTime(value, this.context.currentTime);
    var gainAmt = (paramI / 127) * -1 + 1;
    gainAmt = gainAmt * 0.5 + 0.25;
    this.gainDel.gain.setValueAtTime(gainAmt, this.context.currentTime);
  },

  SetParamJ: function (paramJ) {
    paramJ = _ValueLimit(paramJ, 0, 127);
    var value = paramJ / 1.27;
    this.distortion.curve = _DistortionCurve(value);
  },

  MouseWithin: function (mouseWithin) {
    // console.log('Mouse is inside window: ', mouseWithin);
  },

});